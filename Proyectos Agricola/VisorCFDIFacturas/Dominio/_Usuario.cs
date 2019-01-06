using Herramientas.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class _Usuario: ObjetoBase
    {
        private String _Cuenta;
        private String _Contrasena;
        private Boolean _PrimeraVezLogin;
        private String _NombreCompleto;

        public String Cuenta
        {
            get { return _Cuenta; }
            set { _Cuenta = value; }
        }
        
        public String Contrasena
        {
            get { return _Contrasena; }
            set { _Contrasena = value; }
        }
        
        public Boolean PrimeraVezLogin
        {
            get { return _PrimeraVezLogin; }
            set { _PrimeraVezLogin = value; }
        }
        
        public String NombreCompleto
        {
            get { return _NombreCompleto; }
            set { _NombreCompleto = value; }
        }
    }
}
