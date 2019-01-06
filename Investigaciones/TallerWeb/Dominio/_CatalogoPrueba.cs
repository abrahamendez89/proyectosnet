using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class _CatalogoPrueba
    {
        private String _Nombre;
        private int _Edad;

        public String Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }
       

        public int Edad
        {
            get { return _Edad; }
            set { _Edad = value; }
        }
    }
}
