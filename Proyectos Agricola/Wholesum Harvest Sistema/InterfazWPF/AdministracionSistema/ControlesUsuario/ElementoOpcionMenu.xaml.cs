using Dominio.Sistema;
using System;
using System.Collections.Generic;
using System.Drawing;
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
using InterfazWPF.AdministracionSistema;
using System.Threading;

namespace InterfazWPF
{
    /// <summary>
    /// Lógica de interacción para ElementoOpcionMenu.xaml
    /// </summary>
    public partial class ElementoOpcionMenu : UserControl
    {
        public delegate void ClickElementoMenuOpcion(_sis_FormularioPermisosPorRol formulario);
        public event ClickElementoMenuOpcion clickElementoMenuOpcion;

        public delegate void ClickElementoMenuOpcionContenedor(_sis_Contenedor contenedor);
        public event ClickElementoMenuOpcionContenedor clickElementoMenuOpcionContenedor;

        private _sis_FormularioPermisosPorRol formulario;
        public _sis_FormularioPermisosPorRol Formulario { get { return formulario; } set { formulario = value; txt_titulo.Text = formulario.Formulario.STituloFormulario; AsignarImagen(formulario.Formulario); tituloConEspaciado = txt_titulo.Text + espaciado; textoOriginal= txt_titulo.Text; } }

        private _sis_Contenedor contenedor;
        public _sis_Contenedor Contenedor { get { return contenedor; } set { contenedor = value; txt_titulo.Text = contenedor.STitulo; AsignarImagen(contenedor); tituloConEspaciado = txt_titulo.Text + espaciado; textoOriginal = txt_titulo.Text; } }

        private void AsignarImagen(_sis_Formulario formulario)
        {
            Bitmap imagen = null;
            if (formulario.ImagenAsociada == null || formulario.ImagenAsociada.Imagen == null)
                imagen = new Bitmap(@"Imagenes\Iconos\Sistema\documento.png");
            else
                imagen = formulario.ImagenAsociada.Imagen;
            img_imagen.Source = HerramientasWindow.BitmapAImageSource(imagen);
            img_imagen_Resplandor.Source = img_imagen.Source;
        }
        private void AsignarImagen(_sis_Contenedor contenedor)
        {
            Bitmap imagen = null;
            if (contenedor.ImagenAsociada == null || contenedor.ImagenAsociada.Imagen == null)
                imagen = new Bitmap(@"Imagenes\Iconos\Sistema\carpeta.png");
            else
                imagen = contenedor.ImagenAsociada.Imagen;
            img_imagen.Source = HerramientasWindow.BitmapAImageSource(imagen);
            img_imagen_Resplandor.Source = img_imagen.Source;
        }
        public ElementoOpcionMenu()
        {
            this.InitializeComponent();
            this.MouseUp += img_imagen_MouseDown;
            this.MouseEnter += ElementoOpcionMenu_MouseEnter;
            this.MouseLeave += ElementoOpcionMenu_MouseLeave;
           
        }
        
        void ElementoOpcionMenu_MouseLeave(object sender, MouseEventArgs e)
        {
            if (circular != null)
            {
                circular.Abort();
                txt_titulo.Text = textoOriginal;
            }
        }
        String texto;
        String espaciado = "          ";
        String tituloConEspaciado;
        String textoOriginal;
        void ElementoOpcionMenu_MouseEnter(object sender, MouseEventArgs e)
        {
            if (textoOriginal.Length > 40)
            {
                circular = new Thread(CicularTexto);
                circular.Start();
            }
        }
        Thread circular;
        private void CicularTexto()
        {
            int i = 0;
            while (true)
            {
                Thread.Sleep(100);
                i++;
                Dispatcher.Invoke(new Action(() =>
                {
                    if (i >= tituloConEspaciado.Length)
                        i = 1;
                    int restante = i;
                    
                    texto = tituloConEspaciado.Substring(i, tituloConEspaciado.Length - i);
                    texto += tituloConEspaciado.Substring(0, restante);
                    txt_titulo.Text = texto;
                }));
            }
        }
        void img_imagen_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (formulario != null)
                clickElementoMenuOpcion(Formulario);
            else
                clickElementoMenuOpcionContenedor(contenedor);
        }
    }
}