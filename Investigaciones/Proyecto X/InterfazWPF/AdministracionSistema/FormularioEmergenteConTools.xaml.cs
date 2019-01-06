using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace InterfazWPF.AdministracionSistema
{
    /// <summary>
    /// Lógica de interacción para FormularioEmergenteConTools.xaml
    /// </summary>
    public partial class FormularioEmergenteConTools : Window
    {
        Window ventanaActual;
        private String[] metodosPermitidos = null;
        public FormularioEmergenteConTools(Window window)
        {
            InitializeComponent();
            ventanaActual = window;

            LlenarContenedor(window);

            LlenarToolbox();

            this.SizeToContent = System.Windows.SizeToContent.WidthAndHeight;
        }
        private void LlenarContenedor(Window window)
        {
            try
            {
                //if (actualTab == tabAnterior) return;
                //aqui intentar hacer la separacion de los controles de las ventanas
                Grid gridTemp = (Grid)window.Content;
                if (gridTemp == null)
                    return;
                //gridTemp.Margin = new Thickness(10, 10, 10, 10);
                window.Content = null;
                gridTemp.VerticalAlignment = System.Windows.VerticalAlignment.Center;
                gridTemp.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                contentControl.Content = gridTemp;
                //----------------------------------
                //CentrarContenido(window);
            }
            catch (Exception ex)
            {
                HerramientasWindow.MensajeError(ex,"Ocurrió un error al cargar el contenido de la ventana. [" + ex.Message + "]", "Error creando ventana");
            }
        }
        
        private void LlenarToolbox()
        {
            pnl_Opciones.Children.Clear();
            if (ventanaActual != null)
            {
                Type t = ventanaActual.GetType();

                MethodInfo[] metodos = t.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);

                foreach (MethodInfo metodo in metodos)
                {
                    if (metodo.Name.ToLower().StartsWith("toolbox_"))
                    {
                        String nombre = metodo.Name.Replace("toolbox_", "").Replace("_", " ");
                        if (((metodosPermitidos != null && metodosPermitidos.Contains(nombre))) || metodosPermitidos == null)
                        {
                            ElementoOpcionVentanaEmergente tool = new ElementoOpcionVentanaEmergente();
                            tool.Width = pnl_Opciones.Width;
                            tool.Height = pnl_Opciones.Width;
                            tool.Metodo = metodo.Name;
                            tool.Titulo = nombre;
                            tool.Tipo = t;
                            tool.clickEvento += tool_clickEvento;
                            try
                            {
                                tool.Imagen = new Bitmap(@"Imagenes\Iconos\Formularios\" + tool.Titulo + ".png");
                            }
                            catch
                            {
                                tool.Imagen = new Bitmap(@"Imagenes\Iconos\Sistema\Tarea.png");
                            }
                            pnl_Opciones.Children.Add(tool);
                        }
                    }
                    else if (metodo.Name.ToLower().StartsWith("_toolbox_"))
                    {
                        String nombre = metodo.Name.Replace("_toolbox_", "").Replace("_", " ");
                        ElementoOpcionVentanaEmergente tool = new ElementoOpcionVentanaEmergente();
                        tool.Width = pnl_Opciones.Width;
                        tool.Height = pnl_Opciones.Width;
                        tool.Metodo = metodo.Name;
                        tool.Titulo = nombre;
                        tool.Tipo = t;
                        tool.clickEvento += tool_clickEvento;
                        try
                        {
                            tool.Imagen = new Bitmap(@"Imagenes\Iconos\Formularios\" + tool.Titulo + ".png");
                        }
                        catch
                        {
                            tool.Imagen = new Bitmap(@"Imagenes\Iconos\Sistema\Tarea.png");
                        }
                        pnl_Opciones.Children.Add(tool);
                    }
                }
                
            }

        }

        void tool_clickEvento(string metodo, Type tipo)
        {
            MethodInfo metodoEjec = tipo.GetMethod(metodo, BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
            metodoEjec.Invoke(ventanaActual, new object[] { });
        }
    }
}
