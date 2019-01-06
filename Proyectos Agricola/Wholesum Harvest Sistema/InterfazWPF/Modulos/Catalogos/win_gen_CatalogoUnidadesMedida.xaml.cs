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
using Herramientas.ORM;

namespace InterfazWPF.Modulos.Catalogos
{
    /// <summary>
    /// Lógica de interacción para win_gen_CatalogoUnidadesMedida.xaml
    /// </summary>
    public partial class win_gen_CatalogoUnidadesMedida : Window, iCatalogo
    {
        ManejadorDB manejador;
        _gen_UnidadDeMedida objetoActual;
        public win_gen_CatalogoUnidadesMedida()
        {
            InitializeComponent();
            manejador = new ManejadorDB();
            ConfigurarBuscadores();
        }
        private void ConfigurarBuscadores()
        {
            txt_Buscador.AsignarManejadorDB(manejador);
            txt_Buscador.AsignarCatalogoParaAltas("InterfazWPF.Modulos.Catalogos.win_gen_CatalogoUnidadesMedida");
            txt_Buscador.ConfigurarBusqueda(typeof(_gen_UnidadDeMedida), "_st_Nombre", "_st_Nombre", false, true);
            txt_Buscador.mostrarResultado += txt_Buscador_mostrarResultado;
            txt_Buscador.AgregarCampoAMostrarConAlias("_st_Nombre|Nombre de Unidad de Medida");
            txt_Buscador.AgregarCampoAMostrarConAlias("_oo_Categoria._st_NombreCategoria|Categoría");

            txt_BuscadorCategoria.AsignarManejadorDB(manejador);
            txt_BuscadorCategoria.AsignarCatalogoParaAltas("InterfazWPF.Modulos.Catalogos.win_gen_CatalogoCategoriasUnidadesMedida");
            txt_BuscadorCategoria.ConfigurarBusqueda(typeof(_gen_CategoriaUnidadMedida), "_st_NombreCategoria", "_st_NombreCategoria", false, true);
            txt_BuscadorCategoria.mostrarResultado += txt_BuscadorCategoria_mostrarResultado;
            txt_BuscadorCategoria.AgregarCampoAMostrarConAlias("_st_NombreCategoria|Nombre de Categoría");

        }

        void txt_BuscadorCategoria_mostrarResultado(List<ObjetoBase> listaObjetos)
        {
            if (listaObjetos != null)
            {
                _gen_CategoriaUnidadMedida categoria = (_gen_CategoriaUnidadMedida)listaObjetos[0];
                txt_BuscadorCategoria.SetObjetoAsignado(categoria, categoria.St_NombreCategoria);
            }
        }
        void txt_Buscador_mostrarResultado(List<ObjetoBase> listaObjetos)
        {
            if (listaObjetos != null)
            {
                objetoActual = (_gen_UnidadDeMedida)listaObjetos[0];
                CargarObjeto();
            }
        }
        private void CargarObjeto()
        {
            txt_nombre.Text = objetoActual.St_Nombre;
            if (objetoActual.Oo_Categoria != null)
                txt_BuscadorCategoria.SetObjetoAsignado(objetoActual.Oo_Categoria, objetoActual.Oo_Categoria.St_NombreCategoria);
            else
                txt_BuscadorCategoria.Limpiar();
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
            txt_BuscadorCategoria.Limpiar();
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
                objetoActual = manejador.CrearObjeto<_gen_UnidadDeMedida>();
            objetoActual.St_Nombre = txt_nombre.Text;
            objetoActual.Oo_Categoria = txt_BuscadorCategoria.GetObjetoAsignado<_gen_CategoriaUnidadMedida>();
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
            objetoActual = (_gen_UnidadDeMedida)objeto;
            CargarObjeto();
        }
    }
}
