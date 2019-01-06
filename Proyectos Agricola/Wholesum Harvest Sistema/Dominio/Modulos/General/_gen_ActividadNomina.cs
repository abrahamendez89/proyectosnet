using Herramientas.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio.Modulos.General
{
    public class _gen_ActividadNomina : ObjetoBase
    {
        #region atributos privados
        private int _in_idCrop;
        private String _st_Nombre;
        private double _do_duracion;        
        private _gen_UnidadDeTiempo _oo_unidadTiempoDuracion;
        private _gen_Formula _oo_formulaCosto;
        private double _do_unidadesTarea;
        private _gen_UnidadDeMedida _oo_UnidadMedidaDeTarea;
        private int _in_jornalesNecesarios;
        private double _do_salarioDiarioRegistrado;
        private double _do_CostoPorUnidad;
        private List<_gen_ConfMatActividadNom> _ll_MaterialesUsados;

        #endregion
        #region propiedades publicas
        public double Do_salarioDiarioRegistrado
        {
            get { return _do_salarioDiarioRegistrado; }
            set { _do_salarioDiarioRegistrado = value; }
        }
        public List<_gen_ConfMatActividadNom> Ll_MaterialesUsados
        {
            get { return GetListaRelacionados<_gen_ConfMatActividadNom>("_ll_MaterialesUsados"); }
            set { SetListaRelacionados("_ll_MaterialesUsados", value); }
        }
        public double Do_CostoPorUnidad
        {
            get { return _do_CostoPorUnidad; }
            set { _do_CostoPorUnidad = value; }
        }
        public int In_jornalesNecesarios
        {
            get { return _in_jornalesNecesarios; }
            set { _in_jornalesNecesarios = value; }
        }
        public double Do_unidadesTarea
        {
            get { return _do_unidadesTarea; }
            set { _do_unidadesTarea = value; }
        }
        public _gen_UnidadDeMedida Oo_UnidadMedidaDeTarea
        {
            get { return GetAtributoRelacionado<_gen_UnidadDeMedida>("_oo_UnidadMedidaDeTarea"); }
            set { SetAtributoRelacionado("_oo_UnidadMedidaDeTarea",value); }
        }
        public _gen_Formula Oo_formulaCosto
        {
            get { return GetAtributoRelacionado<_gen_Formula>("_oo_formulaCosto"); }
            set { SetAtributoRelacionado("_oo_formulaCosto",value); }
        }
        public _gen_UnidadDeTiempo Oo_unidadTiempoInicio
        {
            get { return GetAtributoRelacionado<_gen_UnidadDeTiempo>("_oo_unidadTiempoInicio"); }
            set { SetAtributoRelacionado("_oo_unidadTiempoInicio", value); }
        }
        public double Do_duracion
        {
            get { return _do_duracion; }
            set { _do_duracion = value; }
        }
        public _gen_UnidadDeTiempo Oo_unidadTiempoDuracion
        {
            get { return GetAtributoRelacionado<_gen_UnidadDeTiempo>("_oo_unidadTiempoDuracion"); }
            set { SetAtributoRelacionado("_oo_unidadTiempoDuracion", value); }
        }
        public int In_idCrop
        {
            get { return _in_idCrop; }
            set { _in_idCrop = value; }
        }
        public String St_Nombre
        {
            get { return _st_Nombre; }
            set { _st_Nombre = value; }
        }
        #endregion
        #region consultas
        public static readonly String ConsultaPorID = "select * from _gen_ActividadNomina where id = @id";

        #endregion
    }
}
