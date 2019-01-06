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
    /// Lógica de interacción para win_gen_CatalogoUnidadTiempo.xaml
    /// </summary>
    public partial class win_gen_CatalogoUnidadTiempo : Window, iCatalogo
    {

        ManejadorDB manejador = new ManejadorDB();
        _gen_UnidadDeTiempo objetoActual;

        public win_gen_CatalogoUnidadTiempo()
        {
            InitializeComponent();
            ConfigurarBuscadores();
        }

        private void ConfigurarBuscadores()
        {
            txt_Buscador.AsignarManejadorDB(manejador);
            txt_Buscador.AsignarCatalogoParaAltas("InterfazWPF.Modulos.Catalogos.win_gen_CatalogoUnidadTiempo");
            txt_Buscador.ConfigurarBusqueda(typeof(_gen_UnidadDeTiempo), "_st_Nombre", "_st_Nombre", false, true);
            txt_Buscador.mostrarResultado += txt_Buscador_mostrarResultado;
            txt_Buscador.AgregarCampoAMostrarConAlias("_st_Nombre|Nombre de la unidad");
            txt_Buscador.AgregarCampoAMostrarConAlias("_do_EquivalenciaEn1Hora|Equivalencia con 1 Hora");
        }

        void txt_Buscador_mostrarResultado(List<ObjetoBase> listaObjetos)
        {
            if (listaObjetos != null)
            {
                objetoActual = (_gen_UnidadDeTiempo)listaObjetos[0];
                CargarObjeto();
            }
        }
        private void CargarObjeto()
        {
            txt_nombre.Text = objetoActual.St_Nombre;
            txt_equivalenciaHora.ValorDouble = objetoActual.Do_EquivalenciaEn1Hora;
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
            txt_nombre.Text = "";
            txt_equivalenciaHora.ValorDouble = 0;
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
                objetoActual = manejador.CrearObjeto < _gen_UnidadDeTiempo>();
            objetoActual.St_Nombre = txt_nombre.Text;
            objetoActual.Do_EquivalenciaEn1Hora = txt_equivalenciaHora.ValorDouble;
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
            objetoActual = (_gen_UnidadDeTiempo)objeto;
            CargarObjeto();
        }
    }
}
