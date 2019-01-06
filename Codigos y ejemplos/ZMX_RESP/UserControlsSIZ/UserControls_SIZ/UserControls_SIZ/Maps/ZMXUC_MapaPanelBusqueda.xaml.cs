using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
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
using UserControlsSIZ.Utilerias;

namespace UserControlsSIZ.Maps
{
    /// <summary>
    /// Interaction logic for ZMXUC_MapaPanelBusqueda.xaml
    /// </summary>
    public partial class ZMXUC_MapaPanelBusqueda : UserControl
    {
        public String ZMX_PropiedadLocalidadNombre { get; set; }
        public String ZMX_PropiedadMunicipioNombre { get; set; }
        public String ZMX_PropiedadEstadoNombre { get; set; }
        public String ZMX_PropiedadPaisNombre { get; set; }
        public String ZMX_PropiedadCoordenadas { get; set; }

        public Brush ZMX_Color { get { return grdPanelColor.Background; } set { grdPanelColor.Background = value; } }

        public String Distancia { set { txtDistancia.Text = value; } }
        public String Tiempo { set { txtTiempo.Text = value; } }

        public delegate List<object> _ZMX_BuscarLocalidades(ZMXUC_MapaPanelBusqueda panel, String criterioBusqueda);
        public event _ZMX_BuscarLocalidades ZMX_BuscarLocalidades;

        public delegate List<object> _ZMX_BuscarLocalidadesPorMunicipio(ZMXUC_MapaPanelBusqueda panel, String criterioBusqueda);
        public event _ZMX_BuscarLocalidadesPorMunicipio ZMX_BuscarLocalidadesPorMunicipio;

        public delegate void _ZMX_SeleccionoLocalidad(object localidad, Boolean esOrigen, ZMXUC_MapaElementoBusqueda meb);
        public event _ZMX_SeleccionoLocalidad ZMX_SeleccionoLocalidad;

        public void SetColor(Brush color)
        {
            grdPanelColor.Background = color;
            this.btnCambio.BtnBrush = color;

        }

        public Boolean ZMX_MostrarPanelInformacion
        {
            set
            {
                if (value)
                    panelInformacion.Visibility = Visibility.Visible;
                else
                    panelInformacion.Visibility = Visibility.Collapsed;
            }
        }

        public ZMXUC_MapaPanelBusqueda()
        {
            InitializeComponent();
            txtBusquedaOrigen.KeyDown += txt_KeyDown;
            txtBusquedaDestino.KeyDown += txt_KeyDown;
            txtBusquedaOrigen.GotFocus += txt_GotFocus;
            txtBusquedaDestino.GotFocus += txt_GotFocus;



            ConfiguracionInicialCaptura();
        }


        private void txt_GotFocus(object sender, RoutedEventArgs e)
        {
            ultimoTextBox = (TextBox)sender;
        }
        public void ZMX_Limpiar()
        {
            txtBusquedaDestino.Text = "";
            txtBusquedaOrigen.Text = "";
            txtDistancia.Text = "";
            txtTiempo.Text = "";
        }
        private void txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if(ultimoTextBox.Text.Trim().Equals(""))
                {
                    UtileriasControles.MuestraToolTipSobreControl(Window.GetWindow(this), ultimoTextBox, "Es necesario escribir un criterio para la busqueda.", UtileriasControles.Posicion.Derecha);
                    return;
                }
                if ((Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl)))
                {
                    ultimoTextBox = (TextBox)sender;
                    //aqui lanzar la busqueda
                    if (ZMX_BuscarLocalidadesPorMunicipio != null)
                    {
                        List<Object> lista = ZMX_BuscarLocalidadesPorMunicipio(this, ultimoTextBox.Text);
                        DibujarLocalidades(lista);
                    }
                }
                else
                {
                    ultimoTextBox = (TextBox)sender;
                    //aqui lanzar la busqueda
                    if (ZMX_BuscarLocalidades != null)
                    {
                        List<Object> lista = ZMX_BuscarLocalidades(this, ultimoTextBox.Text);
                        DibujarLocalidades(lista);
                    }
                }
            }
            else if (e.Key == Key.Escape)
            {
                LimpiarPanel();
                resultadosBusqueda.ZMX_Limpiar();
            }
        }


        public void AjustarPanelBusqueda()
        {
            grdGeneral.RowDefinitions[1].Height = new GridLength(1, GridUnitType.Star);
        }
        public void AutomaticoPanelBusqueda()
        {
            grdGeneral.RowDefinitions[1].Height = new GridLength(1, GridUnitType.Auto);
        }
        public void LimpiarPanel()
        {
            resultadosBusqueda.ZMX_Limpiar();
            AutomaticoPanelBusqueda();
        }
        private void DibujarLocalidades(List<Object> lista)
        {
            LimpiarPanel();
            resultadosBusqueda.ZMX_Limpiar();
            if (lista != null)
            {
                foreach (Object obj in lista)
                {

                    ZMXUC_MapaElementoBusqueda meb = new ZMXUC_MapaElementoBusqueda();
                    meb.SetColor(this.ZMX_Color);
                    meb.ZMX_Click += Meb_ZMX_Click;
                    //por reflection sacamos sus propiedades para construir el control
                    PropertyInfo piLocalidadNombre = obj.GetType().GetProperty(ZMX_PropiedadLocalidadNombre, BindingFlags.Public | BindingFlags.Instance);
                    meb.ZMX_LocalidadNombre = piLocalidadNombre.GetValue(obj).ToString();
                    PropertyInfo piMunicipioNombre = obj.GetType().GetProperty(ZMX_PropiedadMunicipioNombre, BindingFlags.Public | BindingFlags.Instance);
                    meb.ZMX_MunicipioNombre = piMunicipioNombre.GetValue(obj).ToString();
                    PropertyInfo piEstadoNombre = obj.GetType().GetProperty(ZMX_PropiedadEstadoNombre, BindingFlags.Public | BindingFlags.Instance);
                    meb.ZMX_EstadoNombre = piEstadoNombre.GetValue(obj).ToString();
                    PropertyInfo piPaisNombre = obj.GetType().GetProperty(ZMX_PropiedadPaisNombre, BindingFlags.Public | BindingFlags.Instance);
                    meb.ZMX_PaisNombre = piPaisNombre.GetValue(obj).ToString();
                    //se guarda la entidad en el control
                    meb.ZMX_LocalidadObject = obj;
                    meb.ZMX_ActualizarSubtitulo();
                    //se agrega al control
                    resultadosBusqueda.ZMX_AgregarElementoBusqueda(meb);
                    AjustarPanelBusqueda();

                }
            }
        }

        public void ZMX_SetGrdCaptura(Grid grd)
        {
            scroll.Content = grd;
        }

        TextBox ultimoTextBox;

        public void ZMX_SetLocalidadOrigen(String localidadNombre)
        {
            txtBusquedaOrigen.Text = localidadNombre;
        }
        public void ZMX_SetLocalidadDestino(String localidadNombre)
        {
            txtBusquedaDestino.Text = localidadNombre;
        }

        private void Meb_ZMX_Click(ZMXUC_MapaElementoBusqueda meb)
        {
            if (ultimoTextBox != null)
            {
                ultimoTextBox.Text = meb.ZMX_LocalidadNombre;
                if (ZMX_SeleccionoLocalidad != null)
                {

                    PropertyInfo piCoordenadas = meb.ZMX_LocalidadObject.GetType().GetProperty(ZMX_PropiedadCoordenadas, BindingFlags.Public | BindingFlags.Instance);

                    String coordenadas = piCoordenadas.GetValue(meb.ZMX_LocalidadObject).ToString();

                    if (coordenadas == null || coordenadas.Equals(", "))
                    {
                        meb.ZMX_MostrarMensaje("Ubicación no disponible.");
                        return;
                    }

                    if (ultimoTextBox == txtBusquedaOrigen)
                        ZMX_SeleccionoLocalidad(meb.ZMX_LocalidadObject, true, meb);
                    else
                        ZMX_SeleccionoLocalidad(meb.ZMX_LocalidadObject, false, meb);

                    LimpiarPanel();
                }
            }
        }
        Boolean variableControl = false;
        private void ConfiguracionInicialCaptura()
        {
            grdCaptura.Visibility = Visibility.Visible;
            grdDatos.Visibility = Visibility.Collapsed;
            btnCambio.Icono = Iconos.IconAwesomeSIZ.AwesomeIcons.fa_chevron_left;
            this.Opacity = 0.95;
        }
        private void btnCambio_toolbarBtnClick(Toolbar.ToolbarBtn boton)
        {
            if (!variableControl)
            {
                this.Opacity = 0.70;
                grdCaptura.Visibility = Visibility.Collapsed;
                grdDatos.Visibility = Visibility.Visible;
                variableControl = !variableControl;
                btnCambio.Icono = Iconos.IconAwesomeSIZ.AwesomeIcons.fa_chevron_right;
            }
            else
            {
                this.Opacity = 0.80;
                grdCaptura.Visibility = Visibility.Visible;
                grdDatos.Visibility = Visibility.Collapsed;
                variableControl = !variableControl;
                btnCambio.Icono = Iconos.IconAwesomeSIZ.AwesomeIcons.fa_chevron_left;
            }
        }
    }
}
