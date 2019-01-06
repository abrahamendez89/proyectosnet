using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Herramientas.ORM;

namespace Dominio.Modulos.General
{
    public class _gen_Temporada:ObjetoBase
    {
        #region atributos privados
        private String _st_NombreTemporada;
        private DateTime _dt_InicioTemporada;
        private DateTime _dt_TerminoTemporada;
        private List<_gen_ConfiguracionTemporada> _ll_ConfiguracionesDeTemporada;

        
        #endregion

        #region propiedades publicas
        public List<_gen_ConfiguracionTemporada> Ll_ConfiguracionesDeTemporada
        {
            get { return GetListaRelacionados<_gen_ConfiguracionTemporada>("_ll_ConfiguracionesDeTemporada"); }
            set { SetListaRelacionados("_ll_ConfiguracionesDeTemporada",value); }
        }
        public String St_NombreTemporada
        {
            get { return _st_NombreTemporada; }
            set { _st_NombreTemporada = value; }
        }
        public DateTime Dt_InicioTemporada
        {
            get { return _dt_InicioTemporada; }
            set { _dt_InicioTemporada = value; }
        }
        public DateTime Dt_TerminoTemporada
        {
            get { return _dt_TerminoTemporada; }
            set { _dt_TerminoTemporada = value; }
        }
        #endregion

        #region consultas
        public static readonly String ConsultaTodos = "select * from _gen_Temporada";
        public static readonly String ConsultaPorID = "select * from _gen_Temporada where id = @id";
        #endregion
    }
}
