using Herramientas.Archivos;
using Herramientas.Conversiones;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Herramientas.SQL
{
    public class Parametros
    {
        public static ParametrosProcesados AgregarParametros(String consulta, List<Object> parametros, Boolean PermiteGuardarBytes)
        {
            ParametrosProcesados parametrosProcesados = new ParametrosProcesados();
            parametrosProcesados.ParametrosIdentificadores = new List<string>();
            parametrosProcesados.ValoresProcesados = new List<object>();

            List<String> parametrosIdentificadores = ObtenerListaParametros(consulta);
            if (parametros != null)
            {
                if (parametrosIdentificadores.Count != parametros.Count) throw new Exception("La cantidad de parámetros no corresponde con la cantidad de valores proporcionados.");
                #region entra a esta seccion si es consulta por parametros;

                if (parametros != null && parametros.Count > 0)
                {
                    for (int i = 0; i < parametros.Count; i++)
                    {
                        if (parametros[i] != null)
                        {
                            Type type = parametros[i].GetType();
                            if (type == typeof(Int32) ||
                                type == typeof(float) ||
                                type == typeof(short) ||
                                type == typeof(Int64) ||
                                type == typeof(String) ||
                                type == typeof(Double) ||
                                type == typeof(Boolean) ||
                                type == typeof(decimal))
                            {
                                if (parametrosIdentificadores[i].StartsWith("%"))
                                    parametros[i] = "%" + parametros[i];
                                if (parametrosIdentificadores[i].EndsWith("%"))
                                    parametros[i] = parametros[i] + "%";
                                if (parametrosIdentificadores[i].StartsWith("%") || parametrosIdentificadores[i].EndsWith("%"))
                                {
                                    consulta = consulta.Replace(parametrosIdentificadores[i], parametros[i].ToString());
                                }
                                else
                                {
                                    //comando.Parameters.AddWithValue("@" + parametrosIdentificadores[i], parametros[i]);
                                    parametrosProcesados.ParametrosIdentificadores.Add("@" + parametrosIdentificadores[i]);
                                    parametrosProcesados.ValoresProcesados.Add(parametros[i]);
                                }
                            }
                            else if (type == typeof(DateTime))
                            {
                                if ((DateTime)parametros[i] != DateTime.MinValue)
                                {
                                    //comando.Parameters.AddWithValue("@" + parametrosIdentificadores[i], parametros[i]);
                                    parametrosProcesados.ParametrosIdentificadores.Add("@" + parametrosIdentificadores[i]);
                                    parametrosProcesados.ValoresProcesados.Add(parametros[i]);
                                }
                                else
                                {
                                    consulta = consulta.Replace("@" + parametrosIdentificadores[i], "NULL");
                                }
                            }
                            else if (type == typeof(Bitmap))
                            {
                                //comando.Parameters.AddWithValue("@" + parametrosIdentificadores[i], Converter.BitmapTOBitArray((Bitmap)parametros[i]));
                                parametrosProcesados.ParametrosIdentificadores.Add("@" + parametrosIdentificadores[i]);
                                //if(PermiteGuardarBytes) 
                                    parametrosProcesados.ValoresProcesados.Add(Imagenes.BitmapTOBitArray((Bitmap)parametros[i]));
                                //else parametrosProcesados.ValoresProcesados.Add(Converter.BitmapATexto((Bitmap)parametros[i]));
                            }
                            else if (type == typeof(byte[]))
                            {
                                //comando.Parameters.AddWithValue("@" + parametrosIdentificadores[i], parametros[i]);
                                parametrosProcesados.ParametrosIdentificadores.Add("@" + parametrosIdentificadores[i]);
                                //if(PermiteGuardarBytes) 
                                    parametrosProcesados.ValoresProcesados.Add(parametros[i]);
                                //else parametrosProcesados.ValoresProcesados.Add(Converter.ByteArrayToString((byte[])parametros[i]));
                            }
                            else
                            {
                                //comando.Parameters.AddWithValue("@" + parametrosIdentificadores[i], Converter.ObjectToArray(parametros[i]));
                                parametrosProcesados.ParametrosIdentificadores.Add("@" + parametrosIdentificadores[i]);
                                //if(PermiteGuardarBytes) 
                                    parametrosProcesados.ValoresProcesados.Add(Converter.ObjectToArray(parametros[i]));
                                //else parametrosProcesados.ValoresProcesados.Add(Converter.ByteArrayToString(Converter.ObjectToArray(parametros[i])));
                            }
                        }
                        else
                        {
                            consulta = consulta.Replace("@" + parametrosIdentificadores[i], "NULL");
                        }
                    }
                }
                #endregion
            }
            parametrosProcesados.Consulta = consulta;
            return parametrosProcesados;
        }
        private static List<String> ObtenerListaParametros(String consulta)
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
    }
}
