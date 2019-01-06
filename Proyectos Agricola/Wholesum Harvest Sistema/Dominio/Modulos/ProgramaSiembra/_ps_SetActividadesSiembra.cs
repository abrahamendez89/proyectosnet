using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Herramientas.ORM;

namespace Dominio.Modulos.ProgramaSiembra
{
    public class _ps_SetActividadesSiembra:ObjetoBase
    {
        #region atributos privados
        private String _st_NombreSet;
        private List<_ps_ActividadSiembra> _ll_ActividadesHijas;
        #endregion
        #region propiedades publicas
        public List<_ps_ActividadSiembra> Ll_ActividadesHijas
        {
            get { return GetListaRelacionados< _ps_ActividadSiembra>("_ll_ActividadesHijas"); }
            set { SetListaRelacionados("_ll_ActividadesHijas", value); }
        }
        public String St_NombreSet
        {
            get { return _st_NombreSet; }
            set { _st_NombreSet = value; }
        }
        #endregion
    }
}
