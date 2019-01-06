using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Herramientas.ORM;

namespace Dominio.Modulos.General
{
    public class _gen_UnidadNegocio:ObjetoBase
    {
        #region atributos privados
        private String _st_NombreUnidadNegocio;
        private List<_gen_Etapa> _ll_EtapasRegistradas;
        #endregion

        #region propiedades publicas
        public String St_NombreUnidadNegocio
        {
            get { return _st_NombreUnidadNegocio; }
            set { _st_NombreUnidadNegocio = value; }
        }
        public List<_gen_Etapa> Ll_EtapasRegistradas
        {
            get { return GetListaRelacionados<_gen_Etapa>("_ll_EtapasRegistradas"); }
            set { SetListaRelacionados("_ll_EtapasRegistradas", value); }
        }
        #endregion

        #region consultas
        #endregion
    }
}
