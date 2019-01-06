using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Dominio;
using Dominio.Modulos.ProgramaSiembra;
using LogicaNegocios.ProgramaSiembra;
using System.Windows.Media.Animation;

namespace InterfazWPF
{
    /// <summary>
    /// Lógica de interacción para EspacioGrafico.xaml
    /// </summary>
    public partial class EspacioGrafico : UserControl
    {
        public _ps_EspacioFisico EspacioRepresentado { get; set; }

        public delegate void ClickEspacioDetalle(_ps_EspacioFisico espacioFisicoContenido);
        public event ClickEspacioDetalle clickEspacioDetalle;

        public delegate void ClickEspacioEliminar(_ps_EspacioFisico espacioFisicoContenido);
        public event ClickEspacioEliminar clickEspacioEliminar;

        public delegate void ClickEspacioCultivo(_ps_EspacioFisico espacioFisicoContenido);
        public event ClickEspacioCultivo clickEspacioCultivo;

        public delegate void DobleClickEspacio(_ps_EspacioFisico espacioSeleccionado);
        public event DobleClickEspacio dobleClickEspacio;

        public delegate void SeAgregoEspacioEvento(EspacioGrafico espacioSeleccionado);
        public event SeAgregoEspacioEvento seAgregoEspacioEvento;

        public EspacioGrafico(_ps_EspacioFisico espacioRepresentado)
        {
            this.InitializeComponent();
            //---------eventos de drag--------

            PreviewMouseMove += EspacioGrafico_PreviewMouseMove;
            PreviewMouseLeftButtonDown += EspacioGrafico_PreviewMouseLeftButtonDown;
            Drop += EspacioGrafico_Drop;
            //--------------------------------

            EspacioRepresentado = espacioRepresentado;

            txt_NombreEspacio.Text = espacioRepresentado.st_Nombre_espacio;
            txt_DetalleEspacio.Text = "";
            if (!espacioRepresentado.Bo_esEspacioFinal)
            {
                AllowDrop = true;
                img_Cultivo.Visibility = System.Windows.Visibility.Hidden;
                //double hectareasTotales = ps_ln_Espacios.CalcularHectareajeTotal(espacioRepresentado.ll_Espacios_fisicos_dentro);
                //txt_DetalleEspacio.Text = "Hectareas totales: " + hectareasTotales + " ha\n";
                //if (hectareasTotales > 0)
                //{
                //    Dictionary<String, double> sumas = new Dictionary<string, double>();
                //    sumas = ps_ln_Espacios.CalcularHectareajePorCultivo(espacioRepresentado.ll_Espacios_fisicos_dentro, sumas);
                //    txt_DetalleEspacio.Text += "\nHectareas por cultivo:\n";
                //    foreach (String cultivo in sumas.Keys)
                //    {
                //        txt_DetalleEspacio.Text += "-" + cultivo + ": " + sumas[cultivo] + " ha\n";
                //    }
                //}
            }
            else
            {
                AllowDrop = false;
                img_Cultivo.Visibility = System.Windows.Visibility.Visible;
                txt_DetalleEspacio.Text = "Hectareas: " + espacioRepresentado.do_Numero_hectareas + " ha\n";
            }
            if (espacioRepresentado.Bo_esEspacioFinal && espacioRepresentado.ll_Configuraciones_de_Siembra != null && espacioRepresentado.ll_Configuraciones_de_Siembra.Count > 0 && espacioRepresentado.ll_Configuraciones_de_Siembra[0].oo_Cultivo_plantado != null)
            {
                txt_DetalleEspacio.Text += "Cultivo: " + espacioRepresentado.ll_Configuraciones_de_Siembra[0].oo_Cultivo_plantado.st_Nombre_cultivo + "\n";
                if (espacioRepresentado.ll_Configuraciones_de_Siembra[0].oo_Variedad_de_semilla != null)
                    txt_DetalleEspacio.Text += "Variedad: " + espacioRepresentado.ll_Configuraciones_de_Siembra[0].oo_Variedad_de_semilla.st_Nombre + "\n";
                else
                    if (espacioRepresentado.ll_Configuraciones_de_Siembra[0].Oo_DatosInjerto != null)
                        txt_DetalleEspacio.Text += "Injerto: " + espacioRepresentado.ll_Configuraciones_de_Siembra[0].Oo_DatosInjerto.Oo_VariedadRaiz.st_Nombre + " - " + espacioRepresentado.ll_Configuraciones_de_Siembra[0].Oo_DatosInjerto.Oo_VariedadProductiva.st_Nombre + "\n";
                //txt_DetalleEspacio.Text += "Densidad: " + ps_ln_Densidades.ObtenerFormatoDeDensidad(espacioRepresentado.ll_Configuraciones_de_Siembra[0].oo_Densidad_de_planteo) + "\n";
                txt_DetalleEspacio.Text += "Fecha de planteo: " + espacioRepresentado.ll_Configuraciones_de_Siembra[0].dt_Fecha_de_planteo.ToShortDateString() + "\n";


            }
            Eventos();
        }




        #region eventos de drag & drop
        Point _startPoint;
        Boolean IsDragging;
        void EspacioGrafico_Drop(object sender, DragEventArgs e)
        {
            EspacioGrafico espacio = (EspacioGrafico)e.Data.GetData(typeof(EspacioGrafico));

            if (!this.EspacioRepresentado.Bo_esEspacioFinal && !espacio.EspacioRepresentado.st_Nombre_espacio.Equals(EspacioRepresentado.st_Nombre_espacio))
            {
                if (this.EspacioRepresentado.ll_Espacios_fisicos_dentro == null) this.EspacioRepresentado.ll_Espacios_fisicos_dentro = new List<_ps_EspacioFisico>();
                //this.EspacioRepresentado.ll_Espacios_fisicos_dentro.Add(espacio.EspacioRepresentado);
                ps_ln_Espacios.AgregarEspacioAEspacio(this.EspacioRepresentado,espacio.EspacioRepresentado);


                if (seAgregoEspacioEvento != null)
                    seAgregoEspacioEvento(espacio);
            }
        }
        void EspacioGrafico_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _startPoint = e.GetPosition(null);
        }

        void EspacioGrafico_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed && !IsDragging)
            {
                Point position = e.GetPosition(null);

                if (Math.Abs(position.X - _startPoint.X) > SystemParameters.MinimumHorizontalDragDistance ||
                    Math.Abs(position.Y - _startPoint.Y) > SystemParameters.MinimumVerticalDragDistance)
                {
                    StartDrag(e);

                }
            }
        }
        private void StartDrag(MouseEventArgs e)
        {
            IsDragging = true;
            DataObject data = new DataObject(typeof(EspacioGrafico), this);
            DragDropEffects de = DragDrop.DoDragDrop(this, data, DragDropEffects.Move);

            IsDragging = false;
        }
        #endregion
        private void Eventos()
        {
            img_detalleDelEspacio.MouseDown += img_detalleDelEspacio_MouseDown;
            //img_EliminarEspacio.MouseDown += img_EliminarEspacio_MouseDown;
            img_Cultivo.MouseDown += img_Cultivo_MouseDown;

            this.MouseDoubleClick += EspacioGrafico_MouseDoubleClick;
        }

        void img_Cultivo_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (clickEspacioCultivo != null)
                clickEspacioCultivo(EspacioRepresentado);
        }

        void EspacioGrafico_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dobleClickEspacio != null)
                dobleClickEspacio(EspacioRepresentado);
        }

        void img_EliminarEspacio_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (clickEspacioEliminar != null)
                clickEspacioEliminar(EspacioRepresentado);
        }

        void img_detalleDelEspacio_MouseDown(object sender, MouseButtonEventArgs e)
        {

            if (clickEspacioDetalle != null)
                clickEspacioDetalle(EspacioRepresentado);
        }

    }
}