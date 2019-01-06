using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace InterfazWPF.Modulos.ControlesUsuarioGenerales
{
    public class LineaConectorActividades
    {
        public ElementoActividad ElementoActividadInicio { get; set; }
        public ElementoActividad ElementoActividadFinal { get; set; }
        public Line LineaVisual { get; set; }
        public TextBlock Duracion { get; set; }
        public String duracion { get { return Duracion.Text; } set { Duracion.Text = value; } }

        public LineaConectorActividades()
        {
            Duracion = new TextBlock();
        }

        public void ActualizarLinea()
        {
            LineaVisual.X1 = ElementoActividadInicio.Ubicacion.X;
            LineaVisual.Y1 = ElementoActividadInicio.Ubicacion.Y;
            LineaVisual.X2 = ElementoActividadFinal.Ubicacion.X;
            LineaVisual.Y2 = ElementoActividadFinal.Ubicacion.Y;
            //double mitadAncho = Duracion.RenderSize.Width / 2;
            Canvas.SetLeft(Duracion, ((LineaVisual.X2 - LineaVisual.X1) / 2 + LineaVisual.X1));
            Canvas.SetTop(Duracion, ((LineaVisual.Y2 - LineaVisual.Y1)/2 + LineaVisual.Y1)-40);
        }
    }
}
