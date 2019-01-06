using Herramientas.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class _Equipo : ObjetoBase
    {
        private String _st_NombreEquipoDescripcion;
        private String _st_IPONombreEquipo;
        private String _st_Descripcion;
        private String _st_contraVNC;

        public String St_contraVNC
        {
            get { return _st_contraVNC; }
            set { _st_contraVNC = value; }
        }

        public String St_NombreEquipoDescripcion
        {
            get { return _st_NombreEquipoDescripcion; }
            set { _st_NombreEquipoDescripcion = value; }
        }
       
        public String St_IPONombreEquipo
        {
            get { return _st_IPONombreEquipo; }
            set { _st_IPONombreEquipo = value; }
        }
        
        public String St_Descripcion
        {
            get { return _st_Descripcion; }
            set { _st_Descripcion = value; }
        }
    }
}
