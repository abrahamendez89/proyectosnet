using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Herramientas.ORM;

namespace Dominio.Modulos.ProgramaSiembra
{
    public class _ps_PeriodosDeTransplante:ObjetoBase
    {
        #region atributos privados
        private int _in_DiasPeriodo;
        private _ps_ContenedorDetalle _oo_ContenedorUsado;
        #endregion

        #region propiedades publicas
        public int In_DiasPeriodo
        {
            get { return _in_DiasPeriodo; }
            set { _in_DiasPeriodo = value; }
        }
        public _ps_ContenedorDetalle Oo_ContenedorUsado
        {
            get { return GetAtributoRelacionado<_ps_ContenedorDetalle>("_oo_ContenedorUsado"); }
            set { SetAtributoRelacionado("_oo_ContenedorUsado", value); }
        }
        #endregion

        #region consultas
        #endregion
    }
}
