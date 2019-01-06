using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Herramientas.ORM;

namespace Dominio.Modulos.ProgramaSiembra
{
    public class _ps_InsumoUsadoDetalle:ObjetoBase
    {
        #region atributos privados
        private _ps_Insumo _oo_Insumo;
        private float _fl_CantidadDelInsumo;
        #endregion

        #region propiedades publicas
        public _ps_Insumo Oo_Insumo
        {
            get { return _oo_Insumo; }
            set { _oo_Insumo = value; }
        }
        public float Fl_CantidadDelInsumo
        {
            get { return _fl_CantidadDelInsumo; }
            set { _fl_CantidadDelInsumo = value; }
        }
        #endregion

        #region consultas
        #endregion
    }
}
