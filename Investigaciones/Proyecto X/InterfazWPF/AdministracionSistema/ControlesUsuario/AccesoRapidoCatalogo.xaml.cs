using Dominio;
using InterfazWPF.Modulos.Catalogos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting;
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
using Herramientas.ORM;

namespace InterfazWPF.AdministracionSistema.ControlesUsuario
{
    /// <summary>
    /// Lógica de interacción para AccesoRapidoCatalogo.xaml
    /// </summary>
    public partial class AccesoRapidoCatalogo : UserControl
    {
        ManejadorDB manejador;
        private Assembly assem = Assembly.GetExecutingAssembly();
        public delegate void SeCerroCatalogo();
        public event SeCerroCatalogo seCerroCatalogo;
        Storyboard SobreBoton;
        Storyboard SalirBoton;

        Type tipoObjetoCatalogo;
        //Boolean AceptaMultipleSeleccion;
        //Boolean AceptaBusquedaDeshabilitados;
        String campoBusquedaDefault;
        //Type tipoObjetoBusqueda;

        Boolean seConfiguroBuscador;
        Boolean seConfiguroCampos;
        String campoEtiqueta;


        String rutaCatalogo;
        Boolean estaAutorizado;

        Boolean aceptaMultipleSeleccion;
        Boolean aceptaBusquedaDeshabilitados;
        List<String> camposConAlias = new List<string>();

       // BuscadorCatalogoVentana buscadorCatalogoPopup;// = new BuscadorCatalogoVentana();

        //private static int IndiceSuperior = 99;


        public delegate ObjetoBase AsignarObjetoCatalogo();
        public event AsignarObjetoCatalogo asignarObjetoCatalogo;


        public AccesoRapidoCatalogo()
        {
            this.InitializeComponent();
            try
            {
                inicializarEventos();
            }
            catch
            {

            }
        }
        public void AsignarCatalogoParaAltas(String rutaCatalogo)
        {
            this.rutaCatalogo = rutaCatalogo;

            //buscadorCatalogoPopup.AsignarCatalogoParaAltas(rutaCatalogo);
        }
        public void Configurar(ManejadorDB manejador, String rutaCatalogo)
        {
            this.manejador = manejador;
            this.rutaCatalogo = rutaCatalogo;
            //buscadorCatalogoPopup.AsignarManejadorDB(manejador);
        }

        //public void ConfigurarBusqueda(Type tipoObjetoCatalogo, String campoBusquedaDefault, String campoEtiqueta, Boolean aceptaMultipleSeleccion, Boolean aceptaBusquedaDeshabilitados)
        //{
        //    this.tipoObjetoCatalogo = tipoObjetoCatalogo;
        //    this.campoBusquedaDefault = campoBusquedaDefault;
        //    this.campoEtiqueta = campoEtiqueta;
        //    this.aceptaBusquedaDeshabilitados = aceptaBusquedaDeshabilitados;
        //    this.aceptaMultipleSeleccion = aceptaMultipleSeleccion;
        //    //buscadorCatalogoPopup.ConfigurarBusqueda(tipoObjetoCatalogo, campoBusquedaDefault, campoEtiqueta, aceptaMultipleSeleccion, aceptaBusquedaDeshabilitados);
        //}
        
        //public void AgregarCampoAMostrarConAlias(String nombreCampoConAlias)
        //{
        //    camposConAlias.Add(nombreCampoConAlias);
        //    //buscadorCatalogoPopup.AgregarCampoAMostrarConAlias(nombreCampoConAlias);
        //}
        void img_busqueda_MouseLeave(object sender, MouseEventArgs e)
        {
            //if (buscadorCatalogoPopup.Visibility != System.Windows.Visibility.Visible)
            SalirBoton.Begin();
        }

        void img_busqueda_MouseEnter(object sender, MouseEventArgs e)
        {
            //if (buscadorCatalogoPopup.Visibility != System.Windows.Visibility.Visible)
            SobreBoton.Begin();
        }
        private void inicializarEventos()
        {
            img_busqueda.MouseDown += img_busqueda_MouseDown;
            img_busqueda.MouseEnter += img_busqueda_MouseEnter;
            img_busqueda.MouseLeave += img_busqueda_MouseLeave;

            SobreBoton = (Storyboard)this.FindResource("SobreBoton");
            SalirBoton = (Storyboard)this.FindResource("SalirBoton");
        }

        void img_busqueda_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (!HerramientasWindow.UsuarioLogueadoTienePermisosEdicionCatalogo())
            {
                HerramientasWindow.MensajeAdvertencia("El usuario actual no tiene permisos para modificar catálogos, verificar con el administrador.", "Permiso necesario");
                return;
            }
            if (manejador == null)
            {
                HerramientasWindow.MensajeError(new Exception("El ManejadorDB no fue inicializado."),"El buscador requiere de configuración, Verificar código.", "Error");
                return;
            }
            if (rutaCatalogo == null || rutaCatalogo.Equals(""))
            {
                HerramientasWindow.MensajeError(new Exception("No se especificó una ruta de catálogo."), "El buscador requiere de configuración, Verificar código.", "Error");
                return;
            }
            if (asignarObjetoCatalogo == null)
            {
                HerramientasWindow.MensajeError(new Exception("El evento asignarObjetoCatalogo no se implementó."), "El buscador requiere de configuración, Verificar código.", "Error");
                return;
            }
            MostrarPopup();
            
        }
        List<ObjetoBase> lista;
        String busquedaAnterior = "";
        ObjetoBase objeto;
        private void MostrarPopup()
        {
            ObjectHandle obj = null;
            Window window;
            try
            {
                obj = Activator.CreateInstance(assem.FullName, this.rutaCatalogo);
                window = (Window)obj.Unwrap();

            }
            catch 
            { 
                HerramientasWindow.MensajeError(new Exception("La referencia configurada en el catálogo rápido es incorrecta."),"La referencia registrada en la configuración del sistema para este formulario es incorrecta. Verificar", "Error al cargar el formulario"); 
                return; 
            }
            this.objeto = asignarObjetoCatalogo();
            if (this.objeto != null)
            {
                try
                {
                    iCatalogo cat = (iCatalogo)window;
                    cat.AsignarObjetoDominio(this.objeto);
                    HerramientasWindow.MostrarVentanaEmergenteConTools(window, false);
                }
                catch (Exception ex)
                {
                    HerramientasWindow.MensajeError(ex, "La referencia registrada en la configuración del sistema para este formulario es incorrecta. Verificar", "Error al cargar el formulario");
                    return; 
                }
            }
            
            if (seCerroCatalogo != null)
                seCerroCatalogo();
        }


        private void OcultarPopup()
        {

        }
    }
}
