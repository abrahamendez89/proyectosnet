using Herramientas.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio.Sistema
{
    public class _sis_ModuloSistemaPermiso : ObjetoBase
    {
        private String _st_nombre;
        private String _st_listaFormasAcceso;

        public String St_nombre
        {
            get { return _st_nombre; }
            set { _st_nombre = value; }
        }
        
        public String St_listaFormasAcceso
        {
            get { return _st_listaFormasAcceso; }
            set { _st_listaFormasAcceso = value; }
        }
    }
}
