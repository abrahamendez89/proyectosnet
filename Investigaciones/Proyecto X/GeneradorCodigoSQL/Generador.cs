using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Collections;
using Herramientas.Archivos;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Herramientas.Conversiones;
using Herramientas.SQL;
//using AccesoDatos.Mapeo;

namespace GeneradorCodigoSQL
{
    public partial class Generador : Form
    {
        Assembly assem;// = Assembly.LoadFrom("Dominio.dll");
        Variable variables = new Variable("cache.txt");
        iSQL sql;
        //Mapeo mapeo;
        public Generador()
        {
            InitializeComponent();
            CargarCache();
            //CargarDll();
            temp.BackColor = Color.Red;
        }
        private void CargarCache()
        {
            txt_servidor.Text = variables.ObtenerValorVariable<String>("SERVIDOR_INSTANCIA");
            //txt_instancia.Text = variables.ObtenerValorVariable<String>("INSTANCIA");
            txt_bd.Text = variables.ObtenerValorVariable<String>("BD");
            txt_usuario.Text = variables.ObtenerValorVariable<String>("USUARIO");
            txt_contrase.Text = variables.ObtenerValorVariable<String>("CONTRASEÑA");
            txt_rutaArchivoBDSQlite.Text = variables.ObtenerValorVariable<String>("ARCHIVO_SQLITE");
            txt_rutaDLL.Text = variables.ObtenerValorVariable<String>("ARCHIVO_DLL");

            if (!txt_rutaDLL.Text.Trim().Equals(""))
                CargarDll();
        }
        private Boolean CargarDll()
        {
            if (txt_rutaDLL.Text.Trim().Equals(""))
            {
                Herramientas.Forms.Mensajes.Informacion("Debe cargar el archivo dll primero.");
                return false;
            }

            assem = Assembly.LoadFrom(txt_rutaDLL.Text.Trim());

            lb_clasesDominio.Items.Clear();
            Type[] tipos = assem.GetTypes();
            for (int i = 0; i < tipos.Length; i++)
            {
                Type tipo = tipos[i];
                if ((!tipo.Name.StartsWith("_")))
                    continue;
                lb_clasesDominio.Items.Add(tipo.FullName.Replace("Dominio.", ""));

            }
            return true;
        }
        private void ObtenerTablasDeBD()
        {
            lb_tablasBD.Items.Clear();
            //String consultaTablas = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES order by TABLE_NAME asc";

            DataTable tablas = sql.ObtenerListadoTablas(); //.EjecutarConsulta(consultaTablas, null);

            foreach (DataRow dr in tablas.Rows)
            {
                lb_tablasBD.Items.Add(dr[0].ToString());
            }
        }
        String baseDat = "";
        private void btn_conectar_Click(object sender, EventArgs e)
        {
            baseDat = txt_bd.Text.Trim();
            if (esNueva)
                baseDat = "master";

            String cadena = "data source = @servidorInstancia; initial catalog = @bd; user id = @usuario; password = @contraseña";
            cadena = cadena.Replace("@servidorInstancia", txt_servidor.Text.Trim()).Replace("@bd", baseDat).Replace("@usuario", txt_usuario.Text.Trim()).Replace("@contraseña", txt_contrase.Text.Trim());
            try
            {
                sql = new SQLServer(cadena);
            }
            catch (Exception ex)
            {
                txt_estatus.BackColor = Color.Red;
                txt_estatus.Text = "Error";
                MessageBox.Show("Ocurrio un error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                grb_consultasRapidas.Enabled = false;
                if (MessageBox.Show("Si la causa del error se debe a que la base de datos '" + txt_bd.Text.Trim() + "' es nueva, puede crearla de forma completa. ¿Desea realizar el proceso de creación?", "Checar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    esNueva = true;
                    txt_bd.Enabled = false;
                    NombreBD = txt_bd.Text.Trim();

                    chb_completo.Checked = true;
                    chb_soloCambios.Checked = false;
                    chb_completo.Enabled = false;
                    chb_soloCambios.Enabled = false;

                    btn_conectar_Click(null, null);

                }
            }
            txt_estatus.BackColor = Color.Green;
            txt_estatus.Text = "Conectado";
            temp = txt_estatus;

            CargarDatosBD();

            variables.GuardarValorVariable("SERVIDOR_INSTANCIA", txt_servidor.Text);
            //variables.GuardarValorVariable("INSTANCIA", txt_instancia.Text);
            variables.GuardarValorVariable("BD", txt_bd.Text);
            variables.GuardarValorVariable("USUARIO", txt_usuario.Text);
            variables.GuardarValorVariable("CONTRASEÑA", txt_contrase.Text);
            variables.ActualizarArchivo();

        }

        private void CargarDatosBD()
        {
            try
            {
                ObtenerTablasDeBD();
                tabControl1.SelectedIndex = 1;
                MessageBox.Show("Se conectó correctamente al servidor con la base de datos '" + baseDat + "'.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                grb_consultasRapidas.Enabled = true;
                if (!esNueva)
                {
                    chb_completo.Checked = false;
                    chb_soloCambios.Checked = true;
                    chb_completo.Enabled = true;
                    chb_soloCambios.Enabled = true;
                }
            }
            catch(Exception ex)
            {
                Herramientas.Forms.Mensajes.Error(ex.Message);
            }
        }

        private Boolean esNueva = false;
        private void lb_clasesDominio_Click(object sender, EventArgs e)
        {
            //lb_atributos.Items.Clear();
            //if (lb_clasesDominio.SelectedItem == null) return;
            //Type tipo = assem.GetType("Dominio." + lb_clasesDominio.SelectedItem.ToString());

            //FieldInfo[] atributos = tipo.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

            //for (int j = 0; j < atributos.Length; j++)
            //{
            //    FieldInfo atributo = atributos[j];
            //    if (!atributo.Name.StartsWith("_"))
            //        continue;
            //    lb_atributos.Items.Add(atributo.Name);
            //}

        }
        private String codigo;
        private List<String> nombreTablasRelacion = new List<string>();
        private List<Tabla> tablasFiltradas = new List<Tabla>();
        private List<String> llavesFk = new List<string>();
        private List<String> camposNuevos = new List<string>();
        private String NombreBD = "";

        private List<String> indicesNonClustered = new List<string>();
        private List<String> indicesClustered = new List<string>();

        private void Limpiar()
        {
            nombreTablasRelacion.Clear();
            tablasFiltradas.Clear();
            llavesFk.Clear();
            camposNuevos.Clear();
            indicesClustered.Clear();
            indicesNonClustered.Clear();
            codigo = "";
        }
        TextBox temp = new TextBox();
        private void btn_generarCodigoCompleto_Click(object sender, EventArgs e)
        {
            if (!CargarDll())
                return;

            if (temp.BackColor == Color.Red)
            {
                if (MessageBox.Show("Actualmente no se encuentra conectado a la bd, si desea conectarse antes de generar el código y solo generar los CAMBIOS seleccione la opción 'Cancelar', de lo contrario para continuar seleccione la opción 'Aceptar'. En caso de continuar se generará el código SQL COMPLETO sin verificar cambios.", "Atención", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.Cancel)
                {
                    return;
                }
            }

            Type[] tipos = assem.GetTypes();
            Limpiar();
            ObtenerTablasYCamposNuevos(tipos);
            if (esNueva)
            {
                codigo += sql.ObtenerCodigoCrearBD(NombreBD);
            }
            ObtenerTablasNuevas();
            ObtenerTablasDeRelacion();
            ObtenerCamposNuevos();
            ObtenerLLavesForaneas();
            ObtenerIndicesNonClustered();
            ObtenerIndicesClustered();
            if (codigo.Trim().Equals(""))
            {
                MessageBox.Show("La base de datos está actualizada.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            new CodigoGenerado(sql, codigo).ShowDialog();
            esNueva = false;
            if (!NombreBD.Equals(""))
                txt_bd.Text = NombreBD;
            chb_completo.Checked = false;
            chb_soloCambios.Checked = true;
            txt_bd.Enabled = true;
            //btn_conectar_Click(null, null);
        }

        private Boolean ExisteTabla(String tabla)
        {
            if (chb_completo.Checked)
                return false;

            //String consulta = "SELECT SO.NAME as tabla, SC.NAME as columna FROM sys.objects SO INNER JOIN sys.columns SC ON SO.OBJECT_ID = SC.OBJECT_ID WHERE SO.TYPE = 'U' and SO.NAME = @tabla ORDER BY SO.NAME, SC.NAME";
            return sql.ExisteTabla(tabla);//.EjecutarConsulta(consulta, new List<object>() { tabla });



            //if (resultado.Rows.Count > 0)
            //    return true;
            //else
            //    return false;
        }
        private Boolean ExisteColumnaDeTabla(String tabla, String columna)
        {
            //String consulta = "SELECT SO.NAME as tabla, SC.NAME as columna FROM sys.objects SO INNER JOIN sys.columns SC ON SO.OBJECT_ID = SC.OBJECT_ID WHERE SO.TYPE = 'U' and SO.NAME = @tabla and SC.NAME = @columna ORDER BY SO.NAME, SC.NAME";
            return sql.ExisteColumnaDeTabla(tabla, columna); //.EjecutarConsulta(consulta, new List<object>() { tabla, columna });

            //if (resultado.Rows.Count > 0)
            //    return true;
            //else
            //    return false;
        }
        private String ObtenerNombreTablaDeTipo(Type tipo)
        {
            return tipo.Name;
            //return tipo.FullName.Replace("Dominio.", "");
        }
        private void ObtenerTablasYCamposNuevos(Type[] tipos)
        {
            for (int i = 0; i < tipos.Length; i++)
            {
                Type tipo = tipos[i];
                if ((!tipo.Name.StartsWith("_")))
                    continue;
                FieldInfo[] atributos = tipo.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                Type objetoBase = tipo.BaseType;
                if (!objetoBase.Name.Equals("ObjetoBase"))
                {
                    MessageBox.Show("La clase " + tipo.Name + " no hereda de ObjetoBase, favor de verificar.", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    continue;
                }
                if (!ExisteTabla(ObtenerNombreTablaDeTipo(tipo)))
                {
                    #region cuando no existe la tabla
                    Tabla tabla = new Tabla();

                    tabla.codigo += "create table " + ObtenerNombreTablaDeTipo(tipo) + "\n(\n";
                    tabla.codigo += "\tid " + sql.ObtenerTipoEspecifico(typeof(Int64)) + " " + sql.ObtenerPalabraClaveParaIdentity() + ",\n";
                    tabla.codigo += "\tdtFechaCreacion " + sql.ObtenerTipoEspecifico(typeof(DateTime)) + " " + sql.ObtenerPalabraClaveParaCamposNull() + ",\n";
                    tabla.codigo += "\tdtFechaModificacion " + sql.ObtenerTipoEspecifico(typeof(DateTime)) + " " + sql.ObtenerPalabraClaveParaCamposNull() + ",\n";
                    tabla.codigo += "\tsUsuarioCreacion " + sql.ObtenerTipoEspecifico(typeof(String)) + " " + sql.ObtenerPalabraClaveParaCamposNull() + ",\n";
                    tabla.codigo += "\tsUsuarioModificacion " + sql.ObtenerTipoEspecifico(typeof(String)) + " " + sql.ObtenerPalabraClaveParaCamposNull() + ",\n";
                    tabla.codigo += "\testaDeshabilitado " + sql.ObtenerTipoEspecifico(typeof(Boolean)) + " " + sql.ObtenerPalabraClaveParaCamposNull() + " default 0,\n";

                    for (int j = 0; j < atributos.Length; j++)
                    {
                        FieldInfo atributo = atributos[j];
                        if (!atributo.Name.StartsWith("_"))
                            //&& !atributo.Name.Equals("dtFechaCreacion") && !atributo.Name.Equals("dtFechaModificacion") && !atributo.Name.Equals("sUsuarioCreacion") && !atributo.Name.Equals("sUsuarioModificacion") && !atributo.Name.Equals("estaDeshabilitado"))
                            continue;
                        if (atributo.FieldType.Name.Contains("List"))
                        {
                            String nombreTabla = tipo.Name + "_X_" + atributo.FieldType.GetGenericArguments()[0].Name + "_" + atributo.Name;

                            if (ExisteTabla(nombreTabla))
                                continue;

                            nombreTablasRelacion.Add(nombreTabla);

                            String indice = sql.ObtenerExpresionParaAgregarLlaveForanea("fk_"+nombreTabla + "_contenido", "_contenido", nombreTabla, ObtenerNombreTablaDeTipo(atributo.FieldType.GetGenericArguments()[0]), "id"); //"alter table " + nombreTabla + " add constraint " + nombreTabla + "_contenido foreign key (_contenido) references " + ObtenerNombreTablaDeTipo(atributo.FieldType.GetGenericArguments()[0]) + "(id);";
                            llavesFk.Add(indice);
                            String indice2 = sql.ObtenerExpresionParaAgregarLlaveForanea("fk_" + nombreTabla + "_contenedor", "_contenedor", nombreTabla, ObtenerNombreTablaDeTipo(tipo), "id"); // "alter table " + nombreTabla + " add constraint " + nombreTabla + "_contenedor foreign key (_contenedor) references " + ObtenerNombreTablaDeTipo(tipo) + "(id);";
                            llavesFk.Add(indice2);

                            String indiceClust = sql.ObtenerExpresionParaAgregarIndiceClustered("ci_" + nombreTabla + "_contenedor_fecha", nombreTabla, "_contenedor, _fecha"); //"create clustered index ci_" + nombreTabla + "_contenedor_fecha on " + nombreTabla + " (_contenedor asc,_fecha asc); ";
                            indicesClustered.Add(indiceClust);

                        }
                        else if (atributo.FieldType.Name.StartsWith("_"))
                        {
                            if (sql.ImplementaLlaveForaneaConstraint())
                                tabla.codigo += "\t" + atributo.Name + " " + sql.ObtenerTipoEspecifico(typeof(Int64)) + " " + sql.ObtenerPalabraClaveParaCamposNull() + ",\n";
                            else
                            {
                                String codigoColumna = sql.ObtenerExpresionParaAgregarColumnaDeObjetoRelacionado(atributo.Name, typeof(Int64), ObtenerNombreTablaDeTipo(tipo), ObtenerNombreTablaDeTipo(atributo.FieldType), "id"); //"alter table " + ObtenerNombreTablaDeTipo(tipo) + " add " + atributo.Name + " " + sql.ObtenerTipoEspecifico(typeof(Int64)) + " " + sql.ObtenerPalabraClaveParaCamposNull() + ";\n";
                                camposNuevos.Add(codigoColumna);
                            }

                            String nombreFk = "fk_"+ObtenerNombreTablaDeTipo(tipo) + "_" + ObtenerNombreTablaDeTipo(atributo.FieldType) + "_" + atributo.Name + "_id";
                            String indice = sql.ObtenerExpresionParaAgregarLlaveForanea(nombreFk, atributo.Name, ObtenerNombreTablaDeTipo(tipo), ObtenerNombreTablaDeTipo(atributo.FieldType), "id");//"alter table " + ObtenerNombreTablaDeTipo(tipo) + " add constraint " + nombreFk + " foreign key (" + atributo.Name + ") references " + ObtenerNombreTablaDeTipo(atributo.FieldType) + "(id);";
                            llavesFk.Add(indice);

                            String indiceNonClust = sql.ObtenerExpresionParaAgregarIndiceNonClustered("nci_" + ObtenerNombreTablaDeTipo(tipo) + "_" + atributo.Name, ObtenerNombreTablaDeTipo(tipo), atributo.Name);  //"create nonclustered index nci_" + ObtenerNombreTablaDeTipo(tipo) + "_" + atributo.Name + " on " + ObtenerNombreTablaDeTipo(tipo) + " (" + atributo.Name + "); ";
                            indicesNonClustered.Add(indiceNonClust);

                        }
                        else
                        {
                            String tipoAtributo = ObtenerTipoAtributo(atributo.FieldType);
                            //if (atributo.Name.Equals("id"))
                            //    tabla.codigo += "\t" + atributo.Name + " " + tipoAtributo + " not null identity(1,1) primary key,\n";
                            //else
                            tabla.codigo += "\t" + atributo.Name + " " + tipoAtributo + " " + sql.ObtenerPalabraClaveParaCamposNull() + ",\n";
                        }
                    }
                    tabla.codigo += sql.ObtenerExpresionParaAgregarIndiceClusteredAPK(ObtenerNombreTablaDeTipo(tipo)); // "\tconstraint pk_" + ObtenerNombreTablaDeTipo(tipo) + "_id primary key clustered(id asc)";
                    //tabla.codigo = tabla.codigo.Substring(0, tabla.codigo.Length - 2);
                    tabla.codigo = tabla.codigo.Substring(0, tabla.codigo.Length - 2);
                    tabla.codigo += "\n)" + sql.ObtenerPalabraClaveParaGO();
                    tablasFiltradas.Add(tabla);
                    #endregion
                }
                else
                {
                    #region cuando si existe la tabla solo se agregan columnas
                    for (int j = 0; j < atributos.Length; j++)
                    {
                        String codigoColumna = "";
                        FieldInfo atributo = atributos[j];
                        if (!atributo.Name.StartsWith("_"))
                            //&& !atributo.Name.Equals("dtFechaCreacion") && !atributo.Name.Equals("dtFechaModificacion") && !atributo.Name.Equals("sUsuarioCreacion") && !atributo.Name.Equals("sUsuarioModificacion") && !atributo.Name.Equals("estaDeshabilitado"))
                            continue;
                        if (ExisteColumnaDeTabla(ObtenerNombreTablaDeTipo(tipo), atributo.Name))
                            continue;

                        if (atributo.FieldType.Name.Contains("List"))
                        {
                            String nombreTabla = tipo.Name + "_X_" + atributo.FieldType.GetGenericArguments()[0].Name + "_" + atributo.Name;

                            if (ExisteTabla(nombreTabla))
                                continue;

                            nombreTablasRelacion.Add(nombreTabla);

                            String indice = sql.ObtenerExpresionParaAgregarLlaveForanea("", "_contenido", nombreTabla, ObtenerNombreTablaDeTipo(atributo.FieldType.GetGenericArguments()[0]), "id"); //"alter table " + nombreTabla + " add constraint " + nombreTabla + "_contenido foreign key (_contenido) references " + ObtenerNombreTablaDeTipo(atributo.FieldType.GetGenericArguments()[0]) + "(id);";
                            llavesFk.Add(indice);
                            String indice2 = sql.ObtenerExpresionParaAgregarLlaveForanea("", "_contenedor", nombreTabla, ObtenerNombreTablaDeTipo(tipo), "id"); // "alter table " + nombreTabla + " add constraint " + nombreTabla + "_contenedor foreign key (_contenedor) references " + ObtenerNombreTablaDeTipo(tipo) + "(id);";
                            llavesFk.Add(indice2);

                            String indiceClust = sql.ObtenerExpresionParaAgregarIndiceClustered("ci_" + nombreTabla + "_contenedor_fecha", nombreTabla, "_contenedor, _fecha");  //"create clustered index ci_" + nombreTabla + "_contenedor_fecha on " + nombreTabla + " (_contenedor asc,_fecha asc); ";
                            indicesClustered.Add(indiceClust);
                        }
                        else if (atributo.FieldType.Name.StartsWith("_"))
                        {
                            codigoColumna = sql.ObtenerExpresionParaAgregarColumnaDeObjetoRelacionado(atributo.Name, typeof(Int64), ObtenerNombreTablaDeTipo(tipo), ObtenerNombreTablaDeTipo(atributo.FieldType), "id"); //"alter table " + ObtenerNombreTablaDeTipo(tipo) + " add " + atributo.Name + " " + sql.ObtenerTipoEspecifico(typeof(Int64)) + " " + sql.ObtenerPalabraClaveParaCamposNull() + ";\n";

                            String nombreFk = ObtenerNombreTablaDeTipo(tipo) + "_" + ObtenerNombreTablaDeTipo(atributo.FieldType) + "_" + atributo.Name + "_id";
                            String indice = sql.ObtenerExpresionParaAgregarLlaveForanea(nombreFk, atributo.Name, ObtenerNombreTablaDeTipo(tipo), ObtenerNombreTablaDeTipo(atributo.FieldType), "id");//"alter table " + ObtenerNombreTablaDeTipo(tipo) + " add constraint " + nombreFk + " foreign key (" + atributo.Name + ") references " + ObtenerNombreTablaDeTipo(atributo.FieldType) + "(id);";
                            llavesFk.Add(indice);
                            camposNuevos.Add(codigoColumna);

                            String indiceNonClust = sql.ObtenerExpresionParaAgregarIndiceNonClustered("nci_" + ObtenerNombreTablaDeTipo(tipo) + "_" + atributo.Name, ObtenerNombreTablaDeTipo(tipo), atributo.Name);  //"create nonclustered index nci_" + ObtenerNombreTablaDeTipo(tipo) + "_" + atributo.Name + " on " + ObtenerNombreTablaDeTipo(tipo) + " (" + atributo.Name + "); ";
                            indicesNonClustered.Add(indiceNonClust);

                        }
                        else
                        {
                            String tipoAtributo = ObtenerTipoAtributo(atributo.FieldType);
                            codigoColumna = "alter table " + ObtenerNombreTablaDeTipo(tipo) + " add " + atributo.Name + " " + tipoAtributo + " " + sql.ObtenerPalabraClaveParaCamposNull() + ";\n";
                            camposNuevos.Add(codigoColumna);
                        }
                    }
                    #endregion
                }
            }
        }
        private String ObtenerTipoAtributo(Type tipo)
        {

            return sql.ObtenerTipoEspecifico(tipo);

            //String tipoColumna = "";

            //if (tipo == typeof(Int32))
            //    tipoColumna = "int";
            //else if (tipo == typeof(Int64))
            //    tipoColumna = "bigint";
            //else if (tipo == typeof(short))
            //    tipoColumna = "smallint";
            //else if (tipo == typeof(String))
            //    tipoColumna = "varchar(max)";
            //else if (tipo == typeof(float))
            //    tipoColumna = "real";
            //else if (tipo == typeof(Double))
            //    tipoColumna = "float";
            //else if (tipo == typeof(DateTime))
            //    tipoColumna = "datetime";
            //else if (tipo == typeof(Boolean))
            //    tipoColumna = "bit";
            //else if (tipo == typeof(decimal))
            //    tipoColumna = "decimal";
            //else
            //    tipoColumna = "varbinary(max)";

            //return tipoColumna;
        }
        private void ObtenerTablasDeRelacion()
        {

            foreach (String tabla in nombreTablasRelacion)
            {
                if (sql.ImplementaLlaveForaneaConstraint())
                {
                    codigo += "create table " + tabla + "\n(\n";
                    codigo += "\t_contenedor " + sql.ObtenerTipoEspecifico(typeof(Int64)) + ",\n";
                    codigo += "\t_contenido " + sql.ObtenerTipoEspecifico(typeof(Int64)) + ",\n";
                    codigo += "\t_fecha " + sql.ObtenerTipoEspecifico(typeof(DateTime)) + "";
                    //codigo += "\tconstraint pk_" + tabla + " primary key (_contenedor,_contenido)";
                    codigo += "\n)" + sql.ObtenerPalabraClaveParaGO();
                }
                else
                {
                    codigo += "create table " + tabla + "\n(\n";
                    codigo += "\t_fecha " + sql.ObtenerTipoEspecifico(typeof(DateTime)) + "";
                    //codigo += "\tconstraint pk_" + tabla + " primary key (_contenedor,_contenido)";
                    codigo += "\n)" + sql.ObtenerPalabraClaveParaGO();

                    String tablaContenedora = tabla.Replace("_X_", "|").Split('|')[0];
                    String tablaContenido = tabla.Replace("_X_", "|").Split('|')[1].Replace("__", "|").Split('|')[0];

                    String indice = sql.ObtenerExpresionParaAgregarColumnaDeObjetoRelacionado("_contenido", typeof(Int64), tabla, tablaContenido, "id"); //"alter table " + nombreTabla + " add constraint " + nombreTabla + "_contenido foreign key (_contenido) references " + ObtenerNombreTablaDeTipo(atributo.FieldType.GetGenericArguments()[0]) + "(id);";
                    camposNuevos.Add(indice);
                    String indice2 = sql.ObtenerExpresionParaAgregarColumnaDeObjetoRelacionado("_contenedor", typeof(Int64), tabla, tablaContenedora, "id"); //"alter table " + nombreTabla + " add constraint " + nombreTabla + "_contenido foreign key (_contenido) references " + ObtenerNombreTablaDeTipo(atributo.FieldType.GetGenericArguments()[0]) + "(id);";
                    camposNuevos.Add(indice2);
                }
            }
        }
        private void ObtenerTablasNuevas()
        {
            foreach (Tabla tabla in tablasFiltradas)
            {
                if (!tabla.codigo.Trim().Equals(""))
                    codigo += tabla.codigo + "\n\n";
            }
        }
        private void ObtenerCamposNuevos()
        {
            foreach (String campo in camposNuevos)
            {
                if (!campo.Trim().Equals(""))
                    codigo += campo + "\n\n";
            }
        }
        private void ObtenerLLavesForaneas()
        {
            foreach (String llave in llavesFk)
            {
                if (!llave.Trim().Equals(""))
                    codigo += llave + "\n\n";
            }
            //codigo += "\n";
        }
        private void ObtenerIndicesNonClustered()
        {
            foreach (String indice in indicesNonClustered)
            {
                if (!indice.Trim().Equals(""))
                    codigo += indice + "\n\n";
            }
        }
        private void ObtenerIndicesClustered()
        {
            foreach (String indice in indicesClustered)
            {
                if (!indice.Trim().Equals(""))
                    codigo += indice + "\n\n";
            }
        }
        private void Generador_Load(object sender, EventArgs e)
        {

        }

        private void chb_completo_CheckedChanged(object sender, EventArgs e)
        {
            chb_soloCambios.Checked = !chb_completo.Checked;
        }

        private void chb_soloCambios_CheckedChanged(object sender, EventArgs e)
        {
            chb_completo.Checked = !chb_soloCambios.Checked;
        }
        DataTable resultado;
        DataTable source;
        private void btn_ejecutarConsulta_Click(object sender, EventArgs e)
        {
            source = new DataTable();
            dgb_resultados.DataSource = null;

            String consulta = "";
            try
            {

                //if (txt_consultaRapida.SelectedText.Equals(""))
                //    consulta = txt_consultaRapida.Text;
                //else
                //    consulta = txt_consultaRapida.SelectedText;
                //consulta = consulta.Replace('\r', ' ').Replace('\n', ' ').Replace('\t', ' ');
                //List<String> parametros = sql.ObtenerListaParametros(consulta);
                //if (parametros.Count > 0 && valores == null)
                //{
                //    MessageBox.Show("Se requiere asignar los " + parametros.Count + " parametros encontrados.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
                //}
                //if (parametros.Count > 0 && parametros.Count != valores.Count)
                //{
                //    MessageBox.Show("El numero de parametros encontrados no es igual al numero de parametros asignados. Necesita reasignar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
                //}
                //if (valores != null && valores.Contains(null))
                //{
                //    if (MessageBox.Show("Hay al menos un parametro con valor NULO, ¿Desea continuar?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.No) return;
                //}
                //if (parametros.Count == 0)
                //    valores = null;

                resultado = sql.EjecutarConsulta(consulta, valores);

            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            try
            {
                foreach (DataColumn columna in resultado.Columns)
                {
                    DataColumn nueva = new DataColumn(columna.ColumnName);
                    if (columna.DataType.FullName.Equals("System.Byte[]"))
                        nueva.DataType = typeof(Bitmap);
                    else if (columna.DataType.FullName.Equals("System.Boolean"))
                        nueva.DataType = typeof(String);
                    else if (columna.DataType.FullName.Equals("System.Int64"))
                        nueva.DataType = typeof(String);
                    else
                        nueva.DataType = columna.DataType;
                    nueva.AllowDBNull = true;
                    source.Columns.Add(nueva);
                }
                for (int j = 0; j < resultado.Rows.Count; j++)
                {
                    DataRow dr = source.NewRow();
                    for (int i = 0; i < source.Columns.Count; i++)
                    {
                        if (resultado.Rows[j][i] == DBNull.Value)
                        {
                            if (source.Columns[i].DataType == typeof(String))
                                dr[source.Columns[i].ColumnName] = "NULL";
                            else
                                dr[source.Columns[i].ColumnName] = DBNull.Value;
                        }
                        else if (source.Columns[i].DataType == typeof(Bitmap))
                        {
                            try
                            {

                                Bitmap imagen = (Bitmap)Converter.BitArrayTOBitmap((byte[])resultado.Rows[j][i]);

                                imagen = (Bitmap)((Image)imagen.GetThumbnailImage(40, 40, delegate { return false; }, System.IntPtr.Zero));

                                dr[source.Columns[i].ColumnName] = Convert.ChangeType(imagen, typeof(Bitmap));
                            }
                            catch
                            {
                                //source.Columns[i].DataType = typeof(String);



                                //dr[source.Columns[i].ColumnName] = resultado.Rows[j][i].ToString();
                            }
                        }
                        else
                        {
                            dr[source.Columns[i].ColumnName] = resultado.Rows[j][i];
                        }
                    }
                    source.Rows.Add(dr);
                }

                dgb_resultados.DataSource = source;
                if (consulta.ToLower().StartsWith("select"))
                    MessageBox.Show(resultado.Rows.Count + " filas como resultado.", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Se ejecutó la instrucción correctamente.", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void dgb_resultados_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void lb_clasesDominio_SelectedIndexChanged(object sender, EventArgs e)
        {
            //String item = lb_clasesDominio.SelectedItem.ToString();

            //String[] splt = item.Split('.');

            //txt_seleccionado.Text = splt[splt.Length - 1];

            //txt_consultaRapida.Text = txt_consultaRapida.Text.Insert(txt_consultaRapida.SelectionStart, txt_seleccionado.Text);

        }

        private void lb_tablasBD_SelectedIndexChanged(object sender, EventArgs e)
        {
            String tabla = lb_tablasBD.SelectedItem.ToString();
            DataTable columnas = sql.ObtenerListadoColumnasDeTabla(tabla); //.EjecutarConsulta("SELECT COLUMN_NAME, DATA_TYPE FROM INFORMATION_SCHEMA.COLUMNS where TABLE_NAME = '" + tabla + "' order by TABLE_NAME desc", null);
            lb_columnas.Items.Clear();
            foreach (DataRow dr in columnas.Rows)
            {
                lb_columnas.Items.Add(dr[0].ToString() + " - " + dr[1].ToString());
            }

        }

        private void btn_copiar_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(txt_seleccionado.Text);
        }

        private void btn_convertirArchivoBytes_Click(object sender, EventArgs e)
        {

        }

        public String ConvertirByteArrayAString(byte[] byteArray)
        {
            return "0x" + BitConverter.ToString(byteArray).Replace("-", "");
        }
        public static Bitmap CargarImagenDeArchivos()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Archivos de imagen|*.png;*.jpg;*.jpeg;*.bmp";
            Bitmap imagen = null;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                imagen = new Bitmap(ofd.FileName);
            }
            return imagen;
        }
        List<Object> valores;
        int seleccionStart = 0;
        int longitud = 0;
        private void btn_Parametros_Click(object sender, EventArgs e)
        {
            //if (valores != null) valores.Clear();
            //pnl_Parametros.Visible = true;
            //seleccionStart = txt_consultaRapida.SelectionStart;
            //longitud = txt_consultaRapida.SelectionLength;
            //String consulta = "";
            //if (txt_consultaRapida.SelectedText.Equals(""))
            //    consulta = txt_consultaRapida.Text.Trim();
            //else
            //    consulta = txt_consultaRapida.SelectedText.Trim();
            //List<String> parametros = DBAcceso.ObtenerListaParametros(consulta);
            //valores = new List<object>();
            //cmb_parametros.Items.Clear();
            //foreach (String parametro in parametros)
            //{
            //    cmb_parametros.Items.Add("@" + parametro);
            //    valores.Add(null);
            //}
        }

        private void btn_GuardarParametros_Click(object sender, EventArgs e)
        {
            txt_consultaRapida.Focus();
            txt_consultaRapida.SelectionStart = seleccionStart;
            txt_consultaRapida.SelectionLength = longitud;

            btn_ejecutarConsulta_Click(null, null);
            //valores = null;
        }

        private void cmb_parametros_SelectedIndexChanged(object sender, EventArgs e)
        {
            Object valor = valores[cmb_parametros.SelectedIndex];
            cmb_booleano.Visible = false;
            txt_valor.Visible = false;
            dtp_fecha.Visible = false;
            pb_imagen.Visible = false;
            pb_imagen.Image = null;
            if (valor == null) { cmb_tipos.SelectedIndex = -1; txt_valor.Text = ""; return; }


            if (valor.GetType() == typeof(double))
            {
                cmb_tipos.SelectedItem = "Número con punto decimal";
                txt_valor.Text = valor.ToString();
                txt_valor.Visible = true;
            }
            else if (valor.GetType() == typeof(int))
            {
                cmb_tipos.SelectedItem = "Número Entero";
                txt_valor.Text = valor.ToString();
                txt_valor.Visible = true;
            }
            else if (valor.GetType() == typeof(DateTime))
            {
                cmb_tipos.SelectedItem = "Fecha";
                dtp_fecha.Value = (DateTime)valor;
                dtp_fecha.Visible = true;
            }
            else if (valor.GetType() == typeof(Bitmap))
            {
                cmb_tipos.SelectedItem = "Imagen";
                pb_imagen.Image = (Bitmap)valor;
                pb_imagen.Visible = true;
            }
            else if (valor.GetType() == typeof(String))
            {
                cmb_tipos.SelectedItem = "Cadena";
                txt_valor.Text = valor.ToString();
                txt_valor.Visible = true;
            }
            else if (valor.GetType() == typeof(Boolean))
            {
                if ((Boolean)valor)
                    cmb_booleano.SelectedItem = "True";
                else
                    cmb_booleano.SelectedItem = "False";
                cmb_booleano.Visible = true;
            }
        }
        Object valor = null;
        private void txt_valor_Click(object sender, EventArgs e)
        {

        }

        private void btn_guardarValor_Click(object sender, EventArgs e)
        {
            String tipo = cmb_tipos.SelectedItem.ToString();
            if (tipo == null) { MessageBox.Show("seleccione un tipo"); return; }
            else
            {
                if (tipo.Equals("Fecha"))
                {
                    valores[cmb_parametros.SelectedIndex] = dtp_fecha.Value;
                }
                else if (tipo.Contains("Número"))
                {
                    double vaor = 0;
                    if (!double.TryParse(txt_valor.Text, out vaor))
                    { MessageBox.Show("El valor no puede contener letras o simbolos."); return; }
                    if (tipo.Equals("Número Entero"))
                    {
                        int vaor2 = 0;
                        if (txt_valor.Text.Contains(".") || !int.TryParse(txt_valor.Text, out vaor2))
                        { MessageBox.Show("El valor no puede contener punto decimal."); return; }
                        valores[cmb_parametros.SelectedIndex] = vaor2;
                    }
                    valores[cmb_parametros.SelectedIndex] = vaor;
                }
                else if (tipo.Equals("Imagen"))
                {
                    valores[cmb_parametros.SelectedIndex] = (Bitmap)pb_imagen.Image;
                }
                else if (tipo.Equals("Cadena"))
                {
                    valores[cmb_parametros.SelectedIndex] = txt_valor.Text;
                }
                else if (tipo.Equals("Booleano"))
                {
                    if (cmb_booleano.SelectedItem != null)
                    {
                        Boolean valor = cmb_booleano.SelectedItem.Equals("True");
                        valores[cmb_parametros.SelectedIndex] = valor;
                    }
                }
            }
            borrarYOcultarValores();
        }
        private void borrarYOcultarValores()
        {
            cmb_tipos.SelectedIndex = -1; txt_valor.Text = "";
            cmb_booleano.Visible = false;
            txt_valor.Visible = false;
            dtp_fecha.Visible = false;
            pb_imagen.Visible = false;
            pb_imagen.Image = null;
        }
        private void cmb_tipos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_tipos.SelectedItem == null) return;
            String tipo = cmb_tipos.SelectedItem.ToString();
            txt_valor.Text = "";
            cmb_booleano.Visible = false;
            txt_valor.Visible = false;
            pb_imagen.Visible = false;
            dtp_fecha.Visible = false;
            if (tipo.Equals("Fecha"))
            {
                dtp_fecha.Visible = true;
            }
            else if (tipo.Equals("Imagen"))
            {
                pb_imagen.Visible = true;
            }
            else if (tipo.Equals("Booleano"))
            {
                cmb_booleano.Visible = true;
            }
            else
                txt_valor.Visible = true;
        }

        private void lb_tablasBD_DoubleClick(object sender, EventArgs e)
        {
            txt_seleccionado.Text = lb_tablasBD.SelectedItem.ToString();
            int posicion = txt_consultaRapida.SelectionStart;
            String agregado = txt_seleccionado.Text + " ";
            txt_consultaRapida.Text = txt_consultaRapida.Text.Insert(txt_consultaRapida.SelectionStart, agregado);
            txt_consultaRapida.Focus();
            txt_consultaRapida.SelectionStart = posicion + agregado.Length;
            txt_consultaRapida.SelectionLength = 0;
        }

        private void lb_columnas_DoubleClick(object sender, EventArgs e)
        {
            txt_seleccionado.Text = lb_columnas.SelectedItem.ToString().Split('-')[0].Trim();
            int posicion = txt_consultaRapida.SelectionStart;
            String agregado = txt_seleccionado.Text + " ";
            txt_consultaRapida.Text = txt_consultaRapida.Text.Insert(txt_consultaRapida.SelectionStart, agregado);
            txt_consultaRapida.Focus();
            txt_consultaRapida.SelectionStart = posicion + agregado.Length;
            txt_consultaRapida.SelectionLength = 0;
        }

        private void accesoRapido1(object sender, EventArgs e)
        {
            Button boton = (Button)sender;
            int posicion = txt_consultaRapida.SelectionStart;
            String agregado = boton.Text + " ";
            txt_consultaRapida.Text = txt_consultaRapida.Text.Insert(posicion, agregado);

            txt_consultaRapida.Focus();
            txt_consultaRapida.SelectionStart = posicion + agregado.Length;
            txt_consultaRapida.SelectionLength = 0;
        }

        private void accesoRapido2(object sender, EventArgs e)
        {
            Button boton = (Button)sender;
            int posicion = txt_consultaRapida.SelectionStart;
            String agregado = boton.Text + " ";
            txt_consultaRapida.Text = txt_consultaRapida.Text.Insert(posicion, agregado);

            txt_consultaRapida.Focus();
            txt_consultaRapida.SelectionStart = posicion + agregado.Length - 2;
            txt_consultaRapida.SelectionLength = 0;
        }

        private void accesosRapidos3(object sender, EventArgs e)
        {
            Button boton = (Button)sender;
            int posicion = txt_consultaRapida.SelectionStart;

            String agregado = boton.Text;
            txt_consultaRapida.Text = txt_consultaRapida.Text.Insert(posicion, agregado);

            txt_consultaRapida.Focus();
            txt_consultaRapida.SelectionStart = posicion + agregado.Length;
            txt_consultaRapida.SelectionLength = 0;
        }

        private void pb_imagen_Click(object sender, EventArgs e)
        {
            if (cmb_tipos.SelectedItem == null) return;
            String tipo = cmb_tipos.SelectedItem.ToString();
            if (tipo.Equals("Imagen"))
            {
                pb_imagen.Image = CargarImagenDeArchivos();
            }
        }

        private void btn_salirConsultas_Click(object sender, EventArgs e)
        {
            pnl_Parametros.Visible = false;
            valores = null;
            borrarYOcultarValores();
        }

        private void menu_contextual_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (lb_tablasBD.SelectedItem == null) return;

            String nombreTabla = lb_tablasBD.SelectedItem.ToString();

            String query = "";

            if (e.ClickedItem.Text.Equals("Insert"))
            {
                String consulta = "SELECT SO.NAME as tabla, SC.NAME as columna FROM sys.objects SO INNER JOIN sys.columns SC ON SO.OBJECT_ID = SC.OBJECT_ID WHERE SO.TYPE = 'U' and SO.NAME = @tabla ORDER BY SO.NAME, SC.NAME";
                DataTable resultado = sql.EjecutarConsulta(consulta, new List<object>() { nombreTabla });


                query += "insert " + nombreTabla + " (";
                foreach (DataRow dr in resultado.Rows)
                {
                    if (!dr[1].ToString().Equals("id"))
                        query += dr[1].ToString() + ", ";
                }
                query = query.Substring(0, query.Length - 2);
                query += " ) values (";
                foreach (DataRow dr in resultado.Rows)
                {
                    if (!dr[1].ToString().Equals("id"))
                        query += "@" + dr[1].ToString() + ", ";
                }
                query = query.Substring(0, query.Length - 2);
                query += " )";
            }
            else if (e.ClickedItem.Text.Equals("Select * from"))
            {
                query = "select * from " + nombreTabla;
            }
            else if (e.ClickedItem.Text.Equals("Update"))
            {
                String consulta = "SELECT SO.NAME as tabla, SC.NAME as columna FROM sys.objects SO INNER JOIN sys.columns SC ON SO.OBJECT_ID = SC.OBJECT_ID WHERE SO.TYPE = 'U' and SO.NAME = @tabla ORDER BY SO.NAME, SC.NAME";
                DataTable resultado = sql.EjecutarConsulta(consulta, new List<object>() { nombreTabla });


                query += "update " + nombreTabla + " set ";
                foreach (DataRow dr in resultado.Rows)
                {
                    if (!dr[1].ToString().Equals("id"))
                    {
                        query += dr[1].ToString() + " = @" + dr[1].ToString() + ", ";
                    }
                }
                query = query.Substring(0, query.Length - 2);
                query += " where id = @id";
            }

            int posicion = txt_consultaRapida.SelectionStart;
            String agregado = query;
            txt_consultaRapida.Text = txt_consultaRapida.Text.Insert(posicion, agregado);
            txt_consultaRapida.Focus();
            txt_consultaRapida.SelectionStart = posicion + agregado.Length;
            txt_consultaRapida.SelectionLength = 0;

        }

        private void menu_contextual2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (lb_columnas.SelectedItem == null || lb_tablasBD.SelectedItem == null) return;
            String query = "";
            if (e.ClickedItem.Text.Equals("Update"))
            {
                query += "update " + lb_tablasBD.SelectedItem.ToString() + " set ";
                foreach (String dr in lb_columnas.SelectedItems)
                {
                    String columna = dr.Split('-')[0].Trim();
                    if (!dr[1].ToString().Equals("id"))
                    {
                        query += columna + " = @" + columna + ", ";
                    }
                }
                query = query.Substring(0, query.Length - 2);
                query += " where id = @id";
            }
            int posicion = txt_consultaRapida.SelectionStart;
            String agregado = query;
            txt_consultaRapida.Text = txt_consultaRapida.Text.Insert(posicion, agregado);
            txt_consultaRapida.Focus();
            txt_consultaRapida.SelectionStart = posicion + agregado.Length;
            txt_consultaRapida.SelectionLength = 0;

        }

        private void dgb_resultados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1) return;
            Type tipo = source.Columns[e.ColumnIndex].DataType;
            if (tipo == typeof(Bitmap) && resultado.Rows[e.RowIndex][e.ColumnIndex] != DBNull.Value)
            {
                Bitmap imagen = (Bitmap)Converter.BitArrayTOBitmap((byte[])resultado.Rows[e.RowIndex][e.ColumnIndex]);
                VisorImagenes visor = new VisorImagenes(imagen);
                visor.ShowDialog();
            }
        }

        #region sqlite
        private void btn_BuscarArchivoSQLite_Click(object sender, EventArgs e)
        {
            txt_rutaArchivoBDSQlite.Text = Herramientas.Archivos.Dialogos.BuscarArchivo(new List<string>() { "Archivo de base de datos." }, new List<string>() { "db" });
        }

        private void btn_ConectarSql_Click(object sender, EventArgs e)
        {
            baseDat = txt_bd.Text.Trim();
            if (esNueva)
                baseDat = "master";

            sql = new SQLite();
            sql.ConfigurarConexion(txt_rutaArchivoBDSQlite.Text, false);
            txt_estatusSQLITE.BackColor = Color.Green;
            txt_estatusSQLITE.Text = "Conectado";

            temp = txt_estatusSQLITE;

            CargarDatosBD();

            variables.GuardarValorVariable("ARCHIVO_SQLITE", txt_rutaArchivoBDSQlite.Text);
            variables.ActualizarArchivo();
        }
        #endregion

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            txt_rutaDLL.Text = Herramientas.Archivos.Dialogos.BuscarArchivo(new List<string>() { "Archivo de dll del dominio." }, new List<string>() { "dll" });
            if (!txt_rutaDLL.Text.Trim().Equals(""))
            {
                variables.GuardarValorVariable("ARCHIVO_DLL", txt_rutaDLL.Text.Trim());
                variables.ActualizarArchivo();
                CargarDll();
            }
        }
    }
}
