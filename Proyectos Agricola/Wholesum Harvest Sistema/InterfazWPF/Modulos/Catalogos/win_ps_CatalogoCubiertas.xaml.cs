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
    /// Lógica de interacción para win_ps_CatalogoCubiertas.xaml
    /// </summary>
    public partial class win_ps_CatalogoCubiertas : Window, iCatalogo
    {
        ManejadorDB manejador = new ManejadorDB();
        _ps_Cubierta objetoActual;
        public win_ps_CatalogoCubiertas()
        {
            InitializeComponent();
            //txt_BuscadorCubierta.ConfigurarControl(manejador, typeof(_ps_Cubierta), "id", typeof(long), "_st_NombreCubierta", false, true);
            //txt_BuscadorCubierta.mostrarResultado += txt_Buscador_mostrarResultado;
            //txt_BuscadorCubierta.AgregarCampoConAliasAMostrar("_st_NombreCubierta|Nombre de cubierta");
            txt_BuscadorCubierta.AsignarManejadorDB(manejador);
            txt_BuscadorCubierta.AsignarCatalogoParaAltas("InterfazWPF.Modulos.Catalogos.win_ps_CatalogoCubiertas");
            txt_BuscadorCubierta.ConfigurarBusqueda(typeof(_ps_Cubierta), "_st_NombreCubierta", "_st_NombreCubierta", false, true);
            txt_BuscadorCubierta.mostrarResultado += txt_Buscador_mostrarResultado;
            txt_BuscadorCubierta.AgregarCampoAMostrarConAlias("_st_NombreCubierta|Nombre de cubierta");

        }

        void txt_Buscador_mostrarResultado(List<ObjetoBase> listaObjetos)
        {
            if (listaObjetos != null)
            {
                objetoActual = (_ps_Cubierta)listaObjetos[0];
                CargarObjeto();
            }
        }
        private void CargarObjeto()
        {
            txt_CubiertaDescripcion.Text = objetoActual.St_NombreCubierta;

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
            txt_CubiertaDescripcion.Text = "";
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
                objetoActual = manejador.CrearObjeto < _ps_Cubierta>();

            objetoActual.St_NombreCubierta = txt_CubiertaDescripcion.Text;
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
            objetoActual = (_ps_Cubierta)objeto;
            CargarObjeto();
        }
    }
}
