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
    /// Lógica de interacción para win_ps_CatalogoContenedores.xaml
    /// </summary>
    public partial class win_ps_CatalogoContenedores : Window, iCatalogo
    {
         ManejadorDB manejador = new ManejadorDB();
        _ps_Contenedor objetoActual;
        public win_ps_CatalogoContenedores()
        {
            InitializeComponent();
            //txt_BuscadorContenedores.ConfigurarControl(manejador, typeof(_ps_Contenedor), "id", typeof(long), "_st_NombreContenedor", false, true);
            //txt_BuscadorContenedores.mostrarResultado += txt_Buscador_mostrarResultado;
            //txt_BuscadorContenedores.AgregarCampoConAliasAMostrar("_st_NombreContenedor|Nombre de contenedor");
        }

        void txt_Buscador_mostrarResultado(List<ObjetoBase> listaObjetos)
        {
            if (listaObjetos != null)
            {
                objetoActual = (_ps_Contenedor)listaObjetos[0];
                CargarObjeto();
            }
        }
        private void CargarObjeto()
        {
            txt_ContenedorDescripcion.Text = objetoActual.St_NombreContenedor;

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
            txt_ContenedorDescripcion.Text = "";
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
                objetoActual = manejador.CrearObjeto < _ps_Contenedor>();

            objetoActual.St_NombreContenedor = txt_ContenedorDescripcion.Text;
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
            objetoActual = (_ps_Contenedor)objeto;
            CargarObjeto();
        }
    }
}
