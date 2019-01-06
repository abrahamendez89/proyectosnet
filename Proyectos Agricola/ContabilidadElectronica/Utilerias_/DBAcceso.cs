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
using System.Drawing;
using Utilerias.Utilerias;

namespace Utilerias
{
    public class DBAcceso
    {
        private SqlConnection conexion;
        private SqlTransaction tran;
        private String cadenaConexion;

        private static DBAcceso instanciaSingleton;
        private static String conexionSQLGenerica = "data source = @servidor; initial catalog = @bd; user id = @usuario; password = @contra";
        private static Variable vars;
        public static String Usuario;
        public static String Contrasena;
        public static String BD;
        public static DBAcceso ObtenerInstancia()
        {
            try
            {
                if (instanciaSingleton == null)
                {
                    String conexiont = conexionSQLGenerica.Replace("@servidor", vars.ObtenerValorVariable<String>("servidor")).Replace("@bd", "master").Replace("@usuario", Usuario.Trim()).Replace("@contra", Contrasena.Trim());
                    instanciaSingleton = new DBAcceso(conexiont);
                    instanciaSingleton.AbrirConexion();
                }
                return instanciaSingleton;
            }
            catch (Exception ex)
            {
                Mensajes.Error(ex.Message, "Error al cargar parametros");
                return null;
            }
        }
        public Boolean Reconectar()
        {
            try
            {
                String conexiont = conexionSQLGenerica.Replace("@servidor", vars.ObtenerValorVariable<String>("servidor")).Replace("@bd", BD).Replace("@usuario", Usuario.Trim()).Replace("@contra", Contrasena.Trim());
                instanciaSingleton = new DBAcceso(conexiont);
                instanciaSingleton.AbrirConexion();
                return true;
            }
            catch (Exception ex)
            {
                //Mensajes.Error(ex.Message, "Error al cargar parametros");
                return false;
            }
        }
        public String CadenaConexion { get { return this.cadenaConexion; } }
        public DBAcceso(String cadenaConexion)
        {
            try
            {
                try
                {
                    vars = new Variable("Parametros.ini");
                }
                catch { }
                this.cadenaConexion = cadenaConexion;
                conexion = new SqlConnection();
                conexion.ConnectionString = cadenaConexion;

                conexion.Open();
                instanciaSingleton = this;
            }
            catch (Exception ex)
            {
                if (ex.Message.ToLower().Contains("error: 26"))
                    throw new Exception("Ocurrió un error al conectar al servidor de base de datos. Verificar conexión de red.");
                throw new Exception(ex.Message);
            }
        }
        public DBAcceso(String servidor, String BaseDatos, String usuario, String contra)
        {
            try
            {

                this.cadenaConexion = conexionSQLGenerica.Replace("@servidor", servidor).Replace("@bd", BaseDatos).Replace("@usuario", usuario).Replace("@contra", contra);
                conexion = new SqlConnection();
                conexion.ConnectionString = cadenaConexion;

                conexion.Open();
                instanciaSingleton = this;
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
            tran = conexion.BeginTransaction();
        }
        public void TerminarTransaccion()
        {
            try
            {
                if (tran != null)
                    tran.Commit();
            }
            catch { }
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
        //private int Reconectar()
        //{
        //    for (int i = 0; i < 3; i++)
        //    {
        //        try
        //        {
        //            conexion.Open();
        //            return i;
        //        }
        //        catch (SqlException ssqlex)
        //        {
        //            //conexion.Open();
        //        }
        //    }
        //    throw new Exception("Intentos de conexión con el servidor superados, verificar conexión de red.");
        //}
        public DataTable EjecutarConsulta(String consulta, List<Object> valores)
        {
            try
            {
                for (int i = 0; i < 3; i++)
                {
                    if (conexion.State != ConnectionState.Open)
                    {
                        try
                        {
                            conexion.Open();
                        }
                        catch { }
                    }
                    else
                        break;
                }
                if (conexion.State != ConnectionState.Open)
                {
                    throw new Exception("Limite de intentos de conexión excedidos.");
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
                                    type == typeof(char) ||
                                    type == typeof(decimal))
                                {

                                    comando.Parameters.AddWithValue("@" + parametros[i], valores[i]);
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
                                else if (type == typeof(byte[]))
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
                            }
                        }
                    }
                    #endregion
                }
                //Log.EscribirLog(consulta);
                comando.CommandText = consulta;
                DataTable dt = new DataTable();
                try
                {
                    dt.Load(comando.ExecuteReader());
                }
                catch (Exception ex)
                {

                    if (ex.Message.ToLower().Contains("error: 0"))
                    {
                        if (tran == null)
                        {
                            Reconectar();
                            dt.Load(comando.ExecuteReader());
                        }
                        else
                        {
                            throw new Exception("Se perdió la conexión con el servidor y debido a que se usa una transacción, se necesita iniciar el proceso nuevamente.");
                        }
                    }
                    else
                        throw new Exception(ex.Message);
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
                    if (!atributo.Name.Equals("id") && !atributo.Name.Equals("dtFechaCreacion") && !atributo.Name.Equals("dtFechaModificacion") && !atributo.Name.Equals("sUsuarioCreacion") && !atributo.Name.Equals("sUsuarioModificacion"))
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
                FieldInfo acceso = obj.GetType().GetField("dbAcceso", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                acceso.SetValue(obj, this);
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
