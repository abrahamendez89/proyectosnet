using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ACCESO_DATOS.Anotaciones.Clase;
using ACCESO_DATOS.Conexiones;
using ACCESO_DATOS.Excepciones;
using ACCESO_DATOS.SuperClase;

namespace ACCESO_DATOS.Control
{
    public class Concurrencia
    {
        public static void ValidaVersionConcurrencia<T>(T obj, IClienteBD cliente) where T : CLASE_BASE
        {
            String queryConsulta = "";
            //obteniendo el nombre de la tabla
            ANC_Tabla nombreTabla = obj.GetType().GetCustomAttribute<ANC_Tabla>(true);
            //buscando el campo ultima_act
            PropertyInfo pi = typeof(T).GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public).ToList().Where(y => y.GetCustomAttribute<ANP_CampoVersionamiento>() != null).FirstOrDefault();

            if (pi != null)
            {
                //significa que la tabla cuenta con campo de versionado
                ANP_CampoVersionamiento cv = pi.GetCustomAttribute<ANP_CampoVersionamiento>();
                String condicionBusqueda = Estructura.ObtenCondicionBusquedaWhere<T>(obj);
                queryConsulta = "SELECT " + pi.Name + " FROM " + nombreTabla.Nombre + " WHERE " + condicionBusqueda;

                DataTable dt = cliente.EjecutarSelect(queryConsulta);

                if (dt.Rows.Count > 0)
                {
                    Int64 valorBDVersion = Convert.ToInt64(dt.Rows[0][0]);

                    Int64 valorActualVersion = Convert.ToInt64(pi.GetValue(obj));

                    if(valorBDVersion >= valorActualVersion)
                    {
                        throw new EX_ErrorConcurrencia(obj, "El registro fue actualizado desde otra ubicación.", pi.Name, valorActualVersion, valorBDVersion);
                    }
                }
            }
        }
    }
}
