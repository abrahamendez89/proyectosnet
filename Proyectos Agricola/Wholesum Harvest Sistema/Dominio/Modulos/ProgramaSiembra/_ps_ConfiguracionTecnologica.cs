using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Herramientas.ORM;

namespace Dominio.Modulos.ProgramaSiembra
{
    public class _ps_ConfiguracionTecnologica:ObjetoBase
    {
        #region atributos privados
        private _ps_TecnologiaCultivo _oo_TecnologiaDeCultivoUsada;
        private _ps_Cubierta _oo_CubiertaUsada;
        private _ps_EspacioFisico _oo_EspacioFisicoAsociado;
        private Boolean _bo_TieneSistEnfriamiento;
        #endregion

        #region propiedades publicas
        public Boolean Bo_TieneSistEnfriamiento
        {
            get { return _bo_TieneSistEnfriamiento; }
            set { _bo_TieneSistEnfriamiento = value; }
        }
        public _ps_EspacioFisico Oo_EspacioFisicoAsociado
        {
            get { return GetAtributoRelacionado<_ps_EspacioFisico>("_oo_EspacioFisicoAsociado"); }
            set { SetAtributoRelacionado("_oo_EspacioFisicoAsociado", value); }
        }
        public _ps_TecnologiaCultivo Oo_TecnologiaDeCultivoUsada
        {
            get { return GetAtributoRelacionado<_ps_TecnologiaCultivo>("_oo_TecnologiaDeCultivoUsada"); }
            set { SetAtributoRelacionado("_oo_TecnologiaDeCultivoUsada",value); }
        }
        public _ps_Cubierta Oo_CubiertaUsada
        {
            get { return GetAtributoRelacionado<_ps_Cubierta>("_oo_CubiertaUsada"); }
            set { SetAtributoRelacionado("_oo_CubiertaUsada", value); }
        }
        #endregion

        #region consultas
        #endregion
    }
}
