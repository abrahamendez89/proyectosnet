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
using Dominio.Modulos.ProgramaSiembra;
using InterfazWPF.AdministracionSistema;
using Dominio;
using Dominio.Modulos.General;
using LogicaNegocios.ProgramaSiembra;
using System.Windows.Controls.Primitives;
using Herramientas.ORM;

namespace InterfazWPF.Modulos.ProgramaSiembra
{
    /// <summary>
    /// Lógica de interacción para mod_ps_ConfiguracionDatosEspacioFisico.xaml
    /// </summary>
    public partial class mod_ps_ConfiguracionDatosEspacioFisico : Window
    {
        ManejadorDB manejador = new ManejadorDB();
        _gen_Cultivo cultivo;
        _ps_EtapaConfiguracionSiembra etapa;
        _ps_EspacioFisico espacioFisicoOriginal;
        _ps_EspacioFisico espacioTemporal;
        _ps_ConfiguracionSiembra confSiembraSeleccionada;
        _ps_TecnologiaCultivo tecnologia;

        public Boolean ClickEnAceptar { get; set; }
        public _ps_EspacioFisico EspacioFisicoModificado { get; set; }

        public mod_ps_ConfiguracionDatosEspacioFisico()
        {
            InitializeComponent();
            espacioTemporal = new _ps_EspacioFisico();
            chb_esEspacioFinal.IsChecked = false;


            Iniciales();
            OcultarControles();
            ConfigurarGridMaterialesVariables();
        }
        private void ConfigurarGridMaterialesVariables()
        {
            HerramientasWindow.AgregarColumnaConBindingADataGridView(dgv_materialesVariables, "Material Variable", "MaterialVariable");
            HerramientasWindow.AgregarColumnaConBindingADataGridView(dgv_materialesVariables, "Material Específico", "MaterialEspecifico");
        }
        private void Iniciales()
        {
            dgv_Etapas.MouseLeftButtonUp += dgv_Etapas_MouseLeftButtonUp;
            chb_SeHaranInjertos.Checked += chb_SeHaranInjertos_Checked;
            chb_SeHaranInjertos.Unchecked += chb_SeHaranInjertos_Unchecked;
            accesoCatalogo.asignarObjetoCatalogo += accesoCatalogo_asignarObjetoCatalogo;
            accesoCatalogo.Configurar(manejador, "InterfazWPF.Modulos.Catalogos.win_ps_CatalogoVariedades");
            cmb_etapasConfPerfiles.SelectionChanged += cmb_etapasConfPerfiles_SelectionChanged;
            inicializarBuscadores();
        }



        ObjetoBase accesoCatalogo_asignarObjetoCatalogo()
        {
            return null;
        }

        void chb_SeHaranInjertos_Unchecked(object sender, RoutedEventArgs e)
        {

            gb_datosInjerto.Visibility = System.Windows.Visibility.Hidden;
            gb_datosVariedad.Visibility = System.Windows.Visibility.Visible;
        }

        void chb_SeHaranInjertos_Checked(object sender, RoutedEventArgs e)
        {
            gb_datosInjerto.Visibility = System.Windows.Visibility.Visible;
            gb_datosVariedad.Visibility = System.Windows.Visibility.Hidden;
        }
        int seleccionado = -1;
        void dgv_Etapas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            seleccionado = HerramientasWindow.ObtenerRowSeleccionadoDataGrid(sender, e);
            if (seleccionado != -1)
                confSiembraSeleccionada = espacioTemporal.ll_Configuraciones_de_Siembra[seleccionado];
            CargarConfiguracionSiembraSeleccionada();

        }

        private void CargarConfiguracionSiembraSeleccionada()
        {
            //cargando configuracion de siembra seleccionada
            if (confSiembraSeleccionada.Oo_EtapaConfiguracionSiembra != null)
            {
                txt_BuscadorEtapa.SetObjetoAsignado(confSiembraSeleccionada.Oo_EtapaConfiguracionSiembra, confSiembraSeleccionada.Oo_EtapaConfiguracionSiembra.St_NombreEtapa);
                etapa = confSiembraSeleccionada.Oo_EtapaConfiguracionSiembra;
            }
            if (confSiembraSeleccionada.oo_Cultivo_plantado != null)
            {
                txt_BuscadorCultivo.SetObjetoAsignado(confSiembraSeleccionada.oo_Cultivo_plantado, confSiembraSeleccionada.oo_Cultivo_plantado.st_Nombre_cultivo);
                cultivo = confSiembraSeleccionada.oo_Cultivo_plantado;
                CargarVariedadesDeCultivo();
            }
            if (confSiembraSeleccionada.Bo_SeUsaInjerto)
            {
                gb_datosInjerto.Visibility = System.Windows.Visibility.Visible;
                gb_datosVariedad.Visibility = System.Windows.Visibility.Hidden;
                cmb_VariedadProductiva.SelectedItem = confSiembraSeleccionada.Oo_DatosInjerto.Oo_VariedadProductiva.st_Nombre;
                cmb_VariedadRaiz.SelectedItem = confSiembraSeleccionada.Oo_DatosInjerto.Oo_VariedadRaiz.st_Nombre;
            }
            else
            {
                gb_datosInjerto.Visibility = System.Windows.Visibility.Hidden;
                gb_datosVariedad.Visibility = System.Windows.Visibility.Visible;
                cmb_variedadAUsar.SelectedValue = confSiembraSeleccionada.oo_Variedad_de_semilla.st_Nombre;
            }
            chb_EsPlanteoAbierto.IsChecked = confSiembraSeleccionada.Bo_EsPlanteoAbierto;
            chb_SeHaranInjertos.IsChecked = confSiembraSeleccionada.Bo_SeUsaInjerto;
            chb_SeUsaraTransplante.IsChecked = confSiembraSeleccionada.Bo_HayTransplante;
            txt_densidadPlanteoXMetro2.ValorDouble = confSiembraSeleccionada.Do_Densidad_PlantasXMetro2;

            dtp_FechaSiembra.SelectedDate = confSiembraSeleccionada.dt_Fecha_de_planteo.AddDays(cultivo.In_DiasAntesSiembra * -1);
            dtp_FechaPlanteo.SelectedDate = confSiembraSeleccionada.dt_Fecha_de_planteo;
            dtp_FechaCosecha.SelectedDate = confSiembraSeleccionada.dt_Fecha_de_planteo.AddDays(cultivo.In_DiasDespuesCosecha);

        }
        private void btn_GuardarConfiguracion_MouseUp(object sender, MouseButtonEventArgs e)
        {
            //guardando la conf de siembra
            Boolean esNuevo = false;
            if (confSiembraSeleccionada == null || confSiembraSeleccionada.Id == 0)
            {
                if (confSiembraSeleccionada == null)
                    confSiembraSeleccionada = new _ps_ConfiguracionSiembra();
                esNuevo = true;
            }
            if (cmb_variedadAUsar.SelectedIndex == -1)
            {
                HerramientasWindow.MensajeInformacion("Debe seleccionar una variedad.", "Variedad");
                return;
            }
            confSiembraSeleccionada.EsModificado = true;
            confSiembraSeleccionada.oo_Cultivo_plantado = cultivo;
            confSiembraSeleccionada.Oo_EtapaConfiguracionSiembra = etapa;
            confSiembraSeleccionada.dt_Fecha_de_planteo = dtp_FechaPlanteo.SelectedDate.Value;
            confSiembraSeleccionada.Do_Densidad_PlantasXMetro2 = txt_densidadPlanteoXMetro2.ValorDouble;
            confSiembraSeleccionada.Bo_HayTransplante = (Boolean)chb_SeUsaraTransplante.IsChecked;
            confSiembraSeleccionada.Bo_EsPlanteoAbierto = (Boolean)chb_EsPlanteoAbierto.IsChecked;
            if (!(Boolean)chb_SeHaranInjertos.IsChecked)
            {
                confSiembraSeleccionada.Bo_SeUsaInjerto = false;
                confSiembraSeleccionada.oo_Variedad_de_semilla = cultivo.Ll_VariedadesDisponibles[cmb_variedadAUsar.SelectedIndex];
            }
            else
            {
                confSiembraSeleccionada.Bo_SeUsaInjerto = true;
                if (confSiembraSeleccionada.Oo_DatosInjerto == null) confSiembraSeleccionada.Oo_DatosInjerto = new _ps_DatosInjerto();
                confSiembraSeleccionada.Oo_DatosInjerto.Oo_VariedadProductiva = variedadesProductivas[cmb_VariedadProductiva.SelectedIndex];
                confSiembraSeleccionada.Oo_DatosInjerto.Oo_VariedadRaiz = variedadesRaiz[cmb_VariedadRaiz.SelectedIndex];
            }

            if (esNuevo)
            {
                if (espacioTemporal.ll_Configuraciones_de_Siembra == null) espacioTemporal.ll_Configuraciones_de_Siembra = new List<_ps_ConfiguracionSiembra>();
                espacioTemporal.ll_Configuraciones_de_Siembra.Add(confSiembraSeleccionada);
                confSiembraSeleccionada.oo_Espacio_Fisico_Asociado = espacioTemporal;
            }


            CargarConfiguracionesDeSiembra();


            //confSiembraSeleccionada.CopiarA<_ps_ConfiguracionSiembra>(espacioTemporal.ll_Configuraciones_de_Siembra[seleccionado]);


            LimpiarDatos();
        }
        private void btn_NuevoConfiguracion_MouseUp(object sender, MouseButtonEventArgs e)
        {
            //nueva configuración de siembra
            LimpiarDatos();
        }
        private void inicializarBuscadores()
        {
            txt_BuscadorCultivo.AsignarManejadorDB(manejador);
            txt_BuscadorCultivo.AsignarCatalogoParaAltas("InterfazWPF.Modulos.Catalogos.win_ps_CatalogoCultivos");
            txt_BuscadorCultivo.ConfigurarBusqueda(typeof(_gen_Cultivo), "_st_Nombre_cultivo", "_st_Nombre_cultivo", false, false);
            txt_BuscadorCultivo.mostrarResultado += txt_BuscadorCultivo_mostrarResultado;
            txt_BuscadorCultivo.AgregarCampoAMostrarConAlias("_st_Nombre_cultivo|Nombre del cultivo");

            txt_BuscadorEtapa.AsignarManejadorDB(manejador);
            txt_BuscadorEtapa.AsignarCatalogoParaAltas("InterfazWPF.Modulos.Catalogos.win_ps_CatalogoEtapasConfiguracionSiembra");
            txt_BuscadorEtapa.ConfigurarBusqueda(typeof(_ps_EtapaConfiguracionSiembra), "_st_NombreEtapa", "_st_NombreEtapa", false, false);
            txt_BuscadorEtapa.mostrarResultado += txt_BuscadorEtapa_mostrarResultado;
            txt_BuscadorEtapa.AgregarCampoAMostrarConAlias("_st_NombreEtapa|Nombre de la etapa");

            txt_buscadorTecnologiaCultivo.AsignarManejadorDB(manejador);
            txt_buscadorTecnologiaCultivo.AsignarCatalogoParaAltas("InterfazWPF.Modulos.Catalogos.win_ps_CatalogoTecnologias");
            txt_buscadorTecnologiaCultivo.ConfigurarBusqueda(typeof(_ps_TecnologiaCultivo), "_st_Descripcion", "_st_Descripcion", false, false);
            txt_buscadorTecnologiaCultivo.mostrarResultado += txt_buscadorTecnologiaCultivo_mostrarResultado;
            txt_buscadorTecnologiaCultivo.AgregarCampoAMostrarConAlias("_st_Descripcion|Nombre de Tecnología");

            txt_buscadorPerfil.AsignarManejadorDB(manejador);
            txt_buscadorPerfil.AsignarCatalogoParaAltas("InterfazWPF.Modulos.Catalogos.win_gen_CatalogoPerfiles");
            txt_buscadorPerfil.ConfigurarBusqueda(typeof(_gen_PerfilActividades), "_st_NombrePerfil", "_st_NombrePerfil", false, false);
            txt_buscadorPerfil.mostrarResultado += txt_BuscadorPerfiles_mostrarResultado;
            txt_buscadorPerfil.AgregarCampoAMostrarConAlias("_st_NombrePerfil|Nombre de Perfil");

            txt_buscadorMaterial.AsignarManejadorDB(manejador);
            txt_buscadorMaterial.AsignarCatalogoParaAltas("InterfazWPF.Modulos.Catalogos.win_gen_CatalogoMateriales");
            txt_buscadorMaterial.ConfigurarBusqueda(typeof(_gen_Material), "_st_Descripcion", "_st_Descripcion", false, false);
            txt_buscadorMaterial.mostrarResultado += txt_buscadorMaterial_mostrarResultado;
            txt_buscadorMaterial.AgregarCampoAMostrarConAlias("_st_Descripcion|Descripción de Material");
            txt_buscadorMaterial.AgregarCampoAMostrarConAlias("_in_CodigoCrop|Código CROP");



        }
        void txt_buscadorMaterial_mostrarResultado(List<ObjetoBase> listaObjetos)
        {
            if (listaObjetos != null)
            {
                _gen_Material material = (_gen_Material)listaObjetos[0];
                txt_buscadorMaterial.SetObjetoAsignado(material, material.In_CodigoCrop + " - " + material.St_Descripcion);
            }
        }
        void txt_BuscadorPerfiles_mostrarResultado(List<ObjetoBase> listaObjetos)
        {
            if (listaObjetos != null)
            {
                if (cmb_etapasConfPerfiles.SelectedItem != null)
                {

                    int indiceConf = cmb_etapasConfPerfiles.SelectedIndex;
                    _gen_PerfilActividades perfil = (_gen_PerfilActividades)listaObjetos[0];
                    lb_PerfilesManualesPorEtapa.Items.Add(perfil.St_NombrePerfil);
                    if (espacioTemporal.ll_Configuraciones_de_Siembra[indiceConf].Ll_PerfilActividadesManuales == null) espacioTemporal.ll_Configuraciones_de_Siembra[indiceConf].Ll_PerfilActividadesManuales = new List<_gen_PerfilActividades>();
                    espacioTemporal.ll_Configuraciones_de_Siembra[indiceConf].Ll_PerfilActividadesManuales.Add(perfil);
                    txt_buscadorPerfil.Limpiar();
                    espacioTemporal.ll_Configuraciones_de_Siembra[indiceConf].EsModificado = true;

                    List<_gen_Material> materialVariable = manejador.CargarLista<_gen_Material>(_gen_PerfilActividades.ConsultaMaterialesVariablesPorID.Replace("@id",perfil.Id.ToString()));
                    if (materialVariable != null)
                        MaterialesVariablesPerfiles.AddRange(materialVariable);
                }
                else
                {
                    HerramientasWindow.MensajeAdvertencia("Debe seleccionar una etapa antes.", "Seleccione etapa");
                }
            }
        }

        void txt_buscadorTecnologiaCultivo_mostrarResultado(List<ObjetoBase> listaObjetos)
        {
            if (listaObjetos != null)
            {
                tecnologia = (_ps_TecnologiaCultivo)listaObjetos[0];
                CargarCubiertas();
                CargarPerfiles();
            }
        }

        void txt_BuscadorEtapa_mostrarResultado(List<ObjetoBase> listaObjetos)
        {
            if (listaObjetos != null)
            {
                etapa = (_ps_EtapaConfiguracionSiembra)listaObjetos[0];
            }
        }
        List<_ps_VariedadSemilla> variedadesRaiz = new List<_ps_VariedadSemilla>();
        List<_ps_VariedadSemilla> variedadesProductivas = new List<_ps_VariedadSemilla>();
        private void CargarVariedadesDeCultivo()
        {
            cmb_variedadAUsar.Items.Clear();
            cmb_VariedadProductiva.Items.Clear();
            cmb_VariedadRaiz.Items.Clear();

            variedadesRaiz.Clear();
            variedadesProductivas.Clear();

            if (cultivo != null && cultivo.Ll_VariedadesDisponibles != null)
            {
                foreach (_ps_VariedadSemilla variedad in cultivo.Ll_VariedadesDisponibles)
                {
                    cmb_variedadAUsar.Items.Add(variedad.st_Nombre);
                    if (variedad.Bo_esTipoRaiz)
                    {
                        cmb_VariedadRaiz.Items.Add(variedad.st_Nombre);
                        variedadesRaiz.Add(variedad);
                    }
                    if (variedad.Bo_esTipoProductiva)
                    {
                        cmb_VariedadProductiva.Items.Add(variedad.st_Nombre);
                        variedadesProductivas.Add(variedad);
                    }

                }
            }
        }
        private void CalcularFechas()
        {
            if (dtp_FechaPlanteo.SelectedDate != null)
            {
                if (cultivo == null)
                {

                    HerramientasWindow.MensajeInformacion("Debe seleccionar un cultivo antes para calcular las fechas de forma automática.", "Información");
                    return;
                }
                ps_ln_Espacios.CalcularFechaSiembraYCosecha(confSiembraSeleccionada, cultivo);
                dtp_FechaSiembra.SelectedDate = ((DateTime)dtp_FechaPlanteo.SelectedDate).AddDays(confSiembraSeleccionada.in_DiasAntesSiembra * -1);
                dtp_FechaCosecha.SelectedDate = ((DateTime)dtp_FechaPlanteo.SelectedDate).AddDays(confSiembraSeleccionada.in_DiasDespuesCosecha);
            }
        }
        void txt_BuscadorCultivo_mostrarResultado(List<ObjetoBase> listaObjetos)
        {
            if (listaObjetos != null)
            {
                cultivo = (_gen_Cultivo)listaObjetos[0];
                cmb_variedadAUsar.Items.Clear();
                CargarVariedadesDeCultivo();
                if (confSiembraSeleccionada == null) confSiembraSeleccionada = new _ps_ConfiguracionSiembra();
                confSiembraSeleccionada.oo_Cultivo_plantado = cultivo;

                //ps_ln_Espacios.CalcularFechaSiembraYCosecha(confSiembra, cultivo);
                CalcularFechas();
                CargarPerfiles();
            }
        }

        public mod_ps_ConfiguracionDatosEspacioFisico(_ps_EspacioFisico espacioFisico)
        {
            InitializeComponent();
            Iniciales();
            espacioFisicoOriginal = espacioFisico;
            espacioTemporal = espacioFisico.CrearCopia<_ps_EspacioFisico>();

            if (espacioTemporal.Bo_esEspacioFinal)
                chb_esEspacioFinal.IsChecked = true;
            else if (espacioTemporal.Bo_esEmpaque)
                chb_esEmpaque.IsChecked = true;

            txt_nombreEspacio.Text = espacioTemporal.st_Nombre_espacio;
            txt_nombreEspacioMacro.Text = espacioTemporal.St_NombreEspacioEnMacro;

            if (espacioFisico.Bo_esEspacioFinal)
                CargarValores();
            else
                CargarValoresEmpaque();

            ConfigurarGridMaterialesVariables();
        }


        private void LimpiarDatos()
        {
            txt_BuscadorCultivo.Limpiar();
            txt_BuscadorEtapa.Limpiar();
            txt_densidadPlanteoXMetro2.ValorDouble = 0;
            chb_SeHaranInjertos.IsChecked = false;
            chb_SeUsaraTransplante.IsChecked = false;
            dtp_FechaCosecha.SelectedDate = null;
            dtp_FechaPlanteo.SelectedDate = null;
            dtp_FechaSiembra.SelectedDate = null;
            cmb_variedadAUsar.Items.Clear();
            cmb_VariedadProductiva.Items.Clear();
            cmb_VariedadRaiz.Items.Clear();
            gb_datosInjerto.Visibility = System.Windows.Visibility.Hidden;
            cultivo = null;
            etapa = null;
            confSiembraSeleccionada = null;
        }
        private void CargarConfiguracionesDeSiembra()
        {
            dgv_Etapas.Items.Clear();
            cmb_etapasConf.Items.Clear();
            cmb_etapasConfPerfiles.Items.Clear();
            if (espacioTemporal.ll_Configuraciones_de_Siembra != null)
            {
                foreach (_ps_ConfiguracionSiembra confSiembra in espacioTemporal.ll_Configuraciones_de_Siembra)
                {

                    ModeloEtapas datosGrid = new ModeloEtapas();
                    datosGrid.cultivo = confSiembra.oo_Cultivo_plantado.st_Nombre_cultivo;
                    if (confSiembra.Oo_EtapaConfiguracionSiembra != null)
                    {
                        datosGrid.etapa = confSiembra.Oo_EtapaConfiguracionSiembra.St_NombreEtapa;
                        cmb_etapasConf.Items.Add(confSiembra.Oo_EtapaConfiguracionSiembra.St_NombreEtapa);
                        cmb_etapasConfPerfiles.Items.Add(confSiembra.Oo_EtapaConfiguracionSiembra.St_NombreEtapa);
                    }
                    if (confSiembra.Bo_HayTransplante)
                        datosGrid.variedades = confSiembra.Oo_DatosInjerto.Oo_VariedadProductiva.st_Nombre + confSiembra.Oo_DatosInjerto.Oo_VariedadRaiz.st_Nombre;
                    else
                        datosGrid.variedades = confSiembra.oo_Variedad_de_semilla.st_Nombre;
                    datosGrid.fechaPlanteo = Herramientas.Conversiones.Formatos.DateTimeAFechaCorta(confSiembra.dt_Fecha_de_planteo);
                    datosGrid.fechaSiembra = Herramientas.Conversiones.Formatos.DateTimeAFechaCorta(confSiembra.dt_Fecha_de_planteo.AddDays(confSiembra.oo_Cultivo_plantado.In_DiasAntesSiembra * -1));
                    datosGrid.fechaCosecha = Herramientas.Conversiones.Formatos.DateTimeAFechaCorta(confSiembra.dt_Fecha_de_planteo.AddDays(confSiembra.oo_Cultivo_plantado.In_DiasDespuesCosecha));


                    dgv_Etapas.Items.Add(datosGrid);
                }
            }
        }

        private void btn_Aceptar_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if ((Boolean)chb_esEspacioFinal.IsChecked)
            {
                if (!AsignarValores())
                    return;
            }
            else if ((Boolean)chb_esEspacioFinal.IsChecked)
            {
                //aqui guardar los perfiles del empaque.
                if (!AsignarValoresEmpaque())
                    return;
            }
            else
            {
                //es un espacio contenedor
                espacioTemporal.Bo_esEspacioFinal = (Boolean)chb_esEspacioFinal.IsChecked;
                espacioTemporal.Bo_esEmpaque = (Boolean)chb_esEmpaque.IsChecked;
                espacioTemporal.st_Nombre_espacio = txt_nombreEspacio.Text;
                espacioTemporal.St_NombreEspacioEnMacro = txt_nombreEspacioMacro.Text;
            }

            if (espacioFisicoOriginal == null)
                espacioFisicoOriginal = espacioTemporal;
            else
                espacioTemporal.CopiarA<_ps_EspacioFisico>(espacioFisicoOriginal);
            EspacioFisicoModificado = espacioFisicoOriginal;
            ClickEnAceptar = true;
            Hide();

        }
        private void btn_Cancelar_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Hide();
        }
        private void MostrarControles()
        {
            tc_datosEspacio.Visibility = System.Windows.Visibility.Visible;
            Width = 727.633;
            Height = 569.661;
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

            HerramientasWindow.CentrarVentanaEnPantalla(this);
        }
        private void OcultarControles()
        {
            tc_datosEspacio.Visibility = System.Windows.Visibility.Hidden;
            Width = 727.633;
            Height = 110.661;
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

            HerramientasWindow.CentrarVentanaEnPantalla(this);
        }
        private void CargarValoresEmpaque()
        {
            //lb_perfiles.Items.Clear();
            //tab_PerfilesAsociados.IsSelected = true;
            //if (espacioTemporal.Ll_PerfilesAsociados != null)
            //{
            //    foreach (_gen_PerfilActividades perfil in espacioTemporal.Ll_PerfilesAsociados)
            //    {
            //        lb_perfiles.Items.Add(perfil.St_NombrePerfil);
            //    }
            //}
        }
        private void CargarValores()
        {

            //datos fisicos
            txt_Hectareas.ValorDouble = espacioTemporal.do_Numero_hectareas;
            txt_NumeroCamas.Valor = espacioTemporal.In_Numero_de_camas;
            txt_separacionEntreCamas.ValorFloat = espacioTemporal.Fl_Separacion_entre_camas;
            txt_areaPorCama.ValorDouble = espacioTemporal.Do_AreaPorCama;
            txt_longitudCama.ValorDouble = espacioTemporal.Do_LongitudPorCama;
            txt_numeroCasetas.Valor = espacioTemporal.In_NumeroCasetas;
            txt_perimetro.ValorDouble = espacioTemporal.Do_MetrosPerimetro;
            txt_numeroCaidas.ValorDouble = espacioTemporal.In_NumeroCaidas;
            txt_numeroPerifericas.Valor = espacioTemporal.In_NumeroPerifericas;
            txt_metrosDesague.ValorDouble = espacioTemporal.Do_MetrosDesague;
            //datos de cultivo
            CargarConfiguracionesDeSiembra();
            //datos de la tecnologia
            if (espacioTemporal.Oo_Configuracion_tecnologica != null)
            {
                tecnologia = espacioTemporal.Oo_Configuracion_tecnologica.Oo_TecnologiaDeCultivoUsada;
                if (tecnologia != null)
                    txt_buscadorTecnologiaCultivo.SetObjetoAsignado(tecnologia, tecnologia.st_Descripcion);
                CargarCubiertas();
                if (espacioTemporal.Oo_Configuracion_tecnologica.Oo_CubiertaUsada != null)
                {
                    cmb_CubiertaAUsar.SelectedItem = espacioTemporal.Oo_Configuracion_tecnologica.Oo_CubiertaUsada.St_NombreCubierta;
                }
                chb_tieneSistEnfriamiento.IsChecked = espacioTemporal.Oo_Configuracion_tecnologica.Bo_TieneSistEnfriamiento;
            }
            //perfiles
            CargarPerfiles();


        }

        private void CargarCubiertas()
        {
            cmb_CubiertaAUsar.Items.Clear();
            if (tecnologia != null)
            {
                if (tecnologia.Ll_CubiertasParaTecnologia != null)
                {
                    foreach (_ps_Cubierta cubierta in tecnologia.Ll_CubiertasParaTecnologia)
                    {
                        cmb_CubiertaAUsar.Items.Add(cubierta.St_NombreCubierta);
                    }
                }
            }
        }
        private Boolean AsignarValoresEmpaque()
        {
            if (ValidacionesEmpaque())
            {
                espacioTemporal.st_Nombre_espacio = txt_nombreEspacio.Text;
                espacioTemporal.Bo_esEspacioFinal = (Boolean)chb_esEspacioFinal.IsChecked;
                espacioTemporal.Bo_esEmpaque = (Boolean)chb_esEmpaque.IsChecked;

                return true;
            }
            else
            {
                return false;
            }
        }
        private Boolean AsignarValores()
        {
            if (Validaciones())
            {
                espacioTemporal.st_Nombre_espacio = txt_nombreEspacio.Text;
                espacioTemporal.Bo_esEspacioFinal = (Boolean)chb_esEspacioFinal.IsChecked;
                espacioTemporal.Bo_esEmpaque = (Boolean)chb_esEmpaque.IsChecked;
                //DatosFisicos
                espacioTemporal.do_Numero_hectareas = txt_Hectareas.ValorDouble;
                espacioTemporal.In_Numero_de_camas = txt_NumeroCamas.Valor;
                espacioTemporal.Fl_Separacion_entre_camas = txt_separacionEntreCamas.ValorFloat;
                espacioTemporal.Do_AreaPorCama = txt_areaPorCama.ValorDouble;
                espacioTemporal.Do_LongitudPorCama = txt_longitudCama.ValorDouble;
                espacioTemporal.In_NumeroCasetas = txt_numeroCasetas.Valor;
                espacioTemporal.Do_MetrosPerimetro = txt_perimetro.ValorDouble;
                espacioTemporal.In_NumeroCaidas = txt_numeroCaidas.ValorDouble;
                espacioTemporal.In_NumeroPerifericas = txt_numeroPerifericas.Valor;
                espacioTemporal.Do_MetrosDesague = txt_metrosDesague.ValorDouble;
                //datos del cultivo
                if (espacioTemporal.ll_Configuraciones_de_Siembra == null) espacioTemporal.ll_Configuraciones_de_Siembra = new List<_ps_ConfiguracionSiembra>();
                //datos de la tecnologia
                if (espacioTemporal.Oo_Configuracion_tecnologica == null) espacioTemporal.Oo_Configuracion_tecnologica = new _ps_ConfiguracionTecnologica();
                espacioTemporal.Oo_Configuracion_tecnologica.Oo_TecnologiaDeCultivoUsada = tecnologia;
                if (cmb_CubiertaAUsar.SelectedIndex >= 0)
                    espacioTemporal.Oo_Configuracion_tecnologica.Oo_CubiertaUsada = tecnologia.Ll_CubiertasParaTecnologia[cmb_CubiertaAUsar.SelectedIndex];
                espacioTemporal.Oo_Configuracion_tecnologica.Bo_TieneSistEnfriamiento = (Boolean)chb_tieneSistEnfriamiento.IsChecked;
                espacioTemporal.Oo_Configuracion_tecnologica.EsModificado = true;
                return true;
            }
            else
            {
                return false;
            }
        }
        private Boolean Validaciones()
        {
            //if (cmb_CubiertaAUsar.SelectedIndex == -1)
            //{
            //    HerramientasWindow.MensajeInformacion("Debe seleccionar una cubierta.", "Selecciona cubierta");
            //    return false;
            //}
            return true;
        }
        private Boolean ValidacionesEmpaque()
        {
            //if (cmb_CubiertaAUsar.SelectedIndex == -1)
            //{
            //    HerramientasWindow.MensajeInformacion("Debe seleccionar una cubierta.", "Selecciona cubierta");
            //    return false;
            //}
            return true;
        }




        #region Datos fisicos del espacio
        private void chb_esEspacioFinal_Checked(object sender, RoutedEventArgs e)
        {
            chb_esEmpaque.IsChecked = false;
            MostrarControles();
            tab_datosCultivo.IsEnabled = true;
            tab_DatosEspacioFisico.IsEnabled = true;
            tab_datosTecnologia.IsEnabled = true;
        }
        private void chb_esEspacioFinal_Unchecked(object sender, RoutedEventArgs e)
        {
            OcultarControles();
        }
        #endregion

        #region Datos del cultivo
        private void dtp_FechaPlanteo_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            CalcularFechas();
        }
        private void btn_quitarConfiguracion_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (dgv_Etapas.SelectedIndex >= 0)
            {
                if (HerramientasWindow.MensajeSIoNOAdvertencia("¿Está seguro de eliminar la etapa seleccionada?", "Atencion!!!"))
                {
                    _ps_ConfiguracionSiembra temp = espacioTemporal.ll_Configuraciones_de_Siembra[dgv_Etapas.SelectedIndex];
                    for (int i = 0; i < espacioTemporal.ll_Configuraciones_de_Siembra.Count; i++)
                    {
                        if (espacioTemporal.ll_Configuraciones_de_Siembra[i].Id == temp.Id)
                        {
                            espacioTemporal.ll_Configuraciones_de_Siembra.RemoveAt(i);
                            CargarConfiguracionesDeSiembra();
                            break;
                        }
                    }
                }
            }
        }
        private void btn_subirConfiguracion_MouseUp(object sender, MouseButtonEventArgs e)
        {
            //en 'Seleccionado' esta la etapa seleccionada

            if (seleccionado >= 1)
            {
                _ps_ConfiguracionSiembra temp = espacioTemporal.ll_Configuraciones_de_Siembra[seleccionado - 1];
                espacioTemporal.ll_Configuraciones_de_Siembra[seleccionado - 1] = espacioTemporal.ll_Configuraciones_de_Siembra[seleccionado];
                espacioTemporal.ll_Configuraciones_de_Siembra[seleccionado] = temp;
                seleccionado--;
                CargarConfiguracionesDeSiembra();
                dgv_Etapas.SelectedIndex = seleccionado;
            }

        }

        private void btn_bajarConfiguracion_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (seleccionado <= espacioTemporal.ll_Configuraciones_de_Siembra.Count - 2)
            {
                _ps_ConfiguracionSiembra temp = espacioTemporal.ll_Configuraciones_de_Siembra[seleccionado + 1];
                espacioTemporal.ll_Configuraciones_de_Siembra[seleccionado + 1] = espacioTemporal.ll_Configuraciones_de_Siembra[seleccionado];
                espacioTemporal.ll_Configuraciones_de_Siembra[seleccionado] = temp;
                seleccionado++;
                CargarConfiguracionesDeSiembra();
                dgv_Etapas.SelectedIndex = seleccionado;
            }
        }
        #endregion

        #region MAteriales Variables
        List<_gen_Material> MaterialesVariablesPerfiles = new List<_gen_Material>();
        private void btn_guardarMaterialVariable_MouseUp(object sender, MouseButtonEventArgs e)
        {
            materialVariableSeleccionado.Oo_MaterialEspecifico = txt_buscadorMaterial.GetObjetoAsignado<_gen_Material>();
            materialVariableSeleccionado.EsModificado = true;
            CargarMaterialesVariables();

            txt_materialVariable.Text = "";
            txt_buscadorMaterial.Limpiar();
            confSiembraTempMaterialesVariables.EsModificado = true;

        }

        private void cmb_etapasConf_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmb_etapasConf.SelectedIndex != -1)
            {
                confSiembraTempMaterialesVariables = espacioTemporal.ll_Configuraciones_de_Siembra[cmb_etapasConf.SelectedIndex];
                CargarMaterialesVariables();
            }
        }
        _ps_ConfiguracionSiembra confSiembraTempMaterialesVariables;
        private void CargarMaterialesVariables()
        {
            dgv_materialesVariables.Items.Clear();

            if (confSiembraTempMaterialesVariables.Ll_MaterialesVariable == null) confSiembraTempMaterialesVariables.Ll_MaterialesVariable = new List<_gen_MaterialVariableEspecifico>();

            foreach (_gen_Material material in MaterialesVariablesPerfiles)
            {
                Boolean Encontro = false;
                foreach (_gen_MaterialVariableEspecifico materialVar in confSiembraTempMaterialesVariables.Ll_MaterialesVariable)
                {
                    if (materialVar.Oo_MaterialVariable.Id == material.Id)
                    {
                        if (materialVar.Oo_MaterialEspecifico == null)
                        {
                            materialVar.Oo_MaterialEspecifico = material.Oo_MaterialEspecifico;
                        }
                        Encontro = true;
                        break;
                    }
                }
                if (!Encontro)
                {
                    _gen_MaterialVariableEspecifico mat = new _gen_MaterialVariableEspecifico();
                    mat.Oo_MaterialVariable = material;
                    mat.EsModificado = true;
                    mat.Oo_MaterialEspecifico = material.Oo_MaterialEspecifico;
                    confSiembraTempMaterialesVariables.Ll_MaterialesVariable.Add(mat);
                }
            }

            if (confSiembraTempMaterialesVariables.Ll_MaterialesVariable != null)
            {

                foreach (_gen_MaterialVariableEspecifico material in confSiembraTempMaterialesVariables.Ll_MaterialesVariable)
                {
                    ModeloMaterialesVariables modelo = new ModeloMaterialesVariables();
                    modelo.MaterialVariable = material.Oo_MaterialVariable.St_Descripcion;
                    if (material.Oo_MaterialEspecifico != null)
                        modelo.MaterialEspecifico = material.Oo_MaterialEspecifico.In_CodigoCrop + " - " + material.Oo_MaterialEspecifico.St_Descripcion;
                    dgv_materialesVariables.Items.Add(modelo);
                }
            }
        }
        _gen_MaterialVariableEspecifico materialVariableSeleccionado;
        private void dgv_materialesVariables_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            int indice = HerramientasWindow.ObtenerRowSeleccionadoDataGrid(sender, e);
            if (indice != -1)
            {
                materialVariableSeleccionado = confSiembraTempMaterialesVariables.Ll_MaterialesVariable[indice];
                txt_materialVariable.Text = materialVariableSeleccionado.Oo_MaterialVariable.St_Descripcion;
                txt_buscadorMaterial.SetObjetoAsignado(materialVariableSeleccionado.Oo_MaterialEspecifico, materialVariableSeleccionado.Oo_MaterialEspecifico.In_CodigoCrop + " - " + materialVariableSeleccionado.Oo_MaterialEspecifico.St_Descripcion);
            }
        }
        #endregion
        #region Datos tecnologia
        #endregion

        #region perfiles
        private void CargarPerfiles()
        {
            lb_perfilesAutomaticos.Items.Clear();
            cmb_etapasConf.SelectedIndex = -1;
            dgv_materialesVariables.Items.Clear();
            if (espacioTemporal.ll_Configuraciones_de_Siembra != null)
            {
                foreach (_ps_ConfiguracionSiembra conf in espacioTemporal.ll_Configuraciones_de_Siembra)
                {
                    if (tecnologia != null && conf.oo_Cultivo_plantado != null)
                    {
                        List<_gen_PerfilActividades> perfilesActividades = manejador.CargarLista<_gen_PerfilActividades>(_gen_PerfilActividades.ConsultaPorTecnologiaYCultivo, new List<object>() { tecnologia.Id, conf.oo_Cultivo_plantado.Id });

                        if (perfilesActividades != null)
                        {
                            foreach (_gen_PerfilActividades perfil in perfilesActividades)
                            {
                                List<_gen_Material> materialVariable = manejador.CargarLista<_gen_Material>(_gen_PerfilActividades.ConsultaMaterialesVariablesPorID, new List<object>() { perfil.Id });
                                if (materialVariable != null)
                                    MaterialesVariablesPerfiles.AddRange(materialVariable);
                                lb_perfilesAutomaticos.Items.Add("[Etapa " + conf.Oo_EtapaConfiguracionSiembra.St_NombreEtapa + "] - " + perfil.St_NombrePerfil);
                            }
                        }
                    }
                }
            }
        }
        #endregion

        private void chb_esEmpaque_Unchecked(object sender, RoutedEventArgs e)
        {
            OcultarControles();
        }

        private void chb_esEmpaque_Checked(object sender, RoutedEventArgs e)
        {
            chb_esEspacioFinal.IsChecked = false;
            MostrarControles();
            tab_datosCultivo.IsEnabled = false;
            tab_DatosEspacioFisico.IsEnabled = false;
            tab_datosTecnologia.IsEnabled = false;
        }
        void cmb_etapasConfPerfiles_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmb_etapasConfPerfiles.SelectedItem != null)
            {
                CargarPerfilesManuales();
            }
        }

        private void CargarPerfilesManuales()
        {
            lb_PerfilesManualesPorEtapa.Items.Clear();
            if (espacioTemporal.ll_Configuraciones_de_Siembra[cmb_etapasConfPerfiles.SelectedIndex].Ll_PerfilActividadesManuales != null)
            {
                foreach (_gen_PerfilActividades perfilManual in espacioTemporal.ll_Configuraciones_de_Siembra[cmb_etapasConfPerfiles.SelectedIndex].Ll_PerfilActividadesManuales)
                {
                    lb_PerfilesManualesPorEtapa.Items.Add(perfilManual.St_NombrePerfil);

                    List<_gen_Material> materialVariable = manejador.CargarLista<_gen_Material>(_gen_PerfilActividades.ConsultaMaterialesVariablesPorID, new List<object>() { perfilManual.Id });
                    if (materialVariable != null)
                        MaterialesVariablesPerfiles.AddRange(materialVariable);
                    
                }
            }
        }

        private void btn_eliminarPerfilSeleccionado_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (lb_PerfilesManualesPorEtapa.SelectedItem != null)
            {
                if (cmb_etapasConfPerfiles.SelectedItem != null)
                {
                    if (espacioTemporal.ll_Configuraciones_de_Siembra[cmb_etapasConfPerfiles.SelectedIndex].Ll_PerfilActividadesManuales != null && espacioTemporal.ll_Configuraciones_de_Siembra[cmb_etapasConfPerfiles.SelectedIndex].Ll_PerfilActividadesManuales.Count > 0)
                    {
                        espacioTemporal.ll_Configuraciones_de_Siembra[cmb_etapasConfPerfiles.SelectedIndex].Ll_PerfilActividadesManuales.RemoveAt(lb_PerfilesManualesPorEtapa.SelectedIndex);
                        CargarPerfilesManuales();
                        espacioTemporal.ll_Configuraciones_de_Siembra[cmb_etapasConfPerfiles.SelectedIndex].EsModificado = true;
                    }
                }
                else
                {
                    HerramientasWindow.MensajeAdvertencia("Debe seleccionar una etapa antes.", "Seleccione etapa");
                }
            }
        }

        private void tab_PerfilesAsociados_MouseUp(object sender, MouseButtonEventArgs e)
        {
            cmb_etapasConfPerfiles.SelectedItem = null;
            lb_PerfilesManualesPorEtapa.Items.Clear();
        }


    }
    class ModeloEtapas
    {
        public String etapa { get; set; }
        public String cultivo { get; set; }
        public String variedades { get; set; }
        public String fechaSiembra { get; set; }
        public String fechaPlanteo { get; set; }
        public String fechaCosecha { get; set; }

    }
    class ModeloMaterialesVariables
    {
        public String MaterialVariable { get; set; }
        public String MaterialEspecifico { get; set; }

    }
}
