using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio.Modulos.General;
using Dominio.Modulos.ProgramaSiembra;
using LogicaNegocios.ProgramaSiembra.Clases;
using Dominio;
using System.Data;
using Herramientas.ORM;

namespace LogicaNegocios.ProgramaSiembra
{
    public class ps_ln_Presupuesto
    {
        static ManejadorDB manejador = new ManejadorDB();

        public static Presupuesto ObtenerPresupuestoManoObra(_gen_Temporada Temporada, double salarioDiario)
        {

            DateTime inicioTemporada = Temporada.Dt_InicioTemporada;

            DataTable resultado = ObtenerInformacionActividades(Temporada);

            //calculando semanas de la temporada
            List<DateTime> fechasSemanasInicio = new List<DateTime>();
            List<DateTime> fechasSemanasFin = new List<DateTime>();

            DateTime fechaInicio = new DateTime(inicioTemporada.Year, inicioTemporada.Month, inicioTemporada.Day);
            for (int i = 0; i < 52; i++)
            {
                fechasSemanasInicio.Add(fechaInicio);
                DateTime fechaFin = fechaInicio.AddDays(6);
                fechasSemanasFin.Add(fechaFin);
                fechaInicio = fechaFin.AddDays(1);
            }

            Presupuesto presupuesto = new Presupuesto();
            presupuesto.Espacios = new List<EspacioFisico>();
            presupuesto.CostoTotalPorSemanaActividades = new double[52];
            presupuesto.CostoTotalPorSemanaMateriales = new double[52];
            presupuesto.JornalesTotalesPorSemanaActividades = new double[52];

            Dictionary<long, EspacioFisico> espacios = new Dictionary<long, EspacioFisico>();

            resultado.Columns["Fecha inicio actividad"].ReadOnly = false;
            resultado.Columns["Fecha Termino plazo"].ReadOnly = false;
            resultado.Columns["Fechas de actividad"].ReadOnly = false;
            resultado.Columns["@dias_totales"].ReadOnly = false;

            resultado.Columns["Fecha Termino plazo"].MaxLength = 100000;
            resultado.Columns["Fechas de actividad"].MaxLength = 100000;

            foreach (DataRow dr in resultado.Rows)
            {
                int idEspacio = Convert.ToInt32(dr["ID_ESPACIO"].ToString());
                int idEtapa = Convert.ToInt32(dr["ID_ETAPA"].ToString());
                int idPerfil = Convert.ToInt32(dr["ID_PERFIL"].ToString());
                int idActividad = Convert.ToInt32(dr["ID_ACTIVIDAD"].ToString());
                int idConfSiembra = Convert.ToInt32(dr["ID_CONFSIEMBRA"].ToString());

                _ps_EspacioFisico domEspacio = manejador.Cargar<_ps_EspacioFisico>(_ps_EspacioFisico.ConsultaPorID, new List<Object>() { idEspacio });
                _gen_Etapa domEtapa = manejador.Cargar<_gen_Etapa>(_gen_Etapa.ConsultaPorID, new List<Object>() { idEtapa });
                _gen_PerfilActividades domPerfil = manejador.Cargar<_gen_PerfilActividades>(_gen_PerfilActividades.ConsultaPorID, new List<Object>() { idPerfil });
                _gen_ActividadNomina domActividad = manejador.Cargar<_gen_ActividadNomina>(_gen_ActividadNomina.ConsultaPorID, new List<Object>() { idActividad });
                _ps_ConfiguracionSiembra domConfSiembra = manejador.Cargar<_ps_ConfiguracionSiembra>(_ps_ConfiguracionSiembra.ConsultaPorID, new List<object>() { idConfSiembra });



                int UsarPerdiodoProduccion = Convert.ToInt32(dr["Usar Periodo Produccion"].ToString());
                List<Double> CostosPorDiaProduccion = new List<double>();
                List<Double> cajasCortadas = new List<double>();
                List<Double> cajasEmpacadas = new List<double>();
                if (UsarPerdiodoProduccion == 1)
                {
                    //en esta seccion se calculan las fechas
                    if (domConfSiembra.Ll_CajasProyectadas != null && domConfSiembra.Ll_CajasProyectadas.Count > 0)
                    {
                        dr["Fecha inicio Actividad"] = domConfSiembra.Ll_CajasProyectadas[0].Dt_FechaProyeccion;
                        dr["Fecha Termino plazo"] = domConfSiembra.Ll_CajasProyectadas[domConfSiembra.Ll_CajasProyectadas.Count - 1].Dt_FechaProyeccion;
                        foreach (_ps_CajasCortYEmpProyectadas caja in domConfSiembra.Ll_CajasProyectadas)
                        {
                            dr["Fechas de actividad"] += caja.Dt_FechaProyeccion + "|";
                            cajasCortadas.Add(caja.Do_CantidadCorte);
                            cajasEmpacadas.Add(caja.Do_CantidadEmpaque);
                        }

                        dr["Fechas de actividad"] = dr["Fechas de actividad"].ToString().Substring(0, dr["Fechas de actividad"].ToString().Length - 1);
                    }
                    else
                        continue;
                }
                DateTime fechaInicioActividad = Convert.ToDateTime(dr["Fecha inicio Actividad"]);
                String fechasString = dr["Fechas de actividad"].ToString();
                List<DateTime> fechas = new List<DateTime>();

                List<String> fechasLista = fechasString.Split('|').ToList<String>();
                if (fechasLista.Count == 0)
                    continue;
                if (fechasLista.Count == 1 && fechasLista[0].Equals(""))
                    continue;
                foreach (String fecha in  fechasLista)
                {
                    DateTime dtFecha = Convert.ToDateTime(fecha);
                    fechas.Add(new DateTime(dtFecha.Year, dtFecha.Month, dtFecha.Day));
                }


                if (presupuesto.FechaMenor == DateTime.MinValue)
                    presupuesto.FechaMenor = fechaInicioActividad;

                if (presupuesto.FechaMenor > fechaInicioActividad)
                    presupuesto.FechaMenor = fechaInicioActividad;
                if (presupuesto.FechaMayor < fechas[fechas.Count - 1])
                    presupuesto.FechaMayor = fechas[fechas.Count - 1];

                double diasTotales = 0;
                double costoTotal = 0;
                double costoPorDia = 0;

                if (UsarPerdiodoProduccion == 0)
                {
                    diasTotales = Convert.ToDouble(dr["@dias_totales"].ToString());
                    costoTotal = Convert.ToDouble(dr["Costo calculado"].ToString());

                    costoPorDia = costoTotal / diasTotales;
                }
                else
                {
                    //en caso de usar el tiempo de la producción se calculan los costos por el dia
                    String formula = dr["Formula"].ToString();
                    if (formula == null || formula.Trim().Equals(""))
                        continue;

                    for (int i = 0; i < fechas.Count; i++)
                    {
                        formula = dr["Formula"].ToString();
                        formula = SustituirValores(dr, "Formula");
                        formula = formula.Replace("@unidades_corte", cajasCortadas[i].ToString());
                        formula = formula.Replace("@unidades_empaque", cajasEmpacadas[i].ToString());

                        costoPorDia = Herramientas.Calculos.Expresion.CalcularExpresionString(formula);

                        costoTotal += costoPorDia;

                        CostosPorDiaProduccion.Add(costoPorDia);

                    }
                    costoPorDia = 0;
                }

                EspacioFisico espacio = null;
                if (espacios.ContainsKey(domEspacio.Id))
                {
                    espacio = espacios[domEspacio.Id];
                }
                else
                {
                    espacio = new EspacioFisico();
                    espacio.Espacio = domEspacio;
                    presupuesto.Espacios.Add(espacio);
                    espacio.Perfiles = new List<PerfilActividad>();
                    espacios.Add(domEspacio.Id, espacio);
                }

                PerfilActividad perfil = null;

                foreach (PerfilActividad perfilTemp in espacio.Perfiles)
                {
                    if (perfilTemp.Perfil.Id == domPerfil.Id)
                        perfil = perfilTemp;
                }
                if (perfil == null)
                {
                    perfil = new PerfilActividad();
                    espacio.Perfiles.Add(perfil);
                    perfil.Actividades = new List<Actividad>();
                }


                perfil.Perfil = domPerfil;
                perfil.EspacioFisico = domEspacio;

                if (perfil.FechaMenor == DateTime.MinValue)
                    perfil.FechaMenor = fechaInicioActividad;
                if (perfil.FechaMenor > fechaInicioActividad)
                    perfil.FechaMenor = fechaInicioActividad;
                if (perfil.FechaMayor < fechas[fechas.Count - 1])
                    perfil.FechaMayor = fechas[fechas.Count - 1];

                if (espacio.FechaMenor == DateTime.MinValue)
                    espacio.FechaMenor = fechaInicioActividad;
                if (espacio.FechaMenor > fechaInicioActividad)
                    espacio.FechaMenor = fechaInicioActividad;
                if (espacio.FechaMayor < fechas[fechas.Count - 1])
                    espacio.FechaMayor = fechas[fechas.Count - 1];


                Actividad actividad = new Actividad();
                actividad.ActividadDominio = domActividad;
                actividad.CostoPorDia = costoPorDia;
                actividad.Fechas = fechas;

                //sacando equivalencia en horas para saber cuantos jornales de tiempo completo se
                //necesitan
                if (UsarPerdiodoProduccion == 0)
                {
                    if (domActividad.Oo_unidadTiempoDuracion == null)
                        continue;
                    double horas = domActividad.Oo_unidadTiempoDuracion.Do_EquivalenciaEn1Hora * domActividad.Do_duracion;

                    if (domActividad.Do_salarioDiarioRegistrado == 0) domActividad.Do_salarioDiarioRegistrado = salarioDiario;

                    double actividadesRealizadas = costoPorDia / domActividad.Do_salarioDiarioRegistrado;

                    double jornalesNecesarios = (actividadesRealizadas * horas) / 8;


                    //if (actividad.ActividadDominio.In_idCrop == 4712)
                    //    break;

                    actividad.GastoPorSemana = CargarGastosPorSemana(fechasSemanasInicio, fechasSemanasFin, actividad.Fechas, diasTotales, actividad.CostoPorDia);
                    actividad.JornalesPorSemana = CargarJornalesPorSemana(fechasSemanasInicio, fechasSemanasFin, actividad.Fechas, diasTotales, jornalesNecesarios);
                }
                else
                {
                    actividad.GastoPorSemana = CargarGastosPorSemana(fechasSemanasInicio, fechasSemanasFin, actividad.Fechas, CostosPorDiaProduccion);
                    //actividad.JornalesPorSemana = new Dictionary<int, double>(); // falta determinar numero de jornales
                }
                if (actividad.JornalesPorSemana != null && actividad.JornalesPorSemana.Count > 0)
                    for (int i = 0; i < 52; i++)
                    {
                        actividad.JornalesTotalTemporada += actividad.JornalesPorSemana[i];
                    }

                actividad.CostoTotalTemporada = costoTotal;
                perfil.Actividades.Add(actividad);

                if (espacio.SumatoriaCostosPorSemanaActividades == null) espacio.SumatoriaCostosPorSemanaActividades = new Double[52];
                if (espacio.SumatoriaJornalesPorSemana == null) espacio.SumatoriaJornalesPorSemana = new Double[52];

                //sumarizando los importes

                for (int i = 0; i < 52; i++)
                {
                    espacio.SumatoriaCostosPorSemanaActividades[i] += actividad.GastoPorSemana[i];
                }
                //sumarizando los jornales
                if (actividad.JornalesPorSemana != null && actividad.JornalesPorSemana.Count > 0)
                    for (int i = 0; i < 52; i++)
                    {
                        espacio.SumatoriaJornalesPorSemana[i] += actividad.JornalesPorSemana[i];
                    }

            }

            foreach (EspacioFisico espacio in presupuesto.Espacios)
            {
                for (int i = 0; i < 52; i++)
                {
                    presupuesto.CostoTotalPorSemanaActividades[i] += espacio.SumatoriaCostosPorSemanaActividades[i];
                    presupuesto.JornalesTotalesPorSemanaActividades[i] += espacio.SumatoriaJornalesPorSemana[i];
                }
            }

            return presupuesto;
        }
        public static Presupuesto ObtenerPresupuestoMateriales(_gen_Temporada Temporada)
        {
            DateTime inicioTemporada = Temporada.Dt_InicioTemporada;
            DataTable resultado = ObtenerInformacionMateriales(Temporada);
            DataTable resultadoMaterialesAsociados = ObtenerInformacionMaterialesAsociados(Temporada);

            //calculando semanas de la temporada
            List<DateTime> fechasSemanasInicio = new List<DateTime>();
            List<DateTime> fechasSemanasFin = new List<DateTime>();

            DateTime fechaInicio = new DateTime(inicioTemporada.Year, inicioTemporada.Month, inicioTemporada.Day);
            for (int i = 0; i < 52; i++)
            {
                fechasSemanasInicio.Add(fechaInicio);
                DateTime fechaFin = fechaInicio.AddDays(6);
                fechasSemanasFin.Add(fechaFin);
                fechaInicio = fechaFin.AddDays(1);
            }

            Presupuesto presupuesto = new Presupuesto();
            presupuesto.Espacios = new List<EspacioFisico>();
            presupuesto.CostoTotalPorSemanaActividades = new double[52];
            presupuesto.CostoTotalPorSemanaMateriales = new double[52];
            presupuesto.JornalesTotalesPorSemanaActividades = new double[52];

            Dictionary<long, EspacioFisico> espacios = new Dictionary<long, EspacioFisico>();

            resultado.Columns["Fecha inicio material"].ReadOnly = false;
            resultado.Columns["Fecha Termino plazo"].ReadOnly = false;
            resultado.Columns["Fechas de material"].ReadOnly = false;
            resultado.Columns["@dias_totales"].ReadOnly = false;

            resultado.Columns["Fecha Termino plazo"].MaxLength = 100000;
            resultado.Columns["Fechas de material"].MaxLength = 100000;

            for (int s = 0; s < resultado.Rows.Count; s++)
            {

                DataRow dr = resultado.Rows[s];

                int idEspacio = Convert.ToInt32(dr["ID_ESPACIO"].ToString());
                int idEtapa = Convert.ToInt32(dr["ID_ETAPA"].ToString());
                int idPerfil = Convert.ToInt32(dr["ID_PERFIL"].ToString());
                int idMaterial = Convert.ToInt32(dr["ID_MATERIAL"].ToString());
                int idConfSiembra = Convert.ToInt32(dr["ID_CONFSIEMBRA"].ToString());

                _ps_EspacioFisico domEspacio = manejador.Cargar<_ps_EspacioFisico>(_ps_EspacioFisico.ConsultaPorID, new List<Object>() { idEspacio });
                _gen_Etapa domEtapa = manejador.Cargar<_gen_Etapa>(_gen_Etapa.ConsultaPorID, new List<Object>() { idEtapa });
                _gen_PerfilActividades domPerfil = manejador.Cargar<_gen_PerfilActividades>(_gen_PerfilActividades.ConsultaPorID, new List<Object>() { idPerfil });
                _gen_Material domMaterial = manejador.Cargar<_gen_Material>(_gen_Material.ConsultaPorID, new List<Object>() { idMaterial });

                //if (domMaterial.In_CodigoCrop == 2039)
                //    break;

                int UsarPerdiodoProduccion = Convert.ToInt32(dr["Usar Periodo Produccion"].ToString());
                List<Double> CostosPorDiaProduccion = new List<double>();
                List<Double> cajasCortadas = new List<double>();
                List<Double> cajasEmpacadas = new List<double>();
                if (UsarPerdiodoProduccion == 1)
                {
                    _ps_ConfiguracionSiembra domConfSiembra = manejador.Cargar<_ps_ConfiguracionSiembra>(_ps_ConfiguracionSiembra.ConsultaPorID, new List<object>() { idConfSiembra });

                    //en esta seccion se calculan las fechas
                    //if (domConfSiembra.Ll_CajasProyectadas != null && domConfSiembra.Ll_CajasProyectadas.Count > 0)
                    //{
                    //    dr["Fecha inicio Material"] = domConfSiembra.Ll_CajasProyectadas[0].Dt_FechaProyeccion;
                    //    dr["Fecha Termino plazo"] = domConfSiembra.Ll_CajasProyectadas[domConfSiembra.Ll_CajasProyectadas.Count - 1].Dt_FechaProyeccion;
                    //    foreach (_ps_CajasCortYEmpProyectadas caja in domConfSiembra.Ll_CajasProyectadas)
                    //    {
                    //        dr["Fechas de Material"] += caja.Dt_FechaProyeccion + "|";
                    //        cajasCortadas.Add(caja.Do_CantidadCorte);
                    //        cajasEmpacadas.Add(caja.Do_CantidadEmpaque);
                    //    }

                    //    dr["Fechas de Material"] = dr["Fechas de Material"].ToString().Substring(0, dr["Fechas de Material"].ToString().Length - 1);
                    //}
                    //else
                    //    continue;

                    CalcularFechasMaterialPorPeriodo(ref domConfSiembra, ref dr, ref cajasCortadas, ref cajasEmpacadas);

                }

                DateTime fechaInicioActividad = Convert.ToDateTime(dr["Fecha inicio Material"]);

                #region calculando fechas y determinando fechas menores y mayores
                String fechasString = dr["Fechas de material"].ToString();
                List<DateTime> fechas = new List<DateTime>();
                List<String> fechasLista = fechasString.Split('|').ToList<String>();
                foreach (String fecha in fechasLista)
                {
                    DateTime dtFecha = Convert.ToDateTime(fecha);
                    fechas.Add(new DateTime(dtFecha.Year, dtFecha.Month, dtFecha.Day));
                }


                if (presupuesto.FechaMenor == DateTime.MinValue)
                    presupuesto.FechaMenor = fechaInicioActividad;

                if (presupuesto.FechaMenor > fechaInicioActividad)
                    presupuesto.FechaMenor = fechaInicioActividad;
                if (presupuesto.FechaMayor < fechas[fechas.Count - 1])
                    presupuesto.FechaMayor = fechas[fechas.Count - 1];
                #endregion

                double diasTotales = 0;
                double costoTotal = 0;
                double costoPorDia = 0;
                int veces = 0;
                double Calculo = 0;
                double costoMaterialUnitario = 0;

                #region verificando si existe un material variable
                Boolean encontrado = false;
                if (domMaterial.Bo_EsMaterialVariable)
                {
                    _ps_ConfiguracionSiembra domConfSiembra = manejador.Cargar<_ps_ConfiguracionSiembra>(_ps_ConfiguracionSiembra.ConsultaPorID, new List<object>() { idConfSiembra });
                    if (domConfSiembra.Ll_MaterialesVariable != null)
                    {
                        foreach (_gen_MaterialVariableEspecifico matVar in domConfSiembra.Ll_MaterialesVariable)
                        {
                            if (matVar.Oo_MaterialVariable.Id == domMaterial.Id)
                            {
                                encontrado = true;
                                if (matVar.Oo_MaterialEspecifico != null)
                                    domMaterial = matVar.Oo_MaterialEspecifico;
                                else
                                    domMaterial = domMaterial.Oo_MaterialEspecifico;
                                break;
                            }
                        }
                    }
                    if (!encontrado)
                        domMaterial = domMaterial.Oo_MaterialEspecifico;
                    costoMaterialUnitario = domMaterial.Do_PrecioUnitario;
                    dr["@costo_unitario_material"] = costoMaterialUnitario;
                    
                    Calculo = CalcularImporte(dr, "Formula");
                    dr["Costo calculado"] = Calculo;
                }
                #endregion

                costoMaterialUnitario = Convert.ToDouble(dr["@costo_unitario_material"].ToString());
                if (UsarPerdiodoProduccion == 0)
                {
                    diasTotales = Convert.ToDouble(dr["@dias_totales"].ToString());
                    veces = Convert.ToInt32(dr["Veces"].ToString());
                    Calculo = Convert.ToDouble(dr["Costo calculado"].ToString());

                    costoPorDia = Calculo * veces;
                }
                else
                {
                    //en caso de usar el tiempo de la producción se calculan los costos por el dia
                    String formula = dr["Formula"].ToString();
                    if (formula == null || formula.Trim().Equals(""))
                        continue;
                    for (int i = 0; i < fechas.Count; i++)
                    {

                        formula = dr["Formula"].ToString();
                        formula = SustituirValores(dr, "Formula");
                        formula = formula.Replace("@unidades_corte", cajasCortadas[i].ToString());
                        formula = formula.Replace("@unidades_empaque", cajasEmpacadas[i].ToString());

                        costoPorDia = Herramientas.Calculos.Expresion.CalcularExpresionString(formula);

                        costoTotal += costoPorDia;

                        CostosPorDiaProduccion.Add(costoPorDia);

                    }
                    costoPorDia = 0;
                }


                #region buscando espacios y perfiles de las listas
                EspacioFisico espacio = null;
                if (espacios.ContainsKey(domEspacio.Id))
                {
                    espacio = espacios[domEspacio.Id];
                }
                else
                {
                    espacio = new EspacioFisico();
                    espacio.Espacio = domEspacio;
                    presupuesto.Espacios.Add(espacio);
                    espacio.Perfiles = new List<PerfilActividad>();
                    espacios.Add(domEspacio.Id, espacio);
                }

                PerfilActividad perfil = null;

                foreach (PerfilActividad perfilTemp in espacio.Perfiles)
                {
                    if (perfilTemp.Perfil.Id == domPerfil.Id)
                        perfil = perfilTemp;
                }
                if (perfil == null)
                {
                    perfil = new PerfilActividad();
                    espacio.Perfiles.Add(perfil);
                    perfil.Materiales = new List<Material>();
                }


                perfil.Perfil = domPerfil;
                perfil.EspacioFisico = domEspacio;
                #endregion
                #region calculando fechas mayores y menores
                if (perfil.FechaMenor == DateTime.MinValue)
                    perfil.FechaMenor = fechaInicioActividad;
                if (perfil.FechaMenor > fechaInicioActividad)
                    perfil.FechaMenor = fechaInicioActividad;
                if (perfil.FechaMayor < fechas[fechas.Count - 1])
                    perfil.FechaMayor = fechas[fechas.Count - 1];

                if (espacio.FechaMenor == DateTime.MinValue)
                    espacio.FechaMenor = fechaInicioActividad;
                if (espacio.FechaMenor > fechaInicioActividad)
                    espacio.FechaMenor = fechaInicioActividad;
                if (espacio.FechaMayor < fechas[fechas.Count - 1])
                    espacio.FechaMayor = fechas[fechas.Count - 1];
                #endregion

                Material material = new Material();
                material.MaterialDominio = domMaterial;
                material.CostoPorDia = costoPorDia;
                material.UnidadesPorDia = costoPorDia / costoMaterialUnitario;
                material.Fechas = fechas;
                material.Medida = dr["Medida"].ToString();
                if (UsarPerdiodoProduccion == 0)
                {
                    material.GastoPorSemana = CargarGastosPorSemana(fechasSemanasInicio, fechasSemanasFin, material.Fechas, diasTotales, material.CostoPorDia);
                    material.UnidadesPorSemana = CargarUnidadesMaterialPorSemana(fechasSemanasInicio, fechasSemanasFin, material.Fechas, diasTotales, material.CostoPorDia, costoMaterialUnitario);
                    material.NumeroJornales = 0;
                    material.CostoTotalTemporada = costoPorDia * diasTotales;
                    material.UnidadesTotalestemporada = material.CostoTotalTemporada / costoMaterialUnitario;
                }
                else
                {
                    material.GastoPorSemana = CargarGastosPorSemana(fechasSemanasInicio, fechasSemanasFin, material.Fechas, CostosPorDiaProduccion);
                    material.UnidadesPorSemana = CargarUnidadesMaterialPorSemana(fechasSemanasInicio, fechasSemanasFin, material.Fechas, CostosPorDiaProduccion, costoMaterialUnitario);

                    foreach (double costo in CostosPorDiaProduccion)
                    {
                        material.CostoTotalTemporada += costo;
                        material.UnidadesTotalestemporada += costo / costoMaterialUnitario;
                    }
                }
                perfil.Materiales.Add(material);

                if (espacio.SumatoriaCostosPorSemanaMateriales == null) espacio.SumatoriaCostosPorSemanaMateriales = new Double[52];
                //sumarizando los costos de materiales
                for (int i = 0; i < 52; i++)
                {
                    espacio.SumatoriaCostosPorSemanaMateriales[i] += material.GastoPorSemana[i];
                }
            }
            //------------------------------------------------------------------------------------------------------------------------
            //procesando materiales asociados con actividades
            //------------------------------------------------------------------------------------------------------------------------

            resultadoMaterialesAsociados.Columns["Fecha inicio material"].ReadOnly = false;
            resultadoMaterialesAsociados.Columns["Fecha Termino plazo"].ReadOnly = false;
            resultadoMaterialesAsociados.Columns["Fechas de material"].ReadOnly = false;
            resultadoMaterialesAsociados.Columns["@dias_totales"].ReadOnly = false;

            resultadoMaterialesAsociados.Columns["Fecha Termino plazo"].MaxLength = 100000;
            resultadoMaterialesAsociados.Columns["Fechas de material"].MaxLength = 100000;

            for (int k = 0; k < resultadoMaterialesAsociados.Rows.Count; k++)
            {
                DataRow dr = resultadoMaterialesAsociados.Rows[k];


                int idEspacio = Convert.ToInt32(dr["ID_ESPACIO"].ToString());
                int idEtapa = Convert.ToInt32(dr["ID_ETAPA"].ToString());
                int idConfSiembra = Convert.ToInt32(dr["ID_CONFSIEMBRA"].ToString());

                int idPerfil = Convert.ToInt32(dr["ID_PERFIL"].ToString());
                int idMaterial = Convert.ToInt32(dr["ID_MATERIAL_ASOCIADO"].ToString());
                //double unidadesMaterial = Convert.ToDouble(dr["UNIDADES_MATERIAL"].ToString());
                int veces = Convert.ToInt32(dr["Veces"].ToString());
                double costoUnitarioMaterial = Convert.ToDouble(dr["@costo_unitario_material"].ToString());


                _ps_EspacioFisico domEspacio = manejador.Cargar<_ps_EspacioFisico>(_ps_EspacioFisico.ConsultaPorID, new List<Object>() { idEspacio });
                _gen_Etapa domEtapa = manejador.Cargar<_gen_Etapa>(_gen_Etapa.ConsultaPorID, new List<Object>() { idEtapa });
                _gen_PerfilActividades domPerfil = manejador.Cargar<_gen_PerfilActividades>(_gen_PerfilActividades.ConsultaPorID, new List<Object>() { idPerfil });
                _gen_Material domMaterial = manejador.Cargar<_gen_Material>(_gen_Material.ConsultaPorID, new List<Object>() { idMaterial });

                int UsarPerdiodoProduccion = Convert.ToInt32(dr["Usar Periodo Produccion"].ToString());
                List<Double> CostosPorDiaProduccion = new List<double>();
                List<Double> cajasCortadas = new List<double>();
                List<Double> cajasEmpacadas = new List<double>();
                if (UsarPerdiodoProduccion == 1)
                {
                    _ps_ConfiguracionSiembra domConfSiembra = manejador.Cargar<_ps_ConfiguracionSiembra>(_ps_ConfiguracionSiembra.ConsultaPorID, new List<object>() { idConfSiembra });

                    CalcularFechasMaterialPorPeriodo(ref domConfSiembra, ref dr, ref cajasCortadas, ref cajasEmpacadas);
                }

                DateTime fechaInicioActividad = Convert.ToDateTime(dr["Fecha inicio Material"]);
                #region convirtiendo fechas y determinando fechas mayores y menores
                String fechasString = dr["Fechas de material"].ToString();
                List<DateTime> fechas = new List<DateTime>();
                List<String> fechasLista = fechasString.Split('|').ToList<String>();
                foreach (String fecha in fechasLista)
                    fechas.Add(Convert.ToDateTime(fecha));

                if (presupuesto.FechaMenor == DateTime.MinValue)
                    presupuesto.FechaMenor = fechaInicioActividad;

                if (presupuesto.FechaMenor > fechaInicioActividad)
                    presupuesto.FechaMenor = fechaInicioActividad;
                if (presupuesto.FechaMayor < fechas[fechas.Count - 1])
                    presupuesto.FechaMayor = fechas[fechas.Count - 1];

                #endregion

                double diasTotales = 0;
                double costoTotalMaterialPorActividad = 0;
                double costoPorDia = 0;
                double costoTotal = 0;
                #region verificando si es un material variable
                Boolean encontrado = false;
                if (domMaterial.Bo_EsMaterialVariable)
                {
                    //si hay un material variable, se busca el materiale especifico que se asigno en la configuracion de siembra
                    _ps_ConfiguracionSiembra domConfSiembra = manejador.Cargar<_ps_ConfiguracionSiembra>(_ps_ConfiguracionSiembra.ConsultaPorID, new List<object>() { idConfSiembra });
                    if (domConfSiembra.Ll_MaterialesVariable != null)
                    {
                        foreach (_gen_MaterialVariableEspecifico matVar in domConfSiembra.Ll_MaterialesVariable)
                        {
                            if (matVar.Oo_MaterialVariable.Id == domMaterial.Id)
                            {
                                encontrado = true;
                                if (matVar.Oo_MaterialEspecifico != null)
                                    domMaterial = matVar.Oo_MaterialEspecifico;
                                else
                                    domMaterial = domMaterial.Oo_MaterialEspecifico;
                                break;
                            }
                        }
                    }
                    if (!encontrado)
                        domMaterial = domMaterial.Oo_MaterialEspecifico;
                    costoUnitarioMaterial = domMaterial.Do_PrecioUnitario;
                    dr["@costo_unitario_material"] = costoUnitarioMaterial;
                    costoTotalMaterialPorActividad = CalcularImporte(dr, "Formula Material");
                    dr["Costo calculado material"] = costoTotalMaterialPorActividad;
                }
                #endregion
                double costoMaterialUnitario = Convert.ToDouble(dr["@costo_unitario_material"].ToString());
                //calculando el costo
                if (UsarPerdiodoProduccion == 0)
                {
                    diasTotales = Convert.ToDouble(dr["@dias_totales"].ToString());
                    costoTotalMaterialPorActividad = Convert.ToDouble(dr["Costo calculado material"].ToString());
                    costoPorDia = costoTotalMaterialPorActividad * veces;// costoTotal / diasTotales;
                }
                else
                {
                    //en caso de usar el tiempo de la producción se calculan los costos por el dia
                    String formula = dr["Formula Material"].ToString();
                    if (formula == null || formula.Trim().Equals(""))
                        continue;
                    for (int i = 0; i < fechas.Count; i++)
                    {

                        formula = dr["Formula Material"].ToString();
                        formula = SustituirValores(dr, "Formula Material");
                        formula = formula.Replace("@unidades_corte", cajasCortadas[i].ToString());
                        formula = formula.Replace("@unidades_empaque", cajasEmpacadas[i].ToString());

                        costoPorDia = Herramientas.Calculos.Expresion.CalcularExpresionString(formula);

                        costoTotal += costoPorDia;

                        CostosPorDiaProduccion.Add(costoPorDia);

                    }
                    costoPorDia = 0;
                }


                #region buscando los objetos de las listas cargadas
                EspacioFisico espacio = null;
                if (espacios.ContainsKey(domEspacio.Id))
                {
                    espacio = espacios[domEspacio.Id];
                }
                else
                {
                    espacio = new EspacioFisico();
                    espacio.Espacio = domEspacio;
                    presupuesto.Espacios.Add(espacio);
                    espacio.Perfiles = new List<PerfilActividad>();
                    espacios.Add(domEspacio.Id, espacio);
                }

                PerfilActividad perfil = null;

                foreach (PerfilActividad perfilTemp in espacio.Perfiles)
                {
                    if (perfilTemp.Perfil.Id == domPerfil.Id)
                        perfil = perfilTemp;
                }
                if (perfil == null)
                {
                    perfil = new PerfilActividad();
                    espacio.Perfiles.Add(perfil);
                    perfil.Materiales = new List<Material>();
                }


                perfil.Perfil = domPerfil;
                perfil.EspacioFisico = domEspacio;

                if (perfil.FechaMenor == DateTime.MinValue)
                    perfil.FechaMenor = fechaInicioActividad;
                if (perfil.FechaMenor > fechaInicioActividad)
                    perfil.FechaMenor = fechaInicioActividad;
                if (perfil.FechaMayor < fechas[fechas.Count - 1])
                    perfil.FechaMayor = fechas[fechas.Count - 1];

                if (espacio.FechaMenor == DateTime.MinValue)
                    espacio.FechaMenor = fechaInicioActividad;
                if (espacio.FechaMenor > fechaInicioActividad)
                    espacio.FechaMenor = fechaInicioActividad;
                if (espacio.FechaMayor < fechas[fechas.Count - 1])
                    espacio.FechaMayor = fechas[fechas.Count - 1];
                #endregion

                Material material = new Material();
                material.MaterialDominio = domMaterial;
                material.CostoPorDia = costoPorDia;
                material.UnidadesPorDia = costoPorDia / costoUnitarioMaterial;
                material.Fechas = fechas;

                //if (actividad.ActividadDominio.In_idCrop == 4712)
                //    break;
                if (UsarPerdiodoProduccion == 0)
                {
                    material.GastoPorSemana = CargarGastosPorSemana(fechasSemanasInicio, fechasSemanasFin, material.Fechas, diasTotales, material.CostoPorDia);
                    material.UnidadesPorSemana = CargarUnidadesMaterialPorSemana(fechasSemanasInicio, fechasSemanasFin, material.Fechas, diasTotales, material.CostoPorDia, costoUnitarioMaterial);
                    material.NumeroJornales = 0;
                    material.CostoTotalTemporada = diasTotales * costoPorDia;
                    material.UnidadesTotalestemporada = material.CostoTotalTemporada / costoUnitarioMaterial;
                    
                }
                else
                {
                    material.GastoPorSemana = CargarGastosPorSemana(fechasSemanasInicio, fechasSemanasFin, material.Fechas, CostosPorDiaProduccion);
                    material.UnidadesPorSemana = CargarUnidadesMaterialPorSemana(fechasSemanasInicio, fechasSemanasFin, material.Fechas, CostosPorDiaProduccion, costoMaterialUnitario);
                }
                perfil.Materiales.Add(material);
                if (espacio.SumatoriaCostosPorSemanaMateriales == null) espacio.SumatoriaCostosPorSemanaMateriales = new Double[52];
                //sumarizando costos materiales
                for (int i = 0; i < 52; i++)
                {
                    espacio.SumatoriaCostosPorSemanaMateriales[i] += material.GastoPorSemana[i];
                }

            }

            foreach (EspacioFisico espacio in presupuesto.Espacios)
            {
                for (int i = 0; i < 52; i++)
                {
                    presupuesto.CostoTotalPorSemanaMateriales[i] += espacio.SumatoriaCostosPorSemanaMateriales[i];
                }
            }

            return presupuesto;
        }

        private static void CalcularFechasMaterialPorPeriodo(ref _ps_ConfiguracionSiembra domConfSiembra, ref DataRow dr, ref List<double> cajasCortadas, ref List<double> cajasEmpacadas)
        {
            //en esta seccion se calculan las fechas
            dr["Fechas de Material"] = "";
            if (domConfSiembra.Ll_CajasProyectadas != null && domConfSiembra.Ll_CajasProyectadas.Count > 0)
            {
                dr["Fecha inicio Material"] = domConfSiembra.Ll_CajasProyectadas[0].Dt_FechaProyeccion;
                dr["Fecha Termino plazo"] = domConfSiembra.Ll_CajasProyectadas[domConfSiembra.Ll_CajasProyectadas.Count - 1].Dt_FechaProyeccion;
                foreach (_ps_CajasCortYEmpProyectadas caja in domConfSiembra.Ll_CajasProyectadas)
                {
                    dr["Fechas de Material"] += caja.Dt_FechaProyeccion + "|";
                    cajasCortadas.Add(caja.Do_CantidadCorte);
                    cajasEmpacadas.Add(caja.Do_CantidadEmpaque);
                }

                dr["Fechas de Material"] = dr["Fechas de Material"].ToString().Substring(0, dr["Fechas de Material"].ToString().Length - 1);
            }
            else
                return;
        }

        private static Dictionary<int, double> CargarGastosPorSemana(List<DateTime> fechasSemanaInicio, List<DateTime> fechasSemanaFin, List<DateTime> fechas, List<double> costos)
        {
            Dictionary<int, double> semanas = new Dictionary<int, double>();
            for (int i = 0; i < 52; i++)
                semanas.Add(i, 0);

            int fechasContador = fechas.Count;

            for (int j = 0; j < fechasContador; j++)
            {
                DateTime fecha = fechas[j];
                if (fechasSemanaInicio[0] > fecha)
                {
                    semanas[0] += costos[j];
                    continue;
                }

                for (int i = 0; i < 52; i++)
                {
                    if (fecha >= fechasSemanaInicio[i] && fecha < fechasSemanaFin[i].AddDays(1))
                    {
                        semanas[i] += costos[j];
                        break;
                    }
                }
            }

            return semanas;
        }
        private static Dictionary<int, double> CargarGastosPorSemana(List<DateTime> fechasSemanaInicio, List<DateTime> fechasSemanaFin, List<DateTime> fechas, double diasTotalesReales, double costoPorDia)
        {
            Dictionary<int, double> semanas = new Dictionary<int, double>();
            for (int i = 0; i < 52; i++)
                semanas.Add(i, 0);

            int fechasContador = fechas.Count;

            if (fechasContador > diasTotalesReales)
                fechasContador--;


            for (int j = 0; j < fechasContador; j++)
            {
                DateTime fecha = fechas[j];
                if (fechasSemanaInicio[0] > fecha)
                {
                    semanas[0] += costoPorDia;
                    continue;
                }

                for (int i = 0; i < 52; i++)
                {
                    if (fecha >= fechasSemanaInicio[i] && fecha <= fechasSemanaFin[i])
                    {
                        semanas[i] += costoPorDia;
                        break;
                    }
                }
            }
            //si hay fracciones de dia no considerados, se le suma el equivalente a la fraccion de dia del costo por dia del material
            if (fechasContador < diasTotalesReales)
            {
                DateTime fecha = fechas[fechas.Count - 1];
                if (fechasSemanaInicio[0] > fecha)
                {
                    semanas[0] += costoPorDia * (diasTotalesReales - fechasContador);
                }

                for (int i = 0; i < 52; i++)
                {
                    if (fecha >= fechasSemanaInicio[i] && fecha <= fechasSemanaFin[i])
                    {
                        semanas[i] += costoPorDia * (diasTotalesReales - fechasContador);
                        break;
                    }
                }
            }

            return semanas;
        }
        private static Dictionary<int, double> CargarUnidadesMaterialPorSemana(List<DateTime> fechasSemanaInicio, List<DateTime> fechasSemanaFin, List<DateTime> fechas, double diasTotalesReales, double costoPorDia, double precioUnitario)
        {
            Dictionary<int, double> semanas = new Dictionary<int, double>();
            for (int i = 0; i < 52; i++)
                semanas.Add(i, 0);

            int fechasContador = fechas.Count;

            if (fechasContador > diasTotalesReales)
                fechasContador--;


            for (int j = 0; j < fechasContador; j++)
            {
                DateTime fecha = fechas[j];
                //en caso de q la fecha este fuera de la temporada se carga a la primer semana de la temporada
                if (fechasSemanaInicio[0] > fecha)
                {
                    semanas[0] += costoPorDia / precioUnitario;
                    continue;
                }

                for (int i = 0; i < 52; i++)
                {
                    if (fecha >= fechasSemanaInicio[i] && fecha <= fechasSemanaFin[i])
                    {
                        semanas[i] += costoPorDia / precioUnitario;
                        break;
                    }
                }
            }
            //si hay fracciones de dia no considerados, se le suma el equivalente a la fraccion de dia del costo por dia del material
            if (fechasContador < diasTotalesReales)
            {
                DateTime fecha = fechas[fechas.Count - 1];
                if (fechasSemanaInicio[0] > fecha)
                {
                    semanas[0] += (costoPorDia * (diasTotalesReales - fechasContador)) / precioUnitario;
                }

                for (int i = 0; i < 52; i++)
                {
                    if (fecha >= fechasSemanaInicio[i] && fecha <= fechasSemanaFin[i])
                    {
                        semanas[i] += (costoPorDia * (diasTotalesReales - fechasContador)) / precioUnitario;
                        break;
                    }
                }
            }

            return semanas;
        }
        private static Dictionary<int, double> CargarUnidadesMaterialPorSemana(List<DateTime> fechasSemanaInicio, List<DateTime> fechasSemanaFin, List<DateTime> fechas, List<double> costoPorDia, double precioUnitario)
        {
            Dictionary<int, double> semanas = new Dictionary<int, double>();
            for (int i = 0; i < 52; i++)
                semanas.Add(i, 0);

            int fechasContador = fechas.Count;

            for (int j = 0; j < fechasContador; j++)
            {
                DateTime fecha = fechas[j];
                //en caso de q la fecha este fuera de la temporada se carga a la primer semana de la temporada
                if (fechasSemanaInicio[0] > fecha)
                {
                    semanas[0] += costoPorDia[j] / precioUnitario;
                    continue;
                }

                for (int i = 0; i < 52; i++)
                {
                    if (fecha >= fechasSemanaInicio[i] && fecha <= fechasSemanaFin[i])
                    {
                        semanas[i] += costoPorDia[j] / precioUnitario;
                        break;
                    }
                }
            }

            return semanas;
        }
        private static Dictionary<int, double> CargarJornalesPorSemana(List<DateTime> fechasSemanaInicio, List<DateTime> fechasSemanaFin, List<DateTime> fechas, double diasTotalesReales, double jornalesNecesarios)
        {
            Dictionary<int, double> semanas = new Dictionary<int, double>();
            for (int i = 0; i < 52; i++)
                semanas.Add(i, 0);

            int fechasContador = fechas.Count;

            if (fechasContador > diasTotalesReales)
                fechasContador--;


            for (int j = 0; j < fechasContador; j++)
            {
                DateTime fecha = fechas[j];
                if (fechasSemanaInicio[0] > fecha)
                {
                    semanas[0] += jornalesNecesarios;
                    continue;
                }

                for (int i = 0; i < 52; i++)
                {
                    if (fecha >= fechasSemanaInicio[i] && fecha <= fechasSemanaFin[i])
                    {
                        semanas[i] += jornalesNecesarios;
                        break;
                    }
                }
            }
            //si hay fracciones de dia no considerados, se le suma el equivalente a la fraccion de dia del costo por dia del material
            if (fechasContador < diasTotalesReales)
            {
                DateTime fecha = fechas[fechas.Count - 1];
                if (fechasSemanaInicio[0] > fecha)
                {
                    semanas[0] += jornalesNecesarios * (diasTotalesReales - fechasContador);
                }

                for (int i = 0; i < 52; i++)
                {
                    if (fecha >= fechasSemanaInicio[i] && fecha <= fechasSemanaFin[i])
                    {
                        semanas[i] += jornalesNecesarios * (diasTotalesReales - fechasContador);
                        break;
                    }
                }
            }

            return semanas;
        }
        public static DataTable ObtenerInformacionHectareasPorCultivo(_gen_Temporada Temporada)
        {
            DataTable res = manejador.EjecutarConsulta(@"select 
			cultivo.id as [ID_CULTIVO]
			, tecnologia.id as [ID_TECNOLOGIA]
            --, cultivo._st_Nombre_cultivo as [Cultivo]
			--, tecnologia._st_Descripcion as [Tecnologia]
			, sum(esp2._do_Numero_hectareas) as [Hectareas]
            
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
           

            where temporada.id = @id
            and confTemporada.id = 
            (
	            select top 1 confTemp.id 
	            from _gen_Temporada_X__gen_ConfiguracionTemporada__ll_ConfiguracionesDeTemporada temp_conftemp
	            inner join _gen_ConfiguracionTemporada confTemp on temp_conftemp._contenido = confTemp.id
	            where _contenedor = temporada.id and confTemp._bo_EsVersionLiberada = 1
	            order by confTemp.dtFechaModificacion desc
            )
			group by cultivo.id, tecnologia.id
            order by cultivo.id, tecnologia.id
			", new List<Object>() { Temporada.Id });

            return res;
        }
        public static DataTable ObtenerInformacionActividades(_gen_Temporada Temporada)
        {
            DataTable res = manejador.EjecutarConsulta(@"
            select 
            --esp._st_Nombre_espacio as [Campo]
             esp2.id as [ID_ESPACIO]
            --, esp2._st_Nombre_espacio as [Tabla]
            , tecnologia.id as [ID_TECNOLOGIA]
            , cultivo.id as [ID_CULTIVO]
            , confSiembra.id as [ID_CONFSIEMBRA]
            , etapa.id as [ID_ETAPA]
            --, etapa._st_NombreEtapa as [Etapa]
            , perfil.id as [ID_PERFIL]
            --, perfil._st_NombrePerfil as [Perfil aplicado]
            , actividadNomina.id as [ID_ACTIVIDAD]
            --, cast(actividadNomina._in_idCrop as varchar(MAX)) + ' - ' + actividadNomina._st_Nombre as [Actividades dentro del perfil]
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
            , case when confiActividad._bo_UsarPeriodoDeProduccion is null then 0 else confiActividad._bo_UsarPeriodoDeProduccion end [Usar Periodo Produccion]
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
            , actividadNomina._do_CostoPorUnidad as [@costo_unitario_actividad]
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
            , confSiembra._do_Densidad_PlantasXMetro2 as [@densidad_planteo]
            , cultivo._do_PorcentajeDeSemillaAdicional as [@porcentaje_semilla_adicional]
            , 0.0 as [@ha_totales_cult_tec]
            , case when confiActividad._in_Repeticiones = 0 then 1.0 else confiActividad._in_Repeticiones end as [@dias_totales]
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

            where temporada.id = " + Temporada.Id+ @"
            and confTemporada.id = 
            (
	            select top 1 confTemp.id 
	            from _gen_Temporada_X__gen_ConfiguracionTemporada__ll_ConfiguracionesDeTemporada temp_conftemp
	            inner join _gen_ConfiguracionTemporada confTemp on temp_conftemp._contenido = confTemp.id
	            where _contenedor = temporada.id and confTemp._bo_EsVersionLiberada = 1
	            order by confTemp.dtFechaModificacion desc
            )
            --order by ID_ESPACIO, ID_ETAPA, ID_PERFIL, [Fecha inicio Actividad]

            union all

            select 
                esp2.id as [ID_ESPACIO]
            , tecnologia.id as [ID_TECNOLOGIA]
            , cultivo.id as [ID_CULTIVO]
            , confSiembra.id as [ID_CONFSIEMBRA]
            , etapa.id as [ID_ETAPA]
            , perfil.id as [ID_PERFIL]
            , actividadNomina.id as [ID_ACTIVIDAD]
            , formula._st_Formula as [Formula]
            , case 
            when confiActividad._in_FechaInicioRespecto = 0 
            then Convert(varchar, dateadd(day,(cultivo._in_DiasAntesSiembra * -1) + (tiempoInicio._do_EquivalenciaEn1Hora / 8) * confiActividad._do_tiempoRelativoInicio,confSiembra._dt_Fecha_de_planteo), 120)
            when confiActividad._in_FechaInicioRespecto = 1 
            then Convert(varchar,dateadd(day,(tiempoInicio._do_EquivalenciaEn1Hora / 8) * confiActividad._do_tiempoRelativoInicio,confSiembra._dt_Fecha_de_planteo), 120)
            when confiActividad._in_FechaInicioRespecto = 2
            then Convert(varchar,dateadd(day,cultivo._in_DiasDespuesCosecha + (tiempoInicio._do_EquivalenciaEn1Hora / 8) * confiActividad._do_tiempoRelativoInicio,confSiembra._dt_Fecha_de_planteo), 120)
            end as [Fecha inicio Actividad]
            , case when confiActividad._bo_UsarPeriodoDeProduccion is null then 0 else confiActividad._bo_UsarPeriodoDeProduccion end [Usar Periodo Produccion]
            , case when confiActividad._bo_SinRepeticiones is null then 0 else confiActividad._bo_SinRepeticiones end as [Sin repetición]
            , case when confiActividad._bo_hastaCumplirTodasUnidades is null then 0 else confiActividad._bo_hastaCumplirTodasUnidades end as [Hasta cumplir unidades totales]
						
            , confiActividad._in_Repeticiones as [Repeticiones]
            , confiActividad._in_veces as [Veces]
            , case when confiActividad._oo_unidadTiempoFrecuencia is null then 0 else (tiempoFrecuencia._do_EquivalenciaEn1Hora / 8) * confiActividad._do_frecuencia end as [Dias frecuencia]
            , case when confiActividad._do_plazo is null or confiActividad._oo_unidadTiempoPlazo is null then 0 else (tiempoPlazo._do_EquivalenciaEn1Hora / 8) * confiActividad._do_plazo end as [Dias Plazo]
            , '' as [Fecha Termino plazo]
            , '' as [Fechas de actividad]
            ---------------------------------------------------------
            , actividadNomina._do_CostoPorUnidad as [@costo_unitario_actividad]
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
            , confSiembra._do_Densidad_PlantasXMetro2 as [@densidad_planteo]
            , cultivo._do_PorcentajeDeSemillaAdicional as [@porcentaje_semilla_adicional]
            , 0.0 as [@ha_totales_cult_tec]
            , case when confiActividad._in_Repeticiones = 0 then 1.0 else confiActividad._in_Repeticiones end as [@dias_totales]
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

            inner join _ps_ConfiguracionSiembra_X__gen_PerfilActividades__ll_PerfilActividadesManuales perfManuales on confSiembra.id = perfManuales._contenedor
            inner join _gen_PerfilActividades perfil on perfil.id = perfManuales._contenido

            inner join _gen_PerfilActividades_X__gen_ConfiguracionActividadNominaPerfil__ll_ConfiguracionActividades relPerfil_configActividades on perfil.id = relPerfil_configActividades._contenedor
            inner join _gen_ConfiguracionActividadNominaPerfil confiActividad on relPerfil_configActividades._contenido = confiActividad.id
			
            inner join _gen_ActividadNomina actividadNomina on confiActividad._oo_Actividad = actividadNomina.id
            left join _gen_Formula formula on actividadNomina._oo_formulaCosto = formula.id
            left join _gen_UnidadDeMedida medida on actividadNomina._oo_UnidadMedidaDeTarea = medida.id
            --tiempos
            left join _gen_UnidadDeTiempo tiempoInicio on tiempoInicio.id = confiActividad._oo_unidadTiempoInicio
            left join _gen_UnidadDeTiempo tiempoFrecuencia on tiempoFrecuencia.id = confiActividad._oo_unidadTiempoFrecuencia
            left join _gen_UnidadDeTiempo tiempoPlazo on tiempoplazo.id = confiActividad._oo_unidadTiempoPlazo

            where temporada.id = " + Temporada.Id + @"
            and confTemporada.id = 
            (
	            select top 1 confTemp.id 
	            from _gen_Temporada_X__gen_ConfiguracionTemporada__ll_ConfiguracionesDeTemporada temp_conftemp
	            inner join _gen_ConfiguracionTemporada confTemp on temp_conftemp._contenido = confTemp.id
	            where _contenedor = temporada.id and confTemp._bo_EsVersionLiberada = 1
	            order by confTemp.dtFechaModificacion desc
            )
            order by ID_ESPACIO, ID_ETAPA, ID_PERFIL, [Fecha inicio Actividad]
            ");


            DataTable hectareasCultivo = ObtenerInformacionHectareasPorCultivo(Temporada);


            for (int i = 0; i < res.Rows.Count; i++)
            {
                DataRow dr = res.Rows[i];
                res.Columns["Costo calculado"].ReadOnly = false;
                res.Columns["@ha_totales_cult_tec"].ReadOnly = false;
                double calculo = 0;
                calculo = CalcularImporte(dr, "Formula");
                res.Rows[i]["Costo calculado"] = calculo; //Herramientas.Conversiones.Formatos.DoubleAMonedaANDecimales(calculo, 2);

                //calculando fechas
                String idCultivo = res.Rows[i]["ID_CULTIVO"].ToString();
                String idTecnologia = res.Rows[i]["ID_TECNOLOGIA"].ToString();

                for (int j = 0; j < hectareasCultivo.Rows.Count; j++)
                {
                    if (hectareasCultivo.Rows[j]["ID_CULTIVO"].ToString().Equals(idCultivo) && hectareasCultivo.Rows[j]["ID_TECNOLOGIA"].ToString().Equals(idTecnologia))
                    {
                        res.Rows[i]["@ha_totales_cult_tec"] = hectareasCultivo.Rows[j]["Hectareas"].ToString();
                        break;
                    }

                }


                int UsarPerdiodoProduccion = Convert.ToInt32(dr["Usar Periodo Produccion"].ToString());
                if (UsarPerdiodoProduccion == 1)
                    continue;


                DateTime fechaInicioActividad = Convert.ToDateTime(dr["Fecha inicio Actividad"].ToString());
                if (fechaInicioActividad == null)
                {
                    
                }

                Boolean sinRepeticiones = dr["Sin repetición"].ToString().Equals("1");
                Boolean hastaCumplirUnidades = dr["Hasta cumplir unidades totales"].ToString().Equals("1");

                res.Columns["Fecha inicio Actividad"].ReadOnly = false;
                res.Columns["Fecha Termino plazo"].ReadOnly = false;
                res.Columns["Fechas de actividad"].ReadOnly = false;
                res.Columns["@dias_totales"].ReadOnly = false;

                res.Columns["Fecha Termino plazo"].MaxLength = 100000;
                res.Columns["Fechas de actividad"].MaxLength = 100000;

                res.Rows[i]["Fecha inicio Actividad"] = Herramientas.Conversiones.Formatos.DateTimeAFechaCorta(fechaInicioActividad);
                int diasPlazo = Convert.ToInt32(dr["Dias Plazo"].ToString());
                if (sinRepeticiones && diasPlazo == 0)
                {
                    res.Rows[i]["Fecha Termino plazo"] = dr["Fecha inicio Actividad"].ToString();
                    res.Rows[i]["Fechas de actividad"] = dr["Fecha inicio Actividad"].ToString();
                }
                else
                {
                    double repeticiones = Convert.ToInt32(dr["Repeticiones"].ToString());
                    int veces = Convert.ToInt32(dr["Veces"].ToString());



                    if (hastaCumplirUnidades)
                    {
                        if (res.Rows[i]["@costo_unitario_actividad"] == DBNull.Value || res.Rows[i]["@valor_unidades"] == DBNull.Value)
                            continue;

                        double repeticionesCalculadas = (calculo) / ((Convert.ToDouble(res.Rows[i]["@costo_unitario_actividad"]) * Convert.ToDouble(res.Rows[i]["@valor_unidades"])) * veces);

                        res.Rows[i]["@dias_totales"] = repeticionesCalculadas.ToString();
                        repeticiones = Math.Ceiling(repeticionesCalculadas);
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

                            calculo = CalcularImporte(dr, "Formula");
                            res.Rows[i]["Costo calculado"] = calculo * veces; //Herramientas.Conversiones.Formatos.DoubleAMonedaANDecimales(calculo, 2);


                        }

                        res.Rows[i]["Fechas de actividad"] = fechas.Substring(0, fechas.Length - 3);
                        res.Rows[i]["Fecha Termino plazo"] = Herramientas.Conversiones.Formatos.DateTimeAFechaCorta(fechaFrecuencia);
                    }

                }
            }
            return res;
        }
        public static DataTable ObtenerInformacionMateriales(_gen_Temporada Temporada)
        {
            DataTable res = manejador.EjecutarConsulta(@"
            select 
            --esp._st_Nombre_espacio as [Campo]
             esp2.id as [ID_ESPACIO]
            --, esp2._st_Nombre_espacio as [Tabla]
            , tecnologia.id as [ID_TECNOLOGIA]
            , cultivo.id as [ID_CULTIVO]
            , etapa.id as [ID_ETAPA]
            --, etapa._st_NombreEtapa as [Etapa]
            --, cultivo._st_Nombre_cultivo as [Cultivo]
            , perfil.id as [ID_PERFIL]
            --, perfil._st_NombrePerfil as [Perfil aplicado]
            , material.id as [ID_MATERIAL]
            , confSiembra.id [ID_CONFSIEMBRA]
            --, cast(actividadNomina._in_idCrop as varchar(MAX)) + ' - ' + actividadNomina._st_Nombre as [Actividades dentro del perfil]
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
            when confiMaterial._in_FechaInicioRespecto = 0 
            then Convert(varchar, dateadd(day,(cultivo._in_DiasAntesSiembra * -1) + (tiempoInicio._do_EquivalenciaEn1Hora / 8) * confiMaterial._do_tiempoRelativoInicio,confSiembra._dt_Fecha_de_planteo), 120)
            when confiMaterial._in_FechaInicioRespecto = 1 
            then Convert(varchar,dateadd(day,(tiempoInicio._do_EquivalenciaEn1Hora / 8) * confiMaterial._do_tiempoRelativoInicio,confSiembra._dt_Fecha_de_planteo), 120)
            when confiMaterial._in_FechaInicioRespecto = 2
            then Convert(varchar,dateadd(day,cultivo._in_DiasDespuesCosecha + (tiempoInicio._do_EquivalenciaEn1Hora / 8) * confiMaterial._do_tiempoRelativoInicio,confSiembra._dt_Fecha_de_planteo), 120)
            end as [Fecha inicio Material]
            , case when confiMaterial._bo_UsarPeriodoDeProduccion is null then 0 else confiMaterial._bo_UsarPeriodoDeProduccion end [Usar Periodo Produccion]
            , case when confiMaterial._bo_SinRepeticiones is null then 0 else confiMaterial._bo_SinRepeticiones end as [Sin repetición]
            , case when confiMaterial._bo_hastaCumplirTodasUnidades is null then 0 else confiMaterial._bo_hastaCumplirTodasUnidades end as [Hasta cumplir unidades totales]
						
            --, case when confiActividad._do_plazo is null then 0 else confiActividad._do_plazo end as [Plazo]
            , confiMaterial._in_Repeticiones as [Repeticiones]
            , confiMaterial._in_veces as [Veces]
            --, confiActividad._do_frecuencia
            --, tiempoFrecuencia._st_Nombre
            , case when confiMaterial._oo_unidadTiempoFrecuencia is null then 0 else (tiempoFrecuencia._do_EquivalenciaEn1Hora / 8) * confiMaterial._do_frecuencia end as [Dias frecuencia]
            , case when confiMaterial._do_plazo is null or confiMaterial._oo_unidadTiempoPlazo is null then 0 else (tiempoPlazo._do_EquivalenciaEn1Hora / 8) * confiMaterial._do_plazo end as [Dias Plazo]
            , '' as [Fecha Termino plazo]
            , '' as [Fechas de material]
            ---------------------------------------------------------
            , material._do_PrecioUnitario as [@costo_unitario_material]
            , material._do_UnidadesMedida as [@valor_unidades]
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
            , confSiembra._do_Densidad_PlantasXMetro2 as [@densidad_planteo]
            , cultivo._do_PorcentajeDeSemillaAdicional as [@porcentaje_semilla_adicional]
            , 0.0 as [@ha_totales_cult_tec]
            , case when confiMaterial._in_Repeticiones = 0 then 1 else confiMaterial._in_Repeticiones end as [@dias_totales]
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
            inner join _gen_PerfilActividades_X__gen_ConfiguracionMaterialPerfil__ll_ConfiguracionMateriales relPerfil_configMateriales on perfil.id = relPerfil_configMateriales._contenedor
            inner join _gen_ConfiguracionMaterialPerfil confiMaterial on relPerfil_configMateriales._contenido = confiMaterial.id
			
            inner join _gen_Material material on confiMaterial._oo_Material = material.id
            left join _gen_Formula formula on confiMaterial._oo_FormulaCalculoMaterial = formula.id
            left join _gen_UnidadDeMedida medida on material._oo_UnidadMedida = medida.id
            --tiempos
            left join _gen_UnidadDeTiempo tiempoInicio on tiempoInicio.id = confiMaterial._oo_unidadTiempoInicio
            left join _gen_UnidadDeTiempo tiempoFrecuencia on tiempoFrecuencia.id = confiMaterial._oo_unidadTiempoFrecuencia
            left join _gen_UnidadDeTiempo tiempoPlazo on tiempoplazo.id = confiMaterial._oo_unidadTiempoPlazo

            where temporada.id = " + Temporada.Id + @"
            and confTemporada.id = 
            (
	            select top 1 confTemp.id 
	            from _gen_Temporada_X__gen_ConfiguracionTemporada__ll_ConfiguracionesDeTemporada temp_conftemp
	            inner join _gen_ConfiguracionTemporada confTemp on temp_conftemp._contenido = confTemp.id
	            where _contenedor = temporada.id and confTemp._bo_EsVersionLiberada = 1
	            order by confTemp.dtFechaModificacion desc
            )
            --order by ID_ESPACIO, ID_ETAPA, ID_PERFIL, [Fecha inicio Material]

            union all

			select 
            --esp._st_Nombre_espacio as [Campo]
             esp2.id as [ID_ESPACIO]
            --, esp2._st_Nombre_espacio as [Tabla]
            , tecnologia.id as [ID_TECNOLOGIA]
            , cultivo.id as [ID_CULTIVO]
            , etapa.id as [ID_ETAPA]
            --, etapa._st_NombreEtapa as [Etapa]
            --, cultivo._st_Nombre_cultivo as [Cultivo]
            , perfil.id as [ID_PERFIL]
            --, perfil._st_NombrePerfil as [Perfil aplicado]
            , material.id as [ID_MATERIAL]
            , confSiembra.id [ID_CONFSIEMBRA]
            --, cast(actividadNomina._in_idCrop as varchar(MAX)) + ' - ' + actividadNomina._st_Nombre as [Actividades dentro del perfil]
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
            when confiMaterial._in_FechaInicioRespecto = 0 
            then Convert(varchar, dateadd(day,(cultivo._in_DiasAntesSiembra * -1) + (tiempoInicio._do_EquivalenciaEn1Hora / 8) * confiMaterial._do_tiempoRelativoInicio,confSiembra._dt_Fecha_de_planteo), 120)
            when confiMaterial._in_FechaInicioRespecto = 1 
            then Convert(varchar,dateadd(day,(tiempoInicio._do_EquivalenciaEn1Hora / 8) * confiMaterial._do_tiempoRelativoInicio,confSiembra._dt_Fecha_de_planteo), 120)
            when confiMaterial._in_FechaInicioRespecto = 2
            then Convert(varchar,dateadd(day,cultivo._in_DiasDespuesCosecha + (tiempoInicio._do_EquivalenciaEn1Hora / 8) * confiMaterial._do_tiempoRelativoInicio,confSiembra._dt_Fecha_de_planteo), 120)
            end as [Fecha inicio Material]
            , case when confiMaterial._bo_UsarPeriodoDeProduccion is null then 0 else confiMaterial._bo_UsarPeriodoDeProduccion end [Usar Periodo Produccion]
            , case when confiMaterial._bo_SinRepeticiones is null then 0 else confiMaterial._bo_SinRepeticiones end as [Sin repetición]
            , case when confiMaterial._bo_hastaCumplirTodasUnidades is null then 0 else confiMaterial._bo_hastaCumplirTodasUnidades end as [Hasta cumplir unidades totales]
						
            --, case when confiActividad._do_plazo is null then 0 else confiActividad._do_plazo end as [Plazo]
            , confiMaterial._in_Repeticiones as [Repeticiones]
            , confiMaterial._in_veces as [Veces]
            --, confiActividad._do_frecuencia
            --, tiempoFrecuencia._st_Nombre
            , case when confiMaterial._oo_unidadTiempoFrecuencia is null then 0 else (tiempoFrecuencia._do_EquivalenciaEn1Hora / 8) * confiMaterial._do_frecuencia end as [Dias frecuencia]
            , case when confiMaterial._do_plazo is null or confiMaterial._oo_unidadTiempoPlazo is null then 0 else (tiempoPlazo._do_EquivalenciaEn1Hora / 8) * confiMaterial._do_plazo end as [Dias Plazo]
            , '' as [Fecha Termino plazo]
            , '' as [Fechas de material]
            ---------------------------------------------------------
            , material._do_PrecioUnitario as [@costo_unitario_material]
            , material._do_UnidadesMedida as [@valor_unidades]
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
            , confSiembra._do_Densidad_PlantasXMetro2 as [@densidad_planteo]
            , cultivo._do_PorcentajeDeSemillaAdicional as [@porcentaje_semilla_adicional]
            , 0.0 as [@ha_totales_cult_tec]
            , case when confiMaterial._in_Repeticiones = 0 then 1 else confiMaterial._in_Repeticiones end as [@dias_totales]
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
            
			inner join _ps_ConfiguracionSiembra_X__gen_PerfilActividades__ll_PerfilActividadesManuales perfManuales on confSiembra.id = perfManuales._contenedor
			inner join _gen_PerfilActividades perfil on perfil.id = perfManuales._contenido

			inner join _gen_PerfilActividades_X__gen_ConfiguracionMaterialPerfil__ll_ConfiguracionMateriales relPerfil_configMateriales on perfil.id = relPerfil_configMateriales._contenedor
            inner join _gen_ConfiguracionMaterialPerfil confiMaterial on relPerfil_configMateriales._contenido = confiMaterial.id
			
            inner join _gen_Material material on confiMaterial._oo_Material = material.id
            left join _gen_Formula formula on confiMaterial._oo_FormulaCalculoMaterial = formula.id
            left join _gen_UnidadDeMedida medida on material._oo_UnidadMedida = medida.id
            --tiempos
            left join _gen_UnidadDeTiempo tiempoInicio on tiempoInicio.id = confiMaterial._oo_unidadTiempoInicio
            left join _gen_UnidadDeTiempo tiempoFrecuencia on tiempoFrecuencia.id = confiMaterial._oo_unidadTiempoFrecuencia
            left join _gen_UnidadDeTiempo tiempoPlazo on tiempoplazo.id = confiMaterial._oo_unidadTiempoPlazo

            where temporada.id = " + Temporada.Id + @"
            and confTemporada.id = 
            (
	            select top 1 confTemp.id 
	            from _gen_Temporada_X__gen_ConfiguracionTemporada__ll_ConfiguracionesDeTemporada temp_conftemp
	            inner join _gen_ConfiguracionTemporada confTemp on temp_conftemp._contenido = confTemp.id
	            where _contenedor = temporada.id and confTemp._bo_EsVersionLiberada = 1
	            order by confTemp.dtFechaModificacion desc
            )
            order by ID_ESPACIO, ID_ETAPA, ID_PERFIL, [Fecha inicio Material]

            ");

            DataTable hectareasCultivo = ObtenerInformacionHectareasPorCultivo(Temporada);
                
            for (int i = 0; i < res.Rows.Count; i++)
            {
                DataRow dr = res.Rows[i];
                res.Columns["Costo calculado"].ReadOnly = false;
                res.Columns["@ha_totales_cult_tec"].ReadOnly = false;
                res.Columns["@costo_unitario_material"].ReadOnly = false;
                double calculo = 0;
                calculo = CalcularImporte(dr, "Formula");
                res.Rows[i]["Costo calculado"] = calculo; //Herramientas.Conversiones.Formatos.DoubleAMonedaANDecimales(calculo, 2);


                String idCultivo = res.Rows[i]["ID_CULTIVO"].ToString();
                String idTecnologia = res.Rows[i]["ID_TECNOLOGIA"].ToString();

                for (int j = 0; j < hectareasCultivo.Rows.Count; j++)
                {
                    if (hectareasCultivo.Rows[j]["ID_CULTIVO"].ToString().Equals(idCultivo) && hectareasCultivo.Rows[j]["ID_TECNOLOGIA"].ToString().Equals(idTecnologia))
                    {
                        res.Rows[i]["@ha_totales_cult_tec"] = hectareasCultivo.Rows[j]["Hectareas"].ToString();
                        break;
                    }

                }

                //calculando fechas

                if (dr["Fecha inicio Material"].ToString().Equals(""))
                {
                    continue;
                }

                DateTime fechaInicioActividad = Convert.ToDateTime(dr["Fecha inicio Material"].ToString());

                Boolean sinRepeticiones = dr["Sin repetición"].ToString().Equals("1");
                Boolean hastaCumplirUnidades = dr["Hasta cumplir unidades totales"].ToString().Equals("1");

                res.Columns["Fecha inicio material"].ReadOnly = false;
                res.Columns["Fecha Termino plazo"].ReadOnly = false;
                res.Columns["Fechas de material"].ReadOnly = false;
                res.Columns["@dias_totales"].ReadOnly = false;

                res.Columns["Fecha Termino plazo"].MaxLength = 100000;
                res.Columns["Fechas de material"].MaxLength = 100000;

                res.Rows[i]["Fecha inicio material"] = Herramientas.Conversiones.Formatos.DateTimeAFechaCorta(fechaInicioActividad);
                int diasPlazo = Convert.ToInt32(dr["Dias Plazo"].ToString());
                if (sinRepeticiones && diasPlazo == 0)
                {
                    res.Rows[i]["Fecha Termino plazo"] = dr["Fecha inicio material"].ToString();
                    res.Rows[i]["Fechas de material"] = dr["Fecha inicio material"].ToString();
                }
                else
                {
                    double repeticiones = Convert.ToDouble(dr["Repeticiones"].ToString());
                    int veces = Convert.ToInt32(dr["Veces"].ToString());



                    //if (hastaCumplirUnidades)
                    //{

                    //    double repeticionesCalculadas = (calculo) / ((Convert.ToDouble(res.Rows[i]["@costo_unitario_actividad"]) * veces));
                    //    //repeticionesCalculadas = Convert.ToInt32(Math.Round(repeticionesCalculadas, MidpointRounding.AwayFromZero));
                    //    res.Rows[i]["@dias_totales"] = repeticionesCalculadas;// repeticionesCalculadas.ToString();
                    //    repeticiones = repeticionesCalculadas;
                    //    //res.Rows[i]["Costo calculado"] = calculo
                    //}
                    //else
                    //{
                    //    res.Rows[i]["Costo calculado"] = calculo; *veces;
                    //}
                    if (repeticiones > 0)
                    {
                        DateTime fechaFrecuencia = fechaInicioActividad;
                        int diasFrecuencia = Convert.ToInt32(dr["Dias frecuencia"].ToString());
                        res.Rows[i]["Fechas de material"] += Herramientas.Conversiones.Formatos.DateTimeAFechaCorta(fechaFrecuencia) + " | ";
                        for (int j = 0; j < repeticiones - 1; j++)
                        {
                            fechaFrecuencia = fechaFrecuencia.AddDays(diasFrecuencia);
                            res.Rows[i]["Fechas de material"] += Herramientas.Conversiones.Formatos.DateTimeAFechaCorta(fechaFrecuencia) + " | ";
                        }
                        String fechas = res.Rows[i]["Fechas de material"].ToString();
                        res.Rows[i]["Fechas de material"] = fechas.Substring(0, fechas.Length - 3);
                        res.Rows[i]["Fecha Termino plazo"] = Herramientas.Conversiones.Formatos.DateTimeAFechaCorta(fechaFrecuencia);
                    }
                    else
                    {
                        int diasTotalesCalculados = 0;
                        DateTime fechaFrecuencia = fechaInicioActividad;

                        DateTime fechaPlazo = fechaInicioActividad.AddDays(diasPlazo);

                        int diasFrecuencia = Convert.ToInt32(dr["Dias frecuencia"].ToString());
                        res.Rows[i]["Fechas de material"] += Herramientas.Conversiones.Formatos.DateTimeAFechaCorta(fechaFrecuencia) + " | ";
                        diasTotalesCalculados++;
                        while (fechaFrecuencia <= fechaPlazo)
                        {
                            fechaFrecuencia = fechaFrecuencia.AddDays(diasFrecuencia);
                            res.Rows[i]["Fechas de material"] += Herramientas.Conversiones.Formatos.DateTimeAFechaCorta(fechaFrecuencia) + " | ";
                            diasTotalesCalculados++;
                        }
                        String fechas = res.Rows[i]["Fechas de material"].ToString();

                        if (diasTotalesCalculados > 0)
                        {
                            res.Rows[i]["@dias_totales"] = diasTotalesCalculados.ToString();

                            calculo = CalcularImporte(dr, "Formula");
                            //res.Rows[i]["Costo calculado"] = calculo * veces; //Herramientas.Conversiones.Formatos.DoubleAMonedaANDecimales(calculo, 2);


                        }

                        res.Rows[i]["Fechas de material"] = fechas.Substring(0, fechas.Length - 3);
                        res.Rows[i]["Fecha Termino plazo"] = Herramientas.Conversiones.Formatos.DateTimeAFechaCorta(fechaFrecuencia);
                    }

                }
            }
            return res;
        }
        public static DataTable ObtenerInformacionMaterialesAsociados(_gen_Temporada Temporada)
        {
            DataTable res = manejador.EjecutarConsulta(@"
            select 
            --esp._st_Nombre_espacio as [Campo]
             esp2.id as [ID_ESPACIO]
            --, esp2._st_Nombre_espacio as [Tabla]
            , tecnologia.id as [ID_TECNOLOGIA]
            , cultivo.id as [ID_CULTIVO]
            , etapa.id as [ID_ETAPA]
            , confSiembra.id [ID_CONFSIEMBRA]
            --, etapa._st_NombreEtapa as [Etapa]
            --, cultivo._st_Nombre_cultivo as [Cultivo]
            , perfil.id as [ID_PERFIL]
            --, perfil._st_NombrePerfil as [Perfil aplicado]
            , actividadNomina.id as [ID_ACTIVIDAD]
			, material.id as [ID_MATERIAL_ASOCIADO]
			, medida._st_Nombre as [UNIDAD_MATERIAL]
            --, cast(actividadNomina._in_idCrop as varchar(MAX)) + ' - ' + actividadNomina._st_Nombre as [Actividades dentro del perfil]
            , formulaActividad._st_Formula as [Formula Actividad]
			, formulaMaterial._st_Formula as [Formula Material]
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
            end as [Fecha inicio Material]
            , case when confiActividad._bo_UsarPeriodoDeProduccion is null then 0 else confiActividad._bo_UsarPeriodoDeProduccion end [Usar Periodo Produccion]
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
            , '' as [Fechas de material]
            ---------------------------------------------------------
            , actividadNomina._do_CostoPorUnidad as [@costo_unitario_actividad]
			, material._do_PrecioUnitario as [@costo_unitario_material]
            , actividadNomina._do_unidadesTarea as [@valor_unidades]
            , medidaActividad._st_Nombre as [Medida]
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
            , confSiembra._do_Densidad_PlantasXMetro2 as [@densidad_planteo]
            , cultivo._do_PorcentajeDeSemillaAdicional as [@porcentaje_semilla_adicional]
            , 0.0 as [@ha_totales_cult_tec]
            , case when confiActividad._in_Repeticiones = 0 then 1.0 else confiActividad._in_Repeticiones end as [@dias_totales]
            , cast(0 as varchar(MAX)) as [Costo calculado actividad]
			, cast(0 as varchar(MAX)) as [Costo calculado material]
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
			inner join _gen_ActividadNomina_X__gen_ConfMatActividadNom__ll_MaterialesUsados confiMaterial on actividadNomina.id = confiMaterial._contenedor
			left join _gen_ConfMatActividadNom confiPerfilMaterial on confiPerfilMaterial.id =  confiMaterial._contenido
			left join _gen_Material material on confiPerfilMaterial._oo_MaterialAUsar = material.id
            left join _gen_Formula formulaActividad on actividadNomina._oo_formulaCosto = formulaActividad.id
			left join _gen_Formula formulaMaterial on confiPerfilMaterial._oo_FormulaCalculoMaterial = formulaMaterial.id
            left join _gen_UnidadDeMedida medida on material._oo_UnidadMedida = medida.id
			left join _gen_UnidadDeMedida medidaActividad on actividadNomina._oo_UnidadMedidaDeTarea = medidaActividad.id
            --tiempos
            left join _gen_UnidadDeTiempo tiempoInicio on tiempoInicio.id = confiActividad._oo_unidadTiempoInicio
            left join _gen_UnidadDeTiempo tiempoFrecuencia on tiempoFrecuencia.id = confiActividad._oo_unidadTiempoFrecuencia
            left join _gen_UnidadDeTiempo tiempoPlazo on tiempoplazo.id = confiActividad._oo_unidadTiempoPlazo

            where temporada.id = " + Temporada.Id + @"
            and confTemporada.id = 
            (
	            select top 1 confTemp.id 
	            from _gen_Temporada_X__gen_ConfiguracionTemporada__ll_ConfiguracionesDeTemporada temp_conftemp
	            inner join _gen_ConfiguracionTemporada confTemp on temp_conftemp._contenido = confTemp.id
	            where _contenedor = temporada.id and confTemp._bo_EsVersionLiberada = 1
	            order by confTemp.dtFechaModificacion desc
            )
            order by ID_ESPACIO, ID_ETAPA, ID_PERFIL, [Fecha inicio Material]
            ");

            DataTable hectareasCultivo = ObtenerInformacionHectareasPorCultivo(Temporada);
                
            for (int i = 0; i < res.Rows.Count; i++)
            {
                DataRow dr = res.Rows[i];
                res.Columns["Costo calculado actividad"].ReadOnly = false;
                res.Columns["Costo calculado material"].ReadOnly = false;
                res.Columns["@costo_unitario_material"].ReadOnly = false;

                res.Columns["@ha_totales_cult_tec"].ReadOnly = false;
                double calculoActividad = 0;
                calculoActividad = CalcularImporte(dr, "Formula Actividad");
                res.Rows[i]["Costo calculado actividad"] = calculoActividad; //Herramientas.Conversiones.Formatos.DoubleAMonedaANDecimales(calculo, 2);
                double calculoMaterialPorActividad = 0;
                calculoMaterialPorActividad = CalcularImporte(dr, "Formula material");
                res.Rows[i]["Costo calculado material"] = calculoMaterialPorActividad;


                String idCultivo = res.Rows[i]["ID_CULTIVO"].ToString();
                String idTecnologia = res.Rows[i]["ID_TECNOLOGIA"].ToString();

                for (int j = 0; j < hectareasCultivo.Rows.Count; j++)
                {
                    if (hectareasCultivo.Rows[j]["ID_CULTIVO"].ToString().Equals(idCultivo) && hectareasCultivo.Rows[j]["ID_TECNOLOGIA"].ToString().Equals(idTecnologia))
                    {
                        res.Rows[i]["@ha_totales_cult_tec"] = hectareasCultivo.Rows[j]["Hectareas"].ToString();
                        break;
                    }

                }
                
                //calculando fechas

                if (dr["Fecha inicio Material"].ToString().Equals(""))
                {
                    continue;
                }

                DateTime fechaInicioActividad = Convert.ToDateTime(dr["Fecha inicio Material"].ToString());

                Boolean sinRepeticiones = dr["Sin repetición"].ToString().Equals("1");
                Boolean hastaCumplirUnidades = dr["Hasta cumplir unidades totales"].ToString().Equals("1");

                res.Columns["Fecha inicio material"].ReadOnly = false;
                res.Columns["Fecha Termino plazo"].ReadOnly = false;
                res.Columns["Fechas de material"].ReadOnly = false;
                res.Columns["@dias_totales"].ReadOnly = false;

                res.Columns["Fecha Termino plazo"].MaxLength = 1000;
                res.Columns["Fechas de material"].MaxLength = 1000;

                res.Rows[i]["Fecha inicio material"] = Herramientas.Conversiones.Formatos.DateTimeAFechaCorta(fechaInicioActividad);
                int diasPlazo = Convert.ToInt32(dr["Dias Plazo"].ToString());
                if (sinRepeticiones && diasPlazo == 0)
                {
                    res.Rows[i]["Fecha Termino plazo"] = dr["Fecha inicio material"].ToString();
                    res.Rows[i]["Fechas de material"] = dr["Fecha inicio material"].ToString();
                }
                else
                {
                    double repeticiones = Convert.ToInt32(dr["Repeticiones"].ToString());
                    int veces = Convert.ToInt32(dr["Veces"].ToString());



                    if (hastaCumplirUnidades)
                    {

                        double repeticionesCalculadas = (calculoActividad) / ((Convert.ToDouble(res.Rows[i]["@costo_unitario_actividad"]) * Convert.ToDouble(res.Rows[i]["@valor_unidades"])) * veces);
                        //repeticionesCalculadas = Convert.ToInt32(Math.Round(repeticionesCalculadas,MidpointRounding.AwayFromZero));
                        res.Rows[i]["@dias_totales"] = repeticionesCalculadas.ToString();
                        repeticiones = Math.Ceiling(repeticionesCalculadas);
                        //res.Rows[i]["Costo calculado"] = calculo
                    }
                    else
                    {
                        res.Rows[i]["Costo calculado actividad"] = calculoActividad * veces;
                    }
                    if (repeticiones > 0)
                    {
                        DateTime fechaFrecuencia = fechaInicioActividad;
                        int diasFrecuencia = Convert.ToInt32(dr["Dias frecuencia"].ToString());
                        res.Rows[i]["Fechas de material"] += Herramientas.Conversiones.Formatos.DateTimeAFechaCorta(fechaFrecuencia) + " | ";
                        for (int j = 0; j < repeticiones - 1; j++)
                        {
                            fechaFrecuencia = fechaFrecuencia.AddDays(diasFrecuencia);
                            res.Rows[i]["Fechas de material"] += Herramientas.Conversiones.Formatos.DateTimeAFechaCorta(fechaFrecuencia) + " | ";
                        }
                        String fechas = res.Rows[i]["Fechas de material"].ToString();
                        res.Rows[i]["Fechas de material"] = fechas.Substring(0, fechas.Length - 3);
                        res.Rows[i]["Fecha Termino plazo"] = Herramientas.Conversiones.Formatos.DateTimeAFechaCorta(fechaFrecuencia);
                    }
                    else
                    {
                        int diasTotalesCalculados = 0;
                        DateTime fechaFrecuencia = fechaInicioActividad;

                        DateTime fechaPlazo = fechaInicioActividad.AddDays(diasPlazo);

                        int diasFrecuencia = Convert.ToInt32(dr["Dias frecuencia"].ToString());
                        res.Rows[i]["Fechas de material"] += Herramientas.Conversiones.Formatos.DateTimeAFechaCorta(fechaFrecuencia) + " | ";
                        diasTotalesCalculados++;
                        fechaFrecuencia = fechaFrecuencia.AddDays(diasFrecuencia);
                        while (fechaFrecuencia < fechaPlazo)
                        {
                            fechaFrecuencia = fechaFrecuencia.AddDays(diasFrecuencia);
                            res.Rows[i]["Fechas de material"] += Herramientas.Conversiones.Formatos.DateTimeAFechaCorta(fechaFrecuencia) + " | ";
                            diasTotalesCalculados++;
                        }
                        String fechas = res.Rows[i]["Fechas de material"].ToString();

                        if (diasTotalesCalculados > 0)
                        {
                            res.Rows[i]["@dias_totales"] = diasTotalesCalculados.ToString();

                            calculoActividad = CalcularImporte(dr, "Formula Actividad");
                            res.Rows[i]["Costo calculado actividad"] = calculoActividad * veces; //Herramientas.Conversiones.Formatos.DoubleAMonedaANDecimales(calculo, 2);


                        }

                        res.Rows[i]["Fechas de material"] = fechas.Substring(0, fechas.Length - 3);
                        res.Rows[i]["Fecha Termino plazo"] = Herramientas.Conversiones.Formatos.DateTimeAFechaCorta(fechaFrecuencia);
                    }

                }
            }
            return res;
        }
        private static String SustituirValores(DataRow dr, String CampoFormula)
        {
            String formulaTareaOriginal = dr[CampoFormula].ToString();
            String formulaTarea = formulaTareaOriginal.ToLower();

            //foreach(String variable in Catalogos.win_gen_CatalogoFormulas.Variables)
            //    formulaTarea = formulaTarea.Replace(variable, dr[variable].ToString());

            try { formulaTarea = formulaTarea.Replace("@costo_unitario_actividad", dr["@costo_unitario_actividad"].ToString()); }
            catch { }
            try { formulaTarea = formulaTarea.Replace("@costo_unitario_material", dr["@costo_unitario_material"].ToString()); }
            catch { }
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
            formulaTarea = formulaTarea.Replace("@densidad_planteo", dr["@densidad_planteo"].ToString());
            formulaTarea = formulaTarea.Replace("@porcentaje_semilla_adicional", dr["@porcentaje_semilla_adicional"].ToString());
            formulaTarea = formulaTarea.Replace("@ha_totales_cult_tec", dr["@ha_totales_cult_tec"].ToString());

            return formulaTarea;
        }
        private static double CalcularImporte(DataRow dr, String campoFormula)
        {
            //if (dr["ID_ACTIVIDAD"].ToString().Equals("362"))
            //    return 0;
            String formulaTarea = SustituirValores(dr, campoFormula);

            double calculo = 0;

            if (!formulaTarea.Trim().Equals(""))
            {
                try
                {
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
    }
}
