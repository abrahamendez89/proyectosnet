using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio;

namespace Dominio.Sistema
{
    public class _sis_SesionGuardada:ObjetoBase
    {
        private Object _Sesion;

        public Object Sesion
        {
            get { return _Sesion; }
            set { _Sesion = value; }
        }
        
    }
}
