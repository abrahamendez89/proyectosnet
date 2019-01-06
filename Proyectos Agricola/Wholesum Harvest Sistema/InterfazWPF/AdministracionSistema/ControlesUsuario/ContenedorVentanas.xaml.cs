using Dominio.Sistema;
using InterfazWPF.AdministracionSistema;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Runtime.Remoting;
using System.Text;
using System.Threading;
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
using Dominio;
using Herramientas.ORM;

namespace InterfazWPF
{
    /// <summary>
    /// Lógica de interacción para ContenedorVentanas.xaml
    /// </summary>
    public partial class ContenedorVentanas : UserControl
    {

        public delegate void ClickVentana(Window window, String[] operacionesPermitidas);
        public event ClickVentana clickVentana;
        private List<Window> ventanas = new List<Window>();
        private List<Tab> tabs = new List<Tab>();
        private List<_sis_FormularioPermisosPorRol> formulariosPermisos = new List<_sis_FormularioPermisosPorRol>();
        public int CantidadVentanas { get { return tabs.Count; } }
        private Assembly assem = Assembly.GetExecutingAssembly();
        private ManejadorDB manejador;
        private System.Windows.Size tamPrincipal;

        public ContenedorVentanas()
        {
            this.InitializeComponent();
            Storyboard ocultar = (Storyboard)this.FindResource("Ocultar");
            ocultar.Begin();
            TransSalida = (Storyboard)this.FindResource("Ocultar");
            TransSalida.Completed += TransSalida_Completed;
            //try
            //{
            //    this.manejador = new ManejadorDB();
            //}
            //catch { }
        }
        private int ActualTab = -1;
        Storyboard TransSalida;
        Storyboard TransEntrada;
        public void AsignarManejador(ManejadorDB manejador)
        {
            this.manejador = manejador;
        }
        private void CambiarContenido()
        {
            TransSalida.Begin();
        }
        public void CerrarVentanas()
        {
            for (int i = 0; i < ventanas.Count; i++)
                ventanas[i].Close();
        }
        void TransSalida_Completed(object sender, EventArgs e)
        {
            if (ventanas.Count > 0)
            {
                LlenarContenedor(ventanas[ActualTab], ActualTab);
                TransEntrada = (Storyboard)this.FindResource("Mostrar");
                TransEntrada.Begin();
            }
            else
            {
                grid.Children.Clear();
            }


        }

        private Boolean ExisteReferencia(String referencia)
        {
            foreach (Window ventana in ventanas)
            {
                if (ventana.GetType().FullName.Equals(referencia))
                    return true;
            }
            return false;
        }
        public Boolean AgregarWindow(Window ventana, String nombreVentana, System.Windows.Size tamPrincipal)
        {
            if (ExisteReferencia(ventana.GetType().Name))
            {
                HerramientasWindow.MensajeInformacion("No es posible abrir el formulario, no permite duplicados.", "Verificar");
                return false;
            }
            Tab nuevo = new Tab();
            this.tamPrincipal = tamPrincipal;
            nuevo.Fill = rtn_contenedor_animado.Fill;
            nuevo.img_icono.ToolTip = ventana.GetType().Name;
            nuevo.txt_tituloTab.ToolTip = nombreVentana;

            nuevo.actualTab = tabs.Count;
            nuevo.img_icono.Source = HerramientasWindow.BitmapAImageSource(new Bitmap(@"Imagenes\Iconos\Sistema\documento.png"));
          

            nuevo.click += nuevo_click;
            nuevo.cerrado += nuevo_cerrado;
            nuevo.MouseEnter += nuevo_MouseEnter;
            nuevo.MouseLeave += nuevo_MouseLeave;

            Grid gridWindow = (Grid)ventana.Content;
            ventanas.Add(ventana);
            tabs.Add(nuevo);
            if (ventanas.Count != formulariosPermisos.Count)
                formulariosPermisos.Add(null);
            pnl_tabs.Children.Add(nuevo);
            ActualTab = -1;
            nuevo_click(nuevo.actualTab);
            return true;
        }
        public Boolean AgregarFormularioSinPermisos(_sis_Formulario formulario, System.Windows.Size tamPrincipal)
        {
            if (!formulario.BPermiteMultiples)// || formulario.SReferenciaFormulario.Equals("InterfazWPF.AdministracionSistema.ConfiguracionSistema"))
            {
                if (ExisteReferencia(formulario.SReferenciaFormulario))
                {
                    HerramientasWindow.MensajeInformacion("No es posible abrir el formulario, no permite duplicados.", "Verificar");
                    return false;
                }
            }
            Tab nuevo = new Tab();
            this.tamPrincipal = tamPrincipal;
            nuevo.Fill = rtn_contenedor_animado.Fill;
            nuevo.img_icono.ToolTip = formulario.SReferenciaFormulario;
            if (formulario.SDescripcion == null || formulario.SDescripcion.Trim().Equals(""))
                nuevo.txt_tituloTab.ToolTip = formulario.STituloFormulario;
            else
                nuevo.txt_tituloTab.ToolTip = formulario.SDescripcion;

            nuevo.actualTab = tabs.Count;
            if (formulario.ImagenAsociada != null && formulario.ImagenAsociada.Imagen != null)
                nuevo.img_icono.Source = HerramientasWindow.BitmapAImageSource(formulario.ImagenAsociada.Imagen);
            else
                nuevo.img_icono.Source = HerramientasWindow.BitmapAImageSource(new Bitmap(@"Imagenes\Iconos\Sistema\documento.png"));
            nuevo.txt_tituloTab.Text = formulario.STituloFormulario;

            nuevo.click += nuevo_click;
            nuevo.cerrado += nuevo_cerrado;
            nuevo.MouseEnter += nuevo_MouseEnter;
            nuevo.MouseLeave += nuevo_MouseLeave;
            ObjectHandle obj = null;
            Window window;
            try
            {
                
                //obj = AppDomain.CurrentDomain.CreateInstance(assem.FullName, formulario.SReferenciaFormulario);
                obj = Activator.CreateInstance(assem.FullName, formulario.SReferenciaFormulario);
                window = (Window)obj.Unwrap();

            }
            catch { HerramientasWindow.MensajeErrorSimple("La referencia registrada en la configuración del sistema para este formulario es incorrecta. Verificar", "Error al cargar el formulario"); return false; }

            Grid gridWindow = (Grid)window.Content;
            if(gridWindow == null)
                HerramientasWindow.MensajeErrorSimple("El 'Content' de la ventana es Null. Verificar", "Error al cargar el formulario");
            ventanas.Add(window);
            tabs.Add(nuevo);
            if (ventanas.Count != formulariosPermisos.Count)
                formulariosPermisos.Add(null);
            pnl_tabs.Children.Add(nuevo);
            ActualTab = -1;
            nuevo_click(nuevo.actualTab);
            return true;
        }
        public void AgregarFormularioConPermisos(_sis_FormularioPermisosPorRol formulario, System.Windows.Size tamPrincipal)
        {
            formulariosPermisos.Add(formulario);
            this.tamPrincipal = tamPrincipal;
            if (!AgregarFormularioSinPermisos(formulario.Formulario, tamPrincipal))
                formulariosPermisos.Remove(formulario);

        }

        void nuevo_MouseLeave(object sender, MouseEventArgs e)
        {
            Tab tab = (Tab)sender;
            if (tab.actualTab != ActualTab)
            {
                Storyboard mouseLeave = (Storyboard)tab.FindResource("Desvanecer");
                mouseLeave.Begin();
            }
        }

        void nuevo_MouseEnter(object sender, MouseEventArgs e)
        {
            Tab tab = (Tab)sender;
            if (tab.actualTab != ActualTab)
            {
                Storyboard mouseEnter = (Storyboard)tab.FindResource("Resaltar");
                mouseEnter.Begin();
            }
        }

        void nuevo_cerrado(int tabCerrado)
        {
            tabs.RemoveAt(tabCerrado);
            ventanas[tabCerrado].Close();
            ventanas.RemoveAt(tabCerrado);
            formulariosPermisos.RemoveAt(tabCerrado);
            pnl_tabs.Children.RemoveAt(tabCerrado);
            if (tabCerrado == tabAnterior)
            {
                contentControl.Content = null;
                tabAnterior = -1;
            }
            else if (tabAnterior > tabCerrado)
                tabAnterior--;

            if (tabCerrado > tabs.Count - 1)
                tabCerrado = tabs.Count - 1;

            if (tabCerrado == -1)
                tabCerrado = 0;

            if (tabs.Count == 0)
            {
                Storyboard ocultar = (Storyboard)this.FindResource("Ocultar");
                ocultar.Begin();
                clickVentana(null, null);
            }
            else
            {
                // re enumerando tabs
                for (int i = 0; i < tabs.Count; i++)
                    tabs[i].actualTab = i;
                if (tabAnterior == -1)
                {
                    nuevo_click(tabCerrado);
                }
                else
                    ActualizarEstados(tabAnterior);
            }


            //if (tabCerrado != tabAnterior)
            //{
            //    nuevo_click(tabAnterior);
            //}
            //else
            //{
            //    if (tabCerrado == tabAnterior)
            //        tabAnterior = -1;
            //    if (tabCerrado == 0 && tabs.Count >= 2)
            //    {
            //        nuevo_click(1);
            //    }
            //    if (tabs.Count - 1 > 0)
            //    {
            //        nuevo_click(0);
            //    }
            //    else
            //    {
            //        Storyboard ocultar = (Storyboard)this.FindResource("Ocultar");
            //        ocultar.Begin();
            //        clickVentana(null, null);
            //        return;
            //    }
            //}
            //tabs.RemoveAt(tabCerrado);
            //ventanas[tabCerrado].Close();
            //ventanas.RemoveAt(tabCerrado);
            //formulariosPermisos.RemoveAt(tabCerrado);
            //pnl_tabs.Children.RemoveAt(tabCerrado);
            //for (int i = 0; i < tabs.Count; i++)
            //    tabs[i].actualTab = i;
            
        }
        private void ActualizarEstados(int activo)
        {
            foreach (Tab tab in tabs)
                tab.Desactivar();
            if (activo > tabs.Count - 1)
                tabs[tabs.Count - 1].Activar();
            else
                tabs[activo].Activar();
            
        }

        void nuevo_click(int actualTab)
        {
            if (actualTab == ActualTab && actualTab < 0) return;
            if (actualTab == tabAnterior) return; //le dio click al tab actual el usuario

            ActualTab = actualTab;
            CambiarContenido();
            ActualizarEstados(ActualTab);
            String[] metodosPErmisos = "".Split('|');
            if (formulariosPermisos[actualTab] != null)
            {
                formulariosPermisos[actualTab] = manejador.Cargar<_sis_FormularioPermisosPorRol>(_sis_FormularioPermisosPorRol.ConsultaPorID, new List<object>() { formulariosPermisos[actualTab].Id });

                if (formulariosPermisos[actualTab].MetodosPermisos != null)
                {
                    if (formulariosPermisos[actualTab].MetodosPermisos != null)
                        metodosPErmisos = formulariosPermisos[actualTab].MetodosPermisos.Split('|');
                    else
                        metodosPErmisos = "".Split('|');
                }
            }
            else
                metodosPErmisos = null;

            clickVentana(ventanas[ActualTab], metodosPErmisos);
        }
        int tabAnterior = -1;
        public void Redimensionar(Window window)//, System.Windows.Size sizePantalla)
        {
            if (window == null) return;
            if (window.WindowState == WindowState.Maximized)
            {
                contentControl.Margin = new Thickness(20, 30, 20, 30);
            }
            else
            {
                //contentControl.Content = window.Content;
                #region calculando el centrado de los elementos en la pantalla
                //HerramientasWindow.PrincipalOnTOP(true);

                FrameworkElement pnlClient = window as FrameworkElement;
                double dWidth = 0;
                double dHeight = 0;
                if (pnlClient != null)
                {
                    dWidth = pnlClient.Width;
                    dHeight = pnlClient.Height;
                }

                //window.Show();
                //window.Hide();
                //HerramientasWindow.PrincipalOnTOP(false);
                double windowHeight = dHeight;
                double windowWidth = dWidth;
                

                //this.tamPrincipal = sizePantalla;
                double heightPrincipal = HerramientasWindow.ObtenerSizePrincipal().Height;
                double widhtPrincipal = HerramientasWindow.ObtenerSizePrincipal().Width;//sizePantalla.Width;

                double diferenciaHeight = heightPrincipal - (windowHeight + 100);
                double diferenciaWidht = widhtPrincipal - (windowWidth+60);
                double mitadDiferenciaHeight = diferenciaHeight / 2;
                double mitadDiferenciaWidht = diferenciaWidht / 2;
                if (mitadDiferenciaHeight < 0) mitadDiferenciaHeight = 0;
                if (mitadDiferenciaWidht < 0) mitadDiferenciaWidht = 0;
                contentControl.Margin = new Thickness(mitadDiferenciaWidht, mitadDiferenciaHeight, mitadDiferenciaWidht, mitadDiferenciaHeight);
                //contentControl.Foreground = System.Windows.Media.Brushes.White;
                #endregion
            }
            //gridTemp.VerticalAlignment = System.Windows.VerticalAlignment.Center;
            contentControl.UpdateLayout();
        }
        private void LlenarContenedor(Window window, int actualTab)
        {
            try
            {

                //if (actualTab == tabAnterior) return;
                //aqui intentar hacer la separacion de los controles de las ventanas
                Grid gridTemp = (Grid)window.Content;
                
                window.Content = null;

                if (tabAnterior >= 0 && tabAnterior < ventanas.Count)
                {
                    Grid ContenidoActual = (Grid)contentControl.Content;
                    contentControl.Content = null;
                    try
                    {
                        ventanas[tabAnterior].Content = ContenidoActual;
                    }
                    catch(Exception ex)
                    {
                        HerramientasWindow.MensajeError(ex,"Ocurrió un error al intentar cambiar el contenido de la ventana con la ventana anterior. [" + ex.Message + "]", "Error creando ventana");
                        return;
                    }
                }
                contentControl.Content = gridTemp;
                contentControl.IsVisibleChanged += contentControl_IsVisibleChanged;
                
                tabAnterior = actualTab;
                //----------------------------------
                double a = contentControl.ActualHeight;
                Redimensionar(window);//,this.tamPrincipal);

                //if (window.WindowState == WindowState.Maximized)
                //{
                //    contentControl.Margin = new Thickness(20, 30, 20, 30);
                //}
                //else
                //{
                //    //contentControl.Content = window.Content;
                //    #region calculando el centrado de los elementos en la pantalla
                //    double windowHeight = window.Height;
                //    double windowWidth = window.Width;
                //    double diferenciaHeight = System.Windows.SystemParameters.WorkArea.Height - windowHeight - 110;
                //    double diferenciaWidht = System.Windows.SystemParameters.WorkArea.Width - windowWidth - 50;
                //    double mitadDiferenciaHeight = diferenciaHeight / 2;
                //    double mitadDiferenciaWidht = diferenciaWidht / 2;
                //    if (mitadDiferenciaHeight < 0) mitadDiferenciaHeight = 0;
                //    if (mitadDiferenciaWidht < 0) mitadDiferenciaWidht = 0;
                //    contentControl.Margin = new Thickness(mitadDiferenciaWidht, mitadDiferenciaHeight, mitadDiferenciaWidht, mitadDiferenciaHeight);
                //    //contentControl.Foreground = System.Windows.Media.Brushes.White;
                //    #endregion
                //}
                ////gridTemp.VerticalAlignment = System.Windows.VerticalAlignment.Center;
                //contentControl.UpdateLayout();
            }
            catch (ArgumentException ae)
            {
                contentControl.Margin = new Thickness(20, 10, 20, 30);
                HerramientasWindow.MensajeError(ae,"Ocurrió un error al cargar el contenido de la ventana. [" + ae.Message + "]", "Error creando ventana");
            
            }
            catch (Exception ex)
            {
                HerramientasWindow.MensajeError(ex,"Ocurrió un error al cargar el contenido de la ventana. [" + ex.Message + "]", "Error creando ventana");
            }
        }

        void contentControl_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            //Redimensionar((Window)sender);
        }

        void ContenedorVentanas_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            //Redimensionar((Window)sender);
        }

    }
}