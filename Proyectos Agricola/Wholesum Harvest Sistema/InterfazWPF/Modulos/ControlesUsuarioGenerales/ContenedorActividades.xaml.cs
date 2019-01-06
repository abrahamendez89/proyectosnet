using InterfazWPF.Modulos.ControlesUsuarioGenerales;
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

namespace InterfazWPF
{
    /// <summary>
    /// Lógica de interacción para ContenedorActividades.xaml
    /// </summary>
    public partial class ContenedorActividades : UserControl
    {
        public ContenedorActividades()
        {
            this.InitializeComponent();
            cnv_elementos.MouseDown += cnv_elementos_MouseDown;
            cnv_elementos.MouseMove += cnv_elementos_MouseMove;
            cnv_elementos.MouseUp += cnv_elementos_MouseUp;
        }
        Boolean moviendo = false;
        void cnv_elementos_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (!ModoRelacion)
            {
                moviendo = false;
                seleccionado = null;
            }
        }

        void cnv_elementos_MouseMove(object sender, MouseEventArgs e)
        {
            if (moviendo && seleccionado != null)
            {
                Point p = e.GetPosition((Canvas)sender);
                Canvas.SetLeft(seleccionado, p.X - puntoEnSeleccionado.X);
                Canvas.SetTop(seleccionado, p.Y - puntoEnSeleccionado.Y);

                seleccionado.Ubicacion = new Point(Canvas.GetLeft(seleccionado) + (seleccionado.Size.Width / 2), Canvas.GetTop(seleccionado) + (seleccionado.Size.Height / 2));

                seleccionado.ActualizarLineasVisuales();
            }
            if (ModoRelacion && LineaLogicaTemp != null)
            {
                Point p = e.GetPosition((Canvas)sender);
                LineaVisualTemp.X2 = p.X - 1;
                LineaVisualTemp.Y2 = p.Y - 1;
            }
        }
        ElementoActividad seleccionado;
        void cnv_elementos_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //Point p = e.GetPosition((Canvas)sender);
            //linea.X2 = p.X;
            //linea.Y2 = p.Y;
            //moviendo = true;
        }
        public void AgregarElementoActividad(ElementoActividad elementoActividad)
        {
            Canvas.SetLeft(elementoActividad, 10);
            Canvas.SetTop(elementoActividad, 10);
            cnv_elementos.Children.Add(elementoActividad);
            elementoActividad.Size = new Size(40, 40);
            Canvas.SetZIndex(elementoActividad, 1000);
            elementoActividad.MouseDown += elementoActividad_MouseDown;
            elementoActividad.MouseUp += elementoActividad_MouseUp;
            //AgregarLinea();
        }
        int indice = 1;
        void elementoActividad_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (ModoRelacion && LineaLogicaTemp != null)
            {
                final = (ElementoActividad)sender;
                Canvas.SetZIndex(LineaLogicaTemp.LineaVisual, 1);
                final.AgregarRelacion(LineaLogicaTemp); // = inicio.LineaLogica;
                LineaLogicaTemp.ElementoActividadFinal = final;
                LineaLogicaTemp.ElementoActividadFinal.Ubicacion = new Point(Canvas.GetLeft(final) + (final.Size.Width / 2), Canvas.GetTop(final) + (final.Size.Height / 2));
                LineaLogicaTemp.ActualizarLinea();
                cnv_elementos.Children.Add(LineaLogicaTemp.Duracion);
                ModoRelacion = false;
                LineaVisualTemp = null;
                LineaLogicaTemp = null;
            }
        }
        public Boolean ModoRelacion { get; set; }
        Point puntoEnSeleccionado;
        ElementoActividad inicio;
        ElementoActividad final;
        LineaConectorActividades LineaLogicaTemp;
        Line LineaVisualTemp;
        void elementoActividad_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (ModoRelacion && LineaLogicaTemp == null)
            {
                inicio = (ElementoActividad)sender;
                LineaLogicaTemp = new LineaConectorActividades();
                LineaLogicaTemp.ElementoActividadInicio = inicio;
                LineaLogicaTemp.duracion = "Actividad "+indice+++"\n"+indice*2+" día(s)";
                //lineaConector.ElementoActividadInicio.Ubicacion = e.GetPosition((ElementoActividad)sender);
                LineaLogicaTemp.ElementoActividadInicio.Ubicacion = new Point(Canvas.GetLeft(inicio) + (inicio.Size.Width / 2), Canvas.GetTop(inicio) + (inicio.Size.Height / 2));

                LineaVisualTemp = new Line();
                inicio.AgregarRelacion(LineaLogicaTemp);

                LineaLogicaTemp.LineaVisual = LineaVisualTemp;

                LineaVisualTemp.X1 = LineaLogicaTemp.ElementoActividadInicio.Ubicacion.X;
                LineaVisualTemp.Y1 = LineaLogicaTemp.ElementoActividadInicio.Ubicacion.Y;
                LineaVisualTemp.Stroke = Brushes.Green;
                LineaVisualTemp.StrokeEndLineCap = PenLineCap.Triangle;
                LineaVisualTemp.StrokeThickness = 4;
                
                cnv_elementos.Children.Add(LineaVisualTemp);
            }
            else if(!ModoRelacion)

            {
                seleccionado = (ElementoActividad)sender;
                puntoEnSeleccionado = e.GetPosition((ElementoActividad)sender);
                seleccionado.Ubicacion = new Point(puntoEnSeleccionado.X + (seleccionado.Size.Width / 2), puntoEnSeleccionado.Y + (seleccionado.Size.Height / 2));
                moviendo = true;
            }
        }
    }
}