using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Finisar.SQLite;
using System.Data;

namespace Herramientas.SQL
{
    public class SQLite : iSQL
    {
        private SQLiteConnection conexion;
        private SQLiteTransaction tran;
        private String cadenaConexion;
        private String BD;
        private Boolean esNuevo;
        String connectionString = "Data Source=@archivoBD;Version=3;New=@esNuevo;Compress=True; DateTimeFormat=Ticks;";

        #region metodos para el generadorDeCodigo
        #region generador de codigo
        public String ObtenerTipoEspecifico(Type tipo)
        {
            String tipoColumna = "";

            if (tipo == typeof(Int32))
                tipoColumna = "integer";
            else if (tipo == typeof(Int64))
                tipoColumna = "integer";
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
                tipoColumna = "boolean";
            else if (tipo == typeof(decimal))
                tipoColumna = "decimal";
            else
                tipoColumna = "blob";

            return tipoColumna;
        }
        public Boolean ExisteColumnaDeTabla(String tabla, String columna)
        {
            //String consulta = "SELECT SO.NAME as tabla, SC.NAME as columna FROM sys.objects SO INNER JOIN sys.columns SC ON SO.OBJECT_ID = SC.OBJECT_ID WHERE SO.TYPE = 'U' and SO.NAME = @tabla and SC.NAME = @columna ORDER BY SO.NAME, SC.NAME";

            String consulta = "PRAGMA table_info('" + tabla + "')";
            DataTable resultado = this.EjecutarConsulta(consulta);

            for (int i = 0; i < resultado.Rows.Count; i++)
            {
                if (resultado.Rows[i]["name"].Equals(columna))
                {
                    return true;
                }
            }
            return false;
        }
        public Boolean ExisteTabla(String tabla)
        {
            //String consulta = "SELECT SO.NAME as tabla, SC.NAME as columna FROM sys.objects SO INNER JOIN sys.columns SC ON SO.OBJECT_ID = SC.OBJECT_ID WHERE SO.TYPE = 'U' and SO.NAME = @tabla ORDER BY SO.NAME, SC.NAME";
            String consulta = "SELECT name FROM sqlite_master WHERE name =  '" + tabla + "'";
            DataTable resultado = this.EjecutarConsulta(consulta);

            if (resultado.Rows.Count > 0)
                return true;
            else
                return false;
        }
        public DataTable ObtenerListadoTablas()
        {
            String consultaTablas = "SELECT tbl_name FROM sqlite_master";

            DataTable tablas = this.EjecutarConsulta(consultaTablas, null);
            return tablas;
        }
        public DataTable ObtenerListadoColumnasDeTabla(String tabla)
        {
            String consulta = "PRAGMA table_info('" + tabla + "')";
            DataTable resultado = this.EjecutarConsulta(consulta);

            DataTable columnas = new DataTable();
            columnas.Columns.Add(new DataColumn() { ColumnName = "Nombre" });
            columnas.Columns.Add(new DataColumn() { ColumnName = "Tipo" });

            for (int i = 0; i < resultado.Rows.Count; i++)
            {
                columnas.Rows.Add(resultado.Rows[i]["name"].ToString(), resultado.Rows[i]["type"].ToString());
            }

            return columnas;
        }
        public String ObtenerCodigoCrearBD(String nombreBD)
        {
            this.ConfigurarConexion(BD, true);
            return "";
        }
        public String ObtenerPalabraClaveParaIdentity()
        {
            return "primary key asc autoincrement";
        }
        public String ObtenerPalabraClaveParaCamposNull()
        {
            return "";
        }
        public String ObtenerExpresionParaAgregarIndiceClusteredAPK(String tabla)
        {
            return "";
        }
        public String ObtenerPalabraClaveParaGO()
        {
            return ";\n\n";
        }
        public String ObtenerExpresionParaAgregarColumnaDeObjetoRelacionado(String columna, Type tipoColumna, String tablaAAgregar, String nombreTablaReferencia, String nombreCampoReferencia)
        {
            return "alter table " + tablaAAgregar + " add column " + columna + " " + ObtenerTipoEspecifico(tipoColumna) + " references " + nombreTablaReferencia + "(" + nombreCampoReferencia + ");\n";
        }
        public String ObtenerExpresionParaAgregarLlaveForanea(String nombreLlaveForanea, String columna, String tablaAAgregar, String nombreTablaReferencia, String nombreCampoReferencia)
        {
            return "";
        }
        public String ObtenerExpresionParaAgregarIndiceNonClustered(String nombreIndice, String Tabla, String campo)
        {
            return "create index " + nombreIndice + " on " + Tabla + " ('" + campo + "' asc); ";
        }
        public String ObtenerExpresionParaAgregarIndiceClustered(String nombreIndice, String Tabla, String campo)
        {
            return "create index " + nombreIndice + " on " + Tabla + " (" + campo + "); ";
        }
        public Boolean ImplementaLlaveForaneaConstraint()
        {
            return false;
        }
        #endregion
        #region framework
        public DateTime QueryParaObtenerLaHoraDelServer()
        {
            //return "SELECT datetime('now') as fechaHoraServidor";
            return DateTime.Now;
        }
        public String QueryParaObtenerElUltimoIDInsertado(String tabla)
        {
            return "select seq from sqlite_sequence where name='" + tabla + "';";
        }
        #endregion
        #endregion

        public SQLite()
        {
        }
        public SQLite(String cadenaConexion)
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
            tran = null;
        }
        public void DeshacerTransaccion()
        {
            try
            {
                if (tran != null)
                    tran.Rollback();
                tran = null;
            }
            catch { }
        }
        public Boolean Reconectar()
        {
            for (int i = 0; i < 3; i++)
            {
                try
                {
                    if (conexion.State != ConnectionState.Connecting || conexion.State != ConnectionState.Executing)
                        conexion.Close();
                    //conexion.Close();
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

        }
        public void ConfigurarConexion(String archivoDB, Boolean EsNuevo)
        {
            this.BD = archivoDB;
            this.esNuevo = EsNuevo;
            String esNew = "";
            if (EsNuevo) esNew = "True";
            else esNew = "False";

            this.cadenaConexion = connectionString.Replace("@archivoBD", archivoDB).Replace("@esNuevo", esNew);

            ConfigurarConexion(this.cadenaConexion);
        }

        public void ConfigurarConexion(string cadenaConexion)
        {
            try
            {
                this.cadenaConexion = cadenaConexion;
                conexion = new SQLiteConnection();
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
            throw new NotImplementedException();
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

                String limitNumber = "";
                if (consulta.Contains("select top "))
                {
                    String queryTemp = consulta.Replace("select top ", "");
                    limitNumber = queryTemp.Split(' ')[0];

                    consulta = consulta.Replace(" top " + limitNumber, "");
                    consulta = consulta + " limit " + limitNumber;
                }


                SQLiteCommand comando = conexion.CreateCommand();
                comando.CommandText = consulta;
                comando.Transaction = tran;
                comando.CommandTimeout = 300000;

                for (int i = 0; i < parProcesados.ParametrosIdentificadores.Count; i++)
                {

                    if (parProcesados.ValoresProcesados[i].GetType() != typeof(byte[]))
                    {



                        //if (valores[i].GetType() == typeof(String))
                        //{
                        //    comando.CommandText = comando.CommandText.Replace(parProcesados.ParametrosIdentificadores[i], "'" + parProcesados.ValoresProcesados[i] + "'");
                        //}
                        //else
                        //{
                        SQLiteParameter sqliteParam = new SQLiteParameter();
                        sqliteParam.ParameterName = parProcesados.ParametrosIdentificadores[i];
                        sqliteParam.Value = parProcesados.ValoresProcesados[i];

                        if (parProcesados.ValoresProcesados[i].GetType() == typeof(DateTime))
                            sqliteParam.DbType = DbType.DateTime;
                        //}

                        //comando.Parameters.Add(parProcesados.ParametrosIdentificadores[i], DbType.AnsiString).Value = parProcesados.ValoresProcesados[i];
                        //sqliteParam.DbType = DbType.String;
                        //else
                        //    comando.Parameters.Add(parProcesados.ParametrosIdentificadores[i], parProcesados.ValoresProcesados[i]);

                        //if (consulta.Trim().StartsWith("select"))
                        //{
                        //    sqliteParam.Direction = ParameterDirection.Output;
                        //}



                        comando.Parameters.Add(sqliteParam);
                    }
                    else
                        comando.Parameters.Add(parProcesados.ParametrosIdentificadores[i], DbType.Binary, ((byte[])parProcesados.ValoresProcesados[i]).Length).Value = parProcesados.ValoresProcesados[i];
                }

                //Log.EscribirLog(consulta);
                DataTable dt = new DataTable();
                DataSet ds = new DataSet();
                ds.Tables.Add(dt);
                ds.EnforceConstraints = false;
                SQLiteDataReader dr = null;

                try
                {
                    dr = comando.ExecuteReader(CommandBehavior.Default);

                    ds.Load(dr, LoadOption.OverwriteChanges, dt);
                    
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

                if (tran == null)
                    CerrarConexion();

                return dt;
            }
            catch (Exception ex)
            {
                DeshacerTransaccion();
                throw new Exception(ex.Message + " E=" + conexion.State.ToString());
            }
        }



        public string ObtenerCadenaConexion()
        {
            return cadenaConexion;
        }


        public iSQL ObtenerNuevaInstancia(string cadenaConexion)
        {
            return new SQLite(cadenaConexion);
        }


        public string ObtenerBD()
        {
            return conexion.Database;
        }

        public void AsignarBD(string bd)
        {
            ConfigurarConexion(bd, esNuevo);
        }
    }
}
