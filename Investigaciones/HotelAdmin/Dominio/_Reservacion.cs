using Herramientas.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class _Reservacion:ObjetoBase
    {
        private _Habitacion _oo_habitacion;
        private DateTime _dt_fechaInicio;
        private DateTime _dt_fechaFin;
        private Boolean _bo_estaActiva;
        private _HuespedCliente _oo_huespedCliente;
        private int _in_cantidadPersonas;
        private String _st_observaciones;
        private _PaqueteHabitacion _oo_paquete;

        public _Habitacion Oo_habitacion
        {
            get { return GetAtributoRelacionado<_Habitacion>("_oo_habitacion"); }
            set { SetAtributoRelacionado("_oo_habitacion",value); }
        }
        
        public DateTime Dt_fechaInicio
        {
            get { return _dt_fechaInicio; }
            set { _dt_fechaInicio = value; }
        }
        
        public DateTime Dt_fechaFin1
        {
            get { return _dt_fechaFin; }
            set { _dt_fechaFin = value; }
        }

        public DateTime Dt_fechaFin
        {
            get { return _dt_fechaFin; }
            set { _dt_fechaFin = value; }
        }
        
        public Boolean Bo_estaActiva
        {
            get { return _bo_estaActiva; }
            set { _bo_estaActiva = value; }
        }
        
        public _HuespedCliente Oo_huespedCliente
        {
            get { return GetAtributoRelacionado<_HuespedCliente>("_oo_huespedCliente"); }
            set { SetAtributoRelacionado("_oo_huespedCliente", value); }
        }
        
        public int In_cantidadPersonas
        {
            get { return _in_cantidadPersonas; }
            set { _in_cantidadPersonas = value; }
        }
        
        public String St_observaciones
        {
            get { return _st_observaciones; }
            set { _st_observaciones = value; }
        }
        
        public _PaqueteHabitacion Oo_paquete
        {
            get { return GetAtributoRelacionado<_PaqueteHabitacion>("_oo_paquete"); }
            set { SetAtributoRelacionado("_oo_paquete",value); }
        }
    }
}
