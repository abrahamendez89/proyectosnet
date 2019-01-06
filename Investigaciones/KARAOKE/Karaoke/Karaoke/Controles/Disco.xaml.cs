using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Herramientas.WPF;
using Karaoke.Clases;
using System.Threading;

namespace Karaoke.Controles
{
    /// <summary>
    /// Lógica de interacción para Disco.xaml
    /// </summary>
    public partial class Disco : UserControl
    {
        public delegate void MouseOver(Disco disco);
        public event MouseOver mouseOver;

        public delegate void MouseClickSeleccionoElemento(Disco indice);

        public event MouseClickSeleccionoElemento mouseClickSeleccionoElemento;

        double cordenadaXOriginal = 0;
        double cordenadaYOriginal = 0;
        public Boolean EstaEnModoPistas { get; set; }
        public int IndiceAsignado { get; set; }
       
        public Agrupador AgrupadorAsignado { get; set; }

        public void AsignarAgrupador(Agrupador agrupador)
        {
            AgrupadorAsignado = agrupador;
            txt_titulo.Text = agrupador.NombreAgrupador;
            txt_codigo.Text = agrupador.Codigo.ToString("0000");
            //img_fondoDisco.Source = agrupador.Imagen;
            if (agrupador.ImagenTexto == null || agrupador.ImagenTexto.Trim().Equals(""))
                img_fondoDisco.Source = Herramientas.WPF.Utilidades.BitmapAImageSource(Principal.disco);
            else
                img_fondoDisco.Source = Herramientas.WPF.Utilidades.ArchivoAImageSource(agrupador.ImagenTexto);
            lb_pistas.Items.Clear();
            if (agrupador.ElementosMultimedia != null && agrupador.ElementosMultimedia.Count > 0)
            {
                lb_pistas.Items.Add(0.ToString("00") + " - Reproducir todo".ToUpper());
                foreach (ElementoMultimedia elemento in agrupador.ElementosMultimedia)
                {
                    lb_pistas.Items.Add(elemento.Codigo.ToString("00") + " - " + elemento.Titulo);
                }
            }
        }

        public Disco()
        {
            InitializeComponent();
            //for(int i = 0; i < 22; i++)
            //    lb_pistas.Items.Add(i.ToString("00")+": pista "+i);

            lb_pistas.MouseDoubleClick += lb_pistas_MouseDoubleClick;

            try
            {
                img_fondoDisco.Source = Utilidades.ArchivoAImageSource("cd_estandar.png");
            }
            catch { }

            this.MouseEnter += Disco_MouseEnter;
            this.MouseLeave += Disco_MouseLeave;
            lb_pistas.KeyDown += lb_pistas_KeyDown;

            this.IsVisibleChanged += Disco_IsVisibleChanged;
            rtg_fondo.IsVisibleChanged += Disco_IsVisibleChanged;
        }

        void lb_pistas_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            indice = lb_pistas.SelectedIndex;
            IndiceAsignado = indice;
            Seleccionar();
            mouseClickSeleccionoElemento(this);
        }

        void lb_pistas_KeyDown(object sender, KeyEventArgs e)
        {
        }

        void Disco_MouseLeave(object sender, MouseEventArgs e)
        {
            MostrarCaratula();
        }

        void Disco_MouseEnter(object sender, MouseEventArgs e)
        {
            MostrarPistas();
            if(mouseOver != null) mouseOver(this);
        }

        public List<ElementoMultimedia> ObtenerElementoMultimediaSeleccionado()
        {
            if (indice < 0) return null;
                if (indice == 0)
                {
                    return AgrupadorAsignado.ElementosMultimedia;
                }
                else
                {
                    return new List<ElementoMultimedia>() { AgrupadorAsignado.ElementosMultimedia[indice - 1] };
                }
            //}
            return null;
        }

        void Disco_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (this.Visibility == System.Windows.Visibility.Visible)
            {
                cordenadaXOriginal = GetPosition(txt_codigo).X;
                cordenadaYOriginal = GetPosition(txt_codigo).Y;
            }
        }
        public double HeightManual { get; set; }
        void lb_pistas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MostrarCaratula();
        }
        public void MostrarPistas()
        {
            if (lb_pistas.Items.Count == 0)
                return;

            Storyboard evento = (Storyboard)this.FindResource("ModoPistas");
            evento.Begin();

            MoveTo(txt_codigo, 0, 5);
            MoveTo(txt_titulo, txt_codigo.Width + 5, 5);
            EstaEnModoPistas = true;
            Seleccionar();
        }
        int indice = 0;
        private void Seleccionar()
        {
            if (lb_pistas.Items.Count == 0) return;
            if (indice < 0) indice = lb_pistas.Items.Count - 1;
            if (indice == lb_pistas.Items.Count) indice = 0;
            
            lb_pistas.SelectedIndex = indice;
            //lb_pistas.Focus();
            lb_pistas.ScrollIntoView(lb_pistas.SelectedItem);

            RotarTexto();
        }

        private void RotarTexto()
        {
            if (textoOriginal != null)
                lb_pistas.Items[indiceAnterior] = textoOriginal;

            textoOriginal = lb_pistas.Items[indice].ToString();
            tituloConEspaciado = textoOriginal + espaciado;
            if (circular != null && circular.ThreadState != ThreadState.Stopped) circular.Abort();
            if (textoOriginal.Length * 9 > (lb_pistas.ActualWidth-12))
            {
                circular = new Thread(CicularTexto);
                circular.Start();
            }
        }

        Thread circular;
        String texto;
        String espaciado = "          ";
        String tituloConEspaciado;
        String textoOriginal;
        private void CicularTexto()
        {
            int i = 0;
            while (true)
            {
                Thread.Sleep(130);
                i++;
                if (i >= tituloConEspaciado.Length)
                    i = 1;
                int restante = i;

                texto = tituloConEspaciado.Substring(i, tituloConEspaciado.Length - i);
                texto += tituloConEspaciado.Substring(0, restante);

                Dispatcher.Invoke(new Action(() =>
                {
                    lb_pistas.Items[indice] = texto;
                }));
                
            }
        }
        int indiceAnterior = 0;
        public void SubirEnLista()
        {
            indiceAnterior = indice;
            --indice;
            Seleccionar();
        }
        public void BajarEnLista()
        {
            indiceAnterior = indice;
            ++indice;
            Seleccionar();
        }
        public void MostrarCaratula()
        {
            //if (mostrandoPistas)
            //{

            if (circular != null && circular.ThreadState != ThreadState.Stopped) circular.Abort();

            AsignarAgrupador(AgrupadorAsignado);


            if (lb_pistas.Items.Count == 0)
                return;

            Storyboard evento = (Storyboard)this.FindResource("ModoCaratula");
            evento.Begin();
            MoveTo(txt_codigo, 8, HeightManual - 35);
            MoveTo(txt_titulo, 8 + txt_codigo.Width + 5, HeightManual - 35);
            EstaEnModoPistas = false;
            indice = 0;
            indiceAnterior = 0;
            textoOriginal = null;
            //}
        }
        public void MoveTo(UIElement target, double newX, double newY)
        {
            Vector offset = VisualTreeHelper.GetOffset(target);
            var top = offset.Y;
            var left = offset.X;
            TranslateTransform trans = new TranslateTransform();
            target.RenderTransform = trans;
            DoubleAnimation anim1 = new DoubleAnimation(0, newY - top, TimeSpan.FromSeconds(0.3));
            DoubleAnimation anim2 = new DoubleAnimation(0, newX - left, TimeSpan.FromSeconds(0.3));
            trans.BeginAnimation(TranslateTransform.YProperty, anim1);
            trans.BeginAnimation(TranslateTransform.XProperty, anim2);
        }
        
        private System.Windows.Point GetPosition(UIElement element)
        {
            var positionTransform = element.TransformToAncestor(VisualTreeHelper.GetParent(element) as UIElement);
            System.Windows.Point areaPosition = positionTransform.Transform(new System.Windows.Point(0, 0));

            return areaPosition;
        }
    }
}
