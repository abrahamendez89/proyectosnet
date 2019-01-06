using Dominio;
using Dominio.Modulos.ProgramaSiembra;
using InterfazWPF.AdministracionSistema;
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
using Herramientas.ORM;

namespace InterfazWPF.Modulos.Catalogos
{
    /// <summary>
    /// Lógica de interacción para win_ps_CatalogoEtapasConfiguracionSiembra.xaml
    /// </summary>
    public partial class win_ps_CatalogoEtapasConfiguracionSiembra : Window, iCatalogo
    {
        ManejadorDB manejador = new ManejadorDB();
        _ps_EtapaConfiguracionSiembra objetoActual;
        public win_ps_CatalogoEtapasConfiguracionSiembra()
        {
            InitializeComponent();
            ConfigurarBuscadores();
        }
        private void ConfigurarBuscadores()
        {
            //txt_Buscador.ConfigurarControl(manejador, typeof(_ps_VariedadSemilla), "id", typeof(long), "_st_Nombre", false, true);
            //txt_Buscador.mostrarResultado += txt_Buscador_mostrarResultado;
            //txt_Buscador.AgregarCampoConAliasAMostrar("_st_Nombre|Nombre de variedad");

            txt_buscadorEtapa.AsignarManejadorDB(manejador);
            txt_buscadorEtapa.AsignarCatalogoParaAltas("InterfazWPF.Modulos.Catalogos.win_ps_CatalogoEtapasConfiguracionSiembra");
            txt_buscadorEtapa.ConfigurarBusqueda(typeof(_ps_EtapaConfiguracionSiembra), "_st_NombreEtapa", "_st_NombreEtapa", false, true);
            txt_buscadorEtapa.mostrarResultado += txt_Buscador_mostrarResultado;
            txt_buscadorEtapa.AgregarCampoAMostrarConAlias("_st_NombreEtapa|Nombre de etapa");
        }
        void txt_Buscador_mostrarResultado(List<ObjetoBase> listaObjetos)
        {
            if (listaObjetos != null)
            {
                objetoActual = (_ps_EtapaConfiguracionSiembra)listaObjetos[0];
                CargarObjeto();
            }
        }
        private void CargarObjeto()
        {
            txt_nombreEtapa.Text = objetoActual.St_NombreEtapa;
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
            txt_buscadorEtapa.Limpiar();
            txt_nombreEtapa.Text = "";
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
                objetoActual = manejador.CrearObjeto<_ps_EtapaConfiguracionSiembra>();
            objetoActual.St_NombreEtapa = txt_nombreEtapa.Text;
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
            objetoActual = (_ps_EtapaConfiguracionSiembra)objeto;
            CargarObjeto();
        }
    }
}
