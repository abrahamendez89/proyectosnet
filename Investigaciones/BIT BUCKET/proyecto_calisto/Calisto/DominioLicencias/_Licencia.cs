using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Herramientas.ORM;

namespace DominioLicencias
{
    public class _Licencia:ObjetoBase
    {
        private _EmpresaCliente _oo_EmpresaContrato;
        private String _st_ModulosAcceso;
        private DateTime _dt_FechaInicio;
        private DateTime _dt_FechaFin;
        private Double _do_ImportePagado;
        private String _st_ReferenciaPago;
        private String _Comentarios;
        private _PaqueteComprar _oo_PaqueteComprado;
        private String _st_KeyGenerado;

        public String St_KeyGenerado
        {
            get { return _st_KeyGenerado; }
            set { _st_KeyGenerado = value; }
        }

        public _EmpresaCliente Oo_EmpresaContrato
        {
            get { return GetAtributoRelacionado<_EmpresaCliente>("_oo_EmpresaContrato"); }
            set { SetAtributoRelacionado("_oo_EmpresaContrato", value); }
        }
        
        public String St_ModulosAcceso
        {
            get { return _st_ModulosAcceso; }
            set { _st_ModulosAcceso = value; }
        }
        
        public DateTime Dt_FechaInicio
        {
            get { return _dt_FechaInicio; }
            set { _dt_FechaInicio = value; }
        }
        
        public DateTime Dt_FechaFin
        {
            get { return _dt_FechaFin; }
            set { _dt_FechaFin = value; }
        }
        
        public Double Do_ImportePagado
        {
            get { return _do_ImportePagado; }
            set { _do_ImportePagado = value; }
        }
        
        public String St_ReferenciaPago
        {
            get { return _st_ReferenciaPago; }
            set { _st_ReferenciaPago = value; }
        }
        
        public String Comentarios
        {
            get { return _Comentarios; }
            set { _Comentarios = value; }
        }
        
        public _PaqueteComprar Oo_PaqueteComprado
        {
            get { return GetAtributoRelacionado<_PaqueteComprar>("_oo_PaqueteComprado"); }
            set { SetAtributoRelacionado("_oo_PaqueteComprado",value); }
        }
    }
}
