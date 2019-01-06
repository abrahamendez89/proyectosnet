using Herramientas.ORM;
using Herramientas.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controladores.Sistema
{
    public class FabricaManejadorDB
    {
        private static ManejadorDB InstanciaManejadorSingleton;
        
        public static ManejadorDB ObtenerManejadorDB(Boolean nuevaInstancia)
        {
            ManejadorDB manejador;
            Boolean nueva = false;
            if (!nuevaInstancia)
            {
                if (InstanciaManejadorSingleton == null)
                {
                    nueva = true;
                }
            }
            else
            {
                nueva = true;
            }
            if (nueva)
            {
                //creando instancia iSQL y configurando base de datos
                iSQL sql = new SQLite();
                sql.ConfigurarConexion("calisto.db", false);
                //creando instancia de manejador y asignando la instancia de iSQL
                manejador = new ManejadorDB(sql);
                if (!nuevaInstancia)
                {
                    //es una instancia singleton, por lo que se asigna nuestra instancia.
                    InstanciaManejadorSingleton = manejador;
                }
            }
            else
            {
                //asignando la instancia singleton
                manejador = InstanciaManejadorSingleton;
            }

            //retornando manejador
            return manejador;
        }
    }
}
