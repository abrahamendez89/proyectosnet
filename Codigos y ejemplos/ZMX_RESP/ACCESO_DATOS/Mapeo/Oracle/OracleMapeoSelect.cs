using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ACCESO_DATOS.Anotaciones.Clase;
using ACCESO_DATOS.Anotaciones.Propiedad;
using ACCESO_DATOS.Control;
using ACCESO_DATOS.Mapeo.Interfaces;
using ACCESO_DATOS.SuperClase;

namespace ACCESO_DATOS.Mapeo.Oracle
{
    public class OracleMapeoSelect : IMapeoSelect
    {
        public T ConvertirAObjeto<T>(DataRow dr) where T : CLASE_BASE
        {
            T obj = (T)Activator.CreateInstance(typeof(T));

            foreach (PropertyInfo pi in obj.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public))
            {
                //obtenemos el nombre de la columna
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
                //buscamos ese valor en el dt de retorno
                object valor = null;
                try
                {
                    valor = dr[columnaNombre];
                }
                catch (Exception ex)
                {
                    throw new Exception("La columna '" + columnaNombre + "' especificada en la propiedad '" + nombrePropiedad + "', no se encontró en la consulta, verificar.");
                }
                //identificamos el tipo de la propiedad y lo asignamos.
                if(valor == DBNull.Value)
                {
                    // se hace null el valor de la propiedad de dicha columna

                    pi.SetValue(obj, null);

                    continue;
                }
                if (valor != null)
                {
                    if (pi.PropertyType == typeof(String))
                    {
                        pi.SetValue(obj, valor.ToString());
                    }
                    else if (pi.PropertyType == typeof(Int16) || pi.PropertyType == typeof(Int16?))
                    {
                        pi.SetValue(obj, Convert.ToInt16(valor.ToString()));
                    }
                    else if (pi.PropertyType == typeof(Int32) || pi.PropertyType == typeof(Int32?))
                    {
                        pi.SetValue(obj, Convert.ToInt32(valor.ToString()));
                    }
                    else if (pi.PropertyType == typeof(Int64) || pi.PropertyType == typeof(Int64?))
                    {
                        pi.SetValue(obj, Convert.ToInt64(valor.ToString()));
                    }
                    else if (pi.PropertyType == typeof(Decimal) || pi.PropertyType == typeof(Decimal?))
                    {
                        pi.SetValue(obj, Convert.ToDecimal(valor.ToString()));
                    }
                    else if (pi.PropertyType == typeof(Double) || pi.PropertyType == typeof(Double?))
                    {
                        pi.SetValue(obj, Convert.ToDouble(valor.ToString()));
                    }
                    else if (pi.PropertyType == typeof(DateTime))
                    {
                        pi.SetValue(obj, Convert.ToDateTime(valor.ToString()));
                    }
                    else if (pi.PropertyType == typeof(DateTime?))
                    {
                        pi.SetValue(obj, Convert.ToDateTime(valor.ToString()));
                    }
                    else if (pi.PropertyType == typeof(Boolean) || pi.PropertyType == typeof(Boolean?))
                    {
                        Boolean valorBoolean = valor.ToString().Equals("1");
                        pi.SetValue(obj, valorBoolean);
                    }
                    else if (pi.PropertyType == typeof(Byte[]))
                    {
                        Byte[] valorByteArray = UtileriaAD.CnvObjectToByteArray(valor);
                        pi.SetValue(obj, valorByteArray);
                    }
                }
            }
            return obj;
        }
        public List<T> ConvertirAListaObjeto<T>(DataTable dt) where T : CLASE_BASE
        {
            //creando la lista generica
            var genericListType = typeof(List<>).MakeGenericType(new[] { typeof(T) });
            List<T> lista = (List<T>)Activator.CreateInstance(genericListType);

            foreach(DataRow dr in dt.Rows)
            {
                lista.Add(ConvertirAObjeto<T>(dr));
            }
            return lista;
        }

        public String ObtenerQueryConsultaPorIdentificador<T>(T objeto) where T : CLASE_BASE
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
            //se crea el query para el select
            String queryUpdate = "SELECT * FROM " + tableName + " WHERE @condiciones";
            String condiciones = "";
            //se añade el where
            foreach (String columna in columnasPK)
            {
                condiciones += columna + " = " + columnasValores[columna] + " AND ";
            }
            
            condiciones = condiciones.Substring(0, condiciones.Length - 5);
            queryUpdate = queryUpdate.Replace("@condiciones", condiciones);

            return queryUpdate;
        }

        
    }
}
