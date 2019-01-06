using Dominio;
using Herramientas.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controladores
{
    public class UsuarioCtrl
    {
        ManejadorDB manejador;
        public UsuarioCtrl(ManejadorDB manejador)
        {
            this.manejador = manejador;
        }
        public _Usuario LoginUsuario(String usuario, String contra)
        {
            _Usuario user = manejador.Cargar<_Usuario>("select * from _Usuario where _st_usuario = @_st_usuario and _st_contrasena = @_st_contrasena", new List<object>() { usuario, contra });
            return user;
        }
    }
}
