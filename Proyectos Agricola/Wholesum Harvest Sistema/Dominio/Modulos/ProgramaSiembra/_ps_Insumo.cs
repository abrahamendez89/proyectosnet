using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Herramientas.ORM;

namespace Dominio.Modulos.ProgramaSiembra
{
    public class _ps_Insumo:ObjetoBase
    {
        #region atributos privados
        private String _st_Descripcion;
        private String _st_UnidadDeMedida;
        #endregion

        #region propiedades publicas
        public String St_Descripcion
        {
            get { return _st_Descripcion; }
            set { _st_Descripcion = value; }
        }
        public String St_UnidadDeMedida
        {
            get { return _st_UnidadDeMedida; }
            set { _st_UnidadDeMedida = value; }
        }
        #endregion

        #region consultas
        #endregion
    }
}
