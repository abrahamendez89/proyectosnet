using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ACCESO_DATOS.Anotaciones.Clase;
using ACCESO_DATOS.Anotaciones.Propiedad;
using ACCESO_DATOS.Mapeo.Interfaces;
using ACCESO_DATOS.SuperClase;

namespace ACCESO_DATOS.Mapeo.Oracle
{
    public class OracleMapeoUpdate:IMapeoUpdate
    {
        public String Convertir<T>(T objeto) where T : CLASE_BASE
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
                else if (pi.PropertyType == typeof(Byte[]))
                {
                    String valor = pi.GetValue(objeto).ToString();
                    columnasValores.Add(columnaNombre, ":" + pi.Name);
                }
                else if (pi.PropertyType == typeof(Boolean) || pi.PropertyType == typeof(Boolean?))
                {
                    if (Convert.ToBoolean(pi.GetValue(objeto)))
                    {
                        columnasValores.Add(columnaNombre, "1");
                    }
                    else
                    {
                        columnasValores.Add(columnaNombre, "0");
                    }
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
            //se crea el query para el insert
            String queryUpdate = "UPDATE " + tableName + " SET @columnaValor WHERE @condiciones";
            String columnaValor = "";
            String condiciones = "";
            foreach (String columna in columnasValores.Keys)
            {
                columnaValor += columna + " = " + columnasValores[columna] + ", ";
            }
            //se añade el where
            foreach (String columna in columnasPK)
            {
                condiciones += columna + " = " + columnasValores[columna] + " AND ";
            }


            columnaValor = columnaValor.Substring(0, columnaValor.Length - 2);
            condiciones = condiciones.Substring(0, condiciones.Length - 5);
            queryUpdate = queryUpdate.Replace("@columnaValor", columnaValor).Replace("@condiciones", condiciones);

            return queryUpdate;
        }
        public String Convertir<T>(List<T> lista) where T : CLASE_BASE
        {
            String queryMasivoInsert = "BEGIN @queryUpdate END;";

            String querys = "";

            foreach (T obj in lista)
            {
                querys += Convertir<T>(obj) + "; ";
            }

            queryMasivoInsert = queryMasivoInsert.Replace("@queryUpdate", querys);

            return queryMasivoInsert;
        }
    }
}
