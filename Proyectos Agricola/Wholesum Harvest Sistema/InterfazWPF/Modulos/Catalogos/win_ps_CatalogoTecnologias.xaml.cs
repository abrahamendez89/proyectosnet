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
    /// Lógica de interacción para win_ps_CatalogoTecnologias.xaml
    /// </summary>
    public partial class win_ps_CatalogoTecnologias : Window, iCatalogo
    {
        ManejadorDB manejador = new ManejadorDB();
        _ps_TecnologiaCultivo objetoActual;
        List<_ps_Cubierta> cubiertasAAgregar = new List<_ps_Cubierta>();
        public win_ps_CatalogoTecnologias()
        {
            InitializeComponent();

            txt_BuscadorTecnologia.AsignarManejadorDB(manejador);
            txt_BuscadorTecnologia.AsignarCatalogoParaAltas("InterfazWPF.Modulos.Catalogos.win_ps_CatalogoTecnologias");
            txt_BuscadorTecnologia.ConfigurarBusqueda(typeof(_ps_TecnologiaCultivo), "_st_Descripcion", "_st_Descripcion", false, true);
            txt_BuscadorTecnologia.mostrarResultado += txt_Buscador_mostrarResultado;
            txt_BuscadorTecnologia.AgregarCampoAMostrarConAlias("_st_Descripcion|Descripción");

            txt_buscadorCubierta.AsignarManejadorDB(manejador);
            txt_buscadorCubierta.AsignarCatalogoParaAltas("InterfazWPF.Modulos.Catalogos.win_ps_CatalogoCubiertas");
            txt_buscadorCubierta.ConfigurarBusqueda(typeof(_ps_Cubierta), "_st_NombreCubierta", "_st_NombreCubierta", false, true);
            txt_buscadorCubierta.mostrarResultado += txt_buscadorCubierta_mostrarResultado;
            txt_buscadorCubierta.AgregarCampoAMostrarConAlias("_st_NombreCubierta|Nombre de cubierta");


        }

        void txt_buscadorCubierta_mostrarResultado(List<ObjetoBase> listaObjetos)
        {
            foreach (_ps_Cubierta cubierta in listaObjetos)
            {
                AgregarCubierta(cubierta);
            }
            CargarCubiertas();
        }

        private void CargarCubiertas()
        {
            lb_CubiertasSeleccionadas.Items.Clear();
            foreach (_ps_Cubierta cubierta in cubiertasAAgregar)
            {
                lb_CubiertasSeleccionadas.Items.Add(cubierta.Id + "-" + cubierta.St_NombreCubierta);
            }
        }

        void txt_Buscador_mostrarResultado(List<ObjetoBase> listaObjetos)
        {
            if (listaObjetos != null)
            {
                objetoActual = (_ps_TecnologiaCultivo)listaObjetos[0];
                CargarObjeto();
                CargarCubiertas();
            }
        }
        private void CargarObjeto()
        {
            txt_tecnologiaDescripcion.Text = objetoActual.st_Descripcion;
            cubiertasAAgregar = objetoActual.Ll_CubiertasParaTecnologia;
            CargarCubiertas();
        }
        private void AgregarCubierta(_ps_Cubierta cubierta)
        {
            List<_ps_Cubierta> cubiertaEncontrada = (from i in cubiertasAAgregar
                                                     where i.Id == cubierta.Id
                                                     select i).ToList<_ps_Cubierta>();
            if (cubiertaEncontrada.Count > 0)
            {
                HerramientasWindow.MensajeInformacion("La cubierta '"+cubierta.St_NombreCubierta+"' ya se encuentra agregada.", "Información");
            }
            else
                cubiertasAAgregar.Add(cubierta);

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
            txt_tecnologiaDescripcion.Text = "";
            lb_CubiertasSeleccionadas.Items.Clear();
            txt_buscadorCubierta.Limpiar();
            txt_BuscadorTecnologia.Limpiar();
            
            cubiertasAAgregar.Clear();
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
                objetoActual = manejador.CrearObjeto < _ps_TecnologiaCultivo>();

            objetoActual.st_Descripcion = txt_tecnologiaDescripcion.Text;
            objetoActual.Ll_CubiertasParaTecnologia = cubiertasAAgregar;
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

        private void btn_quitarCubierta_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (lb_CubiertasSeleccionadas.SelectedIndex != -1)
                cubiertasAAgregar.RemoveAt(lb_CubiertasSeleccionadas.SelectedIndex);
            CargarCubiertas();
        }
        public void AsignarObjetoDominio(ObjetoBase objeto)
        {
            objetoActual = (_ps_TecnologiaCultivo)objeto;
            CargarObjeto();
        }
    }
}
