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

namespace InterfazWPF
{
	/// <summary>
	/// Lógica de interacción para ContenedorOpcionesElementoMenu.xaml
	/// </summary>
	public partial class ContenedorOpcionesElementoMenu : UserControl
	{
        public delegate void ClickElementoMenuOpcion(_sis_FormularioPermisosPorRol formulario);
        public event ClickElementoMenuOpcion clickElementoMenuOpcion;
        private List<_sis_Contenedor> historialContenedores = new List<_sis_Contenedor>();
		public ContenedorOpcionesElementoMenu()
		{
			this.InitializeComponent();
            this.MouseLeave += ContenedorOpcionesElementoMenu_MouseLeave;
            this.PreviewKeyDown += ContenedorOpcionesElementoMenu_PreviewKeyDown;
            img_arriba.Source = HerramientasWindow.BitmapAImageSource(new Bitmap(@"Imagenes\Iconos\Sistema\arriba3.png"));
            img_arriba_Resplandor.Source = img_arriba.Source;
            img_arriba.ToolTip = "Regresa a la carpeta anterior. (ESC)";
		}

        void ContenedorOpcionesElementoMenu_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                IrArriba();
            }
        }

        void ContenedorOpcionesElementoMenu_MouseLeave(object sender, MouseEventArgs e)
        {
            Ocultar();
        }
        public void Ocultar()
        {
            this.Visibility = System.Windows.Visibility.Hidden;
        }
        public void BorrarMenu()
        {
            pnl_opciones.Children.Clear();
        }
        public void AgregarOpcionMenuFormulario(_sis_FormularioPermisosPorRol formulario)
        {
            ElementoOpcionMenu opcion = new ElementoOpcionMenu();
            opcion.Formulario = formulario;
            opcion.Width = Width;
            opcion.txt_titulo.Width = opcion.Width;
            //opcion.Height = 120;
            opcion.clickElementoMenuOpcion += opcion_clickElementoMenuOpcion;
            pnl_opciones.Children.Add(opcion);
        }
        public void AgregarOpcionMenuContenedor(_sis_Contenedor contenedor)
        {
            ElementoOpcionMenu opcion = new ElementoOpcionMenu();
            opcion.Contenedor = contenedor;
            opcion.Width = Width;
            opcion.txt_titulo.Width = opcion.Width;
            //opcion.Height = 120;
            opcion.clickElementoMenuOpcionContenedor += opcion_clickElementoMenuOpcionContenedor;
            pnl_opciones.Children.Add(opcion);
        }
        private void EscribirRuta()
        {
            txt_ruta.Text = "";
            if (historialContenedores.Count > 3)
            {
                txt_ruta.Text += historialContenedores[0].STitulo + @"\..\";
                for (int i = historialContenedores.Count-3; i < historialContenedores.Count; i++)
                {
                    txt_ruta.Text += historialContenedores[i].STitulo + @"\";
                }
            }
            else
            {
                foreach (_sis_Contenedor contenedor in historialContenedores)
                {
                    txt_ruta.Text += contenedor.STitulo + @"\";
                }
            }
        }
        public void AgregarOpcionMenuContenedorInicial(_sis_Contenedor contenedor)
        {
            historialContenedores.Clear();
            historialContenedores.Add(contenedor);
            EscribirRuta();
            pnl_opciones.Children.Clear();
            if (contenedor.Contenedores != null)
            {

                foreach (_sis_Contenedor contenedo in contenedor.Contenedores)
                {
                    AgregarOpcionMenuContenedor(contenedo);
                }
            }
            if (contenedor.FormulariosPermisos != null)
            {
                foreach (_sis_FormularioPermisosPorRol formulario in contenedor.FormulariosPermisos)
                {
                    AgregarOpcionMenuFormulario(formulario);
                }
            }
        }

        void opcion_clickElementoMenuOpcionContenedor(_sis_Contenedor contenedor)
        {
            if (contenedor.FormulariosPermisos != null || contenedor.Contenedores != null)
                BorrarMenu();
            else
                return;

            historialContenedores.Add(contenedor);
            EscribirRuta();
            if (contenedor.Contenedores != null)
            {
               
                foreach (_sis_Contenedor contenedo in contenedor.Contenedores)
                {
                    AgregarOpcionMenuContenedor(contenedo);
                }
            }
            if (contenedor.FormulariosPermisos != null)
            {
                foreach (_sis_FormularioPermisosPorRol formulario in contenedor.FormulariosPermisos)
                {
                    AgregarOpcionMenuFormulario(formulario);
                }
            }
        }

        void opcion_clickElementoMenuOpcion(_sis_FormularioPermisosPorRol formulario)
        {
            clickElementoMenuOpcion(formulario);
        }

        private void img_arriba_MouseUp(object sender, MouseButtonEventArgs e)
        {
            IrArriba();
        }
        private void IrArriba()
        {
            if (historialContenedores.Count == 1) return;
            historialContenedores.RemoveAt(historialContenedores.Count - 1);
            if (historialContenedores.Count - 1 == -1) return;
            _sis_Contenedor anterior = historialContenedores[historialContenedores.Count - 1];
            historialContenedores.RemoveAt(historialContenedores.Count - 1);
            opcion_clickElementoMenuOpcionContenedor(anterior);
        }
	}
}