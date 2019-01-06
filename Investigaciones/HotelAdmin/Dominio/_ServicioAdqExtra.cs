using Herramientas.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class _ServicioAdqExtra:ObjetoBase
    {
        private String _st_nombreServicio;
        private double _do_costo;

        public String St_nombreServicio
        {
            get { return _st_nombreServicio; }
            set { _st_nombreServicio = value; }
        }
        
        public double Do_costo
        {
            get { return _do_costo; }
            set { _do_costo = value; }
        }
    }
}
