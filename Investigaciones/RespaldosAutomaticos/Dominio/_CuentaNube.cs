using Herramientas.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class _CuentaNube: ObjetoBase
    {
        private String _Cuenta;
        private String _Contra;
        private String _Servicio;

        public String Cuenta
        {
            get { return _Cuenta; }
            set { _Cuenta = value; }
        }
       
        public String Contra
        {
            get { return _Contra; }
            set { _Contra = value; }
        }
        
        public String Servicio
        {
            get { return _Servicio; }
            set { _Servicio = value; }
        }
    }
}
