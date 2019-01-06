using Herramientas.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio.Sistema
{
    public class _sis_Usuario:ObjetoBase
    {
        private String _st_usuario;
        private String _st_contrasena;
        private _sis_RolUsuario _oo_rol;

        public String St_usuario
        {
            get { return _st_usuario; }
            set { _st_usuario = value; }
        }
        
        public String St_contrasena
        {
            get { return _st_contrasena; }
            set { _st_contrasena = value; }
        }
        
        public _sis_RolUsuario Oo_rol
        {
            get { return GetAtributoRelacionado<_sis_RolUsuario>("_oo_rol"); }
            set { SetAtributoRelacionado("_oo_rol",value); }
        }
    }
}
