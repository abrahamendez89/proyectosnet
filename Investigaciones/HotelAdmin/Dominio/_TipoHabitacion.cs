using Herramientas.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Dominio
{
    public class _TipoHabitacion : ObjetoBase
    {
        private String _st_nombre;
        private String _st_descripcion;
        private double _do_precioPorNoche;
        private List<_Imagen> _ll_imagenesMuestra;
        private int _in_cantidadHuespedes;

        public String St_nombre
        {
            get { return _st_nombre; }
            set { _st_nombre = value; }
        }
        
        public String St_descripcion
        {
            get { return _st_descripcion; }
            set { _st_descripcion = value; }
        }
        
        public double Do_precioPorNoche
        {
            get { return _do_precioPorNoche; }
            set { _do_precioPorNoche = value; }
        }
        
        public List<_Imagen> Ll_imagenesMuestra
        {
            get { return GetListaRelacionados<_Imagen>("_ll_imagenesMuestra"); }
            set { SetListaRelacionados("_ll_imagenesMuestra", value); }
        }
        
        public int In_cantidadHuespedes
        {
            get { return _in_cantidadHuespedes; }
            set { _in_cantidadHuespedes = value; }
        }
    }
}
