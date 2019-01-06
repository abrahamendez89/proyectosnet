using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Herramientas.ORM;

namespace DominioLicencias
{
    public class _PaqueteComprar:ObjetoBase
    {
        private String _st_IdentificadorPaquete;
        private String _st_NombrePaquete;
        private int _in_MesesDuracion;

        public int In_MesesDuracion
        {
            get { return _in_MesesDuracion; }
            set { _in_MesesDuracion = value; }
        }

        public String St_IdentificadorPaquete
        {
            get { return _st_IdentificadorPaquete; }
            set { _st_IdentificadorPaquete = value; }
        }
        
        public String St_NombrePaquete
        {
            get { return _st_NombrePaquete; }
            set { _st_NombrePaquete = value; }
        }
    }
}
