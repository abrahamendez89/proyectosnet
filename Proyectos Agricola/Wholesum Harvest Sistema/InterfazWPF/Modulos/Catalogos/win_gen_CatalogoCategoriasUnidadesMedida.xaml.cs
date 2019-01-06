using Dominio;
using Dominio.Modulos.General;
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
    /// Lógica de interacción para win_gen_CatalogoCategoriasUnidadesMedida.xaml
    /// </summary>
    public partial class win_gen_CatalogoCategoriasUnidadesMedida : Window
    {
         ManejadorDB manejador;
         _gen_CategoriaUnidadMedida objetoActual;
        public win_gen_CatalogoCategoriasUnidadesMedida()
        {
            InitializeComponent();
            manejador = new ManejadorDB();
            ConfigurarBuscadores();
        }
        private void ConfigurarBuscadores()
        {
            txt_Buscador.AsignarManejadorDB(manejador);
            txt_Buscador.AsignarCatalogoParaAltas("InterfazWPF.Modulos.Catalogos.win_gen_CatalogoCategoriasUnidadesMedida");
            txt_Buscador.ConfigurarBusqueda(typeof(_gen_CategoriaUnidadMedida), "_st_NombreCategoria", "_st_NombreCategoria", false, true);
            txt_Buscador.mostrarResultado += txt_Buscador_mostrarResultado;
            txt_Buscador.AgregarCampoAMostrarConAlias("_st_NombreCategoria|Nombre de Categoría");

        }
        void txt_Buscador_mostrarResultado(List<ObjetoBase> listaObjetos)
        {
            if (listaObjetos != null)
            {
                objetoActual = (_gen_CategoriaUnidadMedida)listaObjetos[0];
                CargarObjeto();
            }
        }
        private void CargarObjeto()
        {
            txt_nombre.Text = objetoActual.St_NombreCategoria;
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
                HerramientasWindow.MensajeError(ex,"Error: " + ex.Message, "Error");
            }
        }
        private void Limpiar()
        {
            txt_Buscador.Limpiar();
            txt_nombre.Text = "";
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
                objetoActual = manejador.CrearObjeto<_gen_CategoriaUnidadMedida>();
            objetoActual.St_NombreCategoria = txt_nombre.Text;
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
            objetoActual = (_gen_CategoriaUnidadMedida)objeto;
            CargarObjeto();
        }
    }
}
