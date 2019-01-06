using Herramientas.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class _ModuloAcceso: ObjetoBase
    {
        private String _st_nombreModulo;
        private String _st_formasPermisos;

        public String St_nombreModulo
        {
            get { return _st_nombreModulo; }
            set { _st_nombreModulo = value; }
        }
        
        public String St_formasPermisos
        {
            get { return _st_formasPermisos; }
            set { _st_formasPermisos = value; }
        }
    }
}
