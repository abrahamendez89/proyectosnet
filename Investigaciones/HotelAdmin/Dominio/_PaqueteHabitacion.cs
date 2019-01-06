using Herramientas.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class _PaqueteHabitacion: ObjetoBase
    {
        private String _st_nombrePaquete;
        private double _do_costoPorPersona;
        private double _do_costoPorHabitacion;
        private String _st_descripcion;

        public String St_descripcion
        {
            get { return _st_descripcion; }
            set { _st_descripcion = value; }
        }

        public String St_nombrePaquete
        {
            get { return _st_nombrePaquete; }
            set { _st_nombrePaquete = value; }
        }
        
        public double Do_costoPorPersona
        {
            get { return _do_costoPorPersona; }
            set { _do_costoPorPersona = value; }
        }
        
        public double Do_costoPorHabitacion
        {
            get { return _do_costoPorHabitacion; }
            set { _do_costoPorHabitacion = value; }
        }
    }
}
