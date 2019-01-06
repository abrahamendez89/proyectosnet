using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Herramientas.ORM;

namespace DominioLicencias
{
    public class _EmpresaCliente: ObjetoBase
    {
        private String _st_NombreEmpresa;
        private String _st_Direccion;
        private String _st_telefono;
        private String _st_NombreRepresentante;
        private String _st_EmailRepresentante;
        private String _st_TelefonoRepresentante;
        private List<_Licencia> _ll_LicenciasCompradas;

        public List<_Licencia> Ll_LicenciasCompradas
        {
            get { return GetListaRelacionados<_Licencia>("_ll_LicenciasCompradas"); }
            set { SetListaRelacionados("_ll_LicenciasCompradas",value); }
        }

        public String St_NombreEmpresa
        {
            get { return _st_NombreEmpresa; }
            set { _st_NombreEmpresa = value; }
        }
        
        public String St_Direccion
        {
            get { return _st_Direccion; }
            set { _st_Direccion = value; }
        }
        
        public String St_telefono
        {
            get { return _st_telefono; }
            set { _st_telefono = value; }
        }
        
        public String St_NombreRepresentante
        {
            get { return _st_NombreRepresentante; }
            set { _st_NombreRepresentante = value; }
        }
        
        public String St_EmailRepresentante
        {
            get { return _st_EmailRepresentante; }
            set { _st_EmailRepresentante = value; }
        }
        
        public String St_TelefonoRepresentante
        {
            get { return _st_TelefonoRepresentante; }
            set { _st_TelefonoRepresentante = value; }
        }
    }
}
