using Herramientas.ORM;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web.Script.Serialization;

namespace Herramientas.Web
{
    public class JSON
    {
        public static object ObjetoBaseConvertir;
        public static int Niveles;
        public static String ConvertirObjetoBaseAJSON<T>(T objetoAConvertir)
        {
            return ConvertirObjetoBaseAJSON<T>(objetoAConvertir, 0);
        }
        public static String ConvertirObjetoBaseAJSON<T>(T objetoAConvertir, int niveles)
        {
            return ConvertirObjetoBaseAJSON_Priv(objetoAConvertir, niveles);
        }
        public static String ConvertirListaObjetoBaseAJSON<T>(List<T> listaAConvertir)
        {
            return ConvertirListaObjetoBaseAJSON<T>(listaAConvertir,0);
        }
        public static String ConvertirListaObjetoBaseAJSON<T>(List<T> listaAConvertir, int niveles)
        {
            return ConvertirObjetoBaseAJSON_Priv(listaAConvertir, niveles);
        }
        private static String ConvertirObjetoBaseAJSON_Priv(object objetoAConvertir, int niveles)
        {
            JSON.ObjetoBaseConvertir = objetoAConvertir;
            JSON.Niveles = niveles;

            String cadena = "";
            Type tipo = objetoAConvertir.GetType();
            if (tipo.Name.StartsWith("List"))
            {
                cadena += "[";
                IList lista = (IList)objetoAConvertir;
                foreach (object objetoLista in lista)
                {
                    cadena += "\n{\n";
                    cadena = Convertir(objetoLista, 0, cadena);
                    cadena = cadena.Substring(0, cadena.Length - 1);
                    cadena += "\n},";
                }
                cadena = cadena.Substring(0, cadena.Length - 1);
                cadena += "\n]\n";
            }
            else
            {
                cadena = "{";
                cadena = Convertir(JSON.ObjetoBaseConvertir, 0, cadena);
                cadena = cadena.Substring(0, cadena.Length - 1);
                cadena += "\n}";
            }
           
            return cadena;
        }
        private static String Convertir(Object objeto, int nivelActual, String cadenaActual)
        {
            //if (Niveles == 0)
            //    return "";
            if (nivelActual == Niveles + 1 && Niveles != 0)
                return cadenaActual;

            Type tipo = objeto.GetType();

            //FieldInfo[] atributos = tipo.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            PropertyInfo[] propiedades = tipo.GetProperties();
            nivelActual++;
            for (int i = 0; i < propiedades.Length; i++)
            {
                PropertyInfo atributo = propiedades[i];
                Object valor = null;
                try
                {
                    valor = atributo.GetValue(objeto, null);
                }
                catch
                {
                    continue;
                }
                if (valor != null) // && atributo.Name.StartsWith("_"))
                {
                    //es una tributo valido y ahora se obtiene el tipo de atributo
                    if (atributo.PropertyType.Name.StartsWith("_"))
                    {
                        cadenaActual += "\n";
                        cadenaActual += ObtenerIdentacion(nivelActual) + "\"" + atributo.Name + "\" : \n";
                        nivelActual++;
                        cadenaActual += ObtenerIdentacion(nivelActual) + "{";
                        cadenaActual = Convertir(valor, nivelActual, cadenaActual);
                        cadenaActual = cadenaActual.Substring(0, cadenaActual.Length - 1);
                        cadenaActual += ObtenerIdentacion(nivelActual) + "\n";
                        cadenaActual += ObtenerIdentacion(nivelActual) + "},";
                        nivelActual--;
                    }
                    else if (atributo.PropertyType.Name.StartsWith("List"))
                    {
                        //el atributo es de tipo lista por lo tanto se considera como una lista de objetos de dominio
                        if (nivelActual == Niveles)
                            continue;
                        IList lista = (IList)valor;
                        cadenaActual += "\n";
                        cadenaActual += ObtenerIdentacion(nivelActual) + "\"" + atributo.Name + "\" : \n";
                        cadenaActual += ObtenerIdentacion(nivelActual) + "[";
                        Boolean paso = false;
                        foreach (object objetoLista in lista)
                        {
                            cadenaActual += "\n";
                            nivelActual++;
                            cadenaActual += ObtenerIdentacion(nivelActual) + "{";
                            cadenaActual = Convertir(objetoLista, nivelActual, cadenaActual);
                            cadenaActual = cadenaActual.Substring(0, cadenaActual.Length - 1);
                            cadenaActual += "\n";
                            cadenaActual += ObtenerIdentacion(nivelActual) + "},";
                            nivelActual--;
                            paso = true;

                        }
                        if (paso) cadenaActual = cadenaActual.Substring(0, cadenaActual.Length - 1);
                        cadenaActual += "\n";
                        cadenaActual += ObtenerIdentacion(nivelActual) + "],";
                    }
                    else
                    {
                        //el atributo es del objeto en curso, por lo tanto se obtiene su tipo de atributo.
                        if (atributo.PropertyType == typeof(String))
                        {

                            cadenaActual += "\n";
                            cadenaActual += ObtenerIdentacion(nivelActual) + "\"" + atributo.Name + "\" : \"" + valor.ToString() + "\",";
                        }
                        else if (atributo.PropertyType == typeof(Int32) || atributo.PropertyType == typeof(double) || atributo.PropertyType == typeof(Int64))
                        {
                            cadenaActual += "\n";
                            cadenaActual += ObtenerIdentacion(nivelActual) + "\"" + atributo.Name + "\" : " + valor.ToString() + ",";
                        }
                        else if (atributo.PropertyType == typeof(Bitmap))
                        {
                            cadenaActual += "\n";
                            cadenaActual += ObtenerIdentacion(nivelActual) + "\"" + atributo.Name + "\" : \"" + ConvertirBitmapAStringBase64((Bitmap)valor) + "\",";
                        }
                        else if (atributo.PropertyType == typeof(DateTime) && Convert.ToDateTime(valor) != DateTime.MinValue)
                        {
                            cadenaActual += "\n";
                            cadenaActual += ObtenerIdentacion(nivelActual) + "\"" + atributo.Name + "\" : " + Newtonsoft.Json.JsonConvert.SerializeObject(valor) + ",";
                        }
                        else if (atributo.PropertyType == typeof(Boolean))
                        {
                            cadenaActual += "\n";
                            cadenaActual += ObtenerIdentacion(nivelActual) + "\"" + atributo.Name + "\" : \"" + valor.ToString().ToLower() + "\",";
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
            }
            return cadenaActual;

        }
        //----------
        public static String ConvertirObjetoAJSON<T>(T objetoAConvertir)
        {
            return ConvertirObjetoAJSON<T>(objetoAConvertir, 0);
        }
        public static String ConvertirObjetoAJSON<T>(T objetoAConvertir, int niveles)
        {
            return ConvertirObjetoAJSON_Priv(objetoAConvertir, niveles);
        }
        public static String ConvertirListaObjetoAJSON<T>(List<T> listaAConvertir)
        {
            return ConvertirListaObjetoAJSON<T>(listaAConvertir, 0);
        }
        public static String ConvertirListaObjetoAJSON<T>(List<T> listaAConvertir, int niveles)
        {
            return ConvertirObjetoAJSON_Priv(listaAConvertir, niveles);
        }
        private static String ConvertirObjetoAJSON_Priv(object objetoAConvertir, int niveles)
        {
            JSON.ObjetoBaseConvertir = objetoAConvertir;
            JSON.Niveles = niveles;

            String cadena = "";
            Type tipo = objetoAConvertir.GetType();
            if (tipo.Name.StartsWith("List"))
            {
                cadena += "[";
                IList lista = (IList)objetoAConvertir;
                foreach (object objetoLista in lista)
                {
                    cadena += "\n{\n";
                    cadena = Convertir(objetoLista, 0, cadena);
                    cadena = cadena.Substring(0, cadena.Length - 1);
                    cadena += "\n},";
                }
                cadena = cadena.Substring(0, cadena.Length - 1);
                cadena += "\n]\n";
            }
            else
            {
                cadena = "{";
                cadena = ConvertirObjetoNormal(JSON.ObjetoBaseConvertir, 0, cadena);
                cadena = cadena.Substring(0, cadena.Length - 1);
                cadena += "\n}";
            }

            return cadena;
        }
        private static String ConvertirObjetoNormal(Object objeto, int nivelActual, String cadenaActual)
        {
            //if (Niveles == 0)
            //    return "";
            if (nivelActual == Niveles + 1 && Niveles != 0)
                return cadenaActual;

            Type tipo = objeto.GetType();

            if (tipo == typeof(String) || tipo == typeof(Int32) || tipo == typeof(Int64) || tipo == typeof(Boolean))
            {
                return "\""+objeto.ToString()+ "\" ";
            }
            if(tipo == typeof(DateTime))
            {
                return "\""+Herramientas.Conversiones.Formatos.DateTimeAFechaUniversal((DateTime)objeto)+ "\" ";
            }

            //FieldInfo[] atributos = tipo.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            PropertyInfo[] propiedades = tipo.GetProperties();
            nivelActual++;
            for (int i = 0; i < propiedades.Length; i++)
            {
                PropertyInfo atributo = propiedades[i];
                Object valor = null;
                try
                {
                    valor = atributo.GetValue(objeto, null);
                }
                catch
                {
                    continue;
                }
                if (valor != null) // && atributo.Name.StartsWith("_"))
                {
                    //es una tributo valido y ahora se obtiene el tipo de atributo
                    if (atributo.PropertyType.Name.StartsWith("List"))
                    {
                        //el atributo es de tipo lista por lo tanto se considera como una lista de objetos de dominio
                        if (nivelActual == Niveles)
                            continue;
                        IList lista = (IList)valor;
                        cadenaActual += "\n";
                        cadenaActual += ObtenerIdentacion(nivelActual) + "\"" + atributo.Name + "\" : \n";
                        cadenaActual += ObtenerIdentacion(nivelActual) + "[";
                        Boolean paso = false;
                        Type tipoInterno = lista.GetType().GetGenericArguments()[0];
                        if (tipoInterno == typeof(String) || tipoInterno == typeof(Int32) || tipoInterno == typeof(Int64) || tipoInterno == typeof(Boolean) || tipoInterno == typeof(DateTime) || tipoInterno == typeof(double) || tipoInterno == typeof(float))
                        {
                            foreach (object objetoLista in lista)
                            {
                                cadenaActual += "\n";
                                nivelActual++;
                                cadenaActual += ObtenerIdentacion(nivelActual) +"\"";
                                if(objetoLista.GetType() == typeof(DateTime))
                                cadenaActual += Herramientas.Conversiones.Formatos.DateTimeAFechaUniversal((DateTime)objetoLista);
                                else
                                    cadenaActual += objetoLista.ToString();
                                cadenaActual += "\"\n";
                                cadenaActual += ObtenerIdentacion(nivelActual) + ",";
                                nivelActual--;
                                paso = true;

                            }
                        }
                        else
                        {
                            foreach (object objetoLista in lista)
                            {
                                cadenaActual += "\n";
                                nivelActual++;
                                cadenaActual += ObtenerIdentacion(nivelActual) + "{";
                                cadenaActual += ConvertirObjetoNormal(objetoLista, nivelActual, cadenaActual);
                                cadenaActual += cadenaActual.Substring(0, cadenaActual.Length - 1);
                                cadenaActual += "\n";
                                cadenaActual += ObtenerIdentacion(nivelActual) + "},";
                                nivelActual--;
                                paso = true;

                            }
                        }
                        if (paso) cadenaActual = cadenaActual.Substring(0, cadenaActual.Length - 1);
                        cadenaActual += "\n";
                        cadenaActual += ObtenerIdentacion(nivelActual) + "],";
                    }
                    else
                    {
                        //el atributo es del objeto en curso, por lo tanto se obtiene su tipo de atributo.
                        if (atributo.PropertyType == typeof(String))
                        {

                            cadenaActual += "\n";
                            cadenaActual += ObtenerIdentacion(nivelActual) + "\"" + atributo.Name + "\" : \"" + valor.ToString() + "\",";
                        }
                        else if (atributo.PropertyType == typeof(Int32) || atributo.PropertyType == typeof(double) || atributo.PropertyType == typeof(Int64))
                        {
                            cadenaActual += "\n";
                            cadenaActual += ObtenerIdentacion(nivelActual) + "\"" + atributo.Name + "\" : " + valor.ToString() + ",";
                        }
                        else if (atributo.PropertyType == typeof(Bitmap))
                        {
                            cadenaActual += "\n";
                            cadenaActual += ObtenerIdentacion(nivelActual) + "\"" + atributo.Name + "\" : \"" + ConvertirBitmapAStringBase64((Bitmap)valor) + "\",";
                        }
                        else if (atributo.PropertyType == typeof(DateTime) && Convert.ToDateTime(valor) != DateTime.MinValue)
                        {
                            cadenaActual += "\n";
                            cadenaActual += ObtenerIdentacion(nivelActual) + "\"" + atributo.Name + "\" : " + Newtonsoft.Json.JsonConvert.SerializeObject(valor) + ",";
                        }
                        else if (atributo.PropertyType == typeof(Boolean))
                        {
                            cadenaActual += "\n";
                            cadenaActual += ObtenerIdentacion(nivelActual) + "\"" + atributo.Name + "\" : \"" + valor.ToString().ToLower() + "\",";
                        }
                        else
                        {
                            cadenaActual += "\n";
                            cadenaActual += ObtenerIdentacion(nivelActual) + "\"" + atributo.Name + "\" : \n";
                            nivelActual++;
                            cadenaActual += ObtenerIdentacion(nivelActual) + "{";
                            cadenaActual = ConvertirObjetoNormal(valor, nivelActual, cadenaActual);
                            cadenaActual = cadenaActual.Substring(0, cadenaActual.Length - 1);
                            cadenaActual += ObtenerIdentacion(nivelActual) + "\n";
                            cadenaActual += ObtenerIdentacion(nivelActual) + "},";
                            nivelActual--;
                        }
                    }
                }
            }
            return cadenaActual;

        }
        private static String ObtenerIdentacion(int nivel)
        {
            String identacionSencilla = "\t";
            String resultado = "";
            for (int i = 0; i < nivel; i++)
            {
                resultado += identacionSencilla;
            }
            return resultado;
        }

        private static string ConvertirBitmapAStringBase64(Bitmap imagen)
        {
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            imagen.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] imageBytes = stream.ToArray();

            string base64String = Convert.ToBase64String(imageBytes);
            return base64String;
        }

        public static T ConvertirJSONAObjeto<T>(string json)
        {
            try
            {
                //json = json.Replace("\t"," ").Replace("\n"," ").Replace("\"","'");
                var o = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(json);
                JsonSerializer serializer = new JsonSerializer();
                T t = (T)serializer.Deserialize(new JTokenReader(o), typeof(T));
                return t;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
