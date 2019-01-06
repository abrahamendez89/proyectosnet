using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Aplicacion
{
    public class DBAcceso
    {
        private SqlConnection conexion;
        private SqlTransaction tran;
        private String cadenaConexion;
        public DBAcceso(String cadenaConexion)
        {
            try
            {
                this.cadenaConexion = cadenaConexion;
                conexion = new SqlConnection();
                conexion.ConnectionString = cadenaConexion;
                conexion.Open();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void AbrirConexion()
        {
            try
            {
                if(conexion.State == ConnectionState.Closed)
                    conexion.Open();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        public void CerrarConexion()
        {
            try
            {
                if (conexion.State == ConnectionState.Open)
                    conexion.Close();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        public void IniciarTransaccion()
        {
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
        public DataTable EjecutarConsulta(String consulta)
        {
            return EjecutarConsulta(consulta, null);
        }
        public DataTable EjecutarConsulta(String consulta, List<Object> valores)
        {
            try
            {
                SqlCommand comando = conexion.CreateCommand();
                comando.CommandText = consulta;
                comando.Transaction = tran;
                comando.CommandTimeout = 60000;

                List<String> parametros = ObtenerListaParametros(consulta);
                if (valores != null)
                {
                    if (parametros.Count != valores.Count) throw new Exception("DBAcceso.EjecutarConsulta: La cantidad de parámetros no corresponde con la cantidad de valores proporcionados.");
                    #region entra a esta seccion si es consulta por parametros;

                    if (valores != null && valores.Count > 0)
                    {
                        for (int i = 0; i < valores.Count; i++)
                        {
                            if (valores[i] != null)
                            {
                                Type type = valores[i].GetType();
                                if (type == typeof(Int32) ||
                                    type == typeof(float) ||
                                    type == typeof(short) ||
                                    type == typeof(Int64) ||
                                    type == typeof(String) ||
                                    type == typeof(Double) ||
                                    type == typeof(Boolean) ||
                                    type == typeof(decimal) ||
                                    type == typeof(DateTime))
                                {

                                    comando.Parameters.AddWithValue("@" + parametros[i], valores[i]);
                                }
                                else
                                {
                                    comando.Parameters.AddWithValue("@" + parametros[i], Converter.ObjectToArray(valores[i]));
                                }
                            }
                            else
                            {
                                consulta = consulta.Replace("@" + parametros[i], "NULL");
                                comando.CommandText = consulta;
                            }
                        }
                    }
                    #endregion
                }
                DataTable dt = new DataTable();
                dt.Load(comando.ExecuteReader());
                return dt;
            }
            catch (Exception ex)
            {
                DeshacerTransaccion();
                throw new Exception("DBAcceso.EjecutarConsulta:"+ex.Message);
            }
        }



        public static List<String> ObtenerListaParametros(String consulta)
        {
            List<String> parametros = new List<string>();

            char[] letras = consulta.ToCharArray();
            String temporal = "";
            Boolean entro = false;
            for (int i = 0; i < letras.Length; i++)
            {
                if ((letras[i] == ' ' || letras[i] == ',' || letras[i] == ';' || letras[i] == ')' || letras[i] == '\n' || letras[i] == '\r' || letras[i] == '\t') && entro)
                {
                    if (!parametros.Contains(temporal))
                        parametros.Add(temporal);
                    temporal = "";
                    entro = false;
                }
                if (letras[i] == '@')
                {
                    entro = true;
                    i++;
                }
                if (entro)
                {
                    temporal += letras[i];
                }
            }
            if (!temporal.Equals("") && !parametros.Contains(temporal))
                parametros.Add(temporal);
            return parametros;
        }

    }
}
