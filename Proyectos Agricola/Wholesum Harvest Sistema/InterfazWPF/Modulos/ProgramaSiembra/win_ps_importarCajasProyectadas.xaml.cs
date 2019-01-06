using Dominio;
using Dominio.Modulos.General;
using Dominio.Modulos.ProgramaSiembra;
using Herramientas.Forms;
using Herramientas.ORM;
using Herramientas.SQL;
using InterfazWPF.AdministracionSistema;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace InterfazWPF.Modulos.ProgramaSiembra
{
    /// <summary>
    /// Lógica de interacción para win_ps_importarCajasProyectadas.xaml
    /// </summary>
    public partial class win_ps_importarCajasProyectadas : Window
    {
        Access access;
        DataTable dtCajasProyectadas;
        ManejadorDB manejador;
        _gen_Temporada temporadaSeleccionada;
        _gen_ConfiguracionTemporada configuracionTemporadaSeleccionada;
        List<DateTime> fechasSemanasInicio = new List<DateTime>();
        List<DateTime> fechasSemanasFin = new List<DateTime>();
        public win_ps_importarCajasProyectadas()
        {
            InitializeComponent();
            access = new Access();
            manejador = new ManejadorDB();
            ConfigurarBuscadores();

            Herramientas.WPF.Utilidades.AgregarColumnaConBindingADataGridView(dgv_datos, "Campo", "Campo");
            Herramientas.WPF.Utilidades.AgregarColumnaConBindingADataGridView(dgv_datos, "Tabla", "Tabla");
            Herramientas.WPF.Utilidades.AgregarColumnaConBindingADataGridView(dgv_datos, "Etapa", "Etapa");
            Herramientas.WPF.Utilidades.AgregarColumnaConBindingADataGridView(dgv_datos, "Resultado", "Resultado");

            manejador.guardadoError += manejador_guardadoError;
            manejador.guardadoTerminado += manejador_guardadoTerminado;
            manejador.errorConexion += manejador_errorConexion;


            DateTime fechaInicio = new DateTime(2015, 7, 2);
            for (int i = 0; i < 52; i++)
            {
                fechasSemanasInicio.Add(fechaInicio);
                DateTime fechaFin = fechaInicio.AddDays(6);
                fechasSemanasFin.Add(fechaFin);
                fechaInicio = fechaFin.AddDays(1);
            }

        }

        void manejador_errorConexion(Exception ex)
        {
            HerramientasWindow.MensajeErrorHilo(this, ex, ex.Message, "Error de conexión");
        }
        void manejador_guardadoTerminado(string identificador, string resultado, long id)
        {
            final = DateTime.Now;
            TimeSpan duracion = final - inicio;
            double segundosTotales = duracion.TotalSeconds;
            int segundos = duracion.Seconds;
            manejador.TerminarTransaccion();
            Dispatcher.Invoke(new Action(() =>
                {
                    HerramientasWindow.Mensaje("Se guardó con éxito la información.", "Exito al guardar");
                }));
        }

        void manejador_guardadoError(Exception ex)
        {
            manejador.DeshacerTransaccion();
            HerramientasWindow.MensajeErrorHilo(this, ex, ex.Message, "Error");
        }

        private void ConfigurarBuscadores()
        {
            txt_buscadorTemporada.AsignarManejadorDB(manejador);
            txt_buscadorTemporada.AsignarCatalogoParaAltas("InterfazWPF.Modulos.Catalogos.win_ps_CatalogoTemporadas");
            txt_buscadorTemporada.ConfigurarBusqueda(typeof(_gen_Temporada), "id", "_st_NombreTemporada", false, true);
            txt_buscadorTemporada.mostrarResultado += txt_buscadorTemporada_mostrarResultado;
            txt_buscadorTemporada.AgregarCampoAMostrarConAlias("_st_NombreTemporada|Temporada");

        }

        void txt_buscadorTemporada_mostrarResultado(List<ObjetoBase> listaObjetos)
        {
            if (listaObjetos != null)
            {
                cmb_versiones.Items.Clear();
                temporadaSeleccionada = (_gen_Temporada)listaObjetos[0];
                if (temporadaSeleccionada.Ll_ConfiguracionesDeTemporada != null)
                {
                    foreach (_gen_ConfiguracionTemporada conf in temporadaSeleccionada.Ll_ConfiguracionesDeTemporada)
                    {
                        cmb_versiones.Items.Add(conf.St_version);
                    }
                }
            }
        }
        private void cmb_versiones_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmb_versiones.SelectedIndex >= 0)
            {
                configuracionTemporadaSeleccionada = temporadaSeleccionada.Ll_ConfiguracionesDeTemporada[cmb_versiones.SelectedIndex];
            }
        }
        private void btn_BuscarCargarBD_MouseUp(object sender, MouseButtonEventArgs e)
        {
            String archivo = Herramientas.Archivos.Dialogos.BuscarArchivo(new List<string>() { "BD de Access" }, new List<string>() { "accdb" });
            if (archivo != null)
            {
                txt_rutaArchivo.Text = archivo;
                access.ConfigurarConexion(null, txt_rutaArchivo.Text.Trim());

                String query = "select * from [_CCort y CEmp Proyectadas x Sem qry] order by Campo, Tabla";

                access.AbrirConexion();
                dtCajasProyectadas = access.EjecutarConsulta(query);
                access.CerrarConexion();

                dgv_datos.Items.Clear();

                if (dtCajasProyectadas.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtCajasProyectadas.Rows)
                    {
                        ModeloGridCajasImportadas modelo = new ModeloGridCajasImportadas();
                        modelo.Campo = dr["Campo"].ToString();
                        modelo.Tabla = dr["Tabla"].ToString();
                        modelo.Etapa = dr["Etapa"].ToString();
                        dgv_datos.Items.Add(modelo);
                    }
                }
            }
        }
        DateTime inicio;
        DateTime final;
        private void btn_cargar_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (configuracionTemporadaSeleccionada != null)
            {
                configuracionTemporadaSeleccionada.EsModificado = true;
                if (configuracionTemporadaSeleccionada.Ll_espaciosAsignados != null)
                {
                    foreach (_ps_EspacioFisico espacio in configuracionTemporadaSeleccionada.Ll_espaciosAsignados)
                    {
                        RecorrerRecursivamenteEspacios(espacio);
                    }
                }
                inicio = DateTime.Now;
                HerramientasWindow.MostrarNotificacion("Inició el guardado en segundo plano.", "Guardando...");
                manejador.IniciarTransaccion();
                manejador.GuardarAsincrono("conf", configuracionTemporadaSeleccionada);
            }
        }
        private void RecorrerRecursivamenteEspacios(_ps_EspacioFisico espacio)
        {
            DataRow[] drT = BuscarDataRowEspecifico(espacio);
            int contador = 0;
            espacio.EsModificado = true;
            if (drT != null)
            {

                foreach (DataRow dr in drT)
                {
                    for (int i = 0; i < 52; i++)
                    {
                        double cajasCortadas = Convert.ToDouble(dr["CCort" + (i + 1)].ToString());
                        double cajasEmpacadas = Convert.ToDouble(dr["CEmp" + (i + 1)].ToString());

                        char etapa = Convert.ToChar(dr["Etapa"].ToString());

                        MarcarComoListo(espacio.Oo_EspacioFisicoPadre.st_Nombre_espacio, espacio.st_Nombre_espacio, etapa.ToString());

                        int etapaNumero = etapa - 97;

                        espacio.ll_Configuraciones_de_Siembra[etapaNumero].BorrarObjetosDeListaRelacionadaPermanentemente<_ps_CajasCortYEmpProyectadas>("_ll_CajasProyectadas");

                        if (cajasCortadas > 0 || cajasEmpacadas > 0)
                        {
                            List<DateTime> fechas = CalcularFechas(i);
                            espacio.ll_Configuraciones_de_Siembra[etapaNumero].EsModificado = true;
                            if (espacio.ll_Configuraciones_de_Siembra[etapaNumero].Ll_CajasProyectadas == null) espacio.ll_Configuraciones_de_Siembra[etapaNumero].Ll_CajasProyectadas = new List<_ps_CajasCortYEmpProyectadas>();
                            contador += fechas.Count;
                            foreach (DateTime fecha in fechas)
                            {
                                _ps_CajasCortYEmpProyectadas caj = new _ps_CajasCortYEmpProyectadas();
                                caj.EsModificado = true;
                                caj.Dt_FechaProyeccion = fecha;
                                caj.Do_CantidadCorte = cajasCortadas / 6;
                                caj.Do_CantidadEmpaque = cajasEmpacadas / 6;
                                caj.Oo_ConfiguracionSiembra = espacio.ll_Configuraciones_de_Siembra[etapaNumero];
                                espacio.ll_Configuraciones_de_Siembra[etapaNumero].Ll_CajasProyectadas.Add(caj);
                            }

                        }
                    }
                }
            }
            if (espacio.ll_Espacios_fisicos_dentro != null)
            {
                foreach (_ps_EspacioFisico espacioDentro in espacio.ll_Espacios_fisicos_dentro)
                {
                    RecorrerRecursivamenteEspacios(espacioDentro);
                }
            }
        }
        private void MarcarComoListo(String campo, String tabla, String etapa)
        {
            foreach (ModeloGridCajasImportadas modelo in dgv_datos.Items)
            {
                if (modelo.Campo.Equals(campo) && modelo.Tabla.Equals(tabla) && modelo.Etapa.Equals(etapa) && modelo.Resultado == null)
                {
                    modelo.Resultado = "Listo";
                    return;
                }
            }
        }
        private List<DateTime> CalcularFechas(int semana)
        {
            List<DateTime> fechas = new List<DateTime>();

            DateTime fechaSemana = fechasSemanasInicio[semana];

            fechas.Add(fechaSemana);

            for (int i = 1; i <= 5; i++)
            {
                fechas.Add(fechaSemana.AddDays(i));
            }

            return fechas;
        }
        private DataRow[] BuscarDataRowEspecifico(_ps_EspacioFisico espacio)
        {
            String nombre = espacio.st_Nombre_espacio;
            if (espacio.St_NombreEspacioEnMacro != null)
                nombre = espacio.St_NombreEspacioEnMacro;
            if (espacio.Oo_EspacioFisicoPadre != null)
            {
                String nombrePadre = espacio.Oo_EspacioFisicoPadre.st_Nombre_espacio;
                if (espacio.Oo_EspacioFisicoPadre.St_NombreEspacioEnMacro != null)
                    nombrePadre = espacio.Oo_EspacioFisicoPadre.St_NombreEspacioEnMacro;

                DataRow[] dr = dtCajasProyectadas.Select("TRIM(Tabla) = '" + nombre + "' and TRIM(Campo) = '" + nombrePadre + "'");
                if (dr.Length > 0)
                    return dr;
                else
                    return null;
            }
            return null;
        }

        private void btn_MostrarEnProgramaSiembra_MouseUp(object sender, MouseButtonEventArgs e)
        {
            String query = @"select 
                            --*
                            esp._st_Nombre_espacio as [Campo]
                            --,esp2.id as [ID_ESPACIO]
                            , esp2._st_Nombre_espacio as [Tabla]
                            --, tecnologia._st_Descripcion as [Tecnología]
                            --, etapa.id as [ID_ETAPA]
                            , etapa._st_NombreEtapa as [Etapa]
                            , cultivo._st_Nombre_cultivo as [Cultivo]
                            , cajasProyectadas._do_CantidadCorte as [Corte]
                            , 'Por definir' as [Unidad Corte]
                            , cajasProyectadas._do_CantidadEmpaque as [Empaque]
                            , 'Por definir' as [Unidad Empaque]
                            , cajasProyectadas._dt_fechaProyeccion [Fecha proyección]
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
                            inner join _ps_ConfiguracionSiembra_X__ps_CajasCortYEmpProyectadas__ll_CajasProyectadas rel_confSiembra_cajasProy on confSiembra.id = rel_confSiembra_cajasProy._contenedor
                            inner join _ps_CajasCortYEmpProyectadas cajasProyectadas on rel_confSiembra_cajasProy._contenido = cajasProyectadas.id

                            where temporada._st_NombreTemporada = 'Temporada 15-16' 
                            and confTemporada.id = 
                            (
	                            select top 1 confTemp.id 
	                            from _gen_Temporada_X__gen_ConfiguracionTemporada__ll_ConfiguracionesDeTemporada temp_conftemp
	                            inner join _gen_ConfiguracionTemporada confTemp on temp_conftemp._contenido = confTemp.id
	                            where _contenedor = temporada.id and confTemp._bo_EsVersionLiberada = 1
	                            order by temp_conftemp._fecha desc
                            )";

            dtCajasImportadas = manejador.EjecutarConsulta(query);
            dgv_cajasPorDia.ItemsSource = dtCajasImportadas.AsDataView();

        }
        DataTable dtCajasImportadas;

        private void btn_EnviarAExcel_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (dtCajasImportadas != null)
            {
                String ruta = Herramientas.Archivos.Dialogos.GuardarArchivoRuta(new List<string>() { "Archivo de excel" }, new List<string>() { "xls" }, "CAJAS_IMPORTADAS_" + Herramientas.Conversiones.Formatos.DateTimeAFechaLOGArchivo(DateTime.Now) + ".xls");
                if (ruta != null)
                {
                    ExcelAPI excel = new ExcelAPI();
                    excel.terminoConversion += excel_terminoConversion;
                    excel.mostrarProgresoConversion += excel_mostrarProgresoConversion;
                    excel.ConvertirDataTableAExcel("", dtCajasImportadas);
                }
            }
        }

        void excel_mostrarProgresoConversion(double progresoPorcentaje)
        {
            Dispatcher.Invoke(new Action(() =>
            {
                pb_progresoExportacionExcelCajasImp.Value = progresoPorcentaje;
            }));
        }

        void excel_terminoConversion(string rutaGuardado)
        {
            Dispatcher.Invoke(new Action(() =>
            {
                HerramientasWindow.Mensaje("Archivo enviado con éxito.", "Archivo exportado");
            }));
        }

    }

    class ModeloGridCajasImportadas
    {
        public String Campo { get; set; }
        public String Tabla { get; set; }
        public String Etapa { get; set; }
        public String Resultado { get; set; }
    }
}
