using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio.Modulos.ProgramaSiembra;
using Herramientas.ORM;

namespace Dominio.Modulos.General
{
    public class _gen_PerfilActividades: ObjetoBase
    {
        #region atributos privados
        private String _st_NombrePerfil;
        private _gen_Cultivo _oo_cultivo;
        private _ps_TecnologiaCultivo _oo_tecnologia;
        private List<_gen_ConfiguracionActividadNominaPerfil> _ll_ConfiguracionActividades;
        private List<_gen_ConfiguracionMaterialPerfil> _ll_ConfiguracionMateriales;
        private List<_gen_PerfilActividades> _ll_SubPerfiles;
        #endregion
        #region propiedades publicas
        public String St_NombrePerfil
        {
            get { return _st_NombrePerfil; }
            set { _st_NombrePerfil = value; }
        }
        public _gen_Cultivo Oo_cultivo
        {
            get { return GetAtributoRelacionado<_gen_Cultivo>("_oo_cultivo"); }
            set { SetAtributoRelacionado("_oo_cultivo", value); }
        }
        public _ps_TecnologiaCultivo Oo_tecnologia
        {
            get { return GetAtributoRelacionado<_ps_TecnologiaCultivo>("_oo_tecnologia"); }
            set { SetAtributoRelacionado("_oo_tecnologia",value); }
        }
        public List<_gen_ConfiguracionMaterialPerfil> Ll_ConfiguracionMateriales
        {
            get { return GetListaRelacionados<_gen_ConfiguracionMaterialPerfil>("_ll_ConfiguracionMateriales"); }
            set { SetListaRelacionados("_ll_ConfiguracionMateriales",value); }
        }
        public List<_gen_PerfilActividades> Ll_SubPerfiles
        {
            get { return GetListaRelacionados<_gen_PerfilActividades>("_ll_SubPerfiles"); }
            set { SetListaRelacionados("_ll_SubPerfiles",value); }
        }
        public List<_gen_ConfiguracionActividadNominaPerfil> Ll_ConfiguracionActividades
        {
            get { return GetListaRelacionados<_gen_ConfiguracionActividadNominaPerfil>("_ll_ConfiguracionActividades"); }
            set { SetListaRelacionados("_ll_ConfiguracionActividades", value); }
        }
        #endregion
        #region consultas
        public static readonly String ConsultaPorTecnologiaYCultivo = "select * from _gen_PerfilActividades where _oo_tecnologia = @_oo_tecnologia and _oo_cultivo = @_oo_cultivo";
        public static readonly String ConsultaPorID = "select * from _gen_PerfilActividades where id = @id";
        public static readonly String ConsultaMaterialesVariablesPorID = @"select material.* from _gen_PerfilActividades perfil 
                                                                        inner join _gen_PerfilActividades_X__gen_ConfiguracionActividadNominaPerfil__ll_ConfiguracionActividades perfil_actividad on perfil.id = perfil_actividad._contenedor
                                                                        inner join _gen_ConfiguracionActividadNominaPerfil confActividad on perfil_actividad._contenido = confActividad.id
                                                                        inner join _gen_ActividadNomina actividad on confActividad._oo_Actividad = actividad.id
                                                                        inner join _gen_ActividadNomina_X__gen_ConfMatActividadNom__ll_MaterialesUsados actividad_material on actividad_material._contenedor = actividad.id
                                                                        inner join _gen_ConfMatActividadNom confMAterial on actividad_material._contenido = confMAterial.id
                                                                        inner join _gen_Material material on confMAterial._oo_MaterialAUsar = material.id
                                                                        where material._bo_EsMaterialVariable = 1 and perfil.id = @id

                                                                        union all

                                                                        select mat.* from _gen_PerfilActividades perfil
                                                                        inner join _gen_PerfilActividades_X__gen_ConfiguracionMaterialPerfil__ll_ConfiguracionMateriales rel_perfConf on perfil.id = rel_perfConf._contenedor
                                                                        inner join _gen_ConfiguracionMaterialPerfil matPerf on matPerf.id = rel_perfConf._contenido
                                                                        inner join _gen_Material mat on matPerf._oo_Material = mat.id
                                                                        where mat._bo_EsMaterialVariable = 1 and perfil.id = @id";
        #endregion
    }
}
