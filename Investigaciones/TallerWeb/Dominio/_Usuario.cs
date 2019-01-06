using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class _Usuario
    {
        private String _st_Usuario;
        private String _st_Password;

        public String St_Usuario
        {
            get { return _st_Usuario; }
            set { _st_Usuario = value; }
        }
        
        public String St_Password
        {
            get { return _st_Password; }
            set { _st_Password = value; }
        }
    }
}
