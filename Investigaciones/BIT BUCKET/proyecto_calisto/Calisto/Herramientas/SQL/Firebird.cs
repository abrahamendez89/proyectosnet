using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FirebirdSql.Data.FirebirdClient;
using System.Data;
using Herramientas.Forms.ExcelElements;
using Herramientas.Conversiones;

namespace Herramientas.SQL
{
    public class Firebird : iSQL
    {
        private FbConnection conexion;
        private FbTransaction tran;
        private String cadenaConexion;
        private String BD;
        string servidor;
        string usuario;
        string contrasena;
        //string connectionString =
        //    "User=@USER;" +
        //    "Password=@PASSWORD;" +
        //    "Database=@DATABASE;" +
        //    "DataSource=@DATASOURCE;" +
        //    "Port=3050;" +
        //    "Dialect=3;" +
        //    "Charset=NONE;" +
        //    "Role=;" +
        //    "Connection lifetime=15;" +
        //    "Pooling=true;" +
        //    "MinPoolSize=0;" +
        //    "MaxPoolSize=50;" +
        //    "Packet Size=8192;" +
        //    "ServerType=0";

        string connectionString = "Database=@DATABASE;User=user;Password=@PASSWORD;Dialect=3;Server=@DATASOURCE";


        #region metodos para el generadorDeCodigo
        #region framework
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
                tipoColumna = "varchar(max)";
            else if (tipo == typeof(float))
                tipoColumna = "real";
            else if (tipo == typeof(Double))
                tipoColumna = "float";
            else if (tipo == typeof(DateTime))
                tipoColumna = "datetime";
            else if (tipo == typeof(Boolean))
                tipoColumna = "bit";
            else if (tipo == typeof(decimal))
                tipoColumna = "decimal";
            else
                tipoColumna = "varbinary(max)";

            return tipoColumna;
        }
        public Boolean ExisteColumnaDeTabla(String tabla, String columna)
        {
            String consulta = "SELECT SO.NAME as tabla, SC.NAME as columna FROM sys.objects SO INNER JOIN sys.columns SC ON SO.OBJECT_ID = SC.OBJECT_ID WHERE SO.TYPE = 'U' and SO.NAME = @tabla and SC.NAME = @columna ORDER BY SO.NAME, SC.NAME";
            DataTable resultado = this.EjecutarConsulta(consulta, new List<object>() { tabla, columna });

            if (resultado.Rows.Count > 0)
                return true;
            else
                return false;
        }
        public Boolean ExisteTabla(String tabla)
        {
            String consulta = "SELECT SO.NAME as tabla, SC.NAME as columna FROM sys.objects SO INNER JOIN sys.columns SC ON SO.OBJECT_ID = SC.OBJECT_ID WHERE SO.TYPE = 'U' and SO.NAME = @tabla ORDER BY SO.NAME, SC.NAME";
            DataTable resultado = this.EjecutarConsulta(consulta, new List<object>() { tabla });

            if (resultado.Rows.Count > 0)
                return true;
            else
                return false;
        }
        public DataTable ObtenerListadoTablas()
        {
            String consultaTablas = "SELECT tbl_name FROM sqlite_master WHERE type = @tabla";

            DataTable tablas = this.EjecutarConsulta(consultaTablas, null);
            return tablas;
        }
        public DataTable ObtenerListadoColumnasDeTabla(String tabla)
        {
            DataTable columnas = this.EjecutarConsulta("SELECT COLUMN_NAME, DATA_TYPE FROM INFORMATION_SCHEMA.COLUMNS where TABLE_NAME = '" + tabla + "' order by TABLE_NAME desc", null);

            return columnas;
        }
        public String ObtenerCodigoCrearBD(String nombreBD)
        {
            String codigo = "use master\n" +
                            "go\n" +
                            "create database " + nombreBD + "\n" +
                            "go\n" +
                            "use " + nombreBD + "\n" +
                            "go\n\n";
            return codigo;
        }
        public String ObtenerPalabraClaveParaIdentity()
        {
            return "identity(1,1)";
        }
        public String ObtenerPalabraClaveParaCamposNull()
        {
            return "null";
        }
        public String ObtenerExpresionParaAgregarIndiceClusteredAPK(String tabla)
        {
            return "\tconstraint pk_" + tabla + "_id primary key clustered(id asc)";
        }
        public String ObtenerPalabraClaveParaGO()
        {
            return "\ngo;\n\n";
        }
        public String ObtenerExpresionParaAgregarColumnaDeObjetoRelacionado(String columna, Type tipoColumna, String tablaAAgregar, String nombreTablaReferencia, String nombreCampoReferencia)
        {
            return "alter table " + tablaAAgregar + " add " + columna + " " + ObtenerTipoEspecifico(tipoColumna) + " " + ObtenerPalabraClaveParaCamposNull() + ";\n";
        }
        public String ObtenerExpresionParaAgregarLlaveForanea(String nombreLlaveForanea, String columna, String tablaAAgregar, String nombreTablaReferencia, String nombreCampoReferencia)
        {
            return "alter table " + tablaAAgregar + " add constraint " + nombreLlaveForanea + " foreign key (" + columna + ") references " + nombreTablaReferencia + "(" + nombreCampoReferencia + ");";
        }
        public String ObtenerExpresionParaAgregarIndiceNonClustered(String nombreIndice, String Tabla, String campo)
        {
            return "create nonclustered index " + nombreIndice + " on " + Tabla + " (" + campo + "); ";
        }
        public String ObtenerExpresionParaAgregarIndiceClustered(String nombreIndice, String Tabla, String campo)
        {
            return "create clustered index " + nombreIndice + " on " + Tabla + " (" + campo + "); ";
        }
        public Boolean ImplementaLlaveForaneaConstraint()
        {
            return true;
        }
        #endregion
        #region framework
        public DateTime QueryParaObtenerLaHoraDelServer()
        {
            DataTable dt = EjecutarConsulta("select getdate() as fechaHoraServidor");
            return (DateTime)Converter.ParseType(dt.Rows[0]["fechaHoraServidor"], typeof(DateTime));
        }
        public String QueryParaObtenerElUltimoIDInsertado(String tabla)
        {
            return "select getdate() as fechaHoraServidor";
        }
        #endregion
        #endregion

        public Firebird()
        {
        }
        public Firebird(String cadenaConexion)
        {
            ConfigurarConexion(cadenaConexion);
        }
        public void AbrirConexion()
        {
            try
            {
                if (conexion.State != System.Data.ConnectionState.Open)
                    conexion.Open();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        public void CerrarConexion()
        {
            try
            {
                if (conexion.State != System.Data.ConnectionState.Closed)
                    conexion.Close();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        public void IniciarTransaccion()
        {
            if (conexion.State != System.Data.ConnectionState.Open)
                conexion.Open();
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
        public void ConfigurarConexion(string cadenaConexion)
        {
            try
            {
                this.cadenaConexion = cadenaConexion;
                conexion = new FbConnection();

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

        public void ConfigurarConexion(string servidor, string baseDatos, string usuario, string contrasena)
        {
            this.servidor = servidor;
            this.BD = baseDatos;
            this.usuario = usuario;
            this.contrasena = contrasena;

            this.cadenaConexion = connectionString.Replace("@DATABASE", baseDatos).Replace("@DATASOURCE", servidor).Replace("@USER", usuario).Replace("@PASSWORD", contrasena);

            ConfigurarConexion(this.cadenaConexion);
        }

        public void CrearEInsertarArchivoDataExcel(ExcelArchivo dataExcel)
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
                catch
                {
                    DeshacerTransaccion();
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
                    catch
                    {
                        DeshacerTransaccion();
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

                ParametrosProcesados parProcesados = Parametros.AgregarParametros(consulta, valores, false);
                consulta = parProcesados.Consulta;



                FbCommand comando = conexion.CreateCommand();
                comando.CommandText = consulta;
                comando.Transaction = tran;
                comando.CommandTimeout = 300000000;

                for (int i = 0; i < parProcesados.ParametrosIdentificadores.Count; i++)
                {
                    comando.Parameters.AddWithValue(parProcesados.ParametrosIdentificadores[i], parProcesados.ValoresProcesados[i]);
                }


                //Log.EscribirLog(consulta);
                comando.CommandText = consulta;
                DataTable dt = new DataTable();

                FbDataReader dr = null;

                try
                {
                    //comando.ExecuteScalar();

                    dt.Load(comando.ExecuteReader());
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
            return new Firebird(cadenaConexion);
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
