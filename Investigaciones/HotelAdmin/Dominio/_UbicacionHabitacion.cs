using Herramientas.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class _UbicacionHabitacion:ObjetoBase
    {
        private String _st_ubicacion;
        private String _st_descripcion;

        public String St_ubicacion
        {
            get { return _st_ubicacion; }
            set { _st_ubicacion = value; }
        }
        
        public String St_descripcion
        {
            get { return _st_descripcion; }
            set { _st_descripcion = value; }
        }
    }
}
