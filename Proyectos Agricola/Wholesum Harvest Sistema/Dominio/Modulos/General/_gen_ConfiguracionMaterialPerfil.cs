using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Herramientas.ORM;

namespace Dominio.Modulos.General
{
    public class _gen_ConfiguracionMaterialPerfil: ObjetoBase
    {
        #region atributos privados
        private _gen_Material _oo_Material;
        private double _do_tiempoRelativoInicio;
        private _gen_UnidadDeTiempo _oo_unidadTiempoInicio;
        private int _in_FechaInicioRespecto;
        private int _in_Repeticiones;
        private double _do_frecuencia;
        private int _in_Veces;
        private _gen_UnidadDeTiempo _oo_unidadTiempoFrecuencia;
        private double _do_plazo;
        private _gen_UnidadDeTiempo _oo_unidadTiempoPlazo;
        private Boolean _bo_SinRepeticiones;
        private Boolean _bo_hastaCumplirTodasUnidades;
        private _gen_Formula _oo_FormulaCalculoMaterial;
        private Boolean _bo_UsarPeriodoDeProduccion;
        
        #endregion
        #region propiedades publicas
        public Boolean Bo_UsarPeriodoDeProduccion
        {
            get { return _bo_UsarPeriodoDeProduccion; }
            set { _bo_UsarPeriodoDeProduccion = value; }
        }
        public _gen_Formula Oo_FormulaCalculoMaterial
        {
            get { return GetAtributoRelacionado<_gen_Formula>("_oo_FormulaCalculoMaterial"); }
            set { SetAtributoRelacionado("_oo_FormulaCalculoMaterial", value); }
        }
        public int In_Veces
        {
            get { return _in_Veces; }
            set { _in_Veces = value; }
        }
        public double Do_plazo
        {
            get { return _do_plazo; }
            set { _do_plazo = value; }
        }
        public Boolean Bo_hastaCumplirTodasUnidades
        {
            get { return _bo_hastaCumplirTodasUnidades; }
            set { _bo_hastaCumplirTodasUnidades = value; }
        }
        public _gen_UnidadDeTiempo Oo_unidadTiempoPlazo
        {
            get { return GetAtributoRelacionado<_gen_UnidadDeTiempo>("_oo_unidadTiempoPlazo"); }
            set { SetAtributoRelacionado("_oo_unidadTiempoPlazo", value); }
        }
        public Boolean Bo_SinRepeticiones
        {
            get { return _bo_SinRepeticiones; }
            set { _bo_SinRepeticiones = value; }
        }
        public _gen_Material Oo_Material
        {
            get { return GetAtributoRelacionado<_gen_Material>("_oo_Material"); }
            set { SetAtributoRelacionado("_oo_Material", value); }
        }

        public double Do_tiempoRelativoInicio
        {
            get { return _do_tiempoRelativoInicio; }
            set { _do_tiempoRelativoInicio = value; }
        }

        public _gen_UnidadDeTiempo Oo_unidadTiempoInicio
        {
            get { return GetAtributoRelacionado<_gen_UnidadDeTiempo>("_oo_unidadTiempoInicio"); }
            set { SetAtributoRelacionado("_oo_unidadTiempoInicio", value); }
        }

        public int In_FechaInicioRespecto
        {
            get { return _in_FechaInicioRespecto; }
            set { _in_FechaInicioRespecto = value; }
        }

        public int In_Repeticiones
        {
            get { return _in_Repeticiones; }
            set { _in_Repeticiones = value; }
        }

        public double Do_frecuencia
        {
            get { return _do_frecuencia; }
            set { _do_frecuencia = value; }
        }

        public _gen_UnidadDeTiempo Oo_unidadTiempoFrecuencia
        {
            get { return GetAtributoRelacionado<_gen_UnidadDeTiempo>("_oo_unidadTiempoFrecuencia"); }
            set { SetAtributoRelacionado("_oo_unidadTiempoFrecuencia", value); }
        }
        #endregion
        #region Consultas publicas
        public static readonly String ConsultaParaBuscador = @"select conf.id as ID, case isNULL(conf.EstaDeshabilitado,0) when 1 then 'SI' when 0 then 'NO' end as [Está deshabilitado], act._st_Nombre as [Actividad]
              from _gen_ConfiguracionActividadNominaPerfil conf
              inner join _gen_ActividadNomina act on conf._oo_Actividad = act.id
              where act._st_Nombre like '%@nombre%'";
        #endregion
    }
}
