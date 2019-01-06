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
using Dominio.Modulos.General;
using Herramientas.ORM;

namespace InterfazWPF.Modulos.Catalogos
{
    /// <summary>
    /// Lógica de interacción para win_ps_CatalogoActividadSiembra.xaml
    /// </summary>
    public partial class win_ps_CatalogoActividadSiembra : Window, iCatalogo
    {
        ManejadorDB manejador = new ManejadorDB();
        _ps_ActividadSiembra objetoActual;
        _gen_UnidadDeTiempo unidadTiempo;
        List<_ps_ActividadSiembra> actividadesHijas = new List<_ps_ActividadSiembra>();
        public win_ps_CatalogoActividadSiembra()
        {
            InitializeComponent();
            ConfigurarBuscadores();
        }

        private void ConfigurarBuscadores()
        {
            txt_Buscador.AsignarManejadorDB(manejador);
            txt_Buscador.AsignarCatalogoParaAltas("InterfazWPF.Modulos.Catalogos.win_ps_CatalogoActividadSiembra");
            txt_Buscador.ConfigurarBusqueda(typeof(_ps_ActividadSiembra), "_st_Nombre", "_st_Nombre", false, true);
            txt_Buscador.mostrarResultado += txt_Buscador_mostrarResultado;
            txt_Buscador.AgregarCampoAMostrarConAlias("_st_Nombre|Nombre de la Actividad");

            txt_buscadorUnidadTiempo.AsignarManejadorDB(manejador);
            txt_buscadorUnidadTiempo.AsignarCatalogoParaAltas("InterfazWPF.Modulos.Catalogos.win_gen_CatalogoUnidadTiempo");
            txt_buscadorUnidadTiempo.ConfigurarBusqueda(typeof(_gen_UnidadDeTiempo), "_st_Nombre", "_st_Nombre", false, true);
            txt_buscadorUnidadTiempo.mostrarResultado += txt_buscadorUnidadTiempo_mostrarResultado;
            txt_buscadorUnidadTiempo.AgregarCampoAMostrarConAlias("_st_Nombre|Nombre de la unidad");
            txt_buscadorUnidadTiempo.AgregarCampoAMostrarConAlias("_do_EquivalenciaEn1Hora|Equivalencia con 1 Hora");

        }
        void txt_buscadorUnidadTiempo_mostrarResultado(List<ObjetoBase> listaObjetos)
        {
            if (listaObjetos != null)
            {
                unidadTiempo = (_gen_UnidadDeTiempo)listaObjetos[0];
            }
        }

        void txt_Buscador_mostrarResultado(List<ObjetoBase> listaObjetos)
        {
            if (listaObjetos != null)
            {
                objetoActual = (_ps_ActividadSiembra)listaObjetos[0];
                CargarObjeto();
            }
        }
        private void CargarObjeto()
        {
            txt_nombreActividad.Text = objetoActual.St_Nombre;
            txt_duracion.ValorDouble = objetoActual.Do_Duracion;
            if (objetoActual.Oo_UnidadTiempo != null)
            {
                txt_buscadorUnidadTiempo.SetObjetoAsignado(objetoActual.Oo_UnidadTiempo,objetoActual.Oo_UnidadTiempo.St_Nombre);
                unidadTiempo = objetoActual.Oo_UnidadTiempo;
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
            txt_buscadorUnidadTiempo.Limpiar();
            txt_duracion.ValorDouble = 0;
            txt_nombreActividad.Text = "";
        }
        private Boolean Validar()
        {
            //if (unidadTiempo == null)
            //{
            //    HerramientasWindow.Mensaje
            //}
            return true;
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
                objetoActual = manejador.CrearObjeto < _ps_ActividadSiembra>();
            objetoActual.St_Nombre = txt_nombreActividad.Text;
            objetoActual.Oo_UnidadTiempo = unidadTiempo;
            objetoActual.Do_Duracion = txt_duracion.ValorDouble;
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
            throw new NotImplementedException();
        }
    }
}
