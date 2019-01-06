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
using InterfazWPF.AdministracionSistema;
using Dominio.Modulos.General;
using Dominio;
using Dominio.Modulos.ProgramaSiembra;
using WindowsInput;
using System.Runtime.InteropServices;
using System.Threading;
using Herramientas.ORM;

namespace InterfazWPF.Modulos.Catalogos
{
    /// <summary>
    /// Lógica de interacción para win_ps_CatalogoCultivos.xaml
    /// </summary>

    public partial class win_ps_CatalogoCultivos : Window, iCatalogo
    {
        ManejadorDB manejador;
        _gen_Cultivo objetoActual;
        List<_ps_VariedadSemilla> ListadoVariedadesTemp = new List<_ps_VariedadSemilla>();
        public win_ps_CatalogoCultivos()
        {
            InitializeComponent();
            manejador = new ManejadorDB();
            ConfigurarBuscadores();
        }
        private void ConfigurarBuscadores()
        {
            txt_Buscador.AsignarManejadorDB(manejador);
            txt_Buscador.AsignarCatalogoParaAltas("InterfazWPF.Modulos.Catalogos.win_ps_CatalogoCultivos");
            txt_Buscador.ConfigurarBusqueda(typeof(_gen_Cultivo), "id", "_st_Nombre_cultivo", false, true);
            txt_Buscador.mostrarResultado += txt_Buscador_mostrarResultado;
            txt_Buscador.AgregarCampoAMostrarConAlias("_st_Nombre_cultivo|Nombre del cultivo");

            txt_BuscadorVariedad.AsignarManejadorDB(manejador);
            txt_BuscadorVariedad.AsignarCatalogoParaAltas("InterfazWPF.Modulos.Catalogos.win_ps_CatalogoVariedades");
            txt_BuscadorVariedad.ConfigurarBusqueda(typeof(_ps_VariedadSemilla), "_st_Nombre", "_st_Nombre", true, true);
            txt_BuscadorVariedad.mostrarResultado += txt_BuscadorVariedad_mostrarResultado;
            txt_BuscadorVariedad.AgregarCampoAMostrarConAlias("_st_Nombre|Nombre de Variedad");
            txt_BuscadorVariedad.AgregarCampoAMostrarConAlias("_bo_esTipoRaiz|Es tipo raíz");
            txt_BuscadorVariedad.AgregarCampoAMostrarConAlias("_bo_esTipoProductiva|Es tipo productiva");
        }

        void txt_BuscadorVariedad_mostrarResultado(List<ObjetoBase> listaObjetos)
        {
            foreach (_ps_VariedadSemilla variedad in listaObjetos)
            {
                AgregarVariedad(variedad);
            }
            CargarVariedades();
        }
        private void CargarVariedades()
        {
            lb_VariedadesCultivo.Items.Clear();
            if (ListadoVariedadesTemp == null) ListadoVariedadesTemp = new List<_ps_VariedadSemilla>();

            foreach (_ps_VariedadSemilla variedad in ListadoVariedadesTemp)
            {
                lb_VariedadesCultivo.Items.Add(variedad.st_Nombre);
            }

        }
        private void AgregarVariedad(_ps_VariedadSemilla variedad)
        {
            List<_ps_VariedadSemilla> variedadEncontrada = (from i in ListadoVariedadesTemp
                                                            where i.Id == variedad.Id
                                                            select i).ToList<_ps_VariedadSemilla>();
            if (variedadEncontrada.Count > 0)
            {
                HerramientasWindow.MensajeInformacion("La Variedad '" + variedad.st_Nombre + "' ya se encuentra agregada.", "Información");
            }
            else
                ListadoVariedadesTemp.Add(variedad);

        }
        void txt_Buscador_mostrarResultado(List<ObjetoBase> listaObjetos)
        {
            if (listaObjetos != null)
            {
                objetoActual = (_gen_Cultivo)listaObjetos[0];

                ListadoVariedadesTemp = objetoActual.Ll_VariedadesDisponibles;
                CargarObjeto();
                CargarVariedades();
            }
        }
        private void CargarObjeto()
        {
            txt_nombreCultivo.Text = objetoActual.st_Nombre_cultivo;
            txt_abreviatura.Text = objetoActual.St_Abreviatura;
            txt_diasAntesSiembra.Valor = objetoActual.In_DiasAntesSiembra;
            txt_diasDespuesCosecha.Valor = objetoActual.In_DiasDespuesCosecha;
            ListadoVariedadesTemp = objetoActual.Ll_VariedadesDisponibles;
            txt_porcentajeAdicional.ValorDouble = objetoActual.Do_PorcentajeDeSemillaAdicional;
            CargarVariedades();
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
            txt_nombreCultivo.Text = "";
            txt_BuscadorVariedad.Limpiar();
            txt_Buscador.Limpiar();
            txt_diasAntesSiembra.Text = "";
            txt_diasDespuesCosecha.Text = "";
            txt_abreviatura.Text = "";
            txt_porcentajeAdicional.Text = "";
            lb_VariedadesCultivo.Items.Clear();
            ListadoVariedadesTemp.Clear();
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
                objetoActual = manejador.CrearObjeto < _gen_Cultivo>();
            objetoActual.In_DiasAntesSiembra = txt_diasAntesSiembra.Valor;
            objetoActual.In_DiasDespuesCosecha = txt_diasDespuesCosecha.Valor;
            objetoActual.st_Nombre_cultivo = txt_nombreCultivo.Text;
            objetoActual.St_Abreviatura = txt_abreviatura.Text;
            objetoActual.Do_PorcentajeDeSemillaAdicional = txt_porcentajeAdicional.ValorDouble;
            objetoActual.Ll_VariedadesDisponibles = ListadoVariedadesTemp;
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

        private void btn_QuitarVariedad_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (lb_VariedadesCultivo.SelectedIndex != -1)
                ListadoVariedadesTemp.RemoveAt(lb_VariedadesCultivo.SelectedIndex);
            CargarVariedades();
        }


        public void AsignarObjetoDominio(ObjetoBase objeto)
        {
            objetoActual = (_gen_Cultivo)objeto;
            CargarObjeto();
        }
    }
}
