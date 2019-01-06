using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Herramientas.ORM;

namespace Dominio
{
    public class _CuentaEmpresa:ObjetoBase
    {
        private String _Usuario;
        private String _Contrasena;
        private String _NombreEmpresa;

        public String Usuario
        {
            get { return _Usuario; }
            set { _Usuario = value; }
        }
        
        public String Contrasena
        {
            get { return _Contrasena; }
            set { _Contrasena = value; }
        }

       

        public String NombreEmpresa
        {
            get { return _NombreEmpresa; }
            set { _NombreEmpresa = value; }
        }
    }
}
