using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ACCESO_DATOS.Anotaciones.Clase;
using ACCESO_DATOS.Anotaciones.Propiedad;
using ACCESO_DATOS.SuperClase;

namespace ACCESO_DATOS.Control
{
    public class Estructura
    {
        public static String ObtenNombreTabla<T>() where T : CLASE_BASE
        {
            String nombreTabla = "";
            //se obtienes los valores de la clave primaria
            object[] strLenAttr2 = typeof(T).GetCustomAttributes(true);
            foreach (object atributo in strLenAttr2)
            {
                if (atributo is ANC_Tabla)
                {
                    nombreTabla = (atributo as ANC_Tabla).Nombre;
                    break;
                }
            }
            return nombreTabla;
        }
        public static String ObtenConsecutivo<T>(String idFormadoParcial) where T : CLASE_BASE
        {
            ANC_Tabla nombreTabla = typeof(T).GetCustomAttribute<ANC_Tabla>(true);
            ANC_IDFormado campoId = typeof(T).GetCustomAttribute<ANC_IDFormado>(true);
            String str = "SELECT MAX(REPLACE('"+campoId.Columna+"','" + idFormadoParcial + "'))+1 FROM "+ nombreTabla.Nombre + " WHERE "+ campoId.Columna + " LIKE '"+ idFormadoParcial + "%'";
            return str;
        }
        public static Boolean ContienePropiedadesByteArray<T>() where T : CLASE_BASE
        {
            foreach(PropertyInfo pi in typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.Public))
            {
                if(pi.PropertyType == typeof(Byte[]))
                {
                    return true;
                }
            }
            return false;
        }
        public static Dictionary<String, Object> ObtenerDiccionarioPropiedadesByteArray<T>(T obj) where T : CLASE_BASE
        {
            Dictionary<String, Object> diccionario = new Dictionary<string, Object>();
            foreach (PropertyInfo pi in typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.Public))
            {
                if (pi.PropertyType == typeof(Byte[]))
                {
                    if(pi.GetValue(obj) != null)
                    {
                        diccionario.Add(pi.Name, (Byte[])pi.GetValue(obj));
                    }
                    else
                    {
                        diccionario.Add(pi.Name, null);
                    }
                }
            }
            return diccionario;
        }
        public static String ObtenConsecutivo<T>() where T : CLASE_BASE
        {
            ANC_Tabla nombreTabla = typeof(T).GetCustomAttribute<ANC_Tabla>(true);
            ANC_IDFormado campoId = typeof(T).GetCustomAttribute<ANC_IDFormado>(true);
            String str = "SELECT MAX("+ campoId.Columna + ")+1 FROM "+ nombreTabla.Nombre;
            return str;
        }
        public static String ObtenCondicionBusquedaWhere<T>(T objeto) where T : CLASE_BASE
        {
            //obtenemos la información de la tabla
            ANC_Tabla nombreTabla = objeto.GetType().GetCustomAttribute<ANC_Tabla>(true);
            String tableName = nombreTabla.Nombre;
            //se identifican las columnas y sus valores de insercion
            Dictionary<String, String> columnasValores = new Dictionary<String, String>();

            foreach (PropertyInfo pi in objeto.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                String nombrePropiedad = pi.Name;
                String columnaNombre = "";

                object[] strLenAttr = pi.GetCustomAttributes(true);

                foreach (object atributo in strLenAttr)
                {
                    if (atributo is ANP_Columna)
                    {
                        columnaNombre = (atributo as ANP_Columna).Columna;
                    }
                }
                //si no tiene nombre de columna, se ignora
                if (string.IsNullOrEmpty(columnaNombre))
                    continue;
                if (pi.GetValue(objeto) == null)
                {
                    //se deja null en el valor
                    columnasValores.Add(columnaNombre, "NULL");
                    continue;
                }

                if (pi.PropertyType == typeof(Int16) ||
                    pi.PropertyType == typeof(Int32) ||
                    pi.PropertyType == typeof(Int64) ||
                    pi.PropertyType == typeof(Decimal) ||
                    pi.PropertyType == typeof(Double) ||
                    pi.PropertyType == typeof(Int16?) ||
                    pi.PropertyType == typeof(Int32?) ||
                    pi.PropertyType == typeof(Int64?) ||
                    pi.PropertyType == typeof(Decimal?) ||
                    pi.PropertyType == typeof(Double?))
                {
                    String valor = pi.GetValue(objeto).ToString();
                    columnasValores.Add(columnaNombre, valor);
                }
                else if (pi.PropertyType == typeof(String))
                {
                    String valor = pi.GetValue(objeto).ToString();
                    columnasValores.Add(columnaNombre, "'" + valor + "'");
                }
                else if (pi.PropertyType == typeof(DateTime) || pi.PropertyType == typeof(DateTime?))
                {
                    String valor = ((DateTime)pi.GetValue(objeto)).ToString("yyyy/MM/dd HH:mm:ss", CultureInfo.InvariantCulture);
                    columnasValores.Add(columnaNombre, "TO_DATE('" + valor + "', 'yyyy/mm/dd hh24:mi:ss')");
                }
            }
            //se obtiene los valores de la clave primaria
            object[] strLenAttr2 = objeto.GetType().GetCustomAttributes(true);
            List<String> columnasPK = new List<string>();
            foreach (object atributo in strLenAttr2)
            {
                if (atributo is ANC_Identificador)
                {
                    columnasPK.Add((atributo as ANC_Identificador).Columna);
                }
            }
            //se crea el where
            String queryUpdate = "@condiciones";
            String condiciones = "";
            foreach (String columna in columnasPK)
            {
                condiciones += columna + " = " + columnasValores[columna] + " AND ";
            }
            
            condiciones = condiciones.Substring(0, condiciones.Length - 5);
            queryUpdate = queryUpdate.Replace("@condiciones", condiciones);

            return queryUpdate;
        }
        public static List<String> ObtenerListaParametros(String consulta)
        {
            List<String> parametros = new List<string>();

            char[] letras = consulta.ToCharArray();
            String temporal = "";
            Boolean entro = false;
            for (int i = 0; i < letras.Length; i++)
            {
                if ((letras[i] == ' ' || letras[i] == ',' || letras[i] == ';' || letras[i] == ')' || letras[i] == '\n' || letras[i] == '\r' || letras[i] == '\t' || letras[i] == '%' || letras[i] == '\'') && entro)
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
                if (letras[i] == ':')
                {
                    if (!string.IsNullOrEmpty(temporal))
                    {
                        parametros.Add(temporal);
                        temporal = "";
                        entro = false;
                    }

                    if (letras[i - 1] == '%')
                        temporal += "%" + ':';
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

            List<string> parametrosReservados = new List<string>
            {
                "AD", "A.D.", "AM", "A.M.","BC","B.C.",
                "CC", "SCC", "D", "DAY","DD","DDD",
                "DL", "DS", "DY", "E","EE","FF",
                "FM", "FX", "HH", "HH12","HH24","IW",
                "FM", "FX", "HH", "HH12","HH24","IW",
                "IYY", "IY", "I", "IYYY","J","MI",
                "MM", "MON", "MONTH", "PM","P.M.","Q",
                "RM", "RR", "RRRR", "S", "SS","SSSSS","TS",
                "TZD", "TZH", "TZM", "TZR","WW","W",
                "X", "Y,YYY", "YEAR", "SYEAR","YYYY","SYYYY",
                "YYY", "YY", "Y", "00", "mi", "ss"
            };

            parametros.RemoveAll(p => parametrosReservados.Contains(p));

            return parametros;
        }

        public static string ConvertirParametrosParaQuery(string query, Dictionary<String, Object> parametros)
        {
            String queryConversion = query;
            foreach (String parametro in parametros.Keys)
            {
                String nombreParametro = ":" + parametro;
                Object valor = parametros[parametro];
                if (valor == null)
                {
                    queryConversion = queryConversion.Replace(nombreParametro, "'NULL'");
                }
                else if (valor is DateTime)
                {
                    queryConversion = queryConversion.Replace(nombreParametro, UtileriaAD.CnvDateToString((DateTime)valor));
                }
                else if (valor is DateTime?)
                {
                    queryConversion = queryConversion.Replace(nombreParametro, UtileriaAD.CnvDateToString(((DateTime?)valor).Value));
                }
                else if (valor is Boolean)
                {
                    queryConversion = queryConversion.Replace(nombreParametro, UtileriaAD.CnvBoolToString((Boolean)valor));
                }
            }

            return queryConversion;

        }
    }
}
