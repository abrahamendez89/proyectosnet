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
using Dominio.Sistema;
using System.Windows.Media.Animation;
using System.Drawing;
using InterfazWPF.AdministracionSistema;

namespace InterfazWPF
{
    /// <summary>
    /// Lógica de interacción para ElementoMenu.xaml
    /// </summary>
    public partial class ElementoMenu : UserControl
    {
        public delegate void ClickElementoMenu(int indice);
        public event ClickElementoMenu clickElementoMenu;

        public delegate void ClickElementoMenuOpcion(_sis_FormularioPermisosPorRol formulario);
        public event ClickElementoMenuOpcion clickElementoMenuOpcion;
        public int Indice { get; set; }
        private _sis_Contenedor contenedor;
        public _sis_Contenedor Contenedor
        {
            get
            {
                return contenedor;
            }
            set
            {
                contenedor = value;
                if (contenedor.ImagenAsociada != null && contenedor.ImagenAsociada.Imagen != null)
                {
                    img_imagenIcono.Source = HerramientasWindow.BitmapAImageSource(contenedor.ImagenAsociada.Imagen);
                }
                else
                {
                    img_imagenIcono.Source = HerramientasWindow.BitmapAImageSource(new Bitmap(@"Imagenes\Iconos\Sistema\carpeta.png"));
                }
                img_imagenIcono_reflejo.Source = img_imagenIcono.Source;
                txt_titulo.Text = contenedor.STitulo;
                UpdateLayout();
            }
        }
        public ImageSource ImagenMenu { get { return img_imagenIcono.Source; } set { img_imagenIcono.Source = value; img_imagenIcono_reflejo.Source = img_imagenIcono.Source; } }
        public String Titulo
        {
            get { return txt_titulo.Text; }
            set { txt_titulo.Text = value; txt_titulo.Width = value.Length * 10; }
        }
        Storyboard temblar = null;

        public ElementoMenu()
        {
            this.InitializeComponent();
            contenedorOpcionesElementoMenu.Visibility = System.Windows.Visibility.Hidden;
            temblar = (Storyboard)this.FindResource("Temblar");
            temblar.Completed += mouseEnter_Completed;
            contenedorOpcionesElementoMenu.clickElementoMenuOpcion += contenedorOpcionesElementoMenu_clickElementoMenuOpcion;
            this.img_imagenIcono.MouseUp += ElementoMenu_MouseDown;



            this.img_imagenIcono.MouseEnter += ElementoMenu_MouseEnter;
            this.img_imagenIcono.MouseLeave += ElementoMenu_MouseLeave;
        }

        void contenedorOpcionesElementoMenu_clickElementoMenuOpcion(_sis_FormularioPermisosPorRol formulario)
        {
            contenedorOpcionesElementoMenu.Visibility = System.Windows.Visibility.Hidden;
            clickElementoMenuOpcion(formulario);
        }
        private Boolean estaTemblando;
        void ElementoMenu_MouseLeave(object sender, MouseEventArgs e)
        {
            estaTemblando = false;
            Storyboard mouseEnter = (Storyboard)this.FindResource("OnMouseLeave1");
            mouseEnter.Begin();
        }

        void ElementoMenu_MouseEnter(object sender, MouseEventArgs e)
        {
            estaTemblando = true;
            Storyboard mouseEnter = (Storyboard)this.FindResource("OnMouseEnter1");
            mouseEnter.Begin();
        }

        void ElementoMenu_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //if (contenedor != null)
            //{
            //    clickElementoMenu(contenedor);
            //}

            //contenedorOpcionesElementoMenu.BorrarMenu();
            //contenedor.EliminarCache();

            contenedorOpcionesElementoMenu.AgregarOpcionMenuContenedorInicial(contenedor);

            if(contenedorOpcionesElementoMenu.Visibility == System.Windows.Visibility.Hidden)
                contenedorOpcionesElementoMenu.Visibility = System.Windows.Visibility.Visible;
            else
                contenedorOpcionesElementoMenu.Visibility = System.Windows.Visibility.Hidden;

            clickElementoMenu(Indice);

        }
        public void OcultarOpciones()
        {
            contenedorOpcionesElementoMenu.Ocultar();
        }
        public void Temblar()
        {
            if (!estaTemblando)
            {
                estaTemblando = true;
                temblar.Begin();
            }
        }

        void mouseEnter_Completed(object sender, EventArgs e)
        {
            estaTemblando = false;
        }


    }
}