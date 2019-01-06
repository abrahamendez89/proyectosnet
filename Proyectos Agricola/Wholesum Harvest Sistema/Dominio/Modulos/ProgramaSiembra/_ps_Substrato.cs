using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Herramientas.ORM;

namespace Dominio.Modulos.ProgramaSiembra
{
    public class _ps_Substrato:ObjetoBase
    {
        #region atributos privados
        private String _st_NombreSubstrato;
        #endregion

        #region propiedades publicas
        public String St_NombreSubstrato
        {
            get { return _st_NombreSubstrato; }
            set { _st_NombreSubstrato = value; }
        }
        #endregion

        #region consultas
        #endregion
    }
}
