using Herramientas.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class _HuespedCliente:ObjetoBase
    {
        private String _st_nombreTitular;
        private String _st_apPaternoTitular;
        private String _st_apMaternoTitular;
        private String _st_celularTitular;
        private String _st_nombreReferenciaTitular;
        private String _st_celularReferenciaTitular;
        private DateTime _dt_fechaNacTitular;
        private _ProcedenciaHuesped _oo_procedencia;
        private String _st_detallesVehiculo;

        public String St_nombreTitular
        {
            get { return _st_nombreTitular; }
            set { _st_nombreTitular = value; }
        }
        
        public String St_apPaternoTitular
        {
            get { return _st_apPaternoTitular; }
            set { _st_apPaternoTitular = value; }
        }
        
        public String St_apMaternoTitular
        {
            get { return _st_apMaternoTitular; }
            set { _st_apMaternoTitular = value; }
        }
        
        public String St_celularTitular
        {
            get { return _st_celularTitular; }
            set { _st_celularTitular = value; }
        }
        
        public String St_nombreReferenciaTitular
        {
            get { return _st_nombreReferenciaTitular; }
            set { _st_nombreReferenciaTitular = value; }
        }
        
        public String St_celularReferenciaTitular
        {
            get { return _st_celularReferenciaTitular; }
            set { _st_celularReferenciaTitular = value; }
        }
        
        public DateTime Dt_fechaNacTitular
        {
            get { return _dt_fechaNacTitular; }
            set { _dt_fechaNacTitular = value; }
        }
        
        public _ProcedenciaHuesped Oo_procedencia
        {
            get { return GetAtributoRelacionado<_ProcedenciaHuesped>("_oo_procedencia"); }
            set { SetAtributoRelacionado("_oo_procedencia",value); }
        }
        
        public String St_detallesVehiculo
        {
            get { return _st_detallesVehiculo; }
            set { _st_detallesVehiculo = value; }
        }
    }
}
