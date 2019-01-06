using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterfazWEB.Clases
{
    public class ResultadoPeticion
    {
        private String _Codigo;
        private String _Descripcion;
        private Object _datos;
        private Boolean _FueError;

        public String Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }
        
        public String Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }
        
        public Object Datos
        {
            get { return _datos; }
            set { _datos = value; }
        }
        
        public Boolean FueError
        {
            get { return _FueError; }
            set { _FueError = value; }
        }
    }
}
