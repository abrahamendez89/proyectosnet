using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FirebirdSql.Data.FirebirdClient;
using System.Data;

namespace Utilerias.SQL
{
    public class Firebird : ISQLManager
    {
        private FbConnection conexion;
        private FbTransaction tran;
        private String cadenaConexion;
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
        public  int Reconectar()
        {
            for (int i = 0; i < 3; i++)
            {
                try
                {
                    conexion.Open();
                    return i;
                }
                catch (Exception ssqlex)
                {
                    //conexion.Open();
                }
            }
            throw new Exception("Intentos de conexión con el servidor superados, verificar conexión de red.");
        }
        public DataTable EjecutarConsulta(String consulta)
        {
            try
            {
                if (conexion.State != ConnectionState.Open)
                {
                    Reconectar();
                }


                FbCommand comando = conexion.CreateCommand();
                comando.CommandText = consulta;
                comando.Transaction = tran;
                comando.CommandTimeout = 300000000;

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
        public void ConfigurarConexion(String database, String dataSource)
        {
            string connectionString =
            "User=SYSDBA;" +
            "Password=masterkey;" +
            "Database=@DATABASE;" +
            "DataSource=@DATASOURCE;" +
            "Port=3050;" +
            "Dialect=3;" +
            "Charset=NONE;" +
            "Role=;" +
            "Connection lifetime=15;" +
            "Pooling=true;" +
            "MinPoolSize=0;" +
            "MaxPoolSize=50;" +
            "Packet Size=8192;" +
            "ServerType=0";


            connectionString = connectionString.Replace("@DATABASE", database).Replace("@DATASOURCE", dataSource);

            ConfigurarConexion(connectionString);

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

    }
}
