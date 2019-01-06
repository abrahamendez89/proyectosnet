using Herramientas.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class _ReservacionAplicada: ObjetoBase
    {
        private _Reservacion _oo_reservacionPrevia;
        private int _in_cantidadPersonas;
        private DateTime _dt_fechaLlegada;
        private _PaqueteHabitacion _oo_paqueteHabitacion;
        private List<_AfectacionHabitacion> _ll_afectaciones;
        private List<_ServicioAdqExtra> _ll_serviciosExt;

        public _Reservacion Oo_reservacionPrevia
        {
            get { return GetAtributoRelacionado<_Reservacion>("_oo_reservacionPrevia"); }
            set { SetAtributoRelacionado("_oo_reservacionPrevia", value); }
        }
        
        public int In_cantidadPersonas
        {
            get { return _in_cantidadPersonas; }
            set { _in_cantidadPersonas = value; }
        }
        
        public DateTime Dt_fechaLlegada
        {
            get { return _dt_fechaLlegada; }
            set { _dt_fechaLlegada = value; }
        }
        
        public _PaqueteHabitacion Oo_paqueteHabitacion
        {
            get { return GetAtributoRelacionado<_PaqueteHabitacion>("_oo_paqueteHabitacion"); }
            set { SetAtributoRelacionado("_oo_paqueteHabitacion", value); }
        }
        
        public List<_AfectacionHabitacion> Ll_afectaciones
        {
            get { return GetListaRelacionados<_AfectacionHabitacion>("_ll_afectaciones"); }
            set { SetListaRelacionados("_ll_afectaciones", value); }
        }
        

        public List<_ServicioAdqExtra> Ll_serviciosExt
        {
            get { return GetListaRelacionados<_ServicioAdqExtra>("_ll_serviciosExt"); }
            set { SetListaRelacionados("_ll_serviciosExt", value); }
        }

    }
}
