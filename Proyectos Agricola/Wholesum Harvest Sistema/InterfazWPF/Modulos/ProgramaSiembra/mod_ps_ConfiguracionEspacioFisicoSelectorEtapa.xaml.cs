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
using InterfazWPF.Modulos.ProgramaSiembra.Controles;
using Dominio;
using InterfazWPF.AdministracionSistema;
using Herramientas.ORM;

namespace InterfazWPF.Modulos.ProgramaSiembra
{
    /// <summary>
    /// Lógica de interacción para mod_ps_ConfiguracionEspacioFisicoSelectorEtapa.xaml
    /// </summary>
    public partial class mod_ps_ConfiguracionEspacioFisicoSelectorEtapa : Window
    {
        public _ps_ConfiguracionSiembra ConfiguracionSeleccionada { get; set; }
        public int IndiceConfiguracionSiembra { get; set; }
        ManejadorDB manejador;
        _ps_EspacioFisico espacioFisico;
        public mod_ps_ConfiguracionEspacioFisicoSelectorEtapa(_ps_EspacioFisico espacioFisico, ManejadorDB manejador)
        {
            InitializeComponent();
            Closing += mod_ps_ConfiguracionEspacioFisicoSelectorEtapa_Closing;
            img_cerrar.MouseDown += img_cerrar_MouseDown;
            img_cerrar.ToolTip = "Click para cerrar, o presione escape.";
            txt_mensaje.Text += espacioFisico.st_Nombre_espacio;

            this.manejador = manejador;
            this.espacioFisico = espacioFisico;
            pnl_etapas.HorizontalContentAlignment = System.Windows.HorizontalAlignment.Center;
            this.KeyDown += mod_ps_ConfiguracionEspacioFisicoSelectorEtapa_KeyDown;
            img_basurero.Drop += img_basurero_Drop;
            img_basurero.ToolTip = "Arrastra la etapa sobre este ícono para eliminarla.";
            CargarEtapas();
        }

        

        private void CargarEtapas()
        {
            pnl_etapas.Children.Clear();
            double width = 82;
            if (espacioFisico.ll_Configuraciones_de_Siembra != null)
            {
                //aqui calcular los tamaños para las etapas

                width = 315 / (espacioFisico.ll_Configuraciones_de_Siembra.Count+1);

                if (width > 82) width = 82;

                foreach (_ps_ConfiguracionSiembra confSiTemp in espacioFisico.ll_Configuraciones_de_Siembra)
                {
                    if (confSiTemp.Oo_EtapaConfiguracionSiembra == null)
                    {
                        confSiTemp.Oo_EtapaConfiguracionSiembra = new _ps_EtapaConfiguracionSiembra();
                        //confSiTemp.Oo_EtapaConfiguracionSiembra.EsModificado = true;
                        confSiTemp.Oo_EtapaConfiguracionSiembra.St_NombreEtapa = "-";
                        confSiTemp.Id = -1;
                    }

                    //EtapaConfiguracionSiembra ecS = new EtapaConfiguracionSiembra();
                    //ecS.ConfiguracionSiembra = confSiTemp;
                    //ecS.Height = width;
                    //ecS.Width = ecS.Height;
                    //ecS.clickEtapa += ecS_clickEtapa;
                    //ecS.clickEtapaOpciones += ecS_clickEtapaOpciones;
                    //ecS.PreviewMouseMove += ecS_PreviewMouseMove;
                    //ecS.PreviewMouseLeftButtonDown += ecS_PreviewMouseLeftButtonDown;
                    //pnl_etapas.Children.Add(ecS);

                }
            }
            SelectorAgregarEtapa sae = new SelectorAgregarEtapa();
            sae.Height = width;
            sae.Width = sae.Height;
            sae.MouseDown += sae_MouseDown;
            pnl_etapas.Children.Add(sae);
        }

        #region drag &drop
        Point _startPoint;
        Boolean IsDragging;
        void img_basurero_Drop(object sender, DragEventArgs e)
        {
            if (HerramientasWindow.MensajeSIoNOAdvertencia("¿Desea eliminar la etapa?", "Eliminar etapa"))
            {
                _ps_ConfiguracionSiembra confSiembraQuitar = (_ps_ConfiguracionSiembra)e.Data.GetData(typeof(_ps_ConfiguracionSiembra));

                espacioFisico.ll_Configuraciones_de_Siembra.Remove(confSiembraQuitar);
                CargarEtapas();
            }
        }
        void ecS_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _startPoint = e.GetPosition(null);
        }
        void ecS_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed && !IsDragging)
            {
                Point position = e.GetPosition(null);

                if (Math.Abs(position.X - _startPoint.X) > SystemParameters.MinimumHorizontalDragDistance ||
                    Math.Abs(position.Y - _startPoint.Y) > SystemParameters.MinimumVerticalDragDistance)
                {
                    StartDrag(sender, e);

                }
            } 
        }
        private void StartDrag(Object sender,MouseEventArgs e)
        {
            //IsDragging = true;
            //DataObject data = new DataObject(typeof(_ps_ConfiguracionSiembra), ((EtapaConfiguracionSiembra)sender).ConfiguracionSiembra);
            //DragDropEffects de = DragDrop.DoDragDrop(this, data, DragDropEffects.Move);

            //IsDragging = false;
        }
        #endregion
        void ecS_clickEtapaOpciones(_ps_ConfiguracionSiembra confSiembra, int indice)
        {
            _ps_EtapaConfiguracionSiembra etapaSel = AccederACatalogoEtapas(confSiembra.Oo_EtapaConfiguracionSiembra);
            if (etapaSel != null)
            {
                confSiembra.Oo_EtapaConfiguracionSiembra = etapaSel;
                confSiembra.EsModificado = true;
                CargarEtapas();
            }
        }

        void sae_MouseDown(object sender, MouseButtonEventArgs e)
        {
           _ps_EtapaConfiguracionSiembra etapaSel = AccederACatalogoEtapas(null);
           
           if (etapaSel != null)
           {

           

               if (espacioFisico.ll_Configuraciones_de_Siembra == null) espacioFisico.ll_Configuraciones_de_Siembra = new List<_ps_ConfiguracionSiembra>();

               foreach (_ps_ConfiguracionSiembra confT in espacioFisico.ll_Configuraciones_de_Siembra)
               {
                   if (confT.Oo_EtapaConfiguracionSiembra != null)
                       if (confT.Oo_EtapaConfiguracionSiembra.Id == etapaSel.Id)
                       {
                           HerramientasWindow.MensajeInformacion("La etapa que seleccionó ya esta agregada.", "Etapa duplicada");
                           return;
                       }
               }
               espacioFisico.EsModificado = true;

               _ps_ConfiguracionSiembra nueva = manejador.CrearObjeto<_ps_ConfiguracionSiembra>();
               nueva.EsModificado = true;
               nueva.Oo_EtapaConfiguracionSiembra = etapaSel;
               espacioFisico.ll_Configuraciones_de_Siembra.Add(nueva);
               nueva.oo_Espacio_Fisico_Asociado = espacioFisico;
               CargarEtapas();
           }
            
        }

        private _ps_EtapaConfiguracionSiembra AccederACatalogoEtapas(_ps_EtapaConfiguracionSiembra etapaTemp)
        {
            mod_ps_SeleccionEtapaCatalogo sec = null;
            if(etapaTemp == null)
                sec = new mod_ps_SeleccionEtapaCatalogo(manejador, "");
            else
                sec = new mod_ps_SeleccionEtapaCatalogo(manejador, etapaTemp.St_NombreEtapa);

            sec.ShowDialog();
            if (sec.SeAcepto)
            {
                _ps_EtapaConfiguracionSiembra etapa = sec.EtapaSeleccionada;
                sec.Close();
                return etapa;
            }
            else
            {
                sec.Close();
                return etapaTemp;
            }

        }

        void img_cerrar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Hide();
        }

        void mod_ps_ConfiguracionEspacioFisicoSelectorEtapa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                Hide();
        }

        void ecS_clickEtapa(_ps_ConfiguracionSiembra confSiembra, int indice)
        {
            if (confSiembra.Oo_EtapaConfiguracionSiembra.St_NombreEtapa.Equals("-"))
            {
                HerramientasWindow.MensajeInformacion("Debes asignarle una etapa antes de modificar, usa la opción de edición.", "Información");
                return;
            }
            ConfiguracionSeleccionada = confSiembra;
            IndiceConfiguracionSiembra = indice;
            Hide();
        }

        void mod_ps_ConfiguracionEspacioFisicoSelectorEtapa_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }
    }
}
