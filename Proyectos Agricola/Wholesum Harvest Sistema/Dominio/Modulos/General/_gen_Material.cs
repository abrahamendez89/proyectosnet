using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Herramientas.ORM;

namespace Dominio.Modulos.General
{
    public class _gen_Material:ObjetoBase
    {
        #region atributos privados
        private int _in_CodigoCrop;
        private String _st_Descripcion;
        private String _st_DescripcionCorta;
        private double _do_UnidadesMedida;
        private _gen_UnidadDeMedida _oo_UnidadMedida;
        private double _do_PrecioUnitario;
        private Boolean _bo_EsMaterialVariable;
        private _gen_Material _oo_MaterialEspecifico;
        
        #endregion
        #region propiedades publicas
        public Boolean Bo_EsMaterialVariable
        {
            get { return _bo_EsMaterialVariable; }
            set { _bo_EsMaterialVariable = value; }
        }
        public _gen_Material Oo_MaterialEspecifico
        {
            get { return GetAtributoRelacionado<_gen_Material>("_oo_MaterialEspecifico"); }
            set { SetAtributoRelacionado("_oo_MaterialEspecifico",value); }
        }
        public int In_CodigoCrop
        {
            get { return _in_CodigoCrop; }
            set { _in_CodigoCrop = value; }
        }
        public String St_Descripcion
        {
            get { return _st_Descripcion; }
            set { _st_Descripcion = value; }
        }
        public String St_DescripcionCorta
        {
            get { return _st_DescripcionCorta; }
            set { _st_DescripcionCorta = value; }
        }
        public double Do_UnidadMedidaMinimo
        {
            get { return _do_UnidadesMedida; }
            set { _do_UnidadesMedida = value; }
        }
        public _gen_UnidadDeMedida Oo_UnidadMedida
        {
            get { return GetAtributoRelacionado<_gen_UnidadDeMedida>("_oo_UnidadMedida"); }
            set { SetAtributoRelacionado("_oo_UnidadMedida",value); }
        }
        public double Do_PrecioUnitario
        {
            get { return _do_PrecioUnitario; }
            set { _do_PrecioUnitario = value; }
        }
        #endregion
        #region consultas
        public static readonly String ConsultaPorID = "select * from _gen_Material where id = @id";
        #endregion
    }
}
