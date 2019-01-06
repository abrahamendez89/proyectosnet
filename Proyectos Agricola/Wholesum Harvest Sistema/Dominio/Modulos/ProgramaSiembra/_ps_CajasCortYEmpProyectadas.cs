using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Herramientas.ORM;

namespace Dominio.Modulos.ProgramaSiembra
{
    public class _ps_CajasCortYEmpProyectadas:ObjetoBase
    {
        #region atributos privados
        private _ps_ConfiguracionSiembra _oo_ConfiguracionSiembra;
        private double _do_CantidadCorte;
        private double _do_CantidadEmpaque;
        private DateTime _dt_FechaProyeccion;
        #endregion

        #region propiedades publicas
        public _ps_ConfiguracionSiembra Oo_ConfiguracionSiembra
        {
            get { return GetAtributoRelacionado<_ps_ConfiguracionSiembra>("_oo_ConfiguracionSiembra"); }
            set { SetAtributoRelacionado("_oo_ConfiguracionSiembra", value); }
        }

        public double Do_CantidadCorte
        {
            get { return _do_CantidadCorte; }
            set { _do_CantidadCorte = value; }
        }

        public double Do_CantidadEmpaque
        {
            get { return _do_CantidadEmpaque; }
            set { _do_CantidadEmpaque = value; }
        }


        public DateTime Dt_FechaProyeccion
        {
            get { return _dt_FechaProyeccion; }
            set { _dt_FechaProyeccion = value; }
        }
        #endregion

        #region consultas publicas

        #endregion
    }
}
