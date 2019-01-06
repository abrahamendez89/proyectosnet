using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio.Modulos.ProgramaSiembra;
using Herramientas.ORM;

namespace Dominio.Modulos.General
{
    public class _gen_ConfiguracionTemporada : ObjetoBase
    {
        #region atributos privados
        private _gen_Temporada _oo_Temporada;
        private _gen_UnidadNegocio _oo_UnidadNegocio;
        private String _st_version;
        private _gen_Etapa _oo_EtapaTemporada;
        private List<_ps_EspacioFisico> _ll_espaciosAsignados;
        private Boolean _bo_EsVersionLiberada;
        #endregion

        #region propiedades publicas
        public Boolean Bo_EsVersionLiberada
        {
            get { return _bo_EsVersionLiberada; }
            set { _bo_EsVersionLiberada = value; }
        }
        public List<_ps_EspacioFisico> Ll_espaciosAsignados
        {
            get { return GetListaRelacionados<_ps_EspacioFisico>("_ll_espaciosAsignados"); }
            set { SetListaRelacionados("_ll_espaciosAsignados", value); }
        }
        public _gen_Temporada Oo_Temporada
        {
            get { return GetAtributoRelacionado<_gen_Temporada>("_oo_Temporada"); }
            set { SetAtributoRelacionado("_oo_Temporada", value); }
        }
        public _gen_UnidadNegocio Oo_UnidadNegocio
        {
            get { return GetAtributoRelacionado<_gen_UnidadNegocio>("_oo_UnidadNegocio"); }
            set { SetAtributoRelacionado("_oo_UnidadNegocio", value); }
        }
        public _gen_Etapa Oo_EtapaTemporada
        {
            get { return GetAtributoRelacionado<_gen_Etapa>("_oo_EtapaTemporada"); }
            set { SetAtributoRelacionado("_oo_EtapaTemporada", value); }
        }
        public String St_version
        {
            get { return _st_version; }
            set { _st_version = value; }
        }
        #endregion

        #region consultas
        public static readonly String ConsultaTodos = "select * from _gen_ConfiguracionTemporada";
        #endregion
    }
}
