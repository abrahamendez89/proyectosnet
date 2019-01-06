using Herramientas.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prueba2.Models
{
    public class _Usuario // solo para descartar
    {
        private String _usuario;
        private String _contra;


        public String Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }
        public String Contra
        {
            get { return _contra; }
            set { _contra = value; }
        }
    }
}