using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using Herramientas.ORM;

namespace Dominio.Sistema
{
    public class _sis_LimiteAccesosFallidosAlcanzado:ObjetoBase
    {
        private _sis_ImagenAsociada _FotoPantalla;
        private _sis_ImagenAsociada _FotoWebCam;
        private List<_sis_AccesoFallido> _AccesosFallidos;
        private Boolean _bFueVerificadaNotificacion;

        public Boolean BFueVerificadaNotificacion
        {
            get { return _bFueVerificadaNotificacion; }
            set { _bFueVerificadaNotificacion = value; }
        }

        public _sis_ImagenAsociada FotoPantalla
        {
            get { return GetAtributoRelacionado<_sis_ImagenAsociada>("_FotoPantalla"); }
            set { SetAtributoRelacionado("_FotoPantalla", value); }
        }
        
        public _sis_ImagenAsociada FotoWebCam
        {
            get { return GetAtributoRelacionado<_sis_ImagenAsociada>("_FotoWebCam"); }
            set { SetAtributoRelacionado("_FotoWebCam", value); }
        }
        
        public List<_sis_AccesoFallido> AccesosFallidos
        {
            get { return GetListaRelacionados<_sis_AccesoFallido>("_AccesosFallidos"); }
            set { SetListaRelacionados("_AccesosFallidos",value); }
        }

        #region consultas
        public static readonly String ConsultaAccesosFallidosNoVerificados = "select top 1 * from _sis_LimiteAccesosFallidosAlcanzado where _bFueVerificadaNotificacion = 'False' order by id asc";
        #endregion

    }
}
