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
using Dominio;
using LogicaNegocios;
using InterfazWPF.Modulos.Reportes;
using Dominio.Sistema;
using System.Data;
using Dominio.Modulos.ProgramaSiembra;
using Dominio.Modulos.General;
using InterfazWPF.AdministracionSistema;
using LogicaNegocios.ProgramaSiembra;
using System.Windows.Markup;
using System.IO;
using System.Xml;
using System.Drawing;
using Herramientas.ORM;

namespace InterfazWPF.Modulos.ProgramaSiembra
{
    /// <summary>
    /// Lógica de interacción para win_ps_ejemploA.xaml
    /// </summary>
    public partial class win_ps_PrincipalProgramaSiembra : Window
    {
        ManejadorDB manejador = new ManejadorDB();
        _gen_Temporada temporadaSeleccionada;
        _gen_ConfiguracionTemporada configuracionTemporada;

        int controlWidth = 150;
        int controlHeight = 100;
        int ConfiguracionCargada = -1;

        List<_ps_EspacioFisico> espaciosFisicosCargados = new List<_ps_EspacioFisico>();
        _ps_EspacioFisico espacioTemporal;
        _ps_EspacioFisico espacioPadre;

        public win_ps_PrincipalProgramaSiembra()
        {
            InitializeComponent();
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

            IsVisibleChanged += win_ps_PrincipalProgramaSiembra_IsVisibleChanged;

            //this.lbl_temporada.PreviewMouseLeftButtonDown += EspacioGrafico_PreviewMouseLeftButtonDown;
            //this.lbl_temporada.PreviewMouseMove += EspacioGrafico_PreviewMouseMove;
            //lbl_temporada.AllowDrop = true;

            img_basura.AllowDrop = true;
            img_basura.Drop += img_basura_Drop;

            manejador.guardadoTerminado += manejador_guardadoTerminado;
            manejador.guardadoError += manejador_guardadoError;
        }


        private void ConfigurarBuscadores()
        {
            txt_Buscador.AsignarManejadorDB(manejador);
            txt_Buscador.AsignarCatalogoParaAltas("InterfazWPF.Modulos.Catalogos.win_ps_CatalogoTemporadas");
            txt_Buscador.ConfigurarBusqueda(typeof(_gen_Temporada), "id", "_st_NombreTemporada", false, true);
            txt_Buscador.mostrarResultado += txt_Buscador_mostrarResultado;
            txt_Buscador.AgregarCampoAMostrarConAlias("_st_NombreTemporada|Temporada");

        }

        private void txt_Buscador_mostrarResultado(List<ObjetoBase> listaObjetos)
        {
            if (listaObjetos != null)
            {
                temporadaSeleccionada = (_gen_Temporada)listaObjetos[0];
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
                    HerramientasWindow.MensajeInformacion("Se ha creado la primer versión de la temporada seleccionada (" + temporadaSeleccionada.St_NombreTemporada +")", "Creación correcta");
                }
                cmb_configuracionesTemporada.Items.Clear();
                foreach (_gen_ConfiguracionTemporada confs in temporadaSeleccionada.Ll_ConfiguracionesDeTemporada)
                {
                    cmb_configuracionesTemporada.Items.Add(confs.St_version);
                }
                cmb_configuracionesTemporada.SelectedIndex = temporadaSeleccionada.Ll_ConfiguracionesDeTemporada.Count - 1;
                configuracionTemporada = temporadaSeleccionada.Ll_ConfiguracionesDeTemporada[temporadaSeleccionada.Ll_ConfiguracionesDeTemporada.Count - 1];

                CargarEspaciosDeTemporada();
            }
        }

        void img_basura_Drop(object sender, DragEventArgs e)
        {
            EspacioGrafico espacio = (EspacioGrafico)e.Data.GetData(typeof(EspacioGrafico));
            if (espacio != null)
            {
                if (HerramientasWindow.MensajeSIoNOAdvertencia("¿Desea eliminar el espacio seleccionado?", "Advertencia!!"))
                {
                    ps_ln_Espacios.EliminarEspacioAEspacio(espacioTemporal, espacio.EspacioRepresentado);
                    CargarEspacios();
                }
            }

        }

        void win_ps_PrincipalProgramaSiembra_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            //pnl_EspaciosFisicosCargados.MaxWidth = rtg_fondo.Width;
        }

        void inicio_clickInicioRecorrido()
        {
            espacioTemporal = espacioPadre;
            espaciosFisicosCargados = espacioTemporal.ll_Espacios_fisicos_dentro;

            CargarEspacios();

            espaciosSeleccionadosBotones.RemoveRange(1, espaciosSeleccionadosBotones.Count - 1);
            cargarEspaciosBotonesHistorial();

        }
        private void CargarEspacios()
        {
            pnl_EspaciosFisicosCargados.Children.Clear();
            if (espacioTemporal.ll_Espacios_fisicos_dentro != null)
            {
                foreach (_ps_EspacioFisico espacioFisico in espacioTemporal.ll_Espacios_fisicos_dentro)
                {
                    EspacioGrafico espacioGrafico = new EspacioGrafico(espacioFisico);
                    //espacioGrafico.Width = controlWidth;
                    //espacioGrafico.Height = controlHeight;
                    pnl_EspaciosFisicosCargados.Children.Add(espacioGrafico);
                    espacioGrafico.clickEspacioDetalle += espacioGrafico_clickEspacioDetalle;
                    espacioGrafico.clickEspacioEliminar += espacioGrafico_clickEspacioEliminar;
                    espacioGrafico.dobleClickEspacio += espacioGrafico_dobleClickEspacio;
                    espacioGrafico.clickEspacioCultivo += espacioGrafico_clickEspacioCultivo;
                    espacioGrafico.seAgregoEspacioEvento += espacioGrafico_seAgregoEspacioEvento;
                }
            }
        }

        void espacioGrafico_clickEspacioCultivo(_ps_EspacioFisico espacioFisicoContenido)
        {
            mod_ps_ConfiguracionEspacioFisicoSelectorEtapa mep = new mod_ps_ConfiguracionEspacioFisicoSelectorEtapa(espacioFisicoContenido, manejador);
            mep.ShowDialog();

            _ps_ConfiguracionSiembra confSiembra = mep.ConfiguracionSeleccionada;
            int indice = mep.IndiceConfiguracionSiembra;

            AlmacenMemoria.Guardar("indiceConfSiembra", indice);

            if (confSiembra != null)
            {

                //MultiplesVentanasProceso mul = new MultiplesVentanasProceso("Configuración de espacio.", new List<Object>() { confSiembra, espacioFisicoContenido }, manejador);
                //mul.AgregarVentanaProceso(new InterfazWPF.Modulos.ProgramaSiembra.proc_ps_ConfiguracionEspacioFisico_DatosCultivo(), "Configuración del cultivo y fechas.");
                //if (espacioFisicoContenido.ll_Configuraciones_de_Siembra != null && espacioFisicoContenido.ll_Configuraciones_de_Siembra.Count > 0)
                //{
                //    if (confSiembra.Bo_SeUsaInjerto)
                //        mul.AgregarVentanaProceso(new proc_ps_ConfiguracionEspacioFisico_DatosInjertos(), "Configuración de injerto para el cultivo '" + confSiembra.oo_Cultivo_plantado.st_Nombre_cultivo + "'.");
                //}
                ////mul.Closed += conf_Closed;
                //mul.guardarDatos += mul_guardarDatos;
                //espacioTemp = espacioFisicoContenido;
                //HerramientasWindow.MostrarVentana(mul, true);
            }
            mep.Close();
        }
        void mulDatEspacio_guardarDatos(List<object> parametros)
        {
            _ps_EspacioFisico copia = AlmacenMemoria.Obtener<_ps_EspacioFisico>("espacioFisicoCopia");

            _ps_EspacioFisico original = AlmacenMemoria.Obtener<_ps_EspacioFisico>("espacioFisicoOriginal");



            original = copia;
            original.EsModificado = true;

            espacioTemp = original;

            manejador.GuardarAsincrono("espacioOriginal",original);

            //toolbox_Guardar_espacios();

        }
        void mul_guardarDatos(List<object> parametros)
        {
            _ps_ConfiguracionSiembra confTemp = AlmacenMemoria.Obtener<_ps_ConfiguracionSiembra>("confSiembraCopia");
            _ps_EspacioFisico espSeleccionado = (_ps_EspacioFisico)parametros[1];
            int indice = AlmacenMemoria.Obtener<int>("indiceConfSiembra");
            confTemp.EsModificado = true;
            espSeleccionado.ll_Configuraciones_de_Siembra[indice] = confTemp;
            espSeleccionado.EsModificado = true;

            _ps_ConfiguracionSiembra confOrig = AlmacenMemoria.Obtener<_ps_ConfiguracionSiembra>("confSiembraOriginal");
            confOrig.Dispose();

            AlmacenMemoria.Borrar("indiceConfSiembra");
            AlmacenMemoria.Borrar("confSiembraCopia");
            AlmacenMemoria.Borrar("confSiembraOriginal");
            toolbox_Guardar_espacios();
        }

        void espacioGrafico_seAgregoEspacioEvento(EspacioGrafico espacioSeleccionado)
        {
            if (espacioTemporal != null)
                ps_ln_Espacios.EliminarEspacioAEspacio(espacioTemporal, espacioSeleccionado.EspacioRepresentado);
            else
                ps_ln_Espacios.EliminarEspacioAEspacio(espacioPadre, espacioSeleccionado.EspacioRepresentado);
            CargarEspacios();
        }
        private void CargarEspaciosDeTemporada()
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
                CargarEspacios();

            }
            catch (Exception ex)
            {
                HerramientasWindow.MensajeError(ex, ex.Message, "Error");
            }
        }
        List<UserControl> espaciosSeleccionadosBotones = new List<UserControl>();
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
        void espacioGrafico_dobleClickEspacio(_ps_EspacioFisico espacioSeleccionado)
        {
            if (!espacioSeleccionado.Bo_esEspacioFinal)
            {
                espaciosFisicosCargados = espacioSeleccionado.ll_Espacios_fisicos_dentro;
                espacioTemporal = espacioSeleccionado;
                CargarEspacios();
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
            }
            else
            {
                //espacioGrafico_clickEspacioDetalle(espacioSeleccionado);
            }
        }

        void EspacioSeleccionadoIndice_clickEspacioHistorial(_ps_EspacioFisico espacioFisico, int indice)
        {
            espaciosFisicosCargados = espacioFisico.ll_Espacios_fisicos_dentro;
            espacioTemporal = espacioFisico;
            CargarEspacios();
            espaciosSeleccionadosBotones.RemoveRange(indice + 1, espaciosSeleccionadosBotones.Count - (indice + 1));
            cargarEspaciosBotonesHistorial();
        }

        void espacioGrafico_clickEspacioEliminar(_ps_EspacioFisico espacioFisicoContenido)
        {
            if (HerramientasWindow.MensajeSIoNOAdvertencia("¿Está seguro de eliminar el espacio seleccionado?", "Atención"))
            {
                ps_ln_Espacios.EliminarEspacioAEspacio(espacioTemporal, espacioFisicoContenido);
                espaciosFisicosCargados.Remove(espacioFisicoContenido);
                CargarEspacios();
            }
        }

        void espacioGrafico_clickEspacioDetalle(_ps_EspacioFisico espacioFisicoContenido)
        {
            AbrirConfiguracionEspacio(espacioFisicoContenido);
        }
        private _ps_EspacioFisico espacioTemp;
        private void AbrirConfiguracionEspacio(_ps_EspacioFisico espacioFisico)
        {
            //espacioTemp = manejador.CrearObjeto<_ps_EspacioFisico>();
            if (espacioFisico.Bo_esEspacioFinal)
            {
                //MultiplesVentanasProceso mulDatEspacio = new MultiplesVentanasProceso("Configuración de espacio.", new List<Object>() { espacioFisico }, manejador);
                //mulDatEspacio.AgregarVentanaProceso(new InterfazWPF.Modulos.ProgramaSiembra.proc_ps_ConfiguracionEspacioFisico_DatosEspacio(), "Configuración de '" + espacioFisico.st_Nombre_espacio + "'.");
                //mulDatEspacio.AgregarVentanaProceso(new InterfazWPF.Modulos.ProgramaSiembra.proc_ps_ConfiguracionEspacioFisico_DatosTecnologia(), "Configuración de la tecnología.");

                ////mulDatEspacio.Closed += conf_Closed;
                //espacioTemp = espacioFisico;
                //mulDatEspacio.guardarDatos += mulDatEspacio_guardarDatos;
                //HerramientasWindow.MostrarVentana(mulDatEspacio, true);

                ///HerramientasWindow.PrincipalAgregarVentana(mul, "testeando");

            }
            else
            {
                mod_ps_NombreEspacio nombre = new mod_ps_NombreEspacio(espacioFisico);
                nombre.Closed += nombre_Closed;
                espacioTemp = espacioFisico;
                HerramientasWindow.MostrarVentana(nombre, true);
            }
        }
        private void btn_cargarEspacios_MouseDown(object sender, MouseButtonEventArgs e)
        {
            CargarEspaciosDeTemporada();
        }
        private void _toolbox_Recargar_espacios_de_servidor()
        {
            manejador.UsarAlmacenObjetos = false;
            CargarEspaciosDeTemporada();
            inicio_clickInicioRecorrido();
            manejador.UsarAlmacenObjetos = true;
        }
        private void toolbox_Generar_version()
        {
            //aqui codigo necesario para generar versión
        }
        private void toolbox_Ejecutar()
        {
            CargarEspaciosDeTemporada();
        }
        private void toolbox_Agregar()
        {
            AgregarEspacioFisico();
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
            }
            catch (Exception ex)
            {
                HerramientasWindow.MensajeError(ex, "Ocurrió un error al guardar la temporada. " + ex.Message, "Error");
                manejador.DeshacerTransaccion();
            }
        }
        _ps_EspacioFisico espacioNuevo;
        private void btn_AgregarEspacioFisico_MouseDown(object sender, MouseButtonEventArgs e)
        {
            AgregarEspacioFisico();
        }

        private void AgregarEspacioFisico()
        {
            if (temporadaSeleccionada == null)
            {
                HerramientasWindow.MensajeInformacion("Debe seleccionar una temporada previamente.", "Seleccione una temporada");
                return;
            }
            espacioTemporal.EsModificado = true;
            espacioNuevo = manejador.CrearObjeto<_ps_EspacioFisico>();
            espacioNuevo.EsModificado = true;
            espacioNuevo.Bo_esEspacioFinal = false;
            AbrirConfiguracionEspacio(espacioNuevo);

        }

        void nombre_Closed(object sender, EventArgs e)
        {
            if (((mod_ps_NombreEspacio)sender).SeAcepto)
            {
                if (!ps_ln_Espacios.ExisteNombreEspacioDentroDeEspacio(espacioTemporal, espacioTemp.st_Nombre_espacio))
                {
                    ps_ln_Espacios.AgregarEspacioAEspacio(espacioTemporal, espacioTemp);
                    CargarEspacios();
                }
                else
                {
                    HerramientasWindow.MensajeInformacion("El nombre de espacio que desea agregar ya existe dentro de este espacio, cambie el nombre del espacio que desea agregar.", "Nombre de espacio existente");
                    espacioTemp = null;
                }
            }
        }

        //void conf_Closed(object sender, EventArgs e)
        //{
        //    if (((MultiplesVentanasProceso)sender).SeFinalizo)
        //    {
        //        ps_ln_Espacios.AgregarEspacioAEspacio(espacioTemporal, espacioTemp);
        //        CargarEspacios();
        //    }
        //}

    }
}
