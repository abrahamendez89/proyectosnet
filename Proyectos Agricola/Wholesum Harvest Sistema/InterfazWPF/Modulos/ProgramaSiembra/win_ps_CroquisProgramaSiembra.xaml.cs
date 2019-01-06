using System;
using System.Collections.Generic;
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
using InterfazWPF.AdministracionSistema;
using Dominio;
using Dominio.Modulos.General;
using Dominio.Modulos.ProgramaSiembra;
using LogicaNegocios.ProgramaSiembra;
using System.Drawing;
using Herramientas.ORM;
using System.Data;
using Herramientas.Forms;

namespace InterfazWPF.Modulos.ProgramaSiembra
{
    /// <summary>
    /// Lógica de interacción para win_ps_CroquisProgramaSiembra.xaml
    /// </summary>
    public partial class win_ps_CroquisProgramaSiembra : Window
    {
        ManejadorDB manejador = new ManejadorDB();
        _gen_Temporada temporadaSeleccionada;
        _gen_ConfiguracionTemporada configuracionTemporada;
        List<_ps_EspacioFisico> espaciosFisicosCargados = new List<_ps_EspacioFisico>();
        _ps_EspacioFisico espacioTemporal;
        _ps_EspacioFisico espacioPadre;
        public win_ps_CroquisProgramaSiembra()
        {
            InitializeComponent();
            croquis.ZoomEtiquetas = 10;
            croquis.obtenerEspacioSeleccionado += croquis_obtenerEspacioSeleccionado;
            croquis.obtenerCoordenada += croquis_obtenerCoordenada;
            croquis.obtenerEspacioAgregado += croquis_obtenerEspacioAgregado;
            croquis.obtenerEspacioAModifiar += croquis_obtenerEspacioAModifiar;
            croquis.espacioClick += croquis_espacioClick;
            croquis.reDibujarCroquis += croquis_reDibujarCroquis;
            croquis.construirDatosAMostrar += croquis_construirDatosAMostrar;

            manejador.guardadoTerminado += manejador_guardadoTerminado;
            manejador.guardadoError += manejador_guardadoError;

            espacioPadre = manejador.CrearObjeto<_ps_EspacioFisico>();
            ConfigurarBuscadores();

            EspacioSeleccionadoInicio inicio = new EspacioSeleccionadoInicio();
            inicio.clickInicioRecorrido += inicio_clickInicioRecorrido;
            inicio.Height = pnl_Recorrido.Height;
            inicio.EspacioPadre = espacioPadre;
            inicio.seAgregoEspacioEvento += espacioGrafico_seAgregoEspacioEvento;
            inicio.AllowDrop = true;
            espaciosSeleccionadosBotones.Add(inicio);
            cargarEspaciosBotonesHistorial();

            //List<String> coordenadasCardenal = new List<string>();
            //coordenadasCardenal.Add("24.754188, -107.479524");
            //coordenadasCardenal.Add("24.756429, -107.477984");
            //coordenadasCardenal.Add("24.756297, -107.469024");
            //coordenadasCardenal.Add("24.754974, -107.468976");
            //coordenadasCardenal.Add("24.754900, -107.460678");
            //coordenadasCardenal.Add("24.751117, -107.460530");
            //coordenadasCardenal.Add("24.750448, -107.462646");
            //coordenadasCardenal.Add("24.751059, -107.473737");

            //croquis.AgregarPoligono(coordenadasCardenal, "Cardenal", System.Drawing.Color.Blue, null);

            croquis.IrACoordenada("24.754227, -107.476011", 16);

            cmb_perspectivas.Items.Add("Normal");
            cmb_perspectivas.Items.Add("Producción");
            cmb_perspectivas.Items.Add("Focos de infección");
            cmb_perspectivas.Items.Add("Otros");

            cmb_configuracionesTemporada.SelectionChanged += cmb_configuracionesTemporada_SelectionChanged;


            cmb_tiposReportes.Items.Add("Caracteristicas físicas de espacios");
            cmb_tiposReportes.Items.Add("Fechas y cultivos de espacios");

            AgregarVistasCroquis();

        }


        void croquis_reDibujarCroquis()
        {
            CargarEspacios();
        }

        void croquis_obtenerEspacioAModifiar(_ps_EspacioFisico espacioAModificar)
        {
            mod_ps_ConfiguracionDatosEspacioFisico confEspacio = new mod_ps_ConfiguracionDatosEspacioFisico(espacioAModificar);
            HerramientasWindow.MostrarVentanaDialogo(confEspacio, true);

            if (confEspacio.ClickEnAceptar)
            {
                confEspacio.EspacioFisicoModificado.EsModificado = true;
                manejador.Guardar(confEspacio.EspacioFisicoModificado);
                CargarEspacios();
            }
            confEspacio.Close();

        }

        void manejador_guardadoError(Exception ex)
        {
            Dispatcher.Invoke(new Action(() =>
            {
                HerramientasWindow.MostrarNotificacion(ex.Message, "Error al guardar", new Bitmap(@"Imagenes\Iconos\Formularios\Quitar.png"));
                _toolbox_Recargar_espacios_de_servidor();
            }));
        }
        void manejador_guardadoTerminado(String identificador, string resultado, long id)
        {
            if (identificador.Equals("GuardadoTodos"))
            {
                manejador.TerminarTransaccion();
                Dispatcher.Invoke(new Action(() =>
                {
                    HerramientasWindow.MostrarNotificacion(resultado, "Guardado exitoso", new Bitmap(@"Imagenes\Iconos\Formularios\Guardar.png"));
                    _toolbox_Recargar_espacios_de_servidor();
                }));

            }
            else if (identificador.Equals("espacioOriginal"))
            {
                Dispatcher.Invoke(new Action(() =>
                {
                    HerramientasWindow.MostrarNotificacion(resultado, "Guardado exitoso", new Bitmap(@"Imagenes\Iconos\Formularios\Guardar.png"));
                    CargarEspacios();
                }));
            }
            else if (identificador.Equals("versionConf"))
            {
                Dispatcher.Invoke(new Action(() =>
               {
                   manejador.TerminarTransaccion();
                   HerramientasWindow.MostrarNotificacion("Se generó la versión correctamente.", "Guardado exitoso", new Bitmap(@"Imagenes\Iconos\Formularios\Guardar.png"));
                   CargarTemporadaSeleccionada();
               }));
            }

        }
        void espacioGrafico_seAgregoEspacioEvento(EspacioGrafico espacioSeleccionado)
        {
            if (espacioTemporal != null)
                ps_ln_Espacios.EliminarEspacioAEspacio(espacioTemporal, espacioSeleccionado.EspacioRepresentado);
            else
                ps_ln_Espacios.EliminarEspacioAEspacio(espacioPadre, espacioSeleccionado.EspacioRepresentado);
            CargarEspacios();
        }
        private void cargarEspaciosBotonesHistorial()
        {
            pnl_Recorrido.Children.Clear();

            for (int i = 0; i < espaciosSeleccionadosBotones.Count; i++)
            {
                pnl_Recorrido.Children.Add(espaciosSeleccionadosBotones[i]);
                if (i > 0)
                    ((EspacioSeleccionado)espaciosSeleccionadosBotones[i]).esNormal();

            }
            if (espaciosSeleccionadosBotones.Count > 1)
                ((EspacioSeleccionado)espaciosSeleccionadosBotones[espaciosSeleccionadosBotones.Count - 1]).esUltimo();
        }
        void inicio_clickInicioRecorrido()
        {
            espacioTemporal = espacioPadre;
            espaciosFisicosCargados = espacioTemporal.ll_Espacios_fisicos_dentro;

            CargarEspacios();

            espaciosSeleccionadosBotones.RemoveRange(1, espaciosSeleccionadosBotones.Count - 1);
            cargarEspaciosBotonesHistorial();
            croquis.DesactivarModoEdicion();

        }
        private void txt_Buscador_mostrarResultado(List<ObjetoBase> listaObjetos)
        {
            if (listaObjetos != null)
            {
                temporadaSeleccionada = (_gen_Temporada)listaObjetos[0];
                CargarTemporadaSeleccionada();
            }
        }
        void cmb_configuracionesTemporada_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmb_configuracionesTemporada.SelectedIndex != -1)
            {
                configuracionTemporada = temporadaSeleccionada.Ll_ConfiguracionesDeTemporada[cmb_configuracionesTemporada.SelectedIndex];
                CargarEspaciosDeConfiguracionTemporada();
                HerramientasWindow.MostrarNotificacion("Versión " + configuracionTemporada.St_version + " cargada correctamente.", "Versión programa siembra", null, 5);
            }
        }
        private void CargarTemporadaSeleccionada()
        {
            if (temporadaSeleccionada.Ll_ConfiguracionesDeTemporada == null || temporadaSeleccionada.Ll_ConfiguracionesDeTemporada.Count == 0)
            {
                _gen_ConfiguracionTemporada confNueva = new _gen_ConfiguracionTemporada();
                confNueva.EsModificado = true;
                confNueva.Oo_Temporada = temporadaSeleccionada;
                confNueva.St_version = DateTime.Now.ToString("yyyyMMddHH");
                if (temporadaSeleccionada.Ll_ConfiguracionesDeTemporada == null) temporadaSeleccionada.Ll_ConfiguracionesDeTemporada = new List<_gen_ConfiguracionTemporada>();
                temporadaSeleccionada.Ll_ConfiguracionesDeTemporada.Add(confNueva);
                temporadaSeleccionada.EsModificado = true;
                manejador.GuardarAsincrono("", temporadaSeleccionada);
                HerramientasWindow.MensajeInformacion("Se ha creado la primer versión de la temporada seleccionada (" + temporadaSeleccionada.St_NombreTemporada + ")", "Creación correcta");
            }
            cmb_configuracionesTemporada.Items.Clear();
            foreach (_gen_ConfiguracionTemporada confs in temporadaSeleccionada.Ll_ConfiguracionesDeTemporada)
            {
                cmb_configuracionesTemporada.Items.Add(confs.St_version);
            }
            txt_Buscador.SetObjetoAsignado(temporadaSeleccionada, temporadaSeleccionada.St_NombreTemporada);
            cmb_configuracionesTemporada.SelectedIndex = temporadaSeleccionada.Ll_ConfiguracionesDeTemporada.Count - 1;
            configuracionTemporada = temporadaSeleccionada.Ll_ConfiguracionesDeTemporada[temporadaSeleccionada.Ll_ConfiguracionesDeTemporada.Count - 1];

            CargarEspaciosDeConfiguracionTemporada();
        }
        private void CargarEspacios()
        {
            croquis.BorrarPoligonos();
            cmb_espaciosDentro.Items.Clear();
            if (espacioTemporal.ll_Espacios_fisicos_dentro != null)
            {
                espacioTemporal.EsPadreTemporalCroquis = true;
                croquis.AgregarPoligono(espacioTemporal, System.Drawing.Color.White, null);
                foreach (_ps_EspacioFisico espacioFisico in espacioTemporal.ll_Espacios_fisicos_dentro)
                {
                    espacioFisico.EsPadreTemporalCroquis = false;
                    croquis.AgregarPoligono(espacioFisico, System.Drawing.Color.DarkGray, null);

                    AgregarEspacioACOMBO(espacioFisico);

                }
            }
        }
        private void AgregarEspacioACOMBO(_ps_EspacioFisico espacioFisico)
        {
            if (espacioFisico.St_CoordenadasEspaciales != null)
                cmb_espaciosDentro.Items.Add(espacioFisico.st_Nombre_espacio + "( " + Math.Abs(Herramientas.WPF.Utilidades.RedondearANDecimales(croquis.CalcularArea(espacioFisico.St_CoordenadasEspaciales) / 10000, 2)) + " ha )");
            else
                cmb_espaciosDentro.Items.Add(espacioFisico.st_Nombre_espacio + "( NA )");
        }
        private void CargarEspaciosDeConfiguracionTemporada()
        {
            try
            {
                if (temporadaSeleccionada == null)
                {
                    HerramientasWindow.MensajeInformacion("Debe seleccionar una temporada previamente.", "Información");
                    return;
                }

                _gen_ConfiguracionTemporada config = configuracionTemporada;
                espaciosFisicosCargados = config.Ll_espaciosAsignados;
                espacioPadre.ll_Espacios_fisicos_dentro = config.Ll_espaciosAsignados;
                espacioPadre.Id = -1;
                espacioTemporal = espacioPadre;

                if (config.Bo_EsVersionLiberada)
                    txt_estatus.Text = "Liberada";
                else
                    txt_estatus.Text = "En desarrollo";

                CargarEspacios();
                inicio_clickInicioRecorrido();
            }
            catch (Exception ex)
            {
                HerramientasWindow.MensajeError(ex, ex.Message, "Error");
            }
        }
        List<UserControl> espaciosSeleccionadosBotones = new List<UserControl>();
        private void ConfigurarBuscadores()
        {
            txt_Buscador.AsignarManejadorDB(manejador);
            txt_Buscador.AsignarCatalogoParaAltas("InterfazWPF.Modulos.Catalogos.win_ps_CatalogoTemporadas");
            txt_Buscador.ConfigurarBusqueda(typeof(_gen_Temporada), "id", "_st_NombreTemporada", false, true);
            txt_Buscador.mostrarResultado += txt_Buscador_mostrarResultado;
            txt_Buscador.AgregarCampoAMostrarConAlias("_st_NombreTemporada|Temporada");

        }
        void croquis_obtenerEspacioAgregado(String coordenadasEspacioAgregado)
        {
            if (temporadaSeleccionada == null)
            {
                HerramientasWindow.MensajeAdvertencia("Debes seleccionar una temporada antes", "Atención");
                return;
            }
            mod_ps_ConfiguracionDatosEspacioFisico confEspacio = new mod_ps_ConfiguracionDatosEspacioFisico();
            HerramientasWindow.MostrarVentanaDialogo(confEspacio, true);

            if (confEspacio.ClickEnAceptar)
            {
                confEspacio.EspacioFisicoModificado.EsModificado = true;
                confEspacio.EspacioFisicoModificado.St_CoordenadasEspaciales = coordenadasEspacioAgregado;
                if (espacioTemporal.st_Nombre_espacio == null)
                {
                    if (configuracionTemporada.Ll_espaciosAsignados == null) configuracionTemporada.Ll_espaciosAsignados = new List<_ps_EspacioFisico>();
                    configuracionTemporada.Ll_espaciosAsignados.Add(confEspacio.EspacioFisicoModificado);
                    configuracionTemporada.EsModificado = true;
                    manejador.Guardar(configuracionTemporada);
                }
                else
                {
                    if (espacioTemporal.ll_Espacios_fisicos_dentro == null) espacioTemporal.ll_Espacios_fisicos_dentro = new List<_ps_EspacioFisico>();
                    espacioTemporal.ll_Espacios_fisicos_dentro.Add(confEspacio.EspacioFisicoModificado);
                    espacioTemporal.EsModificado = true;
                    confEspacio.EspacioFisicoModificado.Oo_EspacioFisicoPadre = espacioTemporal;
                    manejador.Guardar(confEspacio.EspacioFisicoModificado);
                }
                CargarEspacios();
            }
            confEspacio.Close();

        }
        List<String> coordenadasTemporal = new List<string>();
        void croquis_obtenerCoordenada(string coordenada)
        {
            coordenadasTemporal.Add(coordenada);
            croquis.AgregarPoligonoTemporal(null, coordenadasTemporal);
        }

        void croquis_obtenerEspacioSeleccionado(_ps_EspacioFisico espacio)
        {
            //croquis.BorrarPoligonos();

            //List<String> coordenadasAlmacenCardenal = new List<string>();
            //coordenadasAlmacenCardenal.Add("24.754359, -107.479370");
            //coordenadasAlmacenCardenal.Add("24.754332, -107.477693");
            //coordenadasAlmacenCardenal.Add("24.753232, -107.477723");
            //coordenadasAlmacenCardenal.Add("24.754170, -107.479477");

            //croquis.AgregarPoligono(coordenadasAlmacenCardenal, "Almacen", System.Drawing.Color.Gray, null);

            //List<String> tabla1 = new List<string>();
            //tabla1.Add("24.754259, -107.477610");
            //tabla1.Add("24.754246, -107.476117");
            //tabla1.Add("24.753294, -107.476093");
            //tabla1.Add("24.753332, -107.477587");

            //croquis.AgregarPoligono(tabla1, "CSO 1", System.Drawing.Color.Red, new List<string>() { "Cultivo: Pepino Americano" });



            Boolean EsDiferente = espacioTemporal != espacio;


            if (EsDiferente)
            {
                cmb_espaciosDentro.Items.Clear();
                espaciosFisicosCargados = espacio.ll_Espacios_fisicos_dentro;
                espacioTemporal = espacio;
                EspacioSeleccionado EspacioSeleccionadoIndice = new EspacioSeleccionado();
                EspacioSeleccionadoIndice.Titulo = espacioTemporal.st_Nombre_espacio;
                EspacioSeleccionadoIndice.EspacioHistorial = espacioTemporal;
                EspacioSeleccionadoIndice.Height = pnl_Recorrido.Height;
                EspacioSeleccionadoIndice.Indice = espaciosSeleccionadosBotones.Count;
                EspacioSeleccionadoIndice.clickEspacioHistorial += EspacioSeleccionadoIndice_clickEspacioHistorial;
                //pnl_Recorrido.Children.Add(a);
                EspacioSeleccionadoIndice.seAgregoEspacioEvento += espacioGrafico_seAgregoEspacioEvento;
                espaciosSeleccionadosBotones.Add(EspacioSeleccionadoIndice);
                cargarEspaciosBotonesHistorial();

                croquis.BorrarPoligonos();

                //agregando el espacio padre al mapa
                espacioTemporal.EsPadreTemporalCroquis = true;
                croquis.AgregarPoligono(espacioTemporal, System.Drawing.Color.White, null);
                if (espacio.ll_Espacios_fisicos_dentro != null)
                {
                    foreach (_ps_EspacioFisico espacioDentro in espacio.ll_Espacios_fisicos_dentro)
                    {
                        espacioDentro.EsPadreTemporalCroquis = false;
                        croquis.AgregarPoligono(espacioDentro, System.Drawing.Color.DarkGray, null);
                        AgregarEspacioACOMBO(espacioDentro);
                    }
                }
            }
        }
        void EspacioSeleccionadoIndice_clickEspacioHistorial(_ps_EspacioFisico espacioFisico, int indice)
        {
            //click a un boton del historial

            espaciosFisicosCargados = espacioFisico.ll_Espacios_fisicos_dentro;
            espacioTemporal = espacioFisico;
            CargarEspacios();
            espaciosSeleccionadosBotones.RemoveRange(indice + 1, espaciosSeleccionadosBotones.Count - (indice + 1));
            cargarEspaciosBotonesHistorial();
            croquis.DesactivarModoEdicion();
            //croquis.CentrarEspacioEnPantallaConZoom(espacioFisico);

        }

        private void toolbox_Guardar_espacios()
        {
            try
            {
                if (temporadaSeleccionada != null)
                {
                    _gen_ConfiguracionTemporada temporada = configuracionTemporada;
                    manejador.IniciarTransaccion();
                    if (espacioPadre.EsModificado)
                    {
                        temporada.Ll_espaciosAsignados = espacioPadre.ll_Espacios_fisicos_dentro;
                        temporada.EsModificado = true;
                    }
                    manejador.GuardarObjetosModificadosAsincrono("GuardadoTodos");
                }
                else
                    HerramientasWindow.MensajeAdvertencia("Debe seleccionar antes una temporada.", "Atención");
            }
            catch (Exception ex)
            {
                HerramientasWindow.MensajeError(ex, "Ocurrió un error al guardar la temporada. " + ex.Message, "Error");
                manejador.DeshacerTransaccion();
            }
        }
        private void toolbox_Cambiar_Estatus_de_la_Version()
        {
            if (configuracionTemporada == null)
            {
                HerramientasWindow.MensajeAdvertencia("Debe seleccionar antes una temporada.", "Seleccione temporada");
                return;

            }
            configuracionTemporada.Bo_EsVersionLiberada = !configuracionTemporada.Bo_EsVersionLiberada;
            configuracionTemporada.EsModificado = true;
            manejador.Guardar(configuracionTemporada);
            CargarEspaciosDeConfiguracionTemporada();
        }
        private void toolbox_Generar_Nueva_Version()
        {

            if (!HerramientasWindow.MensajeSIoNO("¿Está seguro que desea generar una versión nueva del programa de siembra?", "Generación de versión"))
            {
                return;
            }

            if (configuracionTemporada == null)
            {
                HerramientasWindow.MensajeAdvertencia("Debe cargar una temporada y una versión.", "Atención");
                return;
            }
            manejador.IniciarTransaccion();
            _gen_ConfiguracionTemporada configuracionCopia = configuracionTemporada.CrearCopia<_gen_ConfiguracionTemporada>();
            configuracionCopia.EsModificado = true;
            if (temporadaSeleccionada.Ll_ConfiguracionesDeTemporada == null) temporadaSeleccionada.Ll_ConfiguracionesDeTemporada = new List<_gen_ConfiguracionTemporada>();
            temporadaSeleccionada.Ll_ConfiguracionesDeTemporada.Add(configuracionCopia);
            configuracionCopia.Oo_Temporada = temporadaSeleccionada;
            
            temporadaSeleccionada.EsModificado = true;
            ps_ln_Espacios.CrearNuevaVersionTemporada(manejador, configuracionCopia);
        }
        _ps_EspacioFisico espacioNuevo;
        private void _toolbox_Recargar_espacios_de_servidor()
        {
            if (configuracionTemporada != null)
            {
                manejador.UsarAlmacenObjetos = false;
                CargarEspaciosDeConfiguracionTemporada();
                inicio_clickInicioRecorrido();
                manejador.UsarAlmacenObjetos = true;
            }
            else
                HerramientasWindow.MensajeAdvertencia("Debe seleccionar antes una temporada.", "Atención");
        }

        private void cmb_espaciosDentro_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmb_espaciosDentro.SelectedIndex != -1)
            {
                croquis.CentrarEspacioEnPantallaConZoom(espacioTemporal.ll_Espacios_fisicos_dentro[cmb_espaciosDentro.SelectedIndex]);
            }
        }

        void croquis_espacioClick(_ps_EspacioFisico espacioFisico)
        {
            if (espacioFisico == null) return;
            if (espacioTemporal.ll_Espacios_fisicos_dentro == null) return;
            int index = espacioTemporal.ll_Espacios_fisicos_dentro.IndexOf(espacioFisico);
            cmb_espaciosDentro.SelectedIndex = index;
        }
        private void toolbox_Activar_o_desactivar_modo_edicion()
        {
            if (temporadaSeleccionada != null)
            {
                croquis.ActivarDesactivarModoEdicion();
            }
            else
                HerramientasWindow.MensajeAdvertencia("Debe seleccionar antes una temporada.", "Atención");
        }

        private void cmb_perspectivas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmb_perspectivas.SelectedIndex >= 0)
                if (cmb_perspectivas.SelectedIndex == 0)
                    CargarEspacios();
                else
                {
                    CargarEspacios();
                    croquis.Simulacion(cmb_perspectivas.SelectedIndex);
                }
        }
        private void AgregarVistasCroquis()
        {
            cmb_InformacionCroquis.Items.Add("Características de los espacios");
            cmb_InformacionCroquis.Items.Add("Etapas, fechas y cultivos");
            cmb_InformacionCroquis.Items.Add("Espacios y hectareas");
            cmb_InformacionCroquis.Items.Add("Cultivo, fecha planteo, camas hectareas.");
        }
        string croquis_construirDatosAMostrar(_ps_EspacioFisico espacio)
        {
            String datos = "";
            if (cmb_InformacionCroquis.SelectedIndex == 0)
            {
                datos = espacio.st_Nombre_espacio;
                datos += "|Per(m): " + espacio.Do_MetrosPerimetro;
                datos += "|Area(ha): " + espacio.do_Numero_hectareas;
                datos += "|Camas: " + espacio.In_Numero_de_camas;
                datos += "|Casetas: " + espacio.In_NumeroCasetas;
                datos += "|Caídas: " + espacio.In_NumeroCaidas;
                datos += "|Perif: " + espacio.In_NumeroPerifericas;
            }
            else if (cmb_InformacionCroquis.SelectedIndex == 1)
            {
                datos = espacio.st_Nombre_espacio;

                if (espacio.ll_Configuraciones_de_Siembra != null)
                {
                    foreach (_ps_ConfiguracionSiembra conf in espacio.ll_Configuraciones_de_Siembra)
                    {
                        String variedad = "";
                        if (conf.Bo_SeUsaInjerto)
                        {
                            if (conf.Oo_DatosInjerto != null)
                                variedad = conf.Oo_DatosInjerto.Oo_VariedadProductiva.st_Nombre + "-" + conf.Oo_DatosInjerto.Oo_VariedadRaiz.st_Nombre;
                        }
                        else
                        {
                            if (conf.oo_Variedad_de_semilla != null)
                            {
                                variedad = conf.oo_Variedad_de_semilla.st_Nombre;
                            }
                        }
                        datos += "|Etapa " + conf.Oo_EtapaConfiguracionSiembra.St_NombreEtapa + ": "; // +conf.oo_Cultivo_plantado.st_Nombre_cultivo;
                        datos += "|Cult: " + conf.oo_Cultivo_plantado.St_Abreviatura;
                        datos += "|Var: " + variedad;
                        datos += "|Siem: " + Herramientas.Conversiones.Formatos.DateTimeAFechaCortaConDiaMesTexto(conf.dt_Fecha_de_planteo.AddDays(conf.oo_Cultivo_plantado.In_DiasAntesSiembra * -1));
                        datos += "|Plan: " + Herramientas.Conversiones.Formatos.DateTimeAFechaCortaConDiaMesTexto(conf.dt_Fecha_de_planteo);
                        datos += "|Cose: " + Herramientas.Conversiones.Formatos.DateTimeAFechaCortaConDiaMesTexto(conf.dt_Fecha_de_planteo.AddDays(conf.oo_Cultivo_plantado.In_DiasDespuesCosecha));

                    }
                }
                else
                {
                    datos += "|Sin configurar";
                }
            }
            else if (cmb_InformacionCroquis.SelectedIndex == 2)
            {
                datos = espacio.st_Nombre_espacio;
                datos += "|Area(ha): " + espacio.do_Numero_hectareas;
            }
            else if (cmb_InformacionCroquis.SelectedIndex == 3)
            {
                datos = espacio.st_Nombre_espacio;

                if (espacio.ll_Configuraciones_de_Siembra != null)
                {
                    datos += "|Area(Ha): " + Herramientas.Conversiones.Formatos.DoubleRedondearANDecimales(espacio.do_Numero_hectareas, 2);
                    datos += "|Camas: " + espacio.In_Numero_de_camas;
                    datos += "|Marca: " + espacio.Fl_Separacion_entre_camas;

                    foreach (_ps_ConfiguracionSiembra conf in espacio.ll_Configuraciones_de_Siembra)
                    {
                        String variedad = "";
                        if (conf.Bo_SeUsaInjerto)
                        {
                            if (conf.Oo_DatosInjerto != null)
                                variedad = conf.Oo_DatosInjerto.Oo_VariedadProductiva.st_Nombre + "-" + conf.Oo_DatosInjerto.Oo_VariedadRaiz.st_Nombre;
                        }
                        else
                        {
                            if (conf.oo_Variedad_de_semilla != null)
                            {
                                variedad = conf.oo_Variedad_de_semilla.st_Nombre;
                            }
                        }

                        datos += "|Etapa " + conf.Oo_EtapaConfiguracionSiembra.St_NombreEtapa + ": "; // +conf.oo_Cultivo_plantado.st_Nombre_cultivo;
                        datos += "|Cult: " + conf.oo_Cultivo_plantado.St_Abreviatura;
                        datos += "|Densidad: " + conf.Do_Densidad_PlantasXMetro2;
                        datos += "|Var: " + variedad;
                        datos += "|Plan: " + Herramientas.Conversiones.Formatos.DateTimeAFechaCortaConDiaMesTexto(conf.dt_Fecha_de_planteo);

                    }
                }
                else
                {
                    datos += "|Sin configurar";
                }
            }
            return datos;
        }
        //cmb_tiposReportes.Items.Add("Caracteristicas físicas de espacios");
        //    cmb_tiposReportes.Items.Add("Fechas y cultivos de espacios");
        private void btn_reporteExportar_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (cmb_tiposReportes.SelectedItem != null)
            {
                if (temporadaSeleccionada == null)
                {
                    HerramientasWindow.MensajeAdvertencia("Primero debes seleccionar una temporada.", "Mensaje");
                    return;
                }
                try
                {

                    String ruta = Herramientas.Archivos.Dialogos.GuardarArchivoRuta(new List<string>() { "Archivo de excel" }, new List<string>() { "xls" }, "archivo.xls");
                    DataTable dt = new DataTable();
                    ExcelAPI excel = new ExcelAPI();
                    excel.terminoConversion += ex_terminoConversion;

                    if (cmb_tiposReportes.SelectedItem.ToString().Equals("Caracteristicas físicas de espacios"))
                    {
                        String query = @"
            select 
            esp._st_Nombre_espacio as [Campo]
            --,esp2.id as [ID_ESPACIO]
            , esp2._st_Nombre_espacio as [Tabla]
            , tecnologia._st_Descripcion as [Tecnología]
            --, etapa.id as [ID_ETAPA]
            , etapa._st_NombreEtapa as [Etapa]
            , cultivo._st_Nombre_cultivo as [Cultivo]
			, variedad._st_Nombre [Variedad]
			,Convert(varchar, dateadd(day,(cultivo._in_DiasAntesSiembra * -1),confSiembra._dt_Fecha_de_planteo), 103) as [Fecha de siembra]
			,Convert(varchar, confSiembra._dt_Fecha_de_planteo, 103) as [Fecha de planteo]
			,Convert(varchar, dateadd(day,cultivo._in_DiasDespuesCosecha,confSiembra._dt_Fecha_de_planteo), 103) as [Fecha de cosecha]
            
            --, perfil.id as [ID_PERFIL]
            --, perfil._st_NombrePerfil as [Perfil aplicado]
            --, material.id as [ID_MATERIAL]
            --, confSiembra.id [ID_CONFSIEMBRA]
            --, cast(actividadNomina._in_idCrop as varchar(MAX)) + ' - ' + actividadNomina._st_Nombre as [Actividades dentro del perfil]
            --, formula._st_Formula as [Formula]
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
            --, case 
            --when confiMaterial._in_FechaInicioRespecto = 0 
            --then Convert(varchar, dateadd(day,(cultivo._in_DiasAntesSiembra * -1) + (tiempoInicio._do_EquivalenciaEn1Hora / 8) * confiMaterial._do_tiempoRelativoInicio,confSiembra._dt_Fecha_de_planteo), 120)
            --when confiMaterial._in_FechaInicioRespecto = 1 
            --then Convert(varchar,dateadd(day,(tiempoInicio._do_EquivalenciaEn1Hora / 8) * confiMaterial._do_tiempoRelativoInicio,confSiembra._dt_Fecha_de_planteo), 120)
            --when confiMaterial._in_FechaInicioRespecto = 2
            --then Convert(varchar,dateadd(day,cultivo._in_DiasDespuesCosecha + (tiempoInicio._do_EquivalenciaEn1Hora / 8) * confiMaterial._do_tiempoRelativoInicio,confSiembra._dt_Fecha_de_planteo), 120)
            --end as [Fecha inicio Material]
            --, case when confiMaterial._bo_UsarPeriodoDeProduccion is null then 0 else confiMaterial._bo_UsarPeriodoDeProduccion end [Usar Periodo Produccion]
            --, case when confiMaterial._bo_SinRepeticiones is null then 0 else confiMaterial._bo_SinRepeticiones end as [Sin repetición]
            --, case when confiMaterial._bo_hastaCumplirTodasUnidades is null then 0 else confiMaterial._bo_hastaCumplirTodasUnidades end as [Hasta cumplir unidades totales]
						
            --, case when confiActividad._do_plazo is null then 0 else confiActividad._do_plazo end as [Plazo]
            --, confiMaterial._in_Repeticiones as [Repeticiones]
            --, confiMaterial._in_veces as [Veces]
            --, confiActividad._do_frecuencia
            --, tiempoFrecuencia._st_Nombre
            --, case when confiMaterial._oo_unidadTiempoFrecuencia is null then 0 else (tiempoFrecuencia._do_EquivalenciaEn1Hora / 8) * confiMaterial._do_frecuencia end as [Dias frecuencia]
            --, case when confiMaterial._do_plazo is null or confiMaterial._oo_unidadTiempoPlazo is null then 0 else (tiempoPlazo._do_EquivalenciaEn1Hora / 8) * confiMaterial._do_plazo end as [Dias Plazo]
            --, '' as [Fecha Termino plazo]
            --, '' as [Fechas de material]
            ---------------------------------------------------------
            --, material._do_PrecioUnitario as [@costo_unitario_material]
            --, material._do_UnidadesMedida as [@valor_unidades]
            --, medida._st_Nombre as [Medida]
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
            --, case when confiMaterial._in_Repeticiones = 0 then 1 else confiMaterial._in_Repeticiones end as [@dias_totales]
            --, cast(0 as varchar(MAX)) as [Costo calculado]
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
            left join _ps_TecnologiaCultivo tecnologia on confTecnologica._oo_TecnologiaDeCultivoUsada = tecnologia.id
            left join _ps_VariedadSemilla variedad on confSiembra._oo_Variedad_de_semilla = variedad.id

            where temporada.id = " + temporadaSeleccionada.Id + @"
            and confTemporada.id = 
            (
	            select top 1 confTemp.id 
	            from _gen_Temporada_X__gen_ConfiguracionTemporada__ll_ConfiguracionesDeTemporada temp_conftemp
	            inner join _gen_ConfiguracionTemporada confTemp on temp_conftemp._contenido = confTemp.id
	            where _contenedor = temporada.id and confTemp._bo_EsVersionLiberada = 1
	            order by confTemp.dtFechaModificacion desc
            )
            order by Campo, Tabla, Etapa desc";


                        dt = manejador.EjecutarConsulta(query);



                    }
                    else if (cmb_tiposReportes.SelectedItem.ToString().Equals("Fechas y cultivos de espacios"))
                    {
                        String query = @"
                    select 
            esp._st_Nombre_espacio as [Campo]
            --,esp2.id as [ID_ESPACIO]
            , esp2._st_Nombre_espacio as [Tabla]
            --, tecnologia._st_Descripcion as [Tecnología]
            --, etapa.id as [ID_ETAPA]
            , etapa._st_NombreEtapa as [Etapa]
            , cultivo._st_Nombre_cultivo as [Cultivo]
            ,Convert(varchar, dateadd(day,(cultivo._in_DiasAntesSiembra * -1),confSiembra._dt_Fecha_de_planteo), 103) as [Fecha de siembra]
			,Convert(varchar, confSiembra._dt_Fecha_de_planteo, 103) as [Fecha de planteo]
			,Convert(varchar, dateadd(day,cultivo._in_DiasDespuesCosecha,confSiembra._dt_Fecha_de_planteo), 103) as [Fecha de cosecha]
            
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
            
            where temporada.id = " + temporadaSeleccionada.Id + @"
            and confTemporada.id = 
            (
	            select top 1 confTemp.id 
	            from _gen_Temporada_X__gen_ConfiguracionTemporada__ll_ConfiguracionesDeTemporada temp_conftemp
	            inner join _gen_ConfiguracionTemporada confTemp on temp_conftemp._contenido = confTemp.id
	            where _contenedor = temporada.id and confTemp._bo_EsVersionLiberada = 1
	            order by confTemp.dtFechaModificacion desc
            )
            order by Campo, Tabla, Etapa desc";

                        dt = manejador.EjecutarConsulta(query);

                    }

                    excel.ConvertirDataTableAExcel(ruta, dt);
                }

                catch (Exception ex)
                {
                    HerramientasWindow.MensajeError(ex, "Error: " + ex.Message, "Error");
                }
            }
        }

        void ex_terminoConversion(string rutaGuardado)
        {
            HerramientasWindow.MensajeInformacionHilo(this, "Archivo guardado en " + rutaGuardado, "Guardado correcto");
        }
    }
}
