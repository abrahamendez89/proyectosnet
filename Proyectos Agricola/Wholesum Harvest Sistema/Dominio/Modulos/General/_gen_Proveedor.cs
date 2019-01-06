using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Herramientas.ORM;

namespace Dominio.Modulos.General
{
    public class _gen_Proveedor : ObjetoBase
    {
        #region atributos privados
        private String _st_NombreProveedor;
        private int _in_DiasPedidoAnticipacion;
        #endregion
        #region propiedades publicas
        public String St_NombreProveedor
        {
            get { return _st_NombreProveedor; }
            set { _st_NombreProveedor = value; }
        }
        public int In_DiasPedidoAnticipacion
        {
            get { return _in_DiasPedidoAnticipacion; }
            set { _in_DiasPedidoAnticipacion = value; }
        }
        #endregion
        #region metodos publicos estaticos
        #endregion
    }
}
