using Herramientas.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class _Habitacion:ObjetoBase
    {
        private String _st_identificacion;
        private _UbicacionHabitacion _oo_ubicacion;
        private String _st_descripcionUbicacionSimple;
        private Boolean _bo_estaOcupada;
        private _TipoHabitacion _oo_tipoHabitacion;
        private _ReservacionAplicada _oo_reservAplicActual;

        public String St_identificacion
        {
            get { return _st_identificacion; }
            set { _st_identificacion = value; }
        }
        
        public _UbicacionHabitacion Oo_ubicacion
        {
            get { return GetAtributoRelacionado<_UbicacionHabitacion>("_oo_ubicacion"); }
            set { SetAtributoRelacionado("_oo_ubicacion", value); }
        }
        
        public String St_descripcionUbicacionSimple
        {
            get { return _st_descripcionUbicacionSimple; }
            set { _st_descripcionUbicacionSimple = value; }
        }
        
        public Boolean Bo_estaOcupada
        {
            get { return _bo_estaOcupada; }
            set { _bo_estaOcupada = value; }
        }
        
        public _TipoHabitacion Oo_tipoHabitacion
        {
            get { return GetAtributoRelacionado<_TipoHabitacion>("_oo_tipoHabitacion"); }
            set { SetAtributoRelacionado("_oo_tipoHabitacion", value); }
        }
        
        public _ReservacionAplicada Oo_reservAplicActual
        {
            get { return GetAtributoRelacionado<_ReservacionAplicada>("_oo_reservAplicActual"); }
            set { SetAtributoRelacionado("_oo_reservAplicActual", value); }
        }
    }
}
