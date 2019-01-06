using Dominio;
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
using Dominio.Modulos.General;
using InterfazWPF.AdministracionSistema;
using Dominio.Modulos.ProgramaSiembra;
using System.Collections;
using System.Data;
using Herramientas.ORM;

namespace InterfazWPF.Modulos.Catalogos
{
    /// <summary>
    /// Lógica de interacción para win_gen_CatalogoPerfiles.xaml
    /// </summary>
    public partial class win_gen_CatalogoPerfiles : Window, iCatalogo
    {
        ManejadorDB manejador = new ManejadorDB();
        _gen_PerfilActividades objetoActual;

        _gen_Cultivo cultivo;
        _ps_TecnologiaCultivo tecnologia;
        _gen_ConfiguracionActividadNominaPerfil ConfiguracionActividadPerfilTemp;
        _gen_ConfiguracionMaterialPerfil ConfiguracionMaterialPerfilTemp;


        List<_gen_ConfiguracionActividadNominaPerfil> ConfiguracionesActividadesTemp = new List<_gen_ConfiguracionActividadNominaPerfil>();
        List<_gen_ConfiguracionMaterialPerfil> ConfiguracionesMaterialesTemp = new List<_gen_ConfiguracionMaterialPerfil>();

        List<_gen_PerfilActividades> perfilesTemp = new List<_gen_PerfilActividades>();//perfiles hijos


        public win_gen_CatalogoPerfiles()
        {
            InitializeComponent();
            ConfigurarBuscadores();
            cmb_fechaReferencia.Items.Add("Fecha Siembra");
            cmb_fechaReferencia.Items.Add("Fecha Planteo");
            cmb_fechaReferencia.Items.Add("Fecha Cosecha");
            chb_repetirPorNumero.IsChecked = true;
            cmb_fechaReferenciaMaterial.Items.Add("Fecha Siembra");
            cmb_fechaReferenciaMaterial.Items.Add("Fecha Planteo");
            cmb_fechaReferenciaMaterial.Items.Add("Fecha Cosecha");
            chb_repetirPorNumeroMaterial.IsChecked = true;

            HerramientasWindow.AgregarColumnaConBindingADataGridView(dgv_ConfiguracionesPerfiles, "Actividad", "elemento");
            HerramientasWindow.AgregarColumnaConBindingADataGridView(dgv_ConfiguracionesPerfiles, "Inicio", "inicio");
            HerramientasWindow.AgregarColumnaConBindingADataGridView(dgv_ConfiguracionesPerfiles, "Repeticiones/Frecuencia", "frecuencia");

            HerramientasWindow.AgregarColumnaConBindingADataGridView(dgv_ConfiguracionesPerfilesMateriales, "Material", "elemento");
            HerramientasWindow.AgregarColumnaConBindingADataGridView(dgv_ConfiguracionesPerfilesMateriales, "Formula", "formula");
            HerramientasWindow.AgregarColumnaConBindingADataGridView(dgv_ConfiguracionesPerfilesMateriales, "Inicio", "inicio");
            HerramientasWindow.AgregarColumnaConBindingADataGridView(dgv_ConfiguracionesPerfilesMateriales, "Repeticiones/Frecuencia", "frecuencia");

        }

        private void ConfigurarBuscadores()
        {
            //perfil
            txt_Buscador.AsignarManejadorDB(manejador);
            txt_Buscador.AsignarCatalogoParaAltas("InterfazWPF.Modulos.Catalogos.win_gen_CatalogoPerfiles");
            txt_Buscador.ConfigurarBusqueda(typeof(_gen_PerfilActividades), "_st_NombrePerfil", "_st_NombrePerfil", false, true);
            txt_Buscador.mostrarResultado += txt_Buscador_mostrarResultado;
            txt_Buscador.AgregarCampoAMostrarConAlias("_st_NombrePerfil|Nombre de Perfil");
            txt_Buscador.AgregarCampoAMostrarConAlias("_oo_cultivo._st_Nombre_cultivo|Cultivo");
            txt_Buscador.AgregarCampoAMostrarConAlias("_oo_tecnologia._st_Descripcion|Tecnología");

            txt_BuscadorPerfiles.AsignarManejadorDB(manejador);
            txt_BuscadorPerfiles.AsignarCatalogoParaAltas("InterfazWPF.Modulos.Catalogos.win_gen_CatalogoPerfiles");
            txt_BuscadorPerfiles.ConfigurarBusqueda(typeof(_gen_PerfilActividades), "_st_NombrePerfil", "_st_NombrePerfil", true, true);
            txt_BuscadorPerfiles.mostrarResultado += txt_BuscadorPerfiles_mostrarResultado;
            txt_BuscadorPerfiles.AgregarCampoAMostrarConAlias("_st_NombrePerfil|Nombre de Perfil");
            txt_BuscadorPerfiles.AgregarCampoAMostrarConAlias("_oo_cultivo._st_Nombre_cultivo|Cultivo");
            txt_BuscadorPerfiles.AgregarCampoAMostrarConAlias("_oo_tecnologia._st_Descripcion|Tecnología");

            txt_BuscadorCultivo.AsignarManejadorDB(manejador);
            txt_BuscadorCultivo.AsignarCatalogoParaAltas("InterfazWPF.Modulos.Catalogos.win_ps_CatalogoCultivos");
            txt_BuscadorCultivo.ConfigurarBusqueda(typeof(_gen_Cultivo), "id", "_st_Nombre_cultivo", false, true);
            txt_BuscadorCultivo.mostrarResultado += txt_BuscadorCultivo_mostrarResultado;
            txt_BuscadorCultivo.AgregarCampoAMostrarConAlias("_st_Nombre_cultivo|Nombre del cultivo");

            txt_BuscadorTecnologia.AsignarManejadorDB(manejador);
            txt_BuscadorTecnologia.AsignarCatalogoParaAltas("InterfazWPF.Modulos.Catalogos.win_ps_CatalogoTecnologias");
            txt_BuscadorTecnologia.ConfigurarBusqueda(typeof(_ps_TecnologiaCultivo), "_st_Descripcion", "_st_Descripcion", false, true);
            txt_BuscadorTecnologia.mostrarResultado += txt_BuscadorTecnologia_mostrarResultado;
            txt_BuscadorTecnologia.AgregarCampoAMostrarConAlias("_st_Descripcion|Descripción");
            //actividades
            txt_BuscadorActividades.AsignarManejadorDB(manejador);
            txt_BuscadorActividades.AsignarCatalogoParaAltas("InterfazWPF.Modulos.Catalogos.win_gen_CatalogoActividadNomina");
            txt_BuscadorActividades.ConfigurarBusqueda(typeof(_gen_ActividadNomina), "_st_Nombre", "_st_Nombre", false, true);
            txt_BuscadorActividades.mostrarResultado += txt_BuscadorActividades_mostrarResultado;
            txt_BuscadorActividades.AgregarCampoAMostrarConAlias("_st_Nombre|Nombre de Actividad");
            txt_BuscadorActividades.AgregarCampoAMostrarConAlias("_in_idCrop|Código CROP");

            txt_BuscadorUnidadTiempoInicio.AsignarManejadorDB(manejador);
            txt_BuscadorUnidadTiempoInicio.AsignarCatalogoParaAltas("InterfazWPF.Modulos.Catalogos.win_gen_CatalogoUnidadTiempo");
            txt_BuscadorUnidadTiempoInicio.ConfigurarBusqueda(typeof(_gen_UnidadDeTiempo), "_st_Nombre", "_st_Nombre", false, true);
            txt_BuscadorUnidadTiempoInicio.AgregarCampoAMostrarConAlias("_st_Nombre|Nombre");

            txt_BuscadorUnidadTiempoFrecuencia.AsignarManejadorDB(manejador);
            txt_BuscadorUnidadTiempoFrecuencia.AsignarCatalogoParaAltas("InterfazWPF.Modulos.Catalogos.win_gen_CatalogoUnidadTiempo");
            txt_BuscadorUnidadTiempoFrecuencia.ConfigurarBusqueda(typeof(_gen_UnidadDeTiempo), "_st_Nombre", "_st_Nombre", false, true);
            txt_BuscadorUnidadTiempoFrecuencia.AgregarCampoAMostrarConAlias("_st_Nombre|Nombre");

            txt_BuscadorUnidadTiempoPlazo.AsignarManejadorDB(manejador);
            txt_BuscadorUnidadTiempoPlazo.AsignarCatalogoParaAltas("InterfazWPF.Modulos.Catalogos.win_gen_CatalogoUnidadTiempo");
            txt_BuscadorUnidadTiempoPlazo.ConfigurarBusqueda(typeof(_gen_UnidadDeTiempo), "_st_Nombre", "_st_Nombre", false, true);
            txt_BuscadorUnidadTiempoPlazo.AgregarCampoAMostrarConAlias("_st_Nombre|Nombre");

            //materiales
            txt_BuscadorMateriales.AsignarManejadorDB(manejador);
            txt_BuscadorMateriales.AsignarCatalogoParaAltas("InterfazWPF.Modulos.Catalogos.win_gen_CatalogoMateriales");
            txt_BuscadorMateriales.ConfigurarBusqueda(typeof(_gen_Material), "_st_Descripcion", "_st_Descripcion", false, true);
            txt_BuscadorMateriales.mostrarResultado += txt_BuscadorMateriales_mostrarResultado;
            txt_BuscadorMateriales.AgregarCampoAMostrarConAlias("_st_Descripcion|Descripción material");
            txt_BuscadorMateriales.AgregarCampoAMostrarConAlias("_st_DescripcionCorta|Descripción corta material");
            txt_BuscadorMateriales.AgregarCampoAMostrarConAlias("_in_CodigoCrop|Código CROP");

            txt_BuscadorUnidadTiempoInicioMaterial.AsignarManejadorDB(manejador);
            txt_BuscadorUnidadTiempoInicioMaterial.AsignarCatalogoParaAltas("InterfazWPF.Modulos.Catalogos.win_gen_CatalogoUnidadTiempo");
            txt_BuscadorUnidadTiempoInicioMaterial.ConfigurarBusqueda(typeof(_gen_UnidadDeTiempo), "_st_Nombre", "_st_Nombre", false, true);
            txt_BuscadorUnidadTiempoInicioMaterial.AgregarCampoAMostrarConAlias("_st_Nombre|Nombre");

            txt_BuscadorUnidadTiempoFrecuenciaMaterial.AsignarManejadorDB(manejador);
            txt_BuscadorUnidadTiempoFrecuenciaMaterial.AsignarCatalogoParaAltas("InterfazWPF.Modulos.Catalogos.win_gen_CatalogoUnidadTiempo");
            txt_BuscadorUnidadTiempoFrecuenciaMaterial.ConfigurarBusqueda(typeof(_gen_UnidadDeTiempo), "_st_Nombre", "_st_Nombre", false, true);
            txt_BuscadorUnidadTiempoFrecuenciaMaterial.AgregarCampoAMostrarConAlias("_st_Nombre|Nombre");

            txt_BuscadorUnidadTiempoPlazoMaterial.AsignarManejadorDB(manejador);
            txt_BuscadorUnidadTiempoPlazoMaterial.AsignarCatalogoParaAltas("InterfazWPF.Modulos.Catalogos.win_gen_CatalogoUnidadTiempo");
            txt_BuscadorUnidadTiempoPlazoMaterial.ConfigurarBusqueda(typeof(_gen_UnidadDeTiempo), "_st_Nombre", "_st_Nombre", false, true);
            txt_BuscadorUnidadTiempoPlazoMaterial.AgregarCampoAMostrarConAlias("_st_Nombre|Nombre");

            txt_BuscadorFormula.AsignarManejadorDB(manejador);
            txt_BuscadorFormula.AsignarCatalogoParaAltas("InterfazWPF.Modulos.Catalogos.win_gen_CatalogoFormulas");
            txt_BuscadorFormula.ConfigurarBusqueda(typeof(_gen_Formula), "_st_Formula", "_st_Formula", false, true);
            txt_BuscadorFormula.AgregarCampoAMostrarConAlias("_st_Formula|Formula");
        }

        void txt_BuscadorMateriales_mostrarResultado(List<ObjetoBase> listaObjetos)
        {
            if (listaObjetos != null)
            {
                _gen_Material material = (_gen_Material)listaObjetos[0];
                txt_BuscadorMateriales.SetObjetoAsignado(material, material.St_Descripcion);
            }
        }

        void txt_BuscadorTecnologia_mostrarResultado(List<ObjetoBase> listaObjetos)
        {
            if (listaObjetos != null)
            {
                tecnologia = (_ps_TecnologiaCultivo)listaObjetos[0];
            }
        }

        void txt_BuscadorCultivo_mostrarResultado(List<ObjetoBase> listaObjetos)
        {
            if (listaObjetos != null)
            {
                cultivo = (_gen_Cultivo)listaObjetos[0];
            }
        }

        void txt_BuscadorActividades_mostrarResultado(List<ObjetoBase> listaObjetos)
        {
            if (listaObjetos != null)
            {
                ////ConfiguracionPerfilTemp = (_gen_ConfiguracionActividadNominaPerfil)listaObjetos[0];
                ////CargarConfiguracionActividad();
                _gen_ActividadNomina actividad = (_gen_ActividadNomina)listaObjetos[0];
                txt_BuscadorActividades.SetObjetoAsignado(actividad, actividad.In_idCrop + " - " + actividad.St_Nombre);
            }
        }

        void txt_BuscadorPerfiles_mostrarResultado(List<ObjetoBase> listaObjetos)
        {
            if (listaObjetos != null)
            {
                if (perfilesTemp == null) perfilesTemp = new List<_gen_PerfilActividades>();
                foreach (_gen_PerfilActividades perfil in listaObjetos)
                {
                    perfilesTemp.Add(perfil);
                }
                CargarPerfiles();
            }
        }
        void txt_Buscador_mostrarResultado(List<ObjetoBase> listaObjetos)
        {
            if (listaObjetos != null)
            {
                objetoActual = (_gen_PerfilActividades)listaObjetos[0];
                CargarObjeto();
                CargarConfiguracionesActividades();
                CargarPerfiles();
            }
        }

        private void CargarObjeto()
        {
            Limpiar();

            txt_nombrePerfil.Text = objetoActual.St_NombrePerfil;
            ConfiguracionesActividadesTemp = objetoActual.Ll_ConfiguracionActividades;
            ConfiguracionesMaterialesTemp = objetoActual.Ll_ConfiguracionMateriales;
            perfilesTemp = objetoActual.Ll_SubPerfiles;

            cultivo = objetoActual.Oo_cultivo;
            tecnologia = objetoActual.Oo_tecnologia;

            if (cultivo != null) txt_BuscadorCultivo.SetObjetoAsignado(cultivo, cultivo.st_Nombre_cultivo);
            if (tecnologia != null) txt_BuscadorTecnologia.SetObjetoAsignado(tecnologia, tecnologia.st_Descripcion);

            CargarConfiguracionesActividades();
            CargarConfiguracionesMateriales();
            CargarPerfiles();
        }

        private void CargarPerfiles()
        {
            lb_PerfilesHijos.Items.Clear();
            if (perfilesTemp != null)
            {
                foreach (_gen_PerfilActividades perfil in perfilesTemp)
                {
                    lb_PerfilesHijos.Items.Add(perfil.St_NombrePerfil);
                }
            }
        }
        private void GuardarObjeto()
        {
            try
            {
                objetoActual.EsModificado = true;
                manejador.Guardar(objetoActual);
                objetoActual = null;
                Limpiar();
                LimpiarDatosCapturaConfiguracionActividades();
                LimpiarDatosCapturaConfiguracionMateriales();
                HerramientasWindow.MensajeInformacion("Se ha guardado correctamente el objeto.", "Guardado exitoso");
            }
            catch (Exception ex)
            {
                HerramientasWindow.MensajeError(ex, "Error: " + ex.Message, "Error");
            }
        }
        private void GuardarObjetoSinLimpiar()
        {
            try
            {
                objetoActual.EsModificado = true;
                manejador.Guardar(objetoActual);
            }
            catch (Exception ex)
            {
                HerramientasWindow.MensajeError(ex, "Error: " + ex.Message, "Error");
            }
        }
        private void Limpiar()
        {
            txt_Buscador.Limpiar();
            txt_BuscadorCultivo.Limpiar();
            txt_BuscadorTecnologia.Limpiar();
            txt_nombrePerfil.Text = "";
            ConfiguracionesActividadesTemp = null;
            ConfiguracionesMaterialesTemp = null;
            perfilesTemp = null;
            cultivo = null;
            tecnologia = null;
            //lb_Actividades.Items.Clear();
            lb_PerfilesHijos.Items.Clear();
            dgv_ConfiguracionesPerfiles.Items.Clear();
            dgv_ConfiguracionesPerfilesMateriales.Items.Clear();
            ConfiguracionActividadPerfilTemp = null;
        }

        public void _toolbox_Guardar()
        {
            if (objetoActual != null)
            {
                if (!HerramientasWindow.MensajeSIoNOAdvertencia("El objeto actual reemplazará al objeto anterior, ¿Desea continuar?", "Atención"))
                {
                    return;
                }
            }
            else
                objetoActual = manejador.CrearObjeto<_gen_PerfilActividades>();
            objetoActual.St_NombrePerfil = txt_nombrePerfil.Text;
            objetoActual.EsModificado = true;
            objetoActual.Ll_ConfiguracionActividades = ConfiguracionesActividadesTemp;
            objetoActual.Ll_SubPerfiles = perfilesTemp;
            objetoActual.Oo_cultivo = cultivo;
            objetoActual.Oo_tecnologia = tecnologia;
            objetoActual.EstaDeshabilitado = false;
            GuardarObjeto();
        }
        public void _toolbox_Deshabilitar()
        {
            if (objetoActual == null) return;
            objetoActual.EstaDeshabilitado = true;
            GuardarObjeto();
        }
        public void _toolbox_Nuevo()
        {
            objetoActual = null;
            Limpiar();
        }

        public void AsignarObjetoDominio(ObjetoBase objeto)
        {
            objetoActual = (_gen_PerfilActividades)objeto;
            CargarObjeto();
        }
        #region actividades
        private void chb_usarProyeccionProduccionActividades_Checked(object sender, RoutedEventArgs e)
        {
            grid_tiempoActividades.Visibility = System.Windows.Visibility.Hidden;
        }

        private void chb_usarProyeccionProduccionActividades_Unchecked(object sender, RoutedEventArgs e)
        {
            grid_tiempoActividades.Visibility = System.Windows.Visibility.Visible;
        }
        private void CargarConfiguracionesActividades()
        {
            dgv_ConfiguracionesPerfiles.Items.Clear();
            if (ConfiguracionesActividadesTemp != null)
            {
                foreach (_gen_ConfiguracionActividadNominaPerfil confActividad in ConfiguracionesActividadesTemp)
                {
                    Modelo modelo = new Modelo();
                    modelo.elemento = confActividad.Oo_Actividad.In_idCrop + " - " + confActividad.Oo_Actividad.St_Nombre;
                    String conector = "";

                    if (confActividad.Bo_UsarPeriodoDeProduccion)
                    {
                        modelo.inicio = "En la semana de inicio de producción";
                        modelo.frecuencia = "Durante la producción";
                    }
                    else
                    {
                        if (confActividad.Do_tiempoRelativoInicio > 0)
                            conector = "después";
                        if (confActividad.Do_tiempoRelativoInicio < 0)
                            conector = "antes";
                        if (confActividad.Do_tiempoRelativoInicio == 0)
                            modelo.inicio = "En " + cmb_fechaReferencia.Items[confActividad.In_FechaInicioRespecto].ToString();
                        else
                            modelo.inicio = Math.Abs(confActividad.Do_tiempoRelativoInicio) + " " + confActividad.Oo_unidadTiempoInicio.St_Nombre + " " + conector + " de " + cmb_fechaReferencia.Items[confActividad.In_FechaInicioRespecto].ToString();

                        String veces = "";

                        if (confActividad.In_Veces == 1)
                            veces = "una vez";
                        else
                            veces = confActividad.In_Veces + " veces";

                        if (confActividad.In_Repeticiones > 1)
                            modelo.frecuencia = confActividad.In_Repeticiones + " repeticiones, " + veces + " cada " + confActividad.Do_frecuencia + " " + confActividad.Oo_unidadTiempoFrecuencia.St_Nombre;
                        else if (confActividad.Do_plazo > 0)
                            modelo.frecuencia = "Se repetirá " + veces + " cada " + confActividad.Do_frecuencia + " " + confActividad.Oo_unidadTiempoFrecuencia.St_Nombre + " durante " + confActividad.Do_plazo + " " + confActividad.Oo_unidadTiempoPlazo.St_Nombre;
                        else if (confActividad.Bo_hastaCumplirTodasUnidades)
                            modelo.frecuencia = "Se repetirá " + veces + " cada " + confActividad.Do_frecuencia + " " + confActividad.Oo_unidadTiempoFrecuencia.St_Nombre + " hasta cumplir con unidades totales";
                        else
                            modelo.frecuencia = veces + " en ese día";
                    }
                    dgv_ConfiguracionesPerfiles.Items.Add(modelo);
                }
            }
        }
        private void LimpiarDatosCapturaConfiguracionActividades()
        {
            txt_BuscadorActividades.Limpiar();
            txt_InicioActividad.ValorDouble = 0;
            txt_BuscadorUnidadTiempoInicio.Limpiar();
            cmb_fechaReferencia.SelectedIndex = -1;
            txt_repeticiones.Valor = 0;
            txt_cada.ValorDouble = 0;
            txt_BuscadorUnidadTiempoFrecuencia.Limpiar();
            txt_cantidadDePlazo.ValorDouble = 0;
            txt_veces.Valor = 0;
            txt_BuscadorUnidadTiempoPlazo.Limpiar();
            chb_sinRepeticiones.IsChecked = true;
        }
        private void CargarConfiguracionActividad()
        {
            if (ConfiguracionActividadPerfilTemp.Oo_Actividad != null)
            {
                txt_BuscadorActividades.SetObjetoAsignado(ConfiguracionActividadPerfilTemp.Oo_Actividad, ConfiguracionActividadPerfilTemp.Oo_Actividad.In_idCrop + " - " + ConfiguracionActividadPerfilTemp.Oo_Actividad.St_Nombre);
            }

            if (ConfiguracionActividadPerfilTemp.Bo_UsarPeriodoDeProduccion)
            {
                chb_usarProyeccionProduccionActividades.IsChecked = true;
            }
            else
            {
                chb_usarProyeccionProduccionActividades.IsChecked = false;

                txt_InicioActividad.ValorDouble = ConfiguracionActividadPerfilTemp.Do_tiempoRelativoInicio;

                if (ConfiguracionActividadPerfilTemp.Oo_unidadTiempoInicio != null)
                {
                    txt_BuscadorUnidadTiempoInicio.SetObjetoAsignado(ConfiguracionActividadPerfilTemp.Oo_unidadTiempoInicio, ConfiguracionActividadPerfilTemp.Oo_unidadTiempoInicio.St_Nombre);
                }
                cmb_fechaReferencia.SelectedIndex = ConfiguracionActividadPerfilTemp.In_FechaInicioRespecto;
                txt_repeticiones.Valor = ConfiguracionActividadPerfilTemp.In_Repeticiones;
                txt_veces.Valor = ConfiguracionActividadPerfilTemp.In_Veces;
                txt_cada.ValorDouble = ConfiguracionActividadPerfilTemp.Do_frecuencia;
                txt_cantidadDePlazo.ValorDouble = ConfiguracionActividadPerfilTemp.Do_plazo;

                if (ConfiguracionActividadPerfilTemp.Oo_unidadTiempoFrecuencia != null)
                {
                    txt_BuscadorUnidadTiempoFrecuencia.SetObjetoAsignado(ConfiguracionActividadPerfilTemp.Oo_unidadTiempoFrecuencia, ConfiguracionActividadPerfilTemp.Oo_unidadTiempoFrecuencia.St_Nombre);
                }

                if (ConfiguracionActividadPerfilTemp.Oo_unidadTiempoPlazo != null)
                {
                    txt_BuscadorUnidadTiempoPlazo.SetObjetoAsignado(ConfiguracionActividadPerfilTemp.Oo_unidadTiempoPlazo, ConfiguracionActividadPerfilTemp.Oo_unidadTiempoPlazo.St_Nombre);
                }
            }

            if (ConfiguracionActividadPerfilTemp.Bo_SinRepeticiones)
                chb_sinRepeticiones.IsChecked = true;
            else if (ConfiguracionActividadPerfilTemp.In_Repeticiones > 1)
                chb_repetirPorNumero.IsChecked = true;
            else if (ConfiguracionActividadPerfilTemp.Bo_hastaCumplirTodasUnidades)
                chb_hastaCumplirUnidades.IsChecked = true;
            else if (ConfiguracionActividadPerfilTemp.Do_plazo > 0)
                chb_repetirPorPlazo.IsChecked = true;

        }

        private void btn_QuitarPerfil_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (lb_PerfilesHijos.SelectedIndex != -1)
                perfilesTemp.RemoveAt(lb_PerfilesHijos.SelectedIndex);
            CargarPerfiles();
        }
        private Boolean ValidarConfiguracionActividadAAgregar()
        {
            //actividad
            if (txt_BuscadorActividades.ListaObjetos == null || txt_BuscadorActividades.ListaObjetos.Count == 0)
            {
                HerramientasWindow.MensajeInformacion("Debe agregar una actividad.", "Validación");
                return false;
            }
            //inicio
            if ((Boolean)chb_usarProyeccionProduccionActividades.IsChecked)
            {
                return true;
            }
            //if (txt_InicioActividad.ValorDouble == 0)
            //{
            //    HerramientasWindow.MensajeInformacion("Debe definir los dias para el inicio.", "Validación");
            //    return false;
            //}
            if (txt_BuscadorUnidadTiempoInicio.ListaObjetos == null || txt_BuscadorUnidadTiempoInicio.ListaObjetos.Count == 0)
            {
                HerramientasWindow.MensajeInformacion("Debe definir una unidad de tiempo para el inicio.", "Validación");
                return false;
            }
            if (cmb_fechaReferencia.SelectedIndex == -1)
            {
                HerramientasWindow.MensajeInformacion("Debe seleccionar la fecha de referencia para el inicio.", "Validación");
                return false;
            }
            //frecuencia
            if (txt_veces.Valor < 1)
            {
                HerramientasWindow.MensajeInformacion("Debe definir una cantidad de veces que se hará la actividad mayor o igual a 1.", "Validación");
                return false;
            }
            if ((Boolean)chb_repetirPorNumero.IsChecked)
            {
                if (txt_repeticiones.Valor <= 1)
                {
                    HerramientasWindow.MensajeInformacion("Debe definir el número de repeticiones mayor a 1.", "Validación");
                    return false;
                }
            }
            if ((Boolean)chb_repetirPorPlazo.IsChecked)
            {
                if (txt_cantidadDePlazo.ValorDouble == 0)
                {
                    HerramientasWindow.MensajeInformacion("Debe definir el plazo a usar.", "Validación");
                    return false;
                }
                if (txt_BuscadorUnidadTiempoPlazo.ListaObjetos.Count == 0)
                {
                    HerramientasWindow.MensajeInformacion("Debe definir la unidad de tiempo del plazo.", "Validación");
                    return false;
                }
            }
            if ((Boolean)chb_repetirPorNumero.IsChecked || (Boolean)chb_repetirPorPlazo.IsChecked || (Boolean)chb_hastaCumplirUnidades.IsChecked)
            {
                if (txt_cada.ValorDouble == 0)
                {
                    HerramientasWindow.MensajeInformacion("Debe definir los dias de frecuencia de las repeticiones.", "Validación");
                    return false;
                }
                if (txt_BuscadorUnidadTiempoFrecuencia.ListaObjetos == null || txt_BuscadorUnidadTiempoFrecuencia.ListaObjetos.Count == 0)
                {
                    HerramientasWindow.MensajeInformacion("Debe definir una unidad de tiempo para la frecuencia.", "Validación");
                    return false;
                }
            }
            return true;
        }
        private void btn_agregar_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (ValidarConfiguracionActividadAAgregar())
            {
                if (ConfiguracionActividadPerfilTemp == null) ConfiguracionActividadPerfilTemp = new _gen_ConfiguracionActividadNominaPerfil();
                if (objetoActual == null) objetoActual = new _gen_PerfilActividades();
                if (ConfiguracionesActividadesTemp == null) ConfiguracionesActividadesTemp = new List<_gen_ConfiguracionActividadNominaPerfil>();
                //objetoActual.EsModificado = true;
                ConfiguracionActividadPerfilTemp.EsModificado = true;
                //asignando valores
                ConfiguracionActividadPerfilTemp.Oo_Actividad = (_gen_ActividadNomina)txt_BuscadorActividades.GetObjetoAsignado();
                if (!(Boolean)chb_usarProyeccionProduccionActividades.IsChecked)
                {
                    ConfiguracionActividadPerfilTemp.In_Veces = txt_veces.Valor;
                    ConfiguracionActividadPerfilTemp.Do_tiempoRelativoInicio = txt_InicioActividad.ValorDouble;
                    ConfiguracionActividadPerfilTemp.Oo_unidadTiempoInicio = (_gen_UnidadDeTiempo)txt_BuscadorUnidadTiempoInicio.GetObjetoAsignado();
                    ConfiguracionActividadPerfilTemp.In_FechaInicioRespecto = cmb_fechaReferencia.SelectedIndex;
                }
                //frecuencia
                if ((Boolean)chb_usarProyeccionProduccionActividades.IsChecked)
                {
                    ConfiguracionActividadPerfilTemp.In_Repeticiones = 0;
                    ConfiguracionActividadPerfilTemp.Do_frecuencia = 0;
                    ConfiguracionActividadPerfilTemp.Oo_unidadTiempoFrecuencia = null;
                    ConfiguracionActividadPerfilTemp.Oo_unidadTiempoPlazo = null;
                    ConfiguracionActividadPerfilTemp.Do_plazo = 0;
                    ConfiguracionActividadPerfilTemp.Bo_SinRepeticiones = false;
                    ConfiguracionActividadPerfilTemp.Bo_hastaCumplirTodasUnidades = false;
                    ConfiguracionActividadPerfilTemp.Bo_UsarPeriodoDeProduccion = true;
                }
                else if ((Boolean)chb_repetirPorNumero.IsChecked)
                {
                    ConfiguracionActividadPerfilTemp.In_Repeticiones = txt_repeticiones.Valor;
                    ConfiguracionActividadPerfilTemp.Do_frecuencia = txt_cada.ValorDouble;
                    ConfiguracionActividadPerfilTemp.Oo_unidadTiempoFrecuencia = (_gen_UnidadDeTiempo)txt_BuscadorUnidadTiempoFrecuencia.GetObjetoAsignado();
                    ConfiguracionActividadPerfilTemp.Oo_unidadTiempoPlazo = null;
                    ConfiguracionActividadPerfilTemp.Do_plazo = 0;
                    ConfiguracionActividadPerfilTemp.Bo_SinRepeticiones = false;
                    ConfiguracionActividadPerfilTemp.Bo_hastaCumplirTodasUnidades = false;
                    ConfiguracionActividadPerfilTemp.Bo_UsarPeriodoDeProduccion = false;
                }
                else if ((Boolean)chb_repetirPorPlazo.IsChecked)
                {
                    ConfiguracionActividadPerfilTemp.In_Repeticiones = 0;
                    ConfiguracionActividadPerfilTemp.Bo_SinRepeticiones = false;
                    ConfiguracionActividadPerfilTemp.Do_plazo = txt_cantidadDePlazo.ValorDouble;
                    ConfiguracionActividadPerfilTemp.Oo_unidadTiempoPlazo = (_gen_UnidadDeTiempo)txt_BuscadorUnidadTiempoPlazo.GetObjetoAsignado();
                    ConfiguracionActividadPerfilTemp.Do_frecuencia = txt_cada.ValorDouble;
                    ConfiguracionActividadPerfilTemp.Oo_unidadTiempoFrecuencia = (_gen_UnidadDeTiempo)txt_BuscadorUnidadTiempoFrecuencia.GetObjetoAsignado();
                    ConfiguracionActividadPerfilTemp.Bo_hastaCumplirTodasUnidades = false;
                    ConfiguracionActividadPerfilTemp.Bo_UsarPeriodoDeProduccion = false;
                }
                else if ((Boolean)chb_sinRepeticiones.IsChecked)
                {
                    ConfiguracionActividadPerfilTemp.In_Repeticiones = 0;
                    ConfiguracionActividadPerfilTemp.Do_frecuencia = 0;
                    ConfiguracionActividadPerfilTemp.Oo_unidadTiempoFrecuencia = null;
                    ConfiguracionActividadPerfilTemp.Oo_unidadTiempoPlazo = null;
                    ConfiguracionActividadPerfilTemp.Do_plazo = 0;
                    ConfiguracionActividadPerfilTemp.Bo_SinRepeticiones = true;
                    ConfiguracionActividadPerfilTemp.Bo_hastaCumplirTodasUnidades = false;
                    ConfiguracionActividadPerfilTemp.Bo_UsarPeriodoDeProduccion = false;
                }
                else if ((Boolean)chb_hastaCumplirUnidades.IsChecked)
                {
                    ConfiguracionActividadPerfilTemp.Bo_hastaCumplirTodasUnidades = true;
                    ConfiguracionActividadPerfilTemp.In_Repeticiones = 0;
                    ConfiguracionActividadPerfilTemp.Oo_unidadTiempoPlazo = null;
                    ConfiguracionActividadPerfilTemp.Do_plazo = 0;
                    ConfiguracionActividadPerfilTemp.Bo_SinRepeticiones = false;
                    ConfiguracionActividadPerfilTemp.Do_frecuencia = txt_cada.ValorDouble;
                    ConfiguracionActividadPerfilTemp.Oo_unidadTiempoFrecuencia = (_gen_UnidadDeTiempo)txt_BuscadorUnidadTiempoFrecuencia.GetObjetoAsignado();
                    ConfiguracionActividadPerfilTemp.Bo_UsarPeriodoDeProduccion = false;
                }

                if (ConfiguracionActividadPerfilTemp.Id == 0)
                    ConfiguracionesActividadesTemp.Add(ConfiguracionActividadPerfilTemp);

                objetoActual.Ll_ConfiguracionActividades = ConfiguracionesActividadesTemp;

                GuardarObjetoSinLimpiar();
                CargarConfiguracionesActividades();
                ConfiguracionActividadPerfilTemp = null;
                LimpiarDatosCapturaConfiguracionActividades();

            }
        }
        private void dgv_ConfiguracionesPerfiles_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int n = dgv_ConfiguracionesPerfiles.SelectedIndex;
            if (n >= 0)
            {
                ConfiguracionActividadPerfilTemp = ConfiguracionesActividadesTemp[n];
                CargarConfiguracionActividad();
            }
        }

        private void btn_QuitarActividad_MouseUp(object sender, MouseButtonEventArgs e)
        {
            int n = dgv_ConfiguracionesPerfiles.SelectedIndex;
            if (n >= 0)
            {
                ConfiguracionesActividadesTemp.RemoveAt(n);
                ConfiguracionActividadPerfilTemp = null;
                CargarConfiguracionesActividades();
                LimpiarDatosCapturaConfiguracionActividades();
            }
        }

        private void chb_repetirPorNumero_Checked(object sender, RoutedEventArgs e)
        {
            chb_repetirPorPlazo.IsChecked = false;
            chb_sinRepeticiones.IsChecked = false;
            chb_hastaCumplirUnidades.IsChecked = false;
            MostrarControlesRepeticiones();

        }

        private void chb_repetirPorPlazo_Checked(object sender, RoutedEventArgs e)
        {
            chb_repetirPorNumero.IsChecked = false;
            chb_sinRepeticiones.IsChecked = false;
            chb_hastaCumplirUnidades.IsChecked = false;
            OcultarControlesRepeticiones();
        }
        private void OcultarControlesRepeticiones()
        {
            txt_repeticiones.Visibility = System.Windows.Visibility.Hidden;
            lbl_repeticiones.Visibility = System.Windows.Visibility.Hidden;

            lbl_plazo.Visibility = System.Windows.Visibility.Visible;
            txt_cantidadDePlazo.Visibility = System.Windows.Visibility.Visible;
            txt_BuscadorUnidadTiempoPlazo.Visibility = System.Windows.Visibility.Visible;
        }
        private void MostrarControlesRepeticiones()
        {
            txt_repeticiones.Visibility = System.Windows.Visibility.Visible;
            lbl_repeticiones.Visibility = System.Windows.Visibility.Visible;

            lbl_plazo.Visibility = System.Windows.Visibility.Hidden;
            txt_cantidadDePlazo.Visibility = System.Windows.Visibility.Hidden;
            txt_BuscadorUnidadTiempoPlazo.Visibility = System.Windows.Visibility.Hidden;
        }

        private void chb_sinRepeticiones_Checked(object sender, RoutedEventArgs e)
        {
            chb_repetirPorPlazo.IsChecked = false;
            chb_repetirPorNumero.IsChecked = false;
            chb_hastaCumplirUnidades.IsChecked = false;

            txt_repeticiones.Visibility = System.Windows.Visibility.Hidden;
            lbl_repeticiones.Visibility = System.Windows.Visibility.Hidden;

            lbl_plazo.Visibility = System.Windows.Visibility.Hidden;
            txt_cantidadDePlazo.Visibility = System.Windows.Visibility.Hidden;
            txt_BuscadorUnidadTiempoPlazo.Visibility = System.Windows.Visibility.Hidden;
        }

        private void chb_hastaCumplirUnidades_Checked(object sender, RoutedEventArgs e)
        {
            chb_repetirPorPlazo.IsChecked = false;
            chb_repetirPorNumero.IsChecked = false;
            chb_sinRepeticiones.IsChecked = false;

            txt_repeticiones.Visibility = System.Windows.Visibility.Hidden;
            lbl_repeticiones.Visibility = System.Windows.Visibility.Hidden;

            lbl_plazo.Visibility = System.Windows.Visibility.Hidden;
            txt_cantidadDePlazo.Visibility = System.Windows.Visibility.Hidden;
            txt_BuscadorUnidadTiempoPlazo.Visibility = System.Windows.Visibility.Hidden;

        }
        #endregion
        #region materiales
        private void chb_usarProyeccionProduccionMateriales_Checked(object sender, RoutedEventArgs e)
        {
            grid_tiempoMateriales.Visibility = System.Windows.Visibility.Hidden;
        }

        private void chb_usarProyeccionProduccionMateriales_Unchecked(object sender, RoutedEventArgs e)
        {
            grid_tiempoMateriales.Visibility = System.Windows.Visibility.Visible;
        }
        private void CargarConfiguracionesMateriales()
        {
            dgv_ConfiguracionesPerfilesMateriales.Items.Clear();
            if (ConfiguracionesMaterialesTemp != null)
            {
                foreach (_gen_ConfiguracionMaterialPerfil confMaterial in ConfiguracionesMaterialesTemp)
                {
                    Modelo modelo = new Modelo();
                    modelo.elemento = confMaterial.Oo_Material.In_CodigoCrop + " - " + confMaterial.Oo_Material.St_Descripcion;
                    if (confMaterial.Oo_FormulaCalculoMaterial != null)
                        modelo.formula = confMaterial.Oo_FormulaCalculoMaterial.St_Formula;
                    String conector = "";
                    if (confMaterial.Bo_UsarPeriodoDeProduccion)
                    {
                        modelo.inicio = "En la semana de inicio de producción";
                        modelo.frecuencia = "Durante la producción";
                    }
                    else
                    {
                        if (confMaterial.Do_tiempoRelativoInicio > 0)
                            conector = "después";
                        if (confMaterial.Do_tiempoRelativoInicio < 0)
                            conector = "antes";
                        if (confMaterial.Do_tiempoRelativoInicio == 0)
                            modelo.inicio = "En " + cmb_fechaReferencia.Items[confMaterial.In_FechaInicioRespecto].ToString();
                        else
                            modelo.inicio = Math.Abs(confMaterial.Do_tiempoRelativoInicio) + " " + confMaterial.Oo_unidadTiempoInicio.St_Nombre + " " + conector + " de " + cmb_fechaReferenciaMaterial.Items[confMaterial.In_FechaInicioRespecto].ToString();

                        String veces = "";

                        if (confMaterial.In_Veces == 1)
                            veces = "una vez";
                        else
                            veces = confMaterial.In_Veces + " veces";

                        if (confMaterial.In_Repeticiones > 1)
                            modelo.frecuencia = confMaterial.In_Repeticiones + " repeticiones, " + veces + " cada " + confMaterial.Do_frecuencia + " " + confMaterial.Oo_unidadTiempoFrecuencia.St_Nombre;
                        else if (confMaterial.Do_plazo > 0)
                            modelo.frecuencia = "Se repetirá " + veces + " cada " + confMaterial.Do_frecuencia + " " + confMaterial.Oo_unidadTiempoFrecuencia.St_Nombre + " durante " + confMaterial.Do_plazo + " " + confMaterial.Oo_unidadTiempoPlazo.St_Nombre;
                        else if (confMaterial.Bo_hastaCumplirTodasUnidades)
                            modelo.frecuencia = "Se repetirá " + veces + " cada " + confMaterial.Do_frecuencia + " " + confMaterial.Oo_unidadTiempoFrecuencia.St_Nombre + " hasta cumplir con unidades totales";
                        else
                            modelo.frecuencia = veces + " en ese día";
                    }
                    dgv_ConfiguracionesPerfilesMateriales.Items.Add(modelo);
                }
            }
        }
        private void OcultarControlesRepeticionesMateriales()
        {
            txt_repeticionesMaterial.Visibility = System.Windows.Visibility.Hidden;
            lbl_repeticionesMaterial.Visibility = System.Windows.Visibility.Hidden;

            lbl_plazoMaterial.Visibility = System.Windows.Visibility.Visible;
            txt_cantidadDePlazoMaterial.Visibility = System.Windows.Visibility.Visible;
            txt_BuscadorUnidadTiempoPlazoMaterial.Visibility = System.Windows.Visibility.Visible;
        }
        private void MostrarControlesRepeticionesMateriales()
        {
            txt_repeticionesMaterial.Visibility = System.Windows.Visibility.Visible;
            lbl_repeticionesMaterial.Visibility = System.Windows.Visibility.Visible;

            lbl_plazoMaterial.Visibility = System.Windows.Visibility.Hidden;
            txt_cantidadDePlazoMaterial.Visibility = System.Windows.Visibility.Hidden;
            txt_BuscadorUnidadTiempoPlazoMaterial.Visibility = System.Windows.Visibility.Hidden;
        }
        private void btn_QuitarMaterial_MouseUp(object sender, MouseButtonEventArgs e)
        {
            int n = dgv_ConfiguracionesPerfilesMateriales.SelectedIndex;
            if (n >= 0)
            {
                ConfiguracionesMaterialesTemp.RemoveAt(n);
                ConfiguracionMaterialPerfilTemp = null;
                CargarConfiguracionesMateriales();
                LimpiarDatosCapturaConfiguracionMateriales();
            }
        }
        private void LimpiarDatosCapturaConfiguracionMateriales()
        {
            txt_BuscadorMateriales.Limpiar();
            txt_InicioMaterial.ValorDouble = 0;
            txt_BuscadorUnidadTiempoInicioMaterial.Limpiar();
            txt_BuscadorFormula.Limpiar();
            cmb_fechaReferenciaMaterial.SelectedIndex = -1;
            txt_repeticionesMaterial.Valor = 0;
            txt_cadaMaterial.ValorDouble = 0;
            txt_BuscadorUnidadTiempoFrecuenciaMaterial.Limpiar();
            txt_cantidadDePlazoMaterial.ValorDouble = 0;
            txt_vecesMaterial.Valor = 0;
            txt_BuscadorUnidadTiempoPlazoMaterial.Limpiar();
            chb_sinRepeticionesMaterial.IsChecked = true;
        }
        private void dgv_ConfiguracionesPerfilesMateriales_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int n = dgv_ConfiguracionesPerfilesMateriales.SelectedIndex;
            if (n >= 0)
            {
                ConfiguracionMaterialPerfilTemp = ConfiguracionesMaterialesTemp[n];
                CargarConfiguracionMaterial();
            }
        }
        private void CargarConfiguracionMaterial()
        {
            if (ConfiguracionMaterialPerfilTemp.Oo_Material != null)
            {
                txt_BuscadorMateriales.SetObjetoAsignado(ConfiguracionMaterialPerfilTemp.Oo_Material, ConfiguracionMaterialPerfilTemp.Oo_Material.In_CodigoCrop + " - " + ConfiguracionMaterialPerfilTemp.Oo_Material.St_Descripcion);
            }

            if (ConfiguracionMaterialPerfilTemp.Oo_FormulaCalculoMaterial != null)
                txt_BuscadorFormula.SetObjetoAsignado(ConfiguracionMaterialPerfilTemp.Oo_FormulaCalculoMaterial, ConfiguracionMaterialPerfilTemp.Oo_FormulaCalculoMaterial.St_Formula);
            else
                txt_BuscadorFormula.Limpiar();

            if (ConfiguracionMaterialPerfilTemp.Bo_UsarPeriodoDeProduccion)
            {
                chb_usarProyeccionProduccionMateriales.IsChecked = true;
            }
            else
            {
                chb_usarProyeccionProduccionMateriales.IsChecked = false;

                txt_InicioMaterial.ValorDouble = ConfiguracionMaterialPerfilTemp.Do_tiempoRelativoInicio;

                if (ConfiguracionMaterialPerfilTemp.Oo_unidadTiempoInicio != null)
                {
                    txt_BuscadorUnidadTiempoInicioMaterial.SetObjetoAsignado(ConfiguracionMaterialPerfilTemp.Oo_unidadTiempoInicio, ConfiguracionMaterialPerfilTemp.Oo_unidadTiempoInicio.St_Nombre);
                }
                cmb_fechaReferenciaMaterial.SelectedIndex = ConfiguracionMaterialPerfilTemp.In_FechaInicioRespecto;
                txt_repeticionesMaterial.Valor = ConfiguracionMaterialPerfilTemp.In_Repeticiones;
                txt_vecesMaterial.Valor = ConfiguracionMaterialPerfilTemp.In_Veces;
                txt_cadaMaterial.ValorDouble = ConfiguracionMaterialPerfilTemp.Do_frecuencia;
                txt_cantidadDePlazoMaterial.ValorDouble = ConfiguracionMaterialPerfilTemp.Do_plazo;
                if (ConfiguracionMaterialPerfilTemp.Oo_unidadTiempoFrecuencia != null)
                {
                    txt_BuscadorUnidadTiempoFrecuenciaMaterial.SetObjetoAsignado(ConfiguracionMaterialPerfilTemp.Oo_unidadTiempoFrecuencia, ConfiguracionMaterialPerfilTemp.Oo_unidadTiempoFrecuencia.St_Nombre);
                }

                if (ConfiguracionMaterialPerfilTemp.Oo_unidadTiempoPlazo != null)
                {
                    txt_BuscadorUnidadTiempoPlazoMaterial.SetObjetoAsignado(ConfiguracionMaterialPerfilTemp.Oo_unidadTiempoPlazo, ConfiguracionMaterialPerfilTemp.Oo_unidadTiempoPlazo.St_Nombre);
                }
            }

            if (ConfiguracionMaterialPerfilTemp.Bo_SinRepeticiones)
                chb_sinRepeticionesMaterial.IsChecked = true;
            else if (ConfiguracionMaterialPerfilTemp.In_Repeticiones > 1)
                chb_repetirPorNumeroMaterial.IsChecked = true;
            else if (ConfiguracionMaterialPerfilTemp.Bo_hastaCumplirTodasUnidades)
                chb_hastaCumplirUnidadesMaterial.IsChecked = true;
            else if (ConfiguracionMaterialPerfilTemp.Do_plazo > 0)
                chb_repetirPorPlazoMaterial.IsChecked = true;

        }
        private void btn_agregarMaterial_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (ValidarConfiguracionMaterialAAgregar())
            {
                if (ConfiguracionMaterialPerfilTemp == null) ConfiguracionMaterialPerfilTemp = new _gen_ConfiguracionMaterialPerfil();
                if (objetoActual == null) objetoActual = new _gen_PerfilActividades();
                if (ConfiguracionesMaterialesTemp == null) ConfiguracionesMaterialesTemp = new List<_gen_ConfiguracionMaterialPerfil>();
                //objetoActual.EsModificado = true;
                ConfiguracionMaterialPerfilTemp.EsModificado = true;
                //asignando valores
                ConfiguracionMaterialPerfilTemp.Oo_Material = (_gen_Material)txt_BuscadorMateriales.GetObjetoAsignado();
                ConfiguracionMaterialPerfilTemp.Oo_FormulaCalculoMaterial = txt_BuscadorFormula.GetObjetoAsignado<_gen_Formula>();
                if (!(Boolean)chb_usarProyeccionProduccionMateriales.IsChecked)
                {
                    ConfiguracionMaterialPerfilTemp.In_Veces = txt_vecesMaterial.Valor;
                    ConfiguracionMaterialPerfilTemp.Do_tiempoRelativoInicio = txt_InicioMaterial.ValorDouble;
                    ConfiguracionMaterialPerfilTemp.Oo_unidadTiempoInicio = (_gen_UnidadDeTiempo)txt_BuscadorUnidadTiempoInicioMaterial.GetObjetoAsignado();
                    ConfiguracionMaterialPerfilTemp.In_FechaInicioRespecto = cmb_fechaReferenciaMaterial.SelectedIndex;
                }
                //frecuencia
                if ((Boolean)chb_usarProyeccionProduccionMateriales.IsChecked)
                {
                    ConfiguracionMaterialPerfilTemp.In_Repeticiones = 0;
                    ConfiguracionMaterialPerfilTemp.Do_frecuencia = 0;
                    ConfiguracionMaterialPerfilTemp.Oo_unidadTiempoFrecuencia = null;
                    ConfiguracionMaterialPerfilTemp.Oo_unidadTiempoPlazo = null;
                    ConfiguracionMaterialPerfilTemp.Do_plazo = 0;
                    ConfiguracionMaterialPerfilTemp.Bo_SinRepeticiones = false;
                    ConfiguracionMaterialPerfilTemp.Bo_hastaCumplirTodasUnidades = false;
                    ConfiguracionMaterialPerfilTemp.Bo_UsarPeriodoDeProduccion = true;
                }
                else if ((Boolean)chb_repetirPorNumeroMaterial.IsChecked)
                {
                    ConfiguracionMaterialPerfilTemp.In_Repeticiones = txt_repeticionesMaterial.Valor;
                    ConfiguracionMaterialPerfilTemp.Do_frecuencia = txt_cadaMaterial.ValorDouble;
                    ConfiguracionMaterialPerfilTemp.Oo_unidadTiempoFrecuencia = (_gen_UnidadDeTiempo)txt_BuscadorUnidadTiempoFrecuenciaMaterial.GetObjetoAsignado();
                    ConfiguracionMaterialPerfilTemp.Oo_unidadTiempoPlazo = null;
                    ConfiguracionMaterialPerfilTemp.Do_plazo = 0;
                    ConfiguracionMaterialPerfilTemp.Bo_SinRepeticiones = false;
                    ConfiguracionMaterialPerfilTemp.Bo_hastaCumplirTodasUnidades = false;
                    ConfiguracionMaterialPerfilTemp.Bo_UsarPeriodoDeProduccion = false;
                }
                else if ((Boolean)chb_repetirPorPlazoMaterial.IsChecked)
                {
                    ConfiguracionMaterialPerfilTemp.In_Repeticiones = 0;
                    ConfiguracionMaterialPerfilTemp.Bo_SinRepeticiones = false;
                    ConfiguracionMaterialPerfilTemp.Do_plazo = txt_cantidadDePlazoMaterial.ValorDouble;
                    ConfiguracionMaterialPerfilTemp.Oo_unidadTiempoPlazo = (_gen_UnidadDeTiempo)txt_BuscadorUnidadTiempoPlazoMaterial.GetObjetoAsignado();
                    ConfiguracionMaterialPerfilTemp.Do_frecuencia = txt_cadaMaterial.ValorDouble;
                    ConfiguracionMaterialPerfilTemp.Oo_unidadTiempoFrecuencia = (_gen_UnidadDeTiempo)txt_BuscadorUnidadTiempoFrecuenciaMaterial.GetObjetoAsignado();
                    ConfiguracionMaterialPerfilTemp.Bo_hastaCumplirTodasUnidades = false;
                    ConfiguracionMaterialPerfilTemp.Bo_UsarPeriodoDeProduccion = false;
                }
                else if ((Boolean)chb_sinRepeticionesMaterial.IsChecked)
                {
                    ConfiguracionMaterialPerfilTemp.In_Repeticiones = 0;
                    ConfiguracionMaterialPerfilTemp.Do_frecuencia = 0;
                    ConfiguracionMaterialPerfilTemp.Oo_unidadTiempoFrecuencia = null;
                    ConfiguracionMaterialPerfilTemp.Oo_unidadTiempoPlazo = null;
                    ConfiguracionMaterialPerfilTemp.Do_plazo = 0;
                    ConfiguracionMaterialPerfilTemp.Bo_SinRepeticiones = true;
                    ConfiguracionMaterialPerfilTemp.Bo_hastaCumplirTodasUnidades = false;
                    ConfiguracionMaterialPerfilTemp.Bo_UsarPeriodoDeProduccion = false;
                }
                else if ((Boolean)chb_hastaCumplirUnidadesMaterial.IsChecked)
                {
                    ConfiguracionMaterialPerfilTemp.Bo_hastaCumplirTodasUnidades = true;
                    ConfiguracionMaterialPerfilTemp.In_Repeticiones = 0;
                    ConfiguracionMaterialPerfilTemp.Oo_unidadTiempoPlazo = null;
                    ConfiguracionMaterialPerfilTemp.Do_plazo = 0;
                    ConfiguracionMaterialPerfilTemp.Bo_SinRepeticiones = false;
                    ConfiguracionMaterialPerfilTemp.Do_frecuencia = txt_cadaMaterial.ValorDouble;
                    ConfiguracionMaterialPerfilTemp.Oo_unidadTiempoFrecuencia = (_gen_UnidadDeTiempo)txt_BuscadorUnidadTiempoFrecuenciaMaterial.GetObjetoAsignado();
                    ConfiguracionMaterialPerfilTemp.Bo_UsarPeriodoDeProduccion = false;
                }

                if (ConfiguracionMaterialPerfilTemp.Id == 0)
                    ConfiguracionesMaterialesTemp.Add(ConfiguracionMaterialPerfilTemp);

                objetoActual.Ll_ConfiguracionMateriales = ConfiguracionesMaterialesTemp;

                GuardarObjetoSinLimpiar();
                CargarConfiguracionesMateriales();
                ConfiguracionMaterialPerfilTemp = null;
                LimpiarDatosCapturaConfiguracionMateriales();

            }
        }

        private bool ValidarConfiguracionMaterialAAgregar()
        {
            //material
            if (txt_BuscadorMateriales.ListaObjetos == null || txt_BuscadorMateriales.ListaObjetos.Count == 0)
            {
                HerramientasWindow.MensajeInformacion("Debe agregar un material.", "Validación");
                return false;
            }
            //inicio
            if ((Boolean)chb_usarProyeccionProduccionMateriales.IsChecked)
            {
                return true;
            }
            //if (txt_InicioMaterial.ValorDouble == 0)
            //{
            //    HerramientasWindow.MensajeInformacion("Debe definir los dias para el inicio.", "Validación");
            //    return false;
            //}
            if (txt_BuscadorUnidadTiempoInicioMaterial.ListaObjetos == null || txt_BuscadorUnidadTiempoInicioMaterial.ListaObjetos.Count == 0)
            {
                HerramientasWindow.MensajeInformacion("Debe definir una unidad de tiempo para el inicio.", "Validación");
                return false;
            }
            if (cmb_fechaReferenciaMaterial.SelectedIndex == -1)
            {
                HerramientasWindow.MensajeInformacion("Debe seleccionar la fecha de referencia para el inicio.", "Validación");
                return false;
            }
            //frecuencia
            if (txt_vecesMaterial.Valor < 1)
            {
                HerramientasWindow.MensajeInformacion("Debe definir una cantidad de veces que se hará la actividad mayor o igual a 1.", "Validación");
                return false;
            }
            if ((Boolean)chb_repetirPorNumeroMaterial.IsChecked)
            {
                if (txt_repeticionesMaterial.Valor <= 1)
                {
                    HerramientasWindow.MensajeInformacion("Debe definir el número de repeticiones mayor a 1.", "Validación");
                    return false;
                }
            }
            if ((Boolean)chb_repetirPorPlazoMaterial.IsChecked)
            {
                if (txt_cantidadDePlazoMaterial.ValorDouble == 0)
                {
                    HerramientasWindow.MensajeInformacion("Debe definir el plazo a usar.", "Validación");
                    return false;
                }
                if (txt_BuscadorUnidadTiempoPlazoMaterial.ListaObjetos.Count == 0)
                {
                    HerramientasWindow.MensajeInformacion("Debe definir la unidad de tiempo del plazo.", "Validación");
                    return false;
                }
            }
            if ((Boolean)chb_repetirPorNumeroMaterial.IsChecked || (Boolean)chb_repetirPorPlazoMaterial.IsChecked || (Boolean)chb_hastaCumplirUnidadesMaterial.IsChecked)
            {
                if (txt_cadaMaterial.ValorDouble == 0)
                {
                    HerramientasWindow.MensajeInformacion("Debe definir los dias de frecuencia de las repeticiones.", "Validación");
                    return false;
                }
                if (txt_BuscadorUnidadTiempoFrecuenciaMaterial.ListaObjetos == null || txt_BuscadorUnidadTiempoFrecuenciaMaterial.ListaObjetos.Count == 0)
                {
                    HerramientasWindow.MensajeInformacion("Debe definir una unidad de tiempo para la frecuencia.", "Validación");
                    return false;
                }
            }
            return true;
        }

        private void chb_repetirPorNumeroMaterial_Checked(object sender, RoutedEventArgs e)
        {
            chb_repetirPorPlazoMaterial.IsChecked = false;
            chb_sinRepeticionesMaterial.IsChecked = false;
            chb_hastaCumplirUnidadesMaterial.IsChecked = false;
            MostrarControlesRepeticionesMateriales();
        }

        private void chb_repetirPorPlazoMaterial_Checked(object sender, RoutedEventArgs e)
        {
            chb_repetirPorNumeroMaterial.IsChecked = false;
            chb_sinRepeticionesMaterial.IsChecked = false;
            chb_hastaCumplirUnidadesMaterial.IsChecked = false;
            OcultarControlesRepeticionesMateriales();
        }

        private void chb_sinRepeticionesMaterial_Checked(object sender, RoutedEventArgs e)
        {
            chb_repetirPorPlazoMaterial.IsChecked = false;
            chb_repetirPorNumeroMaterial.IsChecked = false;
            chb_hastaCumplirUnidadesMaterial.IsChecked = false;

            txt_repeticionesMaterial.Visibility = System.Windows.Visibility.Hidden;
            lbl_repeticionesMaterial.Visibility = System.Windows.Visibility.Hidden;

            lbl_plazoMaterial.Visibility = System.Windows.Visibility.Hidden;
            txt_cantidadDePlazoMaterial.Visibility = System.Windows.Visibility.Hidden;
            txt_BuscadorUnidadTiempoPlazoMaterial.Visibility = System.Windows.Visibility.Hidden;
        }

        private void chb_hastaCumplirUnidadesMaterial_Checked(object sender, RoutedEventArgs e)
        {
            chb_repetirPorPlazoMaterial.IsChecked = false;
            chb_repetirPorNumeroMaterial.IsChecked = false;
            chb_sinRepeticionesMaterial.IsChecked = false;

            txt_repeticionesMaterial.Visibility = System.Windows.Visibility.Hidden;
            lbl_repeticionesMaterial.Visibility = System.Windows.Visibility.Hidden;

            lbl_plazoMaterial.Visibility = System.Windows.Visibility.Hidden;
            txt_cantidadDePlazoMaterial.Visibility = System.Windows.Visibility.Hidden;
            txt_BuscadorUnidadTiempoPlazoMaterial.Visibility = System.Windows.Visibility.Hidden;
        }
        #endregion

        private void btn_verPerfilesEnCultivos_MouseUp(object sender, MouseButtonEventArgs e)
        {
            String query = @"select 
                            cul.id as [ID Cultivo]
                            , cul._st_Nombre_cultivo as [Cultivo]
                            ,tec._st_Descripcion as [Tecnología]
                            , perf._st_NombrePerfil [Perfil asociado]
                            from _gen_Cultivo cul
                            left join _gen_PerfilActividades perf on cul.id = perf._oo_cultivo
                            left join _ps_TecnologiaCultivo tec on perf._oo_tecnologia = tec.id";

            DataTable dt = manejador.EjecutarConsulta(query);

            HerramientasWindow.MostrarVisorConsultas("Perfiles aplicados a los cultivos", dt);

        }


    }
    //clase modelo para datagrid

    class Modelo
    {
        public String elemento { get; set; }
        public String formula { get; set; }
        public String inicio { get; set; }
        public String frecuencia { get; set; }
    }
}
