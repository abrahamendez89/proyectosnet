using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio.Modulos.General;
using Herramientas.ORM;

namespace Dominio.Modulos.ProgramaSiembra
{
    public class _ps_ConfiguracionSiembra : ObjetoBase
    {
        #region atributos privados
        //private _ps_DensidadPlanteo _oo_Densidad_de_planteo;
        private double _do_Densidad_PlantasXMetro2;
        private _ps_EspacioFisico _oo_Espacio_Fisico_Asociado;
        private DateTime _dt_Fecha_de_planteo;
        private int _in_DiasAntesSiembra;
        private int _in_DiasDespuesCosecha;
        private _ps_VariedadSemilla _oo_Variedad_de_semilla;
        private _gen_Cultivo _oo_Cultivo_plantado;
        private _ps_DatosInjerto _oo_DatosInjerto;
        private List<_ps_PeriodosDeTransplante> _ll_PeriodosTransplanteRaiz;
        private List<_ps_PeriodosDeTransplante> _ll_PeriodosTransplanteProductiva;
        private Boolean _bo_SeUsaInjerto;
        private Boolean _bo_HayTransplante;
        private _ps_EtapaConfiguracionSiembra _oo_EtapaConfiguracionSiembra;
        private Boolean _bo_EsPlanteoAbierto;
        private List<_gen_MaterialVariableEspecifico> _ll_MaterialesVariable;
        private List<_ps_CajasCortYEmpProyectadas> _ll_CajasProyectadas;
        private List<_gen_PerfilActividades> _ll_PerfilActividadesManuales;

        #endregion
        #region propiedades publicas
        public List<_gen_PerfilActividades> Ll_PerfilActividadesManuales
        {
            get { return GetListaRelacionados<_gen_PerfilActividades>("_ll_PerfilActividadesManuales"); }
            set { SetListaRelacionados("_ll_PerfilActividadesManuales", value); }
        }
        public List<_gen_MaterialVariableEspecifico> Ll_MaterialesVariable
        {
            get { return GetListaRelacionados<_gen_MaterialVariableEspecifico>("_ll_MaterialesVariable"); }
            set { SetListaRelacionados("_ll_MaterialesVariable", value); }
        }
        public List<_ps_CajasCortYEmpProyectadas> Ll_CajasProyectadas
        {
            get { return GetListaRelacionados<_ps_CajasCortYEmpProyectadas>("_ll_CajasProyectadas"); }
            set { SetListaRelacionados("_ll_CajasProyectadas", value); }
        }
        public Boolean Bo_EsPlanteoAbierto
        {
            get { return _bo_EsPlanteoAbierto; }
            set { _bo_EsPlanteoAbierto = value; }
        }
        public _ps_EtapaConfiguracionSiembra Oo_EtapaConfiguracionSiembra
        {
            get { return GetAtributoRelacionado<_ps_EtapaConfiguracionSiembra>("_oo_EtapaConfiguracionSiembra"); }
            set { SetAtributoRelacionado("_oo_EtapaConfiguracionSiembra", value); }
        }
        public double Do_Densidad_PlantasXMetro2
        {
            get { return _do_Densidad_PlantasXMetro2; }
            set { _do_Densidad_PlantasXMetro2 = value; }
        }
        public Boolean Bo_SeUsaInjerto
        {
            get { return _bo_SeUsaInjerto; }
            set { _bo_SeUsaInjerto = value; }
        }
        public Boolean Bo_HayTransplante
        {
            get { return _bo_HayTransplante; }
            set { _bo_HayTransplante = value; }
        }
        public List<_ps_PeriodosDeTransplante> Ll_PeriodosTransplanteProductiva
        {
            get { return GetListaRelacionados<_ps_PeriodosDeTransplante>("_ll_PeriodosTransplanteProductiva"); }
            set { SetListaRelacionados("_ll_PeriodosTransplanteProductiva", value); }
        }
        public List<_ps_PeriodosDeTransplante> Ll_PeriodosTransplanteRaiz
        {
            get { return GetListaRelacionados<_ps_PeriodosDeTransplante>("_ll_PeriodosTransplanteRaiz"); }
            set { SetListaRelacionados("_ll_PeriodosTransplanteRaiz", value); }
        }
        public _ps_DatosInjerto Oo_DatosInjerto
        {
            get { return GetAtributoRelacionado<_ps_DatosInjerto>("_oo_DatosInjerto"); }
            set { SetAtributoRelacionado("_oo_DatosInjerto", value); }
        }

        public _ps_VariedadSemilla oo_Variedad_de_semilla
        {
            get { return GetAtributoRelacionado<_ps_VariedadSemilla>("_oo_Variedad_de_semilla"); }
            set { SetAtributoRelacionado("_oo_Variedad_de_semilla", value); }
        }

        public _gen_Cultivo oo_Cultivo_plantado
        {
            get { return GetAtributoRelacionado<_gen_Cultivo>("_oo_Cultivo_plantado"); }
            set { SetAtributoRelacionado("_oo_Cultivo_plantado", value); }
        }
        public _ps_EspacioFisico oo_Espacio_Fisico_Asociado
        {
            get { return GetAtributoRelacionado<_ps_EspacioFisico>("_oo_Espacio_Fisico_Asociado"); }
            set { SetAtributoRelacionado("_oo_Espacio_Fisico_Asociado", value); }
        }

        public DateTime dt_Fecha_de_planteo
        {
            get { return _dt_Fecha_de_planteo; }
            set { _dt_Fecha_de_planteo = value; }
        }

        public int in_DiasDespuesCosecha
        {
            get { return _in_DiasDespuesCosecha; }
            set { _in_DiasDespuesCosecha = value; }
        }

        public int in_DiasAntesSiembra
        {
            get { return _in_DiasAntesSiembra; }
            set { _in_DiasAntesSiembra = value; }
        }
        #endregion
        #region consultas
        public static readonly String ConsultaPorID = "select * from _ps_ConfiguracionSiembra where id = @id";
        #endregion
    }
}
