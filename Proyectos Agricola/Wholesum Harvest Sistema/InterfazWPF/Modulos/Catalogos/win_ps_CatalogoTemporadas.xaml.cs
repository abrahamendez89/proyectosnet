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
using Dominio.Modulos.General;
using Dominio;
using Dominio.Modulos.ProgramaSiembra;
using WindowsInput;
using System.Runtime.InteropServices;
using System.Threading;
using Herramientas.ORM;

namespace InterfazWPF.Modulos.Catalogos
{
    /// <summary>
    /// Lógica de interacción para win_ps_CatalogoCultivos.xaml
    /// </summary>

    public partial class win_ps_CatalogoTemporadas : Window, iCatalogo
    {
        ManejadorDB manejador;
        _gen_Temporada objetoActual;
        public win_ps_CatalogoTemporadas()
        {
            InitializeComponent();
            manejador = new ManejadorDB();
            ConfigurarBuscadores();
        }
        private void ConfigurarBuscadores()
        {
            txt_Buscador.AsignarManejadorDB(manejador);
            txt_Buscador.AsignarCatalogoParaAltas("InterfazWPF.Modulos.Catalogos.win_ps_CatalogoTemporadas");
            txt_Buscador.ConfigurarBusqueda(typeof(_gen_Temporada), "id", "_st_NombreTemporada", false, true);
            txt_Buscador.mostrarResultado += txt_Buscador_mostrarResultado;
            txt_Buscador.AgregarCampoAMostrarConAlias("_st_NombreTemporada|Temporada");

        }
        void txt_Buscador_mostrarResultado(List<ObjetoBase> listaObjetos)
        {
            if (listaObjetos != null)
            {
                objetoActual = (_gen_Temporada)listaObjetos[0];

                CargarObjeto();
            }
        }
        private void CargarObjeto()
        {
            txt_nombreCultivo.Text = objetoActual.St_NombreTemporada;
            dtp_fechaInicio.SelectedDate = objetoActual.Dt_InicioTemporada;
            dtp_FechaFin.SelectedDate = objetoActual.Dt_TerminoTemporada;
        }
        private void GuardarObjeto()
        {
            try
            {
                objetoActual.EsModificado = true;
                manejador.Guardar(objetoActual);
                objetoActual = null;
                Limpiar();
                HerramientasWindow.MensajeInformacion("Se ha guardado correctamente el objeto.", "Guardado exitoso");
            }
            catch (Exception ex)
            {
                HerramientasWindow.MensajeError(ex, "Error: " + ex.Message, "Error");
            }
        }
        private void Limpiar()
        {
            txt_Buscador.Limpiar();
            txt_nombreCultivo.Text = "";
            dtp_FechaFin.SelectedDate = null;
            dtp_fechaInicio.SelectedDate = null;
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
                objetoActual = manejador.CrearObjeto<_gen_Temporada>();
            objetoActual.Dt_InicioTemporada = dtp_fechaInicio.SelectedDate.Value;
            objetoActual.Dt_TerminoTemporada = dtp_FechaFin.SelectedDate.Value;
            objetoActual.St_NombreTemporada = txt_nombreCultivo.Text;
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
            objetoActual = (_gen_Temporada)objeto;
            CargarObjeto();
        }
    }
}
