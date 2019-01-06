using Dominio;
using Dominio.Modulos.General;
using Dominio.Modulos.ProgramaSiembra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Herramientas.ORM;

namespace LogicaNegocios.ProgramaSiembra
{
    public class ps_ln_Espacios
    {
        public static Boolean ExisteNombreEspacioDentroDeEspacio(_ps_EspacioFisico espacioPadre, String espacioABuscar)
        {
            if (espacioPadre.ll_Espacios_fisicos_dentro == null) espacioPadre.ll_Espacios_fisicos_dentro = new List<_ps_EspacioFisico>();
            foreach (_ps_EspacioFisico esp in espacioPadre.ll_Espacios_fisicos_dentro)
            {
                if (esp.st_Nombre_espacio.ToLower().Trim().Equals(espacioABuscar.ToLower().Trim()))
                    return true;
            }
            return false;
        }
        public static double CalcularHectareajeTotal(List<_ps_EspacioFisico> lista)
        {
            double suma = 0;
            if (lista != null)
                foreach (_ps_EspacioFisico esp in lista)
                {
                    if (esp.Bo_esEspacioFinal)
                    {
                        suma += esp.do_Numero_hectareas;
                    }
                    suma += CalcularHectareajeTotal(esp.ll_Espacios_fisicos_dentro);
                }
            return suma;
        }
        public static Dictionary<String, double> CalcularHectareajePorCultivo(List<_ps_EspacioFisico> lista, Dictionary<String, double> sumas)
        {
            //Dictionary<String, double> sumas = new Dictionary<string, double>();
            if (lista != null)
                foreach (_ps_EspacioFisico esp in lista)
                {
                    if (esp.Bo_esEspacioFinal)
                    {
                        if (esp.ll_Configuraciones_de_Siembra != null && esp.ll_Configuraciones_de_Siembra.Count > 0 && esp.ll_Configuraciones_de_Siembra[0] != null && esp.ll_Configuraciones_de_Siembra[0].oo_Cultivo_plantado != null)
                        {
                            String cultivoNombre = esp.ll_Configuraciones_de_Siembra[0].oo_Cultivo_plantado.st_Nombre_cultivo;
                            if (!sumas.ContainsKey(cultivoNombre)) sumas.Add(cultivoNombre, 0);
                            sumas[cultivoNombre] += esp.do_Numero_hectareas;
                        }
                        //suma += esp.do_Numero_hectareas;
                    }
                    sumas = CalcularHectareajePorCultivo(esp.ll_Espacios_fisicos_dentro, sumas);
                }
            return sumas;
        }
        public static void CalcularFechaSiembraYCosecha(_ps_ConfiguracionSiembra configuracionSiembra, _gen_Cultivo cultivoASembrar)
        {
            if (configuracionSiembra != null)
            {
                DateTime fechaPlanteo = configuracionSiembra.dt_Fecha_de_planteo;
                if (cultivoASembrar != null)
                {
                    configuracionSiembra.in_DiasAntesSiembra = cultivoASembrar.In_DiasAntesSiembra;
                    configuracionSiembra.in_DiasDespuesCosecha = cultivoASembrar.In_DiasDespuesCosecha;
                }
            }
        }
        public static void AgregarEspacioAEspacio(_ps_EspacioFisico espacioBase, _ps_EspacioFisico espacioAAgregar)
        {
            //espacioBase.EsModificado = true;
            espacioAAgregar.EsModificado = true;
            if (espacioBase.ll_Espacios_fisicos_dentro == null) espacioBase.ll_Espacios_fisicos_dentro = new List<_ps_EspacioFisico>();

            for (int i = 0; i < espacioBase.ll_Espacios_fisicos_dentro.Count; i++)
            {
                if (espacioBase.ll_Espacios_fisicos_dentro[i].st_Nombre_espacio.Trim().ToLower().Equals(espacioAAgregar.st_Nombre_espacio.Trim().ToLower()))
                {
                    espacioBase.ll_Espacios_fisicos_dentro[i] = espacioAAgregar;

                    return;
                }
            }
            espacioBase.ll_Espacios_fisicos_dentro.Add(espacioAAgregar);
            espacioBase.EsModificado = true;
        }
        public static void EliminarEspacioAEspacio(_ps_EspacioFisico espacioBase, _ps_EspacioFisico espacioAEliminar)
        {
            //espacioBase.EsModificado = true;
            if (espacioBase.ll_Espacios_fisicos_dentro == null) espacioBase.ll_Espacios_fisicos_dentro = new List<_ps_EspacioFisico>();

            for (int i = 0; i < espacioBase.ll_Espacios_fisicos_dentro.Count; i++)
            {
                if (espacioBase.ll_Espacios_fisicos_dentro[i].st_Nombre_espacio.Trim().ToLower().Equals(espacioAEliminar.st_Nombre_espacio.Trim().ToLower()))
                {
                    espacioBase.ll_Espacios_fisicos_dentro.Remove(espacioBase.ll_Espacios_fisicos_dentro[i]);
                    espacioBase.EsModificado = true;
                    return;
                }
            }
        }
        public static String CrearNuevaVersionTemporada(ManejadorDB manejador, _gen_ConfiguracionTemporada configuracionTemporada)
        {
            //seteamos los ids en 0 para que se generen nuevamente los espacios nuevos

            configuracionTemporada.Id = 0;
            configuracionTemporada.St_version = DateTime.Now.ToString("yyyyMMddHHmm");
            configuracionTemporada.EsModificado = true;

            if (configuracionTemporada.Ll_espaciosAsignados != null)
            {
                foreach (_ps_EspacioFisico espacioEnTemporada in configuracionTemporada.Ll_espaciosAsignados)
                {
                    espacioEnTemporada.Oo_ConfiguracionTemporadaAsociada = configuracionTemporada;
                    SetIDEspaciosRecursivo(espacioEnTemporada);
                }
            }

            manejador.GuardarAsincrono("versionConf", configuracionTemporada);

            return "";
        }

        private static void SetIDEspaciosRecursivo(_ps_EspacioFisico espacioEnTemporada)
        {
            if (espacioEnTemporada.Oo_Configuracion_tecnologica != null)
            {
                espacioEnTemporada.Oo_Configuracion_tecnologica.Oo_EspacioFisicoAsociado = espacioEnTemporada;
                var cubierta = espacioEnTemporada.Oo_Configuracion_tecnologica.Oo_CubiertaUsada;
                var tecnologiaCultivo = espacioEnTemporada.Oo_Configuracion_tecnologica.Oo_TecnologiaDeCultivoUsada;
                espacioEnTemporada.Oo_Configuracion_tecnologica.Id = 0;
                espacioEnTemporada.Oo_Configuracion_tecnologica.EsModificado = true;
            }
            if (espacioEnTemporada.ll_Configuraciones_de_Siembra != null)
            {
                foreach (_ps_ConfiguracionSiembra configuracion in espacioEnTemporada.ll_Configuraciones_de_Siembra)
                {
                    

                    if (configuracion.Ll_MaterialesVariable != null)
                    {
                        foreach (_gen_MaterialVariableEspecifico materialVarEspecifico in configuracion.Ll_MaterialesVariable)
                        {
                            var mat = materialVarEspecifico.Oo_MaterialEspecifico;
                            var matv = materialVarEspecifico.Oo_MaterialVariable;
                            materialVarEspecifico.Id = 0;
                            materialVarEspecifico.EsModificado = true;
                        }
                    }
                    configuracion.oo_Espacio_Fisico_Asociado = espacioEnTemporada;
                    if (configuracion.Oo_DatosInjerto != null)
                    {
                        configuracion.Oo_DatosInjerto.Id = 0;
                        configuracion.Oo_DatosInjerto.EsModificado = true;
                    }
                    var variedad = configuracion.oo_Variedad_de_semilla;
                    var cultivo = configuracion.oo_Cultivo_plantado;
                    var etapa = configuracion.Oo_EtapaConfiguracionSiembra;
                    configuracion.Id = 0;
                    configuracion.EsModificado = true;
                }
            }
            if (espacioEnTemporada.ll_Espacios_fisicos_dentro != null)
            {
                foreach (_ps_EspacioFisico espacioDentro in espacioEnTemporada.ll_Espacios_fisicos_dentro)
                {
                    espacioDentro.Oo_EspacioFisicoPadre = espacioEnTemporada;
                    SetIDEspaciosRecursivo(espacioDentro);
                }
            }
            espacioEnTemporada.Id = 0;
            espacioEnTemporada.EsModificado = true;
        }

    }
}
