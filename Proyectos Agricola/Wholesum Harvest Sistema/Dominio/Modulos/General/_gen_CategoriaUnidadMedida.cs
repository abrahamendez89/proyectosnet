using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Herramientas.ORM;

namespace Dominio.Modulos.General
{
    public class _gen_CategoriaUnidadMedida: ObjetoBase
    {
        #region atributos privados
        private String _st_NombreCategoria;
        #endregion

        #region propiedades publicas
        public String St_NombreCategoria
        {
            get { return _st_NombreCategoria; }
            set { _st_NombreCategoria = value; }
        }
        #endregion
    }
}
