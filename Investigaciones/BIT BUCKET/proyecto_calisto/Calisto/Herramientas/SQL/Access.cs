using Herramientas.Conversiones;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;

namespace Herramientas.SQL
{
    public class Access : iSQL
    {
        private String cadenaConexion;
        private OleDbConnection conexion;
        private OleDbTransaction tran;
        private String BD;
        private String provider;
        String connectionString = @"Provider=@provider;Data Source=@archivo;Persist Security Info=False;";

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

        public void ConfigurarConexion(string cadenaConexion)
        {
            this.cadenaConexion = cadenaConexion;
        }

        public void ConfigurarConexion(string servidor, string baseDatos, string usuario, string contrasena)
        {

        }

        public void ConfigurarConexion(string provider, string archivoAccess)
        {
            this.provider = provider;
            BD = archivoAccess;
            String providerDefault = "Microsoft.ACE.OLEDB.12.0";
            if (provider == null || provider.Trim().Equals("")) provider = providerDefault;
            this.cadenaConexion = connectionString.Replace("@provider", provider).Replace("@archivo", archivoAccess);
        }

        public void AbrirConexion()
        {
            conexion = new OleDbConnection(cadenaConexion);
            conexion.Open();
        }

        public void CerrarConexion()
        {
            conexion.Close();
        }

        public DataTable EjecutarConsulta(string consulta)
        {
            return EjecutarConsulta(consulta, null);
        }

        public void IniciarTransaccion()
        {
            if (conexion.State != ConnectionState.Open)
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

        public void CrearEInsertarArchivoDataExcel(Forms.ExcelElements.ExcelArchivo dataExcel)
        {
            throw new NotImplementedException();
        }

        public DataTable EjecutarConsulta(string consulta, List<object> valores)
        {
            try
            {

                ParametrosProcesados parProcesados = Parametros.AgregarParametros(consulta, valores, true);
                consulta = parProcesados.Consulta;

                OleDbCommand comando = conexion.CreateCommand();
                comando.CommandText = consulta;
                comando.Transaction = tran;
                comando.CommandTimeout = 300000000;

                for (int i = 0; i < parProcesados.ParametrosIdentificadores.Count; i++)
                {
                    comando.Parameters.AddWithValue(parProcesados.ParametrosIdentificadores[i], parProcesados.ValoresProcesados[i]);
                }

                OleDbDataReader dbReader = comando.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(dbReader);
                return dataTable;
            }
            catch (OleDbException ex)
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
            Access access = new Access();
            access.ConfigurarConexion(cadenaConexion);
            return access;
        }


        public string ObtenerBD()
        {
            return conexion.Database;
        }

        public void AsignarBD(string bd)
        {
            ConfigurarConexion(this.provider, bd);
        }

    }
}
