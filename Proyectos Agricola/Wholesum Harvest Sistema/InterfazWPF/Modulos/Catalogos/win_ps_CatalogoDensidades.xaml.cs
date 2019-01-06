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
    /// Lógica de interacción para win_ps_CatalogoDensidades.xaml
    /// </summary>
    public partial class win_ps_CatalogoDensidades : Window, iCatalogo
    {
        ManejadorDB manejador = new ManejadorDB();
        _ps_DensidadPlanteo objetoActual;
        public win_ps_CatalogoDensidades()
        {
            InitializeComponent();
            AgregarHileras();
            ConfigurarBuscadores();
        }
        private void ConfigurarBuscadores()
        {
            //txt_Buscador.ConfigurarControl(manejador, typeof(_ps_DensidadPlanteo), "id", typeof(long), "id", false, false);
            //txt_Buscador.mostrarResultado += txt_Buscador_mostrarResultado;
            //txt_Buscador.AgregarCampoConAliasAMostrar("_fl_Centimetros_de_separacion|Separación (cm)");
            //txt_Buscador.AgregarCampoConAliasAMostrar("_in_Numero_de_hileras|Número hileras");
            //txt_Buscador.AgregarCampoConAliasAMostrar("_fl_CentimetrosCorazon|Corazón (cm)");
        }
        private void AgregarHileras()
        {
            cmb_NumeroHileras.Items.Add("1");
            cmb_NumeroHileras.Items.Add("2");
        }
        void txt_Buscador_mostrarResultado(List<ObjetoBase> listaObjetos)
        {
            if (listaObjetos != null)
            {
                objetoActual = (_ps_DensidadPlanteo)listaObjetos[0];
                CargarObjeto();
            }
        }
        private void CargarObjeto()
        {
            txt_Separacion.ValorFloat = objetoActual.fl_Centimetros_de_separacion;
            txt_Corazon.ValorFloat = objetoActual.Fl_CentimetrosCorazon;
            cmb_NumeroHileras.SelectedItem = objetoActual.in_Numero_de_hileras;
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
            txt_Separacion.Text = "";
            txt_Corazon.Text = "";
            cmb_NumeroHileras.SelectedItem = null;
            cmb_NumeroHileras.SelectedItem = null;
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
                objetoActual = manejador.CrearObjeto < _ps_DensidadPlanteo>();

            objetoActual.in_Numero_de_hileras = Convert.ToInt32(cmb_NumeroHileras.SelectedItem);
            objetoActual.fl_Centimetros_de_separacion = txt_Separacion.ValorFloat;
            objetoActual.Fl_CentimetrosCorazon = txt_Corazon.ValorFloat;
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
            objetoActual = (_ps_DensidadPlanteo)objeto;
            CargarObjeto();
        }
    }
}
