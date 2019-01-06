using Herramientas.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class _PersonalSoporte:ObjetoBase
    {
        private String _Nombre;
        private String _Email;
        
        public String Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }
        public String Email
        {
            get { return _Email; }
            set { _Email = value; }
        }
    }
}
