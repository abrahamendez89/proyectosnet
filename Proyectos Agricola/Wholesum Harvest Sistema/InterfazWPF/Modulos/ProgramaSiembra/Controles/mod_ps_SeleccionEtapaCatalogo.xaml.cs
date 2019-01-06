using Dominio;
using Dominio.Modulos.ProgramaSiembra;
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

namespace InterfazWPF.Modulos.ProgramaSiembra.Controles
{
    /// <summary>
    /// Lógica de interacción para mod_ps_SeleccionEtapaCatalogo.xaml
    /// </summary>
    public partial class mod_ps_SeleccionEtapaCatalogo : Window
    {
        ManejadorDB manejador;
        public _ps_EtapaConfiguracionSiembra EtapaSeleccionada { get; set; }
        public Boolean SeAcepto { get; set; }
        public mod_ps_SeleccionEtapaCatalogo(ManejadorDB manejador, String etiquetaEtapa)
        {
            InitializeComponent();
            this.manejador = manejador;
            ConfigurarBuscadores();
            //txt_buscadorEtapa.Etiqueta = etiquetaEtapa;

            btn_aceptar.MouseDown += btn_aceptar_MouseDown;
            btn_cancelar.MouseDown += btn_cancelar_MouseDown;
        }

        void btn_cancelar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SeAcepto = false;
            EtapaSeleccionada = null;
            Hide();
        }

        void btn_aceptar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SeAcepto = true;
            Hide();
        }
        private void ConfigurarBuscadores()
        {
            txt_buscadorEtapa.AsignarManejadorDB(manejador);
            txt_buscadorEtapa.AsignarCatalogoParaAltas("InterfazWPF.Modulos.Catalogos.win_ps_CatalogoEtapasConfiguracionSiembra");
            txt_buscadorEtapa.ConfigurarBusqueda(typeof(_ps_EtapaConfiguracionSiembra), "_st_NombreEtapa", "_st_NombreEtapa", false, true);
            txt_buscadorEtapa.mostrarResultado += txt_buscadorEtapa_mostrarResultado;
            txt_buscadorEtapa.AgregarCampoAMostrarConAlias("_st_NombreEtapa|Nombre de etapa");
        }

        void txt_buscadorEtapa_mostrarResultado(List<ObjetoBase> listaObjetos)
        {
            EtapaSeleccionada = (_ps_EtapaConfiguracionSiembra)listaObjetos[0];
        }
    }
}
