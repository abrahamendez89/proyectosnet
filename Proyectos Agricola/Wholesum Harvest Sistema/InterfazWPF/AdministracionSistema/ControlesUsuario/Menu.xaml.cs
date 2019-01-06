using Dominio.Sistema;
using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Threading;
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
    /// Lógica de interacción para Menu.xaml
    /// </summary>
    public partial class Menu : UserControl
    {
        public delegate void ClickMenu(_sis_Contenedor contenedor);
        //public event ClickMenu clickMenu;

        public delegate void ClickElementoMenuOpcion(_sis_FormularioPermisosPorRol formulario);
        public event ClickElementoMenuOpcion clickElementoMenuOpcion;

        public int AnchoElementoMenu = 60;
        public int AltoElementoMenu = 60;
        public int SeparacionElementoMenu = 5;

        public Menu()
        {
            this.InitializeComponent();
            this.MouseMove += Menu_MouseMove;

            this.IsVisibleChanged += Menu_IsVisibleChanged;

        }

        void Menu_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                if (!((Boolean)e.NewValue))
                {
                    //t.Abort(); //terminando animacion
                }
            }
            catch (Exception ex) { }
        }

        void Menu_MouseMove(object sender, MouseEventArgs e)
        {
        }
        List<ElementoMenu> elementos = new List<ElementoMenu>();
        Thread t;
        public void AgregarElementoMenu(String titulo, Bitmap imagen, String referenciaFormulario)
        {
            _sis_Contenedor f = new _sis_Contenedor();
            f.ImagenAsociada.Imagen = imagen;
            f.STitulo = titulo;
            AgregarElementoMenu(f);
        }
        public void EliminarOpcionesEspeciales()
        {
            try
            {
                //Opciones especiales
                int encontrado = -1;
                for (int i = 0; i < elementos.Count; i++)
                {
                    if (elementos[i].Contenedor.STitulo.Equals("Opciones especiales"))
                    {
                        encontrado = i;
                        break;
                    }
                }
                elementos.RemoveAt(encontrado);
            }
            catch { }
        }
        public void AgregarElementoMenu(_sis_Contenedor contenedor)
        {
            ElementoMenu elemento = new ElementoMenu();
            elemento.Contenedor = contenedor;
            elemento.Height = AltoElementoMenu;
            elemento.Width = AnchoElementoMenu;
            elemento.Indice = elementos.Count;
            elemento.clickElementoMenu += elemento_clickElementoMenu;
            elemento.clickElementoMenuOpcion += elemento_clickElementoMenuOpcion;
            if (contenedor.STitulo == null) elemento.Visibility = System.Windows.Visibility.Hidden;
            elementos.Add(elemento);




        }

        void elemento_clickElementoMenu(int indice)
        {
            for (int i = 0; i < elementos.Count; i++)
            {
                if (i != indice)
                    elementos[i].OcultarOpciones();
            }
        }

        public void OcultarMenusOpciones()
        {
            for (int i = 0; i < elementos.Count; i++)
            {
                elementos[i].OcultarOpciones();
            }
        }
        public int NumeroElementos { get { return elementos.Count; } }
        void elemento_clickElementoMenuOpcion(_sis_FormularioPermisosPorRol formulario)
        {
            clickElementoMenuOpcion(formulario);
        }

        public void LimpiarElementos()
        {
            cnv_elementosMenu.Children.Clear();
            elementos.Clear();
            if (t != null)
                t.Abort();
        }
        public void DibujarElementos(double AnchoActual)
        {
            //elementos = (from e in elementos orderby e.Titulo ascending select e).ToList<ElementoMenu>();

            //AgregarElementoMenu(null, null, null);
            //AgregarElementoMenu("Inicio", new Bitmap(@"Imagenes\Iconos\Sistema\Inicio.png"), null);
            //AgregarElementoMenu("Atrás", new Bitmap(@"Imagenes\Iconos\Sistema\Atras.png"), null);

            int CoordenadaY = 55 - AltoElementoMenu;
            int AnchoTotalOcupado = elementos.Count * AnchoElementoMenu + (SeparacionElementoMenu * (elementos.Count - 1));
            int posicionInicial = (int)((AnchoActual - AnchoTotalOcupado) / 2);
            int i = 0;
            cnv_elementosMenu.Children.Clear();

            foreach (ElementoMenu elemento in elementos)
            {

                cnv_elementosMenu.Children.Add(elemento);
                Canvas.SetLeft(elemento, posicionInicial + ((AnchoElementoMenu + SeparacionElementoMenu) * i)); //X
                Canvas.SetTop(elemento, CoordenadaY); //Y
                i++;
            }

            //t = new Thread(TiemblenIconos);
            //t.Start();
        }

        private void TiemblenIconos()
        {
            try
            {
                while (this.IsVisible)
                {
                    Thread.Sleep(10000);
                    foreach (ElementoMenu elemento in elementos)
                    {
                        if (elemento.Visibility == System.Windows.Visibility.Visible)
                        {
                            Thread.Sleep(2000);
                            elemento.Dispatcher.BeginInvoke((Action)(() => { elemento.Temblar(); }));
                        }
                    }

                    for (int i = elementos.Count - 1; i > 0; i--)
                    {
                        if (elementos[i].Visibility == System.Windows.Visibility.Visible)
                        {
                            Thread.Sleep(2000);
                            elementos[i].Dispatcher.BeginInvoke((Action)(() => { elementos[i].Temblar(); }));
                        }
                    }
                }
            }
            catch (ThreadAbortException tae)
            {
                return;
            }
        }

    }
}