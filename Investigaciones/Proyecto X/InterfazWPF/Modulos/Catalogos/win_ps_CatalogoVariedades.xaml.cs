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
using Dominio.Modulos.ProgramaSiembra;
using InterfazWPF.AdministracionSistema;
using Herramientas.ORM;

namespace InterfazWPF.Modulos.Catalogos
{
    /// <summary>
    /// Lógica de interacción para win_ps_CatalogoVariedades.xaml
    /// </summary>
    public partial class win_ps_CatalogoVariedades : Window, iCatalogo
    {
        ManejadorDB manejador = new ManejadorDB();
        _ps_VariedadSemilla objetoActual;
        
        public win_ps_CatalogoVariedades()
        {
            InitializeComponent();
            ConfigurarBuscadores();
            

        }
        private void ConfigurarBuscadores()
        {
            //txt_Buscador.ConfigurarControl(manejador, typeof(_ps_VariedadSemilla), "id", typeof(long), "_st_Nombre", false, true);
            //txt_Buscador.mostrarResultado += txt_Buscador_mostrarResultado;
            //txt_Buscador.AgregarCampoConAliasAMostrar("_st_Nombre|Nombre de variedad");

            txt_Buscador.AsignarManejadorDB(manejador);
            txt_Buscador.AsignarCatalogoParaAltas("InterfazWPF.Modulos.Catalogos.win_ps_CatalogoVariedades");
            txt_Buscador.ConfigurarBusqueda(typeof(_ps_VariedadSemilla), "_st_Nombre", "_st_Nombre", false, true);
            txt_Buscador.mostrarResultado += txt_Buscador_mostrarResultado;
            txt_Buscador.AgregarCampoAMostrarConAlias("_st_Nombre|Nombre de variedad");
            txt_Buscador.AgregarCampoAMostrarConAlias("_bo_esTipoRaiz|Es tipo raíz");
            txt_Buscador.AgregarCampoAMostrarConAlias("_bo_esTipoProductiva|Es tipo productiva");

        }

        void txt_Buscador_mostrarResultado(List<ObjetoBase> listaObjetos)
        {
            if (listaObjetos != null)
            {
                objetoActual = (_ps_VariedadSemilla)listaObjetos[0];
                CargarObjeto();
            }
        }
        private void CargarObjeto()
        {
            txt_nombreCultivo.Text = objetoActual.st_Nombre;
            chb_TipoProductiva.IsChecked = objetoActual.Bo_esTipoProductiva;
            chb_tipoRaiz.IsChecked = objetoActual.Bo_esTipoRaiz;
            txt_Comentario.Text = objetoActual.St_Comentario;
            //if(objetoActual.Oo_VariedadSemillaMaterial != null)
            //    txt_buscadorMaterial.SetObjetoAsignado(objetoActual.Oo_VariedadSemillaMaterial, objetoActual.Oo_VariedadSemillaMaterial.In_CodigoCrop + " - " + objetoActual.Oo_VariedadSemillaMaterial.St_Descripcion);
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
            chb_tipoRaiz.IsChecked = true;
            chb_TipoProductiva.IsChecked = false;
            txt_Comentario.Text = "";
            txt_buscadorMaterial.Limpiar();
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
                objetoActual = manejador.CrearObjeto < _ps_VariedadSemilla>();
            objetoActual.Bo_esTipoProductiva = (Boolean)chb_TipoProductiva.IsChecked;
            objetoActual.Bo_esTipoRaiz = (Boolean)chb_tipoRaiz.IsChecked;
            objetoActual.st_Nombre = txt_nombreCultivo.Text;
            objetoActual.St_Comentario = txt_Comentario.Text;
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
            objetoActual = (_ps_VariedadSemilla)objeto;
            CargarObjeto();
        }
    }
}
