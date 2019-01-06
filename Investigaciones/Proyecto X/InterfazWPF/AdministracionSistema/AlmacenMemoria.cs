using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterfazWPF.AdministracionSistema
{
    public class AlmacenMemoria
    {
        private static Dictionary<String, Object> almacen = new Dictionary<string, object>();


        public static void Guardar(String identificador, Object objeto)
        {
            if (almacen.ContainsKey(identificador))
            {
                almacen[identificador] = objeto;
            }
            else   
            {
                almacen.Add(identificador, objeto);
            }
        }
        public static T Obtener<T>(String identificador)
        {
            if (almacen.ContainsKey(identificador))
            {
                return (T)almacen[identificador];
            }
            else
            {
                return default(T);
            }
        }
        public static void Borrar()
        {
            almacen.Clear();
        }
        public static void Borrar(String identificador)
        {
            almacen.Remove(identificador);
        }
    }
}
