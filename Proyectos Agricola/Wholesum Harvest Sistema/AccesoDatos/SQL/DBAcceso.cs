using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using Herramientas.Conversiones;
using System.Drawing;
using Herramientas.Archivos;
using System.Threading;

namespace AccesoDatos.SQL
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
                if (ex.Message.ToLower().Contains("error: 26"))
                    throw new Exception("Ocurrió un error al conectar al servidor de base de datos. Verificar conexión de red.");
                throw new Exception(ex.Message);
            }
        }
        public void AbrirConexion()
        {
            try
            {
                conexion.Open();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        public void CerrarConexion()
        {
            try
            {
                conexion.Close();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        public void IniciarTransaccion()
        {
            if (conexion.State != ConnectionState.Open)
                Reconectar();
            tran = conexion.BeginTransaction();
        }
        public void TerminarTransaccion()
        {
            try
            {
                if (tran != null)
                {
                    tran.Commit();
                    conexion.Close();
                    conexion.Dispose();
                }
            }
            catch { }
        }
        public void DeshacerTransaccion()
        {
            try
            {
                if (tran != null)
                {
                    tran.Rollback();
                    conexion.Close();
                    conexion.Dispose();
                }
            }
            catch { }
        }
        public DataTable EjecutarConsulta(String consulta)
        {
            return EjecutarConsulta(consulta, null);
        }
        private int Reconectar()
        {
            for (int i = 0; i < 3; i++)
            {
                try
                {
                    //if (conexion.State != ConnectionState.Connecting)
                    //    conexion.Close();
                    if (conexion.State != ConnectionState.Open)
                    {
                        conexion.Close();
                        conexion.ConnectionString = cadenaConexion;
                        conexion.Open();
                    }
                    return i;
                }
                catch (SqlException ssqlex)
                {
                    //conexion.Open();
                }
            }
            throw new Exception("Intentos de conexión con el servidor superados, verificar conexión de red.");
        }
        public DataTable EjecutarConsulta(String consulta, List<Object> valores)
        {
            try
            {
                if (conexion.State != ConnectionState.Open)
                {
                    Reconectar();
                }


                SqlCommand comando = conexion.CreateCommand();
                comando.CommandText = consulta;
                comando.Transaction = tran;
                comando.CommandTimeout = 300000;

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
                                    type == typeof(decimal))
                                {
                                    if (parametros[i].StartsWith("%"))
                                        valores[i] = "%" + valores[i];
                                    if (parametros[i].EndsWith("%"))
                                        valores[i] = valores[i] + "%";
                                    if (parametros[i].StartsWith("%") || parametros[i].EndsWith("%"))
                                    {
                                        consulta = consulta.Replace(parametros[i], valores[i].ToString());
                                    }
                                    else
                                    {
                                        comando.Parameters.AddWithValue("@" + parametros[i], valores[i]);
                                    }
                                }
                                else if (type == typeof(DateTime))
                                {
                                    if ((DateTime)valores[i] != DateTime.MinValue)
                                        comando.Parameters.AddWithValue("@" + parametros[i], valores[i]);
                                    else
                                        consulta = consulta.Replace("@" + parametros[i], "NULL");
                                }
                                else if (type == typeof(Bitmap))
                                {
                                    comando.Parameters.AddWithValue("@" + parametros[i], Converter.BitmapTOBitArray((Bitmap)valores[i]));
                                }
                                else
                                {
                                    comando.Parameters.AddWithValue("@" + parametros[i], Converter.ObjectToArray(valores[i]));
                                }
                            }
                            else
                            {
                                consulta = consulta.Replace("@" + parametros[i], "NULL");
                            }
                        }
                    }
                    #endregion
                }
                //Log.EscribirLog(consulta);
                comando.CommandText = consulta;
                SqlDataReader dReader = null;
                DataTable dt = new DataTable();
                try
                {
                    dReader = comando.ExecuteReader();
                    dt.Load(dReader);
                    dReader.Close();
                }
                catch (Exception ex)
                {
                    Reconectar();
                    if (ex.Message.Contains("DataReader") || ex.Message.Contains("ExecuteReader"))
                    {
                        
                        for (int i = 0; i < 10; i++)
                        {
                            Reconectar();
                            Thread.Sleep(100);
                            try
                            {
                                dt.Load(comando.ExecuteReader());
                                return dt;
                            }
                            catch (Exception ex2)
                            {
                                Console.Write(ex2.Message);
                            }
                        }
                        throw new Exception("Se superó el limite de intentos de consulta con el data reader ocupado.");
                    }
                    else if (ex.Message.ToLower().Contains("error: 0"))
                    {
                        if (tran == null)
                        {
                            int intentos = Reconectar();
                            dt.Load(comando.ExecuteReader());
                            Log.EscribirLog("Se perdió la conexión con el servidor, pero se pudo reestablecer exitosamente en " + intentos + " intento(s).");
                        }
                        else
                        {
                            throw new Exception("Se perdió la conexión con el servidor y debido a que se usa una transacción, se necesita iniciar el proceso nuevamente.");
                        }
                    }
                    
                    else
                        throw new Exception(ex.Message);
                }

                if (tran == null || tran.Connection == null)
                {
                    //conexion.Close();
                    //conexion.Dispose();
                }
                
                comando.Dispose();
                return dt;
            }
            catch (Exception ex)
            {
                DeshacerTransaccion();
                throw new Exception("DBAcceso.EjecutarConsulta:" + ex.Message);
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
                if ((letras[i] == ' ' || letras[i] == ',' || letras[i] == ';' || letras[i] == ')' || letras[i] == '\n' || letras[i] == '\r' || letras[i] == '\t' || letras[i] == '%') && entro)
                {
                    if (!parametros.Contains(temporal))
                    {
                        if (letras[i] == '%')
                            temporal += "%";
                        parametros.Add(temporal);
                    }
                    temporal = "";
                    entro = false;
                }
                if (letras[i] == '@')
                {
                    if (letras[i - 1] == '%')
                        temporal += "%@";
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
        //----------------------------------------------------------
        private IList createGenericList(Type typeInList)
        {
            var genericListType = typeof(List<>).MakeGenericType(new[] { typeInList });
            return (IList)Activator.CreateInstance(genericListType);
        }
        public IList MapearDataTableAObjecto(Type tipo, DataTable dt)
        {
            FieldInfo[] atributos = tipo.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

            IList listaT = createGenericList(tipo);

            foreach (DataRow dr in dt.Rows)
            {
                var obj = tipo
                     .GetConstructor(Type.EmptyTypes)
                     .Invoke(null);
                for (int j = 0; j < atributos.Length; j++)
                {
                    FieldInfo atributo = atributos[j];
                    if (!atributo.Name.Equals("id") && !atributo.Name.Equals("dtFechaCreacion") && !atributo.Name.Equals("dtFechaModificacion") && !atributo.Name.Equals("sUsuarioCreacion") && !atributo.Name.Equals("sUsuarioModificacion") && !atributo.Name.Equals("estaDeshabilitado"))
                    {
                        if (!atributo.Name.StartsWith("_") || atributo.FieldType.Name.Contains("List") || atributo.FieldType.Name.StartsWith("_"))
                            continue; // se ignoran las listas de objetos relacionados y los objetos relacionados
                    }
                    FieldInfo campo = obj.GetType().GetField(atributo.Name, BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);

                    try
                    {
                        if (dr[atributo.Name] != DBNull.Value)
                        {
                            if (campo.FieldType == typeof(Bitmap))
                                campo.SetValue(obj, Converter.BitArrayTOBitmap((byte[])dr[atributo.Name]));
                            else if (dr[atributo.Name].GetType() == typeof(byte[]) && campo.FieldType == typeof(Object))
                            {
                                byte[] bytes = (byte[])Converter.ParseType(dr[atributo.Name], typeof(byte[]));
                                MemoryStream memStream = new MemoryStream();
                                BinaryFormatter binForm = new BinaryFormatter();

                                memStream.Write(bytes, 0, bytes.Length);
                                memStream.Seek(0, SeekOrigin.Begin);

                                object objyyyyyyyyy = Converter.ArrayToObject(bytes);

                                object objtttttttttttt = (object)binForm.Deserialize(memStream);


                                campo.SetValue(obj, Converter.ParseType(bytes, campo.FieldType));
                            }
                            else if (dr[atributo.Name].GetType() == typeof(byte[])) // atributos del tipo object (imagenes, archivos, huellas, etc)
                                campo.SetValue(obj, Converter.ArrayToObject((byte[])dr[atributo.Name]));
                            else
                                campo.SetValue(obj, Converter.ParseType(dr[atributo.Name], campo.FieldType));
                        }
                    }
                    catch (Exception ae)
                    {
                        campo.SetValue(obj, null);
                    }

                }
                
                //FieldInfo acceso = obj.GetType().GetField("dbAcceso", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                //acceso.SetValue(obj, this);

                listaT.Add(obj);

            }
            return listaT;
        }

        public List<T> MapearDataTableAObjecto<T>(DataTable dt)
        {
            Type tipo = typeof(T);
            return (List<T>)MapearDataTableAObjecto(tipo, dt);
        }
    }
}
