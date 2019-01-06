using Herramientas.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class _TipoManttoHabitacion :ObjetoBase
    {
        private String _st_nombre;
        
        public String St_nombre
        {
            get { return _st_nombre; }
            set { _st_nombre = value; }
        }

    }
}
