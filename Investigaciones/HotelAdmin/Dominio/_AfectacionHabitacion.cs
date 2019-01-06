using Herramientas.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class _AfectacionHabitacion: ObjetoBase
    {
        private String _st_Nombre;
        private double _do_costoAproximado;
        public String St_Nombre
        {
            get { return _st_Nombre; }
            set { _st_Nombre = value; }
        }
        public double Do_costoAproximado
        {
            get { return _do_costoAproximado; }
            set { _do_costoAproximado = value; }
        }
    }
}
