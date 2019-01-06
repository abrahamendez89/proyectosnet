using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio.Modulos.General;
using Herramientas.ORM;

namespace Dominio.Modulos.ProgramaSiembra
{
    public class _ps_EspacioFisico : ObjetoBase
    {
        #region atributos privados
        private int _in_NumeroCasetas;
        private double _in_NumeroCaidas;
        private int _in_NumeroPerifericas;
        private int _in_Numero_de_camas;
        private double _do_MetrosDesague;
        private float _fl_Separacion_entre_camas;
        private double _do_MetrosPerimetro;
        private double _do_Numero_hectareas;
        private String _st_Nombre_espacio;
        private List<_ps_EspacioFisico> _ll_Espacios_fisicos_dentro;
        private List<_ps_ConfiguracionSiembra> _ll_Configuraciones_de_Siembra;
        private _ps_ConfiguracionTecnologica _oo_Configuracion_tecnologica; //representacion de una relación 1 a 1
        private _gen_ConfiguracionTemporada _oo_ConfiguracionTemporadaAsociada;
        private Boolean _bo_esEspacioFinal;
        private double _do_AreaPorCama;
        private double _do_LongitudPorCama;
        private String _st_CoordenadasEspaciales;
        private _ps_EspacioFisico _oo_EspacioFisicoPadre;
        private Boolean esPadreTemporalCroquis;
        private String _st_NombreEspacioEnMacro;
        private Boolean _bo_esEmpaque;
        private List<_gen_PerfilActividades> _ll_PerfilesAsociados;
        #endregion
        #region propiedades publicas
        public List<_gen_PerfilActividades> Ll_PerfilesAsociados
        {
            get { return GetListaRelacionados<_gen_PerfilActividades>("_ll_PerfilesAsociados"); }
            set { SetListaRelacionados("_ll_PerfilesAsociados",value); }
        }
        public Boolean Bo_esEmpaque
        {
            get { return _bo_esEmpaque; }
            set { _bo_esEmpaque = value; }
        }
        public String St_NombreEspacioEnMacro
        {
            get { return _st_NombreEspacioEnMacro; }
            set { _st_NombreEspacioEnMacro = value; }
        }
        public double Do_MetrosDesague
        {
            get { return _do_MetrosDesague; }
            set { _do_MetrosDesague = value; }
        }
        public double In_NumeroCaidas
        {
            get { return _in_NumeroCaidas; }
            set { _in_NumeroCaidas = value; }
        }
        public int In_NumeroPerifericas
        {
            get { return _in_NumeroPerifericas; }
            set { _in_NumeroPerifericas = value; }
        }
        public Boolean EsPadreTemporalCroquis
        {
            get { return esPadreTemporalCroquis; }
            set { esPadreTemporalCroquis = value; }
        }
        public _ps_EspacioFisico Oo_EspacioFisicoPadre
        {
            get { return GetAtributoRelacionado<_ps_EspacioFisico>("_oo_EspacioFisicoPadre"); }
            set { SetAtributoRelacionado("_oo_EspacioFisicoPadre",value); }
        }
        public String St_CoordenadasEspaciales
        {
            get { return _st_CoordenadasEspaciales; }
            set { _st_CoordenadasEspaciales = value; }
        }
        public double Do_AreaPorCama
        {
            get { return _do_AreaPorCama; }
            set { _do_AreaPorCama = value; }
        }
        public double Do_LongitudPorCama
        {
            get { return _do_LongitudPorCama; }
            set { _do_LongitudPorCama = value; }
        }
        public int In_Numero_de_camas
        {
            get { return _in_Numero_de_camas; }
            set { _in_Numero_de_camas = value; }
        }
        public float Fl_Separacion_entre_camas
        {
            get { return _fl_Separacion_entre_camas; }
            set { _fl_Separacion_entre_camas = value; }
        }
        public Boolean Bo_esEspacioFinal
        {
            get { return _bo_esEspacioFinal; }
            set { _bo_esEspacioFinal = value; }
        }
        public _gen_ConfiguracionTemporada Oo_ConfiguracionTemporadaAsociada
        {
            get { return GetAtributoRelacionado<_gen_ConfiguracionTemporada>("_oo_ConfiguracionTemporadaAsociada"); }
            set { SetAtributoRelacionado("_oo_ConfiguracionTemporadaAsociada", value); }
        }
        public int In_NumeroCasetas
        {
            get { return _in_NumeroCasetas; }
            set { _in_NumeroCasetas = value; }
        }
        public double Do_MetrosPerimetro
        {
            get { return _do_MetrosPerimetro; }
            set { _do_MetrosPerimetro = value; }
        }
        public _ps_ConfiguracionTecnologica Oo_Configuracion_tecnologica
        {
            get { return GetAtributoRelacionado<_ps_ConfiguracionTecnologica>("_oo_Configuracion_tecnologica"); }
            set { SetAtributoRelacionado("_oo_Configuracion_tecnologica", value); }
        }
        public List<_ps_ConfiguracionSiembra> ll_Configuraciones_de_Siembra
        {
            get { return GetListaRelacionados<_ps_ConfiguracionSiembra>("_ll_Configuraciones_de_Siembra"); }
            set { SetListaRelacionados("_ll_Configuraciones_de_Siembra", value); }
        }

        public double do_Numero_hectareas
        {
            get { return _do_Numero_hectareas; }
            set { _do_Numero_hectareas = value; }
        }

        public String st_Nombre_espacio
        {
            get { return _st_Nombre_espacio; }
            set { _st_Nombre_espacio = value; }
        }

        public List<_ps_EspacioFisico> ll_Espacios_fisicos_dentro
        {
            get { return GetListaRelacionados< _ps_EspacioFisico>("_ll_Espacios_fisicos_dentro"); }
            set { SetListaRelacionados("_ll_Espacios_fisicos_dentro", value); }
        }
        #endregion
        #region consultas
        public static readonly String ConsultaPorNombre = "select * from _ps_EspacioFisico where _st_Nombre_espacio = @_st_Nombre_espacio";
        public static readonly String ConsultaPorID = "select * from _ps_EspacioFisico where id = @id";

        #endregion






    }
}
