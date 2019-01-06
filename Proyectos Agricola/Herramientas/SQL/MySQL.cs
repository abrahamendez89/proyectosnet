using Herramientas.Calculos;
using Herramientas.Conversiones;
using Herramientas.Forms.ExcelElements;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Herramientas.SQL
{
    public class MySQL : iSQL
    {
        private MySqlConnection conexion;
        private MySqlTransaction tran;
        private String cadenaConexion;
        private String BD;
        String servidor;
        String usuario;
        String contrasena;
        string connectionString = "SERVER = @SERVIDOR; DATABASE = @BASEDATOS; UID = @USUARIO; PASSWORD = @CONTRASENA";

        #region metodos para el generadorDeCodigo
        #region generador de codigo
        public String ObtenerTipoEspecifico(Type tipo)
        {
            String tipoColumna = "";

            if (tipo == typeof(Int32))
                tipoColumna = "int";
            else if (tipo == typeof(Int64))
                tipoColumna = "bigint";
            else if (tipo == typeof(short))
                tipoColumna = "smallint";
            else if (tipo == typeof(String))
                tipoColumna = "text";
            else if (tipo == typeof(float))
                tipoColumna = "real";
            else if (tipo == typeof(Double))
                tipoColumna = "real";
            else if (tipo == typeof(DateTime))
                tipoColumna = "datetime";
            else if (tipo == typeof(Boolean))
                tipoColumna = "bit";
            else if (tipo == typeof(decimal))
                tipoColumna = "boolean";
            else
                tipoColumna = "blob";

            return tipoColumna;
        }
        public Boolean ExisteColumnaDeTabla(String tabla, String columna)
        {
            String consulta = "SELECT column_name FROM information_schema.COLUMNS WHERE table_name = @tabla AND column_name = @columna";
            DataTable resultado = this.EjecutarConsulta(consulta, new List<object>() { tabla, columna });

            if (resultado.Rows.Count > 0)
                return true;
            else
                return false;
        }
        public Boolean ExisteTabla(String tabla)
        {
            String consulta = "SELECT table_name FROM information_schema.tables WHERE table_name = @tabla";
            DataTable resultado = this.EjecutarConsulta(consulta, new List<object>() { tabla });

            if (resultado.Rows.Count > 0)
                return true;
            else
                return false;
        }
        public DataTable ObtenerListadoTablas()
        {
            String consultaTablas = "SELECT  table_name  FROM information_schema.tables where table_type = 'BASE TABLE' and engine = 'InnoDB'";

            DataTable tablas = this.EjecutarConsulta(consultaTablas, null);
            return tablas;
        }
        public DataTable ObtenerListadoColumnasDeTabla(String tabla)
        {
            DataTable columnas = this.EjecutarConsulta("SELECT column_name FROM information_schema.COLUMNS WHERE table_name = '"+tabla+"' order by table_name asc", null);

            return columnas;
        }
        public String ObtenerCodigoCrearBD(String nombreBD)
        {
            String codigo = "create database " + nombreBD + "\n" +
                            "go\n\n" +
                            "use " + nombreBD + "\n" +
                            "go\n\n";
            return codigo;
        }
        public String ObtenerPalabraClaveParaIdentity()
        {
            return "not null auto_increment";
        }
        public String ObtenerPalabraClaveParaCamposNull()
        {
            return "null";
        }
        public String ObtenerPalabraClaveParaGO()
        {
            return "\ngo\n\n";
        }
        public String ObtenerExpresionParaAgregarIndiceClusteredAPK(String tabla)
        {
            return "\tconstraint pk_" + tabla + "_id primary key (id),\n";
        }
        public String ObtenerExpresionParaAgregarColumnaDeObjetoRelacionado(String columna, Type tipoColumna, String tablaAAgregar, String nombreTablaReferencia, String nombreCampoReferencia)
        {
            return "alter table " + tablaAAgregar + " add " + columna + " " + ObtenerTipoEspecifico(tipoColumna) + " " + ObtenerPalabraClaveParaCamposNull() + ";\n";
        }
        public String ObtenerExpresionParaAgregarLlaveForanea(String nombreLlaveForanea, String columna, String tablaAAgregar, String nombreTablaReferencia, String nombreCampoReferencia)
        {
            String nRan = NumerosAleatorios.ObtenerInt(1, 9999).ToString();
            return "alter table " + tablaAAgregar + " add constraint " + nombreLlaveForanea.Substring(0, 20) + "_" + nombreLlaveForanea.Substring(nombreLlaveForanea.Length - 10, 10) + "_" + nRan + " foreign key (" + columna + ") references " + nombreTablaReferencia + " (" + nombreCampoReferencia + ");";
        }
        public String ObtenerExpresionParaAgregarIndiceNonClustered(String nombreIndice, String Tabla, String campo)
        {
            return "";
        }
        public String ObtenerExpresionParaAgregarIndiceClustered(String nombreIndice, String Tabla, String campo)
        {
            String[] campos = campo.Split(',');
            String camposConAsc = "";
            for (int i = 0; i < campos.Length; i++)
            {
                camposConAsc += campos[i] + ",";
            }
            camposConAsc = camposConAsc.Substring(0, camposConAsc.Length - 1);
            String nRan = NumerosAleatorios.ObtenerInt(1, 9999).ToString();
            return "create index " + nombreIndice.Substring(0, 20) + "_" + nombreIndice.Substring(nombreIndice.Length - 10, 10) + "_" + nRan + " on " + Tabla + " (" + camposConAsc + "); ";
        }
        public Boolean ImplementaLlaveForaneaConstraint()
        {
            return true;
        }
        #endregion
        #region framework
        public DateTime QueryParaObtenerLaHoraDelServer()
        {
            DataTable dt = EjecutarConsulta("select NOW() as fechaHoraServidor");
            return (DateTime)Converter.ParseType(dt.Rows[0]["fechaHoraServidor"], typeof(DateTime));
        }
        public String QueryParaObtenerElUltimoIDInsertado(String tabla)
        {
            return "SELECT LAST_INSERT_ID();";
        }
        #endregion
        #endregion

        public MySQL()
        {
        }
        public MySQL(String cadenaConexion)
        {
            ConfigurarConexion(cadenaConexion);
        }
        public void AbrirConexion()
        {
            try
            {
                if (conexion.State != ConnectionState.Open)
                    conexion.Open();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        public void CerrarConexion()
        {
            try
            {
                if (conexion.State != ConnectionState.Closed)
                    conexion.Close();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        public void IniciarTransaccion()
        {
            if (conexion.State != ConnectionState.Open)
                conexion.Open();
            else
            {
                conexion.Close();
                conexion.Open();
            }
            tran = conexion.BeginTransaction();
        }
        public void TerminarTransaccion()
        {
            if (tran != null)
                tran.Commit();
        }
        public void DeshacerTransaccion()
        {
            try
            {
                if (tran != null)
                    tran.Rollback();
            }
            catch { }
        }
        public Boolean Reconectar()
        {
            for (int i = 0; i < 3; i++)
            {
                try
                {
                    //if (conexion.State != ConnectionState.Connecting)
                    //    conexion.Close();
                    conexion.Close();
                    if (conexion.State != ConnectionState.Open)
                    {
                        conexion.Close();
                        conexion.ConnectionString = cadenaConexion;
                        conexion.Open();
                    }
                    return true;
                }
                catch (Exception ssqlex)
                {
                    return false;
                }
            }
            throw new Exception("Intentos de conexión con el servidor superados, verificar conexión de red.");
        }
        public DataTable EjecutarConsulta(String consulta)
        {
            return EjecutarConsulta(consulta, null);
        }
        public void ConfigurarConexion(String servidor, String baseDatos, String usuario, String contrasena)
        {
            this.servidor = servidor;
            this.BD = baseDatos;
            this.usuario = usuario;
            this.contrasena = contrasena;



            this.cadenaConexion = connectionString.Replace("@SERVIDOR", servidor).Replace("@BASEDATOS", baseDatos).Replace("@USUARIO", usuario).Replace("@CONTRASENA", contrasena);

            ConfigurarConexion(this.cadenaConexion);

        }
        public void ConfigurarConexion(string cadenaConexion)
        {
            try
            {
                this.cadenaConexion = cadenaConexion;
                conexion = new MySqlConnection();
                conexion.ConnectionString = cadenaConexion;

                conexion.Open();
            }
            catch (Exception ex)
            {
                if (ex.Message.ToLower().Contains("error: 26"))
                    throw new Exception("Ocurrió un error al conectar al servidor de base de datos. Verificar conexión de red.");
                throw new Exception(ex.Message);
            }
        }
        public void CrearEInsertarArchivoDataExcel(Forms.ExcelElements.ExcelArchivo dataExcel)
        {
            foreach (ExcelHoja hoja in dataExcel.Hojas)
            {
                String createComando = "create table @tabla(@columnas);";
                createComando = createComando.Replace("@tabla", hoja.NombreHoja);
                String columnas = "";
                foreach (String columna in hoja.NombresColumnas)
                {
                    columnas += "\n\t@nombre varchar(80),";
                    columnas = columnas.Replace("@nombre", columna);
                }
                columnas = columnas.Substring(0, columnas.Length - 1);
                columnas += "\n";
                createComando = createComando.Replace("@columnas", columnas);
                //Console.WriteLine(createComando);
                try
                {
                    IniciarTransaccion();
                    EjecutarConsulta(createComando);
                    TerminarTransaccion();
                }
                catch (Exception ex)
                {
                    DeshacerTransaccion();
                    throw ex;
                }

                foreach (ExcelFila fila in hoja.ExcelFilasDatos)
                {
                    String insertComando = "insert into @tabla values(@valores);";
                    insertComando = insertComando.Replace("@tabla", hoja.NombreHoja);
                    String valores = "";
                    foreach (String dato in fila.Datos)
                    {
                        valores += "'" + dato + "',";
                    }
                    valores = valores.Substring(0, valores.Length - 1);
                    insertComando = insertComando.Replace("@valores", valores);
                    //Console.WriteLine(insertComando);
                    try
                    {
                        IniciarTransaccion();
                        EjecutarConsulta(insertComando);
                        TerminarTransaccion();
                    }
                    catch (Exception ex)
                    {
                        DeshacerTransaccion();
                        throw ex;
                    }
                }
            }
        }


        public DataTable EjecutarConsulta(string consulta, List<object> valores)
        {
            try
            {
                if (conexion.State != ConnectionState.Open)
                {
                    Reconectar();
                }


                ParametrosProcesados parProcesados = Parametros.AgregarParametros(consulta, valores, true);
                consulta = parProcesados.Consulta;


                MySqlCommand comando = conexion.CreateCommand();
                comando.CommandText = consulta;
                comando.Transaction = tran;
                comando.CommandTimeout = 300000;

                for (int i = 0; i < parProcesados.ParametrosIdentificadores.Count; i++)
                {
                    comando.Parameters.AddWithValue(parProcesados.ParametrosIdentificadores[i], parProcesados.ValoresProcesados[i]);
                }

                //Log.EscribirLog(consulta);
                comando.CommandText = consulta;
                DataTable dt = new DataTable();

                MySqlDataReader dr = null;

                try
                {
                    dr = comando.ExecuteReader();
                    dt.Load(dr);
                    dr.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                return dt;
            }
            catch (Exception ex)
            {
                DeshacerTransaccion();
                throw new Exception(ex.Message);
            }
        }


        public void ConfigurarConexion(string archivoDB, bool EsNuevo)
        {

        }


        public string ObtenerCadenaConexion()
        {
            return cadenaConexion;
        }
        public iSQL ObtenerNuevaInstancia(string cadenaConexion)
        {
            return new MySQL(cadenaConexion);
        }


        public string ObtenerBD()
        {
            return conexion.Database;
        }

        public void AsignarBD(string bd)
        {
            ConfigurarConexion(this.servidor, bd, this.usuario, this.contrasena);
        }
    }
}
