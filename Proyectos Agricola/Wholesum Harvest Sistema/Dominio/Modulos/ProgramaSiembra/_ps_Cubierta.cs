using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Herramientas.ORM;

namespace Dominio.Modulos.ProgramaSiembra
{
    public class _ps_Cubierta:ObjetoBase
    {
        #region atributos privados
        private String _st_NombreCubierta;
        #endregion

        #region propiedades publicas
        public String St_NombreCubierta
        {
            get { return _st_NombreCubierta; }
            set { _st_NombreCubierta = value; }
        }
        #endregion

        #region consultas
        #endregion
    }
}
