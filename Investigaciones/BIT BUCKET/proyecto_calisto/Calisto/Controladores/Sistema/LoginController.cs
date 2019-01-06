using Dominio.Sistema;
using Herramientas.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controladores.Sistema
{
    public class LoginController
    {
        ManejadorDB manejador;
        public LoginController()
        {
            manejador = FabricaManejadorDB.ObtenerManejadorDB(false);
        }
        public Boolean Iniciar(String usuario, String contrasena)
        {
            _sis_Usuario user = manejador.Cargar<_sis_Usuario>("select * from _sis_Usuario where _st_usuario = @_st_usuario and _st_contrasena = @_st_contrasena", new List<object>() { usuario, contrasena });

            if (user != null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
