using Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Charting;
using Herramientas.ORM;

namespace InterfazWPF.Modulos.ProgramaSiembra
{
    /// <summary>
    /// Lógica de interacción para win_ps_resultadoCalculoActividades.xaml
    /// </summary>
    public partial class win_ps_resultadoCalculoActividades : Window
    {
        ManejadorDB manejador = new ManejadorDB();

        public win_ps_resultadoCalculoActividades()
        {
            InitializeComponent();

            
            CrearDataGrid();
            CargarDatos();

        }

        private void CrearDataGrid()
        {
            DataTable dt = CargarDatos();
            dgr_resultados.DataContext = dt.DefaultView;
            dgr_resultados.IsReadOnly = true;
            
        }
        private DataTable CargarDatos()
        {
            DataTable res = manejador.EjecutarConsulta(@"
            select 
              esp._st_Nombre_espacio as [Campo]
            , esp2._st_Nombre_espacio as [Tabla]
            , tecnologia._st_Descripcion as [Tecnología]
            , etapa._st_NombreEtapa as [Etapa]
            , cultivo._st_Nombre_cultivo as [Cultivo]
            , perfil._st_NombrePerfil as [Perfil aplicado]
            , cast(actividadNomina._in_idCrop as varchar(MAX)) + ' - ' + actividadNomina._st_Nombre as [Actividades dentro del perfil]
            , formula._st_Formula as [Formula]
			--Tiempo
			--, confiActividad._do_tiempoRelativoInicio
			--, tiempoInicio._st_Nombre
			--, (tiempoInicio._do_EquivalenciaEn1Hora / 8) * confiActividad._do_tiempoRelativoInicio as [Dias relativo inicio]
			--, case 
			--when confiActividad._in_FechaInicioRespecto = 0 
			--then 'Siembra'
			--when confiActividad._in_FechaInicioRespecto = 1 
			--then 'Planteo'
			--when confiActividad._in_FechaInicioRespecto = 2
			--then 'Cosecha'
			--end
			--, cultivo._in_DiasAntesSiembra * -1 as [Dias Antes Siembra]
			--,confSiembra._dt_Fecha_de_planteo
			, case 
			when confiActividad._in_FechaInicioRespecto = 0 
			then Convert(varchar, dateadd(day,(cultivo._in_DiasAntesSiembra * -1) + (tiempoInicio._do_EquivalenciaEn1Hora / 8) * confiActividad._do_tiempoRelativoInicio,confSiembra._dt_Fecha_de_planteo), 120)
			when confiActividad._in_FechaInicioRespecto = 1 
			then Convert(varchar,dateadd(day,(tiempoInicio._do_EquivalenciaEn1Hora / 8) * confiActividad._do_tiempoRelativoInicio,confSiembra._dt_Fecha_de_planteo), 120)
			when confiActividad._in_FechaInicioRespecto = 2
			then Convert(varchar,dateadd(day,cultivo._in_DiasDespuesCosecha + (tiempoInicio._do_EquivalenciaEn1Hora / 8) * confiActividad._do_tiempoRelativoInicio,confSiembra._dt_Fecha_de_planteo), 120)
			end as [Fecha inicio Actividad]
			, case when confiActividad._bo_SinRepeticiones is null then 0 else confiActividad._bo_SinRepeticiones end as [Sin repetición]
            , case when confiActividad._bo_hastaCumplirTodasUnidades is null then 0 else confiActividad._bo_hastaCumplirTodasUnidades end as [Hasta cumplir unidades totales]
						
            --, case when confiActividad._do_plazo is null then 0 else confiActividad._do_plazo end as [Plazo]
			, confiActividad._in_Repeticiones as [Repeticiones]
            , confiActividad._in_veces as [Veces]
			--, confiActividad._do_frecuencia
			--, tiempoFrecuencia._st_Nombre
			, case when confiActividad._oo_unidadTiempoFrecuencia is null then 0 else (tiempoFrecuencia._do_EquivalenciaEn1Hora / 8) * confiActividad._do_frecuencia end as [Dias frecuencia]
			, case when confiActividad._do_plazo is null or confiActividad._oo_unidadTiempoPlazo is null then 0 else (tiempoPlazo._do_EquivalenciaEn1Hora / 8) * confiActividad._do_plazo end as [Dias Plazo]
			, '' as [Fecha Termino plazo]
            , '' as [Fechas de actividad]
			---------------------------------------------------------
            , actividadNomina._do_CostoPorUnidad as [@costo_unitario]
            , actividadNomina._do_unidadesTarea as [@valor_unidades]
            , medida._st_Nombre as [Medida]
            --------------------------------------------------------
            , esp2._do_LongitudPorCama as [@long_cama]
            , esp2._do_AreaPorCama as [@area_cama]
            , esp2._do_MetrosDesague as [@metros_desague]
            , esp2._do_MetrosPerimetro as [@metros_perimetro]
            , esp2._do_Numero_hectareas as [@no_ha]
            , esp2._fl_Separacion_entre_camas as [@separacion_camas]
            , esp2._in_Numero_de_camas as [@no_camas]
            , esp2._in_NumeroCaidas as [@no_caidas]
            , esp2._in_NumeroCasetas as [@no_casetas]
            , esp2._in_NumeroPerifericas as [@no_perifericas]
			, case when confiActividad._in_Repeticiones = 0 then 1 else confiActividad._in_Repeticiones end as [@dias_totales]
            , cast(0 as varchar(MAX)) as [Costo calculado]
            from _gen_Temporada temporada
            inner join _gen_Temporada_X__gen_ConfiguracionTemporada__ll_ConfiguracionesDeTemporada TempoConfTemporada on temporada.id = TempoConfTemporada._contenedor
            inner join _gen_ConfiguracionTemporada confTemporada on TempoConfTemporada._contenido = confTemporada.id
            inner join _gen_ConfiguracionTemporada_X__ps_EspacioFisico__ll_espaciosAsignados contTempEspaciosFisicos on confTemporada.id = contTempEspaciosFisicos._contenedor
            inner join _ps_EspacioFisico esp on contTempEspaciosFisicos._contenido = esp.id
            inner join _ps_EspacioFisico_X__ps_EspacioFisico__ll_Espacios_fisicos_dentro relEspFisico_EspFisico on esp.id = relEspFisico_EspFisico._contenedor
            inner join _ps_EspacioFisico esp2 on relEspFisico_EspFisico._contenido = esp2.id
            inner join _ps_EspacioFisico_X__ps_ConfiguracionSiembra__ll_Configuraciones_de_Siembra relEspFisico_ConfSiembra on esp2.id = relEspFisico_ConfSiembra._contenedor
            inner join _ps_ConfiguracionSiembra confSiembra on relEspFisico_ConfSiembra._contenido = confSiembra.id
            inner join _ps_EtapaConfiguracionSiembra etapa on confSiembra._oo_EtapaConfiguracionSiembra = etapa.id
            inner join _gen_Cultivo cultivo on confSiembra._oo_Cultivo_plantado = cultivo.id
            inner join _ps_ConfiguracionTecnologica confTecnologica on esp2._oo_Configuracion_tecnologica = confTecnologica.id
            inner join _ps_TecnologiaCultivo tecnologia on confTecnologica._oo_TecnologiaDeCultivoUsada = tecnologia.id
            inner join _gen_PerfilActividades perfil on tecnologia.id = perfil._oo_tecnologia and perfil._oo_cultivo = cultivo.id
            inner join _gen_PerfilActividades_X__gen_ConfiguracionActividadNominaPerfil__ll_ConfiguracionActividades relPerfil_configActividades on perfil.id = relPerfil_configActividades._contenedor
            inner join _gen_ConfiguracionActividadNominaPerfil confiActividad on relPerfil_configActividades._contenido = confiActividad.id
			
            inner join _gen_ActividadNomina actividadNomina on confiActividad._oo_Actividad = actividadNomina.id
            left join _gen_Formula formula on actividadNomina._oo_formulaCosto = formula.id
            left join _gen_UnidadDeMedida medida on actividadNomina._oo_UnidadMedidaDeTarea = medida.id
			--tiempos
			left join _gen_UnidadDeTiempo tiempoInicio on tiempoInicio.id = confiActividad._oo_unidadTiempoInicio
			left join _gen_UnidadDeTiempo tiempoFrecuencia on tiempoFrecuencia.id = confiActividad._oo_unidadTiempoFrecuencia
			left join _gen_UnidadDeTiempo tiempoPlazo on tiempoplazo.id = confiActividad._oo_unidadTiempoPlazo

            where temporada._st_NombreTemporada = 'Temporada 15-16'
            order by Campo, Tabla
            ");


            for (int i = 0; i < res.Rows.Count; i++)
            {
                DataRow dr = res.Rows[i];
                res.Columns["Costo calculado"].ReadOnly = false;
                double calculo = 0;
                calculo = CalcularImporte(dr);
                res.Rows[i]["Costo calculado"] = calculo; //Herramientas.Conversiones.Formatos.DoubleAMonedaANDecimales(calculo, 2);

                //calculando fechas
                DateTime fechaInicioActividad = Convert.ToDateTime(dr["Fecha inicio Actividad"].ToString());

                Boolean sinRepeticiones = dr["Sin repetición"].ToString().Equals("1");
                Boolean hastaCumplirUnidades = dr["Hasta cumplir unidades totales"].ToString().Equals("1");

                res.Columns["Fecha inicio Actividad"].ReadOnly = false;
                res.Columns["Fecha Termino plazo"].ReadOnly = false;
                res.Columns["Fechas de actividad"].ReadOnly = false;
                res.Columns["@dias_totales"].ReadOnly = false;

                res.Columns["Fecha Termino plazo"].MaxLength = 1000;
                res.Columns["Fechas de actividad"].MaxLength = 1000;

                res.Rows[i]["Fecha inicio Actividad"] = Herramientas.Conversiones.Formatos.DateTimeAFechaCorta(fechaInicioActividad);
                int diasPlazo = Convert.ToInt32(dr["Dias Plazo"].ToString());
                if (sinRepeticiones && diasPlazo == 0)
                {
                    res.Rows[i]["Fecha Termino plazo"] = dr["Fecha inicio Actividad"].ToString();
                    res.Rows[i]["Fechas de actividad"] = dr["Fecha inicio Actividad"].ToString();
                }
                else
                {
                    int repeticiones = Convert.ToInt32(dr["Repeticiones"].ToString());
                    int veces = Convert.ToInt32(dr["Veces"].ToString());



                    if (hastaCumplirUnidades)
                    {

                        double repeticionesCalculadas = (calculo) / ((Convert.ToDouble(res.Rows[i]["@costo_unitario"]) * Convert.ToDouble(res.Rows[i]["@valor_unidades"])) * veces);
                        repeticionesCalculadas = Convert.ToInt32(Math.Round(repeticionesCalculadas, MidpointRounding.AwayFromZero));
                        res.Rows[i]["@dias_totales"] = repeticionesCalculadas.ToString();
                        repeticiones = (int)repeticionesCalculadas;
                        //res.Rows[i]["Costo calculado"] = calculo
                    }
                    else
                    {
                        res.Rows[i]["Costo calculado"] = calculo * veces;
                    }
                    if (repeticiones > 0)
                    {
                        DateTime fechaFrecuencia = fechaInicioActividad;
                        int diasFrecuencia = Convert.ToInt32(dr["Dias frecuencia"].ToString());
                        res.Rows[i]["Fechas de actividad"] += Herramientas.Conversiones.Formatos.DateTimeAFechaCorta(fechaFrecuencia) + " | ";
                        for (int j = 0; j < repeticiones - 1; j++)
                        {
                            fechaFrecuencia = fechaFrecuencia.AddDays(diasFrecuencia);
                            res.Rows[i]["Fechas de actividad"] += Herramientas.Conversiones.Formatos.DateTimeAFechaCorta(fechaFrecuencia) + " | ";
                        }
                        String fechas = res.Rows[i]["Fechas de actividad"].ToString();
                        res.Rows[i]["Fechas de actividad"] = fechas.Substring(0, fechas.Length - 3);
                        res.Rows[i]["Fecha Termino plazo"] = Herramientas.Conversiones.Formatos.DateTimeAFechaCorta(fechaFrecuencia);
                    }
                    else
                    {
                        int diasTotalesCalculados = 0;
                        DateTime fechaFrecuencia = fechaInicioActividad;

                        DateTime fechaPlazo = fechaInicioActividad.AddDays(diasPlazo);

                        int diasFrecuencia = Convert.ToInt32(dr["Dias frecuencia"].ToString());
                        res.Rows[i]["Fechas de actividad"] += Herramientas.Conversiones.Formatos.DateTimeAFechaCorta(fechaFrecuencia) + " | ";
                        diasTotalesCalculados++;
                        while (fechaFrecuencia <= fechaPlazo)
                        {
                            fechaFrecuencia = fechaFrecuencia.AddDays(diasFrecuencia);
                            res.Rows[i]["Fechas de actividad"] += Herramientas.Conversiones.Formatos.DateTimeAFechaCorta(fechaFrecuencia) + " | ";
                            diasTotalesCalculados++;
                        }
                        String fechas = res.Rows[i]["Fechas de actividad"].ToString();

                        if (diasTotalesCalculados > 0)
                        {
                            res.Rows[i]["@dias_totales"] = diasTotalesCalculados.ToString();

                            calculo = CalcularImporte(dr);
                            res.Rows[i]["Costo calculado"] = calculo * veces; //Herramientas.Conversiones.Formatos.DoubleAMonedaANDecimales(calculo, 2);


                        }

                        res.Rows[i]["Fechas de actividad"] = fechas.Substring(0, fechas.Length - 3);
                        res.Rows[i]["Fecha Termino plazo"] = Herramientas.Conversiones.Formatos.DateTimeAFechaCorta(fechaFrecuencia);
                    }

                }
            }
            return res;
        }
        private double CalcularImporte(DataRow dr)
        {
            String formulaTareaOriginal = dr["Formula"].ToString();

            String formulaTarea = formulaTareaOriginal.ToLower();

            //foreach(String variable in Catalogos.win_gen_CatalogoFormulas.Variables)
            //    formulaTarea = formulaTarea.Replace(variable, dr[variable].ToString());

            formulaTarea = formulaTarea.Replace("@costo_unitario", dr["@costo_unitario"].ToString());
            formulaTarea = formulaTarea.Replace("@valor_unidades", dr["@valor_unidades"].ToString());
            formulaTarea = formulaTarea.Replace("@long_cama", dr["@long_cama"].ToString());
            formulaTarea = formulaTarea.Replace("@area_cama", dr["@area_cama"].ToString());
            formulaTarea = formulaTarea.Replace("@metros_desague", dr["@metros_desague"].ToString());
            formulaTarea = formulaTarea.Replace("@metros_perimetro", dr["@metros_perimetro"].ToString());
            formulaTarea = formulaTarea.Replace("@no_ha", dr["@no_ha"].ToString());
            formulaTarea = formulaTarea.Replace("@separacion_camas", dr["@separacion_camas"].ToString());
            formulaTarea = formulaTarea.Replace("@no_camas", dr["@no_camas"].ToString());
            formulaTarea = formulaTarea.Replace("@no_caidas", dr["@no_caidas"].ToString());
            formulaTarea = formulaTarea.Replace("@no_casetas", dr["@no_casetas"].ToString());
            formulaTarea = formulaTarea.Replace("@no_perifericas", dr["@no_perifericas"].ToString());
            formulaTarea = formulaTarea.Replace("@dias_totales", dr["@dias_totales"].ToString());

            double calculo = 0;
            
            if (!formulaTarea.Trim().Equals(""))
            {
                try
                {
                    int veces = Convert.ToInt32(dr["Veces"].ToString());

                    calculo = Herramientas.Calculos.Expresion.CalcularExpresionString(formulaTarea);
                    return calculo; // Herramientas.Conversiones.Formatos.DoubleAMonedaANDecimales(calculo, 2);
                }
                catch (Exception ex)
                {
                    return 0;
                }
            }
            return calculo;
        }
        

        private void Boton_MouseUp(object sender, MouseButtonEventArgs e)
        {
            CrearDataGrid();
            CargarDatos();
        }
    }
    
}
