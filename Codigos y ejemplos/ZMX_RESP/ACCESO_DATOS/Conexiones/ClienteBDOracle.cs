using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACCESO_DATOS.Control;
using Oracle.ManagedDataAccess.Client;

namespace ACCESO_DATOS.Conexiones
{
    public class ClienteBDOracle : IClienteBD
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        OracleConnection conexion;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        OracleTransaction transaccion;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        int commandTimeout = 30000;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        String cadenaConexion;

        public String Host { get { if (conexion != null) { return conexion.HostName; } else { return ""; } } }
        public String SSID { get { if (conexion != null) { return conexion.InstanceName; } else { return ""; } } }


        private String ConcatenarException(Exception ex)
        {
            String cadena = "";
            while (ex != null)
            {
                cadena += ex.Message + " > ";
                ex = ex.InnerException;
            }
            return cadena.Substring(0, cadena.Length - 3);
        }

        public void AbrirConexion()
        {
            try
            {
                if (conexion != null)
                    throw new Exception("Ya hay una conexión activa.");

                conexion = new OracleConnection(this.cadenaConexion);
                conexion.Open();

                OracleGlobalization info = conexion.GetSessionInfo();
                info.DateFormat = "yyyy/mm/dd hh24:mi:ss";
                conexion.SetSessionInfo(info);



            }
            catch (Exception ex)
            {
                throw new Exception(ConcatenarException(ex));
            }
        }
        public void AsignarCadenaConexion(string cadenaConexion)
        {
            this.cadenaConexion = cadenaConexion;
        }

        public void CerrarConexion()
        {
            try
            {
                conexion.Close();
                conexion.Dispose();
                conexion = null;
            }
            catch (Exception ex)
            {
                throw new Exception(ConcatenarException(ex));
            }
        }

        public void DeshacerTransaccion()
        {
            try
            {
                if (transaccion == null)
                {
                    return;
                    //throw new Exception("No es posible deshacer la transacción debido a que no se ha iniciado anteriormente.");
                }
                transaccion.Rollback();
                transaccion.Dispose();
                transaccion = null;
            }
            catch (Exception ex)
            {
                throw new Exception(ConcatenarException(ex));
            }
        }

        public int EjecutarDelete(string deleteQuery)
        {
            try
            {
                if (conexion == null || conexion.State == ConnectionState.Closed)
                    throw new Exception("Debe Abrir la conexión antes.");


                OracleCommand comando = conexion.CreateCommand();
                comando.CommandText = deleteQuery;
                comando.Transaction = transaccion;
                comando.CommandTimeout = commandTimeout;

                int registrosAfectados = 0;
                try
                {
                    registrosAfectados = comando.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return registrosAfectados;
            }
            catch (Exception ex)
            {
                throw new Exception(ConcatenarException(ex));
            }
        }

        public int EjecutarDelete(string deleteQuery, List<object> parametros)
        {
            throw new NotImplementedException();
        }

        public int EjecutarInsert(string insertQuery)
        {
            try
            {
                if (conexion == null || conexion.State == ConnectionState.Closed)
                    throw new Exception("Debe Abrir la conexión antes.");

                OracleCommand comando = conexion.CreateCommand();
                comando.CommandText = insertQuery;
                comando.Transaction = transaccion;
                comando.CommandTimeout = commandTimeout;

                int registrosAfectados = 0;
                try
                {
                    registrosAfectados = comando.ExecuteNonQuery();
                    comando.Dispose();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return registrosAfectados;
            }
            catch (Exception ex)
            {
                throw new Exception(ConcatenarException(ex));
            }
        }

        public int EjecutarInsert(string insertQuery, Dictionary<String, Object> parametros)
        {
            try
            {
                if (conexion == null || conexion.State == ConnectionState.Closed)
                    throw new Exception("Debe Abrir la conexión antes.");

                String query = Estructura.ConvertirParametrosParaQuery(insertQuery, parametros);

                List<String> parametrosQ = Estructura.ObtenerListaParametros(query);

                OracleCommand comando = conexion.CreateCommand();
                comando.CommandText = query;
                comando.Transaction = transaccion;
                comando.CommandTimeout = commandTimeout;

                //se asignan los parametros
                foreach (String parametro in parametrosQ)
                {
                    if (parametros.ContainsKey(parametro))
                        comando.Parameters.Add(new OracleParameter(parametro, parametros[parametro]));
                }

                int registrosAfectados = 0;
                try
                {
                    registrosAfectados = comando.ExecuteNonQuery();
                    comando.Dispose();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return registrosAfectados;
            }
            catch (Exception ex)
            {
                throw new Exception(ConcatenarException(ex));
            }
        }

        public DataTable EjecutarSelect(string selectQuery)
        {
            try
            {
                if (conexion == null || conexion.State == ConnectionState.Closed)
                    throw new Exception("Debe Abrir la conexión antes.");

                OracleCommand comando = conexion.CreateCommand();
                comando.CommandText = selectQuery;
                comando.Transaction = transaccion;
                comando.CommandTimeout = commandTimeout;

                DataTable dt = new DataTable();

                OracleDataReader dr = null;


                try
                {
                    dr = comando.ExecuteReader();
                    using (DataSet ds = new DataSet() { EnforceConstraints = false })
                    {
                        ds.Tables.Add(dt);
                        dt.Load(dr, LoadOption.OverwriteChanges);
                        ds.Tables.Remove(dt);
                    }
                    dr.Close();
                    comando.Dispose();
                    dr.Dispose();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ConcatenarException(ex));
            }
        }

        public DataTable EjecutarSelect(string selectQuery, Dictionary<String, Object> parametros)
        {
            try
            {
                if (conexion == null || conexion.State == ConnectionState.Closed)
                    throw new Exception("Debe Abrir la conexión antes.");



                String query = Estructura.ConvertirParametrosParaQuery(selectQuery, parametros);

                List<String> parametrosQ = Estructura.ObtenerListaParametros(query);

                OracleCommand comando = conexion.CreateCommand();
                comando.CommandText = query;
                comando.Transaction = transaccion;
                comando.CommandTimeout = commandTimeout;


                //se asignan los parametros
                foreach (String parametro in parametrosQ)
                {
                    if (parametros.ContainsKey(parametro))
                        comando.Parameters.Add(new OracleParameter(parametro, parametros[parametro]));
                }



                DataTable dt = new DataTable();

                OracleDataReader dr = null;


                try
                {
                    dr = comando.ExecuteReader();
                    using (DataSet ds = new DataSet() { EnforceConstraints = false })
                    {
                        ds.Tables.Add(dt);
                        dt.Load(dr, LoadOption.OverwriteChanges);
                        ds.Tables.Remove(dt);
                    }
                    dr.Close();
                    comando.Dispose();
                    dr.Dispose();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ConcatenarException(ex));
            }
        }

        public int EjecutarUpdate(string updateQuery)
        {
            try
            {
                if (conexion == null || conexion.State == ConnectionState.Closed)
                    throw new Exception("Debe Abrir la conexión antes.");

                OracleCommand comando = conexion.CreateCommand();
                comando.CommandText = updateQuery;
                comando.Transaction = transaccion;
                comando.CommandTimeout = commandTimeout;

                int registrosAfectados = 0;
                try
                {
                    registrosAfectados = comando.ExecuteNonQuery();
                    comando.Dispose();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return registrosAfectados;
            }
            catch (Exception ex)
            {
                throw new Exception(ConcatenarException(ex));
            }
        }

        public int EjecutarUpdate(string updateQuery, Dictionary<String, Byte[]> parametros)
        {
            try
            {
                if (conexion == null || conexion.State == ConnectionState.Closed)
                    throw new Exception("Debe Abrir la conexión antes.");

                OracleCommand comando = conexion.CreateCommand();
                comando.CommandText = updateQuery;
                comando.Transaction = transaccion;
                comando.CommandTimeout = commandTimeout;

                //se asignan los parametros
                foreach (String parametro in parametros.Keys)
                {
                    comando.Parameters.Add(parametro, OracleDbType.Blob, parametros[parametro], ParameterDirection.Input);
                }

                int registrosAfectados = 0;
                try
                {
                    registrosAfectados = comando.ExecuteNonQuery();
                    comando.Dispose();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return registrosAfectados;
            }
            catch (Exception ex)
            {
                throw new Exception(ConcatenarException(ex));
            }
        }

        public void IniciarTransaccion()
        {
            try
            {
                if (conexion == null || conexion.State == ConnectionState.Closed)
                    throw new Exception("Debe Abrir la conexión antes.");
                if (transaccion != null)
                {
                    throw new Exception("No es posible iniciar una transacción mas de una vez. Finalice una transacción para iniciar otra.");
                }
                transaccion = conexion.BeginTransaction(IsolationLevel.ReadCommitted);
            }
            catch (Exception ex)
            {
                throw new Exception(ConcatenarException(ex));
            }
        }

        public string ObtenerCadenaConexion()
        {
            throw new NotImplementedException();
        }

        public void TerminarTransaccion()
        {
            try
            {
                if (transaccion == null)
                {
                    throw new Exception("No es posible deshacer la transacción debido a que no se ha iniciado anteriormente.");
                }
                transaccion.Commit();
                transaccion.Dispose();
                transaccion = null;
            }
            catch (Exception ex)
            {
                throw new Exception(ConcatenarException(ex));
            }
        }

        public bool EstaActivaConexion()
        {
            return conexion != null;
        }

        public bool EstaActivaTransaccion()
        {
            return transaccion != null;
        }

        public int EjecutaInsertUpdate(string insertUpdate)
        {
            try
            {
                if (conexion == null || conexion.State == ConnectionState.Closed)
                    throw new Exception("Debe Abrir la conexión antes.");

                OracleCommand comando = conexion.CreateCommand();
                comando.CommandText = insertUpdate;
                comando.Transaction = transaccion;
                comando.CommandTimeout = commandTimeout;

                int registrosAfectados = 0;
                try
                {
                    registrosAfectados = comando.ExecuteNonQuery();
                    comando.Dispose();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return registrosAfectados;
            }
            catch (Exception ex)
            {
                throw new Exception(ConcatenarException(ex));
            }
        }

        public int EjecutarUpdate(string updateQuery, Dictionary<string, object> parametros)
        {
            throw new NotImplementedException();
        }

        public int EjecutarDelete(string deleteQuery, Dictionary<string, object> parametros)
        {
            throw new NotImplementedException();
        }
    }
}
