using Herramientas.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio.Sistema
{
    public class _sis_RolUsuario:ObjetoBase
    {
        private String _st_nombreRol;
        private Boolean _bo_esAdmin;
        private List<_sis_ModuloSistemaPermiso> _ll_modulosAcceso;

        public List<_sis_ModuloSistemaPermiso> Ll_modulosAcceso
        {
            get { return GetListaRelacionados<_sis_ModuloSistemaPermiso>("_ll_modulosAcceso"); }
            set { SetAtributoRelacionado("_ll_modulosAcceso", value); }
        }
    }
}
