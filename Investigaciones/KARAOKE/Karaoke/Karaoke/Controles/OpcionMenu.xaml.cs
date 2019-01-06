using Karaoke.Clases;
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

namespace Karaoke.Controles
{
    /// <summary>
    /// Lógica de interacción para OpcionMenu.xaml
    /// </summary>
    public partial class OpcionMenu : UserControl
    {
        public delegate void SeleccionoCategoria(Agrupador agrupador);
        public event SeleccionoCategoria seleccionoCategoria;

        public delegate void EntroMouse(OpcionMenu opcionMenu);
        public event EntroMouse entroMouse;

        public delegate void Click(OpcionMenu opcionMenu);
        public event Click click;

        public delegate void SeleccionoPista(ElementoListaReproduccion elementoLista);
        public event SeleccionoPista seleccionoPista;

        public Boolean Seleccionado { get; set; }

        public Agrupador AgrupadorPrincipalCategorias { get { return agrupador; } set { agrupador = value; if (agrupador.ImagenTexto != null && !agrupador.ImagenTexto.Trim().Equals("")) { img_imagen.Source = Herramientas.WPF.Utilidades.ArchivoAImageSource(agrupador.ImagenTexto); } else { img_imagen.Source = Herramientas.WPF.Utilidades.ArchivoAImageSource(@"Imagenes\categoria_carpeta.png"); } txt_nombreCategoria.Text = agrupador.NombreAgrupador; txt_informacion.Visibility = System.Windows.Visibility.Hidden; txt_titulo.Visibility = System.Windows.Visibility.Hidden; } }
        public void ActualizarProgreso()
        {
            if (elementoLista == null) return;
            //if (elementoLista.elemento != null && elementoLista.elemento.TipoElemento == ElementoMultimedia.TipoElementoMultimedia.YouTube)
            //{
            //    txt_titulo.Text = elementoLista.elemento.Titulo;
            //    pb_descargado.Visibility = System.Windows.Visibility.Visible;
            //    pb_descargado.Value = elementoLista.elemento.ProgresoDescargado;
            //}
            //else
            //{
            //    pb_descargado.Visibility = System.Windows.Visibility.Hidden;
            //    pb_descargado.Value = 0;
            //}
        }
        public ElementoListaReproduccion ElementoLista
        {
            get { return elementoLista; }
            set
            {
                elementoLista = value;
                txt_numeroPista.Text = elementoLista.NumeroPista.ToString("00");
                txt_titulo.Text = elementoLista.elemento.Titulo;
                txt_nombreCategoria.Visibility = System.Windows.Visibility.Hidden;
                
                if (elementoLista.elemento.AgrupadorContiene == null)
                {
                    txt_informacion.Text = "YOUTUBE";
                    if (elementoLista.elemento.TipoElemento == ElementoMultimedia.TipoElementoMultimedia.Karaoke)
                        txt_informacion.Text += " KARAOKE";
                    if (elementoLista.elemento.TipoElemento == ElementoMultimedia.TipoElementoMultimedia.Musica)
                        txt_informacion.Text += " MUSICA";
                    if (elementoLista.elemento.TipoElemento == ElementoMultimedia.TipoElementoMultimedia.Video)
                        txt_informacion.Text += " VIDEO";
                    //if (elementoLista.elemento != null && elementoLista.elemento.TipoElemento == ElementoMultimedia.TipoElementoMultimedia.YouTube)
                    //{
                    //    txt_titulo.Text = elementoLista.elemento.Titulo;
                    //    pb_descargado.Visibility = System.Windows.Visibility.Visible;
                    //    pb_descargado.Value = elementoLista.elemento.ProgresoDescargado;
                    //}
                    //else
                    //{
                    //    pb_descargado.Visibility = System.Windows.Visibility.Hidden;
                    //    pb_descargado.Value = 0;
                    //}
                }
                else
                    txt_informacion.Text = elementoLista.elemento.AgrupadorContiene.AgrupadorPadre.AgrupadorPadre.NombreAgrupador + "|" + elementoLista.elemento.AgrupadorContiene.NombreAgrupador; img_imagen.Source = elementoLista.Imagen;
            }
        }
        private Agrupador agrupador;
        private ElementoListaReproduccion elementoLista;
        public int Indice { get; set; }
        public OpcionMenu()
        {
            InitializeComponent();

            this.MouseDown += OpcionMenu_MouseDown;
            this.MouseDoubleClick += OpcionMenu_MouseDoubleClick;
            this.MouseEnter += OpcionMenu_MouseEnter;
        }

        void OpcionMenu_MouseEnter(object sender, MouseEventArgs e)
        {
            entroMouse(this);
        }

        void OpcionMenu_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (seleccionoPista != null)
            {
                seleccionoPista(elementoLista);
                return;
            }
            if (seleccionoCategoria != null)
            {
                seleccionoCategoria(this.agrupador);
                return;
            }
        }

        void OpcionMenu_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (click != null) click(this);
        }
        public void Seleccionar()
        {
            Seleccionado = true;
            Storyboard evento = (Storyboard)this.FindResource("Seleccionar");
            evento.Begin();
        }
        public void SeleccionarAgrupador()
        {
            if (agrupador != null)
            {
                if (seleccionoCategoria != null)
                    seleccionoCategoria(this.agrupador);
            }
        }
        public void Deseleccionar()
        {
            if (Seleccionado)
            {
                Seleccionado = false;
                Storyboard evento = (Storyboard)this.FindResource("Deseleccionar");
                evento.Begin();
            }
        }
    }
}
