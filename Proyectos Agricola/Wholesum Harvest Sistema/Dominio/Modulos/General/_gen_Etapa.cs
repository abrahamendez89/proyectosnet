using Herramientas.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio.Modulos.General
{
    public class _gen_Etapa:ObjetoBase
    {
        #region atributos privados
        private String _st_NombreEtapa;
        private DateTime _dt_InicioEtapa;
        private DateTime _dt_TerminoEtapa;
        #endregion

        #region propiedades publicas
        public String St_NombreEtapa
        {
            get { return _st_NombreEtapa; }
            set { _st_NombreEtapa = value; }
        }
        public DateTime Dt_InicioEtapa
        {
            get { return _dt_InicioEtapa; }
            set { _dt_InicioEtapa = value; }
        }
        public DateTime Dt_TerminoEtapa
        {
            get { return _dt_TerminoEtapa; }
            set { _dt_TerminoEtapa = value; }
        }
        #endregion

        #region consultas
        public static readonly String ConsultaPorID = "select * from _gen_Etapa where id = @id";

        #endregion
    }
}
