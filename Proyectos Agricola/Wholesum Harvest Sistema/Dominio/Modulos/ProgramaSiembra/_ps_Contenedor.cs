using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Herramientas.ORM;

namespace Dominio.Modulos.ProgramaSiembra
{
    public class _ps_Contenedor:ObjetoBase
    {
        #region atributos privados
        private String _st_NombreContenedor;

        
        #endregion

        #region propiedades publicas
        public String St_NombreContenedor
        {
            get { return _st_NombreContenedor; }
            set { _st_NombreContenedor = value; }
        }
        #endregion

        #region consultas
        #endregion
    }
}
