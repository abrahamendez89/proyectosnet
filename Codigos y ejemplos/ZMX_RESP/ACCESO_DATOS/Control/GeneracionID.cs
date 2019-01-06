using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ACCESO_DATOS.Anotaciones.Clase;

namespace ACCESO_DATOS.Control
{
    public class GeneracionID
    {
        public static String CrearIDFormadoParcial<T>(T obj)
        {
            //obtenemos el nombre de la columna que tiene el ID Formado
            ANC_IDFormado nombreTabla = obj.GetType().GetCustomAttribute<ANC_IDFormado>(true);
            String id = "";
            if (nombreTabla == null)
            {
                return "";
                //throw new Exception("La entidad de tipo '" + obj.GetType().Name + "' no tiene definida una columna ID con la anotación 'ANC_IDFormado'.");
            }
            List<ANC_IDFormadoParte> atributosIdFormado = obj.GetType().GetCustomAttributes<ANC_IDFormadoParte>(true).ToList().OrderBy(x=> x.Orden).ToList();

            if(atributosIdFormado == null || atributosIdFormado.Count == 0)
            {
                //solo es un consecutivo, y se acumula


            }
            else
            {
                //se forma de acuerdo a las partes consultadas
               
                foreach(ANC_IDFormadoParte atributo in atributosIdFormado)
                {
                    if (atributo.Propiedad != null)
                    {
                        object valor = obj.GetType().GetProperty(atributo.Propiedad, BindingFlags.Instance | BindingFlags.Public).GetValue(obj);

                        if (valor == null)
                        {
                            throw new Exception("La propiedad '" + atributo.Propiedad + "' es parte del ID, debe ser diferente de null.");
                        }

                        Int64 valorInt64 = Convert.ToInt64(valor);
                        String formato = CrearFormatoToString(atributo.Digitos);

                        id += valorInt64.ToString(formato);
                    }                  

                }
            }
            return id;
        }
        public static String CrearFormatoToString(int digitos)
        {
            String formato = "";
            for(int i = 0; i < digitos; i++)
            {
                formato += "0";
            }
            return formato;
        }
    }
}
