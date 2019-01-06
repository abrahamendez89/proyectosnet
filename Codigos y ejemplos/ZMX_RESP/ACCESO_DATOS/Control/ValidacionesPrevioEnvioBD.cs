using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ACCESO_DATOS.Anotaciones.Clase;
using ACCESO_DATOS.Anotaciones.Propiedad;
using ACCESO_DATOS.Excepciones;

namespace ACCESO_DATOS.Control
{
    public class ValidacionesPrevioEnvioBD
    {
        public static void ValidaCompleto<T>(T obj)
        {
            ValidaNullables<T>(obj);
            ValidaPrecisionNumerica<T>(obj);
            ValidaStrings<T>(obj);
            ValidaTieneLlavePrimariaCorrecta<T>(obj);
        }
        public static void ValidaTieneLlavePrimariaCorrecta<T>(T objeto)
        {
            //se obtienes los valores de la clave primaria
            object[] strLenAttr2 = objeto.GetType().GetCustomAttributes(true);
            //se obtiene el idFormado, para omitirlo de la validacion
            ANC_IDFormado atributoID = typeof(T).GetCustomAttribute<ANC_IDFormado>(true);

            foreach (object atributo in strLenAttr2)
            {
                if (atributo is ANC_Identificador)
                {
                    if(atributoID != null && (atributo as ANC_Identificador).Columna.Equals(atributoID.Columna))
                    {
                        //se omite, porque esta propiedad se formara con las idFormadoParte.
                        continue;
                    }

                    String columna = (atributo as ANC_Identificador).Columna;
                    String propiedad = (atributo as ANC_Identificador).Propiedad;

                    PropertyInfo pi = objeto.GetType().GetProperty(propiedad, System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);

                    if (pi.GetValue(objeto) == null)
                    {
                        throw new EX_IdentificadorIncompletoException(objeto,"La propiedad '" + propiedad + "' debe tener un valor al ser parte del identificador.", propiedad);
                    }

                }
            }
        }

        public static void ValidaNullables<T>(T objeto)
        {
            //se obtienes los valores de la clave primaria
            foreach (PropertyInfo pi in objeto.GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public))
            {
                //verificando si es requerido
                ANP_Configuracion conf = pi.GetCustomAttribute<ANP_Configuracion>(true);

                if (conf != null && !conf.Nullable && pi.GetValue(objeto) == null)
                {
                    throw new EX_ValorNullableException(objeto, "La propiedad '" + pi.Name + "' debe tener un valor porque es requerido.", pi.Name);
                }
                if (conf != null && !conf.Nullable && pi.GetValue(objeto) != null && pi.PropertyType == typeof(String) && String.IsNullOrEmpty(pi.GetValue(objeto).ToString()))
                {
                    throw new EX_ValorNullableException(objeto, "La propiedad '" + pi.Name + "' debe tener un valor diferente a vacío porque es requerido.", pi.Name);
                }

            }
        }
        public static void ValidaStrings<T>(T objeto)
        {
            //se obtienes los valores de la clave primaria
            foreach (PropertyInfo pi in objeto.GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public))
            {
                //verificando si es requerido

                ANP_LongitudString longitud = pi.GetCustomAttribute<ANP_LongitudString>(true);

                if (longitud != null)
                {
                    if (pi.PropertyType == typeof(String))
                    {
                        object valor = pi.GetValue(objeto);
                        if (valor == null)
                            continue;
                        if (longitud.Maxima != 0)
                        {
                            if (valor.ToString().Length > longitud.Maxima)
                            {
                                throw new EX_LongitudStringInvalidaException(objeto, "La propiedad '" + pi.Name + "' debe tener una longitud máxima de '" + longitud.Maxima + "'.", pi.Name, valor.ToString(), longitud.Maxima, longitud.Minima);
                            }

                        }
                        if (longitud.Minima != 0)
                        {
                            if (valor.ToString().Length < longitud.Minima)
                            {
                                throw new EX_LongitudStringInvalidaException(objeto, "La propiedad '" + pi.Name + "' debe tener una longitud mínima de '" + longitud.Minima + "'.", pi.Name, valor.ToString(), longitud.Maxima, longitud.Minima);
                            }
                        }
                    }
                    else
                    {
                        throw new EX_ErrorConfiguracionClaseException(objeto, "La propiedad '" + pi.Name + "' no debe utilizar la anotación 'ANP_LongitudString' ya que no es de tipo String.", pi.Name, "ANP_LongitudString");
                    }
                }
            }
        }
        public static void ValidaPrecisionNumerica<T>(T objeto)
        {
            //se obtienes los valores de la clave primaria
            foreach (PropertyInfo pi in objeto.GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public))
            {
                //verificando si es requerido

                ANP_PrecisionNumerica precision = pi.GetCustomAttribute<ANP_PrecisionNumerica>(true);

                if (precision != null)
                {
                    if (
                        pi.PropertyType == typeof(Double) || pi.PropertyType == typeof(Double?) ||
                        pi.PropertyType == typeof(Decimal) || pi.PropertyType == typeof(Decimal?) ||
                        pi.PropertyType == typeof(Int16) || pi.PropertyType == typeof(Int16?) ||
                        pi.PropertyType == typeof(Int32) || pi.PropertyType == typeof(Int32?) || 
                        pi.PropertyType == typeof(Int64) || pi.PropertyType == typeof(Int64?))
                    {
                        object valor = pi.GetValue(objeto);
                        if (valor == null)
                            continue;

                        //validando numeros enteros
                        if (pi.PropertyType == typeof(Int16) || pi.PropertyType == typeof(Int16?) ||
                        pi.PropertyType == typeof(Int32) || pi.PropertyType == typeof(Int32?) ||
                        pi.PropertyType == typeof(Int64) || pi.PropertyType == typeof(Int64?))
                        {
                            if (precision.Enteros != 0 && valor.ToString().Length > precision.Enteros)
                            {
                                throw new EX_PrecisionNumericaException(objeto, "La propiedad '" + pi.Name + "' debe tener máximo '" + precision.Enteros + "' decimales.", pi.Name, valor.ToString(), precision.Enteros, precision.Decimales, precision.NumeroMaximo, precision.NumeroMinimo);
                            }
                            if ((precision.NumeroMaximo != 0 && Convert.ToInt64(valor) > precision.NumeroMaximo) || (precision.NumeroMinimo != 0 && Convert.ToInt64(valor) < precision.NumeroMinimo))
                            {
                                throw new EX_PrecisionNumericaException(objeto, "La propiedad '" + pi.Name + "' está fuera de rango debe estar desde '" + precision.NumeroMinimo + "' hasta '" + precision.NumeroMaximo + "'.", pi.Name, valor.ToString(), precision.Enteros, precision.Decimales, precision.NumeroMaximo, precision.NumeroMinimo);
                            }
                        }
                        //validando numeros decimales
                        if (pi.PropertyType == typeof(Double) || pi.PropertyType == typeof(Double?) ||
                        pi.PropertyType == typeof(Decimal) || pi.PropertyType == typeof(Decimal?))
                        {
                            //si tiene punto se validan los decimales, en caso contraro, solo se valida como un entero
                            if(valor.ToString().Contains("."))
                            {
                                int enteros = valor.ToString().Split('.')[0].Length;
                                int decimales = valor.ToString().Split('.')[1].Length;

                                double valorDecimal = Convert.ToDouble(valor);

                                if (precision.Enteros != 0 && enteros > precision.Enteros)
                                {
                                    throw new EX_PrecisionNumericaException(objeto, "La propiedad '" + pi.Name + "' debe tener máximo '" + precision.Enteros + "' enteros.", pi.Name, valor.ToString(), precision.Enteros, precision.Decimales, precision.NumeroMaximo, precision.NumeroMinimo);
                                }
                                if (precision.Decimales != 0 && decimales > precision.Decimales)
                                {
                                    throw new EX_PrecisionNumericaException(objeto, "La propiedad '" + pi.Name + "' debe tener máximo '" + precision.Decimales + "' decimales.", pi.Name, valor.ToString(), precision.Enteros, precision.Decimales, precision.NumeroMaximo, precision.NumeroMinimo);
                                }
                                if ((precision.NumeroMaximo != 0 && valorDecimal > precision.NumeroMaximo ) || (precision.NumeroMinimo != 0 && valorDecimal < precision.NumeroMinimo))
                                {
                                    throw new EX_PrecisionNumericaException(objeto, "La propiedad '" + pi.Name + "' está fuera de rango debe estar desde '" + precision.NumeroMinimo + "' hasta '" + precision.NumeroMaximo + "'.", pi.Name, valor.ToString(), precision.Enteros, precision.Decimales, precision.NumeroMaximo, precision.NumeroMinimo);
                                }
                            }
                            else
                            {
                                if (precision.Enteros != 0 && valor.ToString().Length > precision.Enteros)
                                {
                                    throw new EX_PrecisionNumericaException(objeto, "La propiedad '" + pi.Name + "' debe tener máximo '" + precision.Enteros + "' decimales.", pi.Name, valor.ToString(), precision.Enteros, precision.Decimales, precision.NumeroMaximo, precision.NumeroMinimo);
                                }
                                if ((precision.NumeroMaximo != 0 && Convert.ToInt64(valor) > precision.NumeroMaximo) || (precision.NumeroMinimo != 0 && Convert.ToInt64(valor) < precision.NumeroMinimo))
                                {
                                    throw new EX_PrecisionNumericaException(objeto, "La propiedad '" + pi.Name + "' está fuera de rango debe estar desde '" + precision.NumeroMinimo + "' hasta '" + precision.NumeroMaximo + "'.", pi.Name, valor.ToString(), precision.Enteros, precision.Decimales, precision.NumeroMaximo, precision.NumeroMinimo);
                                }
                            }
                        }
                    }
                    else
                    {
                        throw new EX_ErrorConfiguracionClaseException(objeto, "La propiedad '" + pi.Name + "' no debe utilizar la anotación 'ANP_PrecisionNumerica' ya que no es de tipo Númerico.", pi.Name, "ANP_PrecisionNumerica");
                    }
                }
            }
        }
    }
}
