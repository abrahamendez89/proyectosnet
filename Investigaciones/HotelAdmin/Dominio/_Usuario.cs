using Herramientas.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class _Usuario:ObjetoBase
    {
        private String _st_usuario;
        private String _st_contrasena;
        private String _st_email;
        private Boolean _bo_esAdmin;
        private String _st_permisosModulos;
        private List<_ModuloAcceso> _ll_modulos;

        public List<_ModuloAcceso> Ll_modulos
        {
            get { return GetListaRelacionados<_ModuloAcceso>("_ll_modulos"); }
            set { SetListaRelacionados("_ll_modulos", value); }
        }
       

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
        
        public String St_email
        {
            get { return _st_email; }
            set { _st_email = value; }
        }
       
        public Boolean Bo_esAdmin
        {
            get { return _bo_esAdmin; }
            set { _bo_esAdmin = value; }
        }
        
        public String St_permisosModulos
        {
            get { return _st_permisosModulos; }
            set { _st_permisosModulos = value; }
        }
    }
}
