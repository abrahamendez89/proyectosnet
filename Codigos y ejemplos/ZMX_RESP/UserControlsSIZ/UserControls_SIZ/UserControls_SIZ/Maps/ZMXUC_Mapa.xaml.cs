using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using loctTarifaFlete.Models;
using Microsoft.Maps.MapControl.WPF;
using Newtonsoft.Json;
using UserControlsSIZ.Maps.MenuSeleccion;
using UserControlsSIZ.Maps.Model;
using UserControlsSIZ.Utilerias;

namespace UserControlsSIZ.Maps
{
    /// <summary>
    /// Interaction logic for ZMXUC_Mapa.xaml
    /// </summary>
    public partial class ZMXUC_Mapa : UserControl
    {

        public String ZMX_PropiedadLocalidadNombre { get { return panelBusqueda.ZMX_PropiedadLocalidadNombre; } set { panelBusqueda.ZMX_PropiedadLocalidadNombre = value; } }
        public String ZMX_PropiedadMunicipioNombre { get { return panelBusqueda.ZMX_PropiedadMunicipioNombre; } set { panelBusqueda.ZMX_PropiedadMunicipioNombre = value; } }
        public String ZMX_PropiedadEstadoNombre { get { return panelBusqueda.ZMX_PropiedadEstadoNombre; } set { panelBusqueda.ZMX_PropiedadEstadoNombre = value; } }
        public String ZMX_PropiedadPaisNombre { get { return panelBusqueda.ZMX_PropiedadPaisNombre; } set { panelBusqueda.ZMX_PropiedadPaisNombre = value; } }


        public Boolean ZMX_PermiteMarcarPuntosEnMapa { get; set; }

        public String ZMX_PropiedadCoordenadas { get { return panelBusqueda.ZMX_PropiedadCoordenadas; } set { panelBusqueda.ZMX_PropiedadCoordenadas = value; } }

        public delegate List<object> _ZMX_BuscarLocalidades(ZMXUC_Mapa mapa, String criterioBusqueda);
        public event _ZMX_BuscarLocalidades ZMX_BuscarLocalidades;

        public delegate List<object> _ZMX_BuscarLocalidadesPorMunicipio(ZMXUC_Mapa mapa, String criterioBusqueda);
        public event _ZMX_BuscarLocalidadesPorMunicipio ZMX_BuscarLocalidadesPorMunicipio;

        public delegate void _ZMX_SeleccionoUbicacion(ZMXUC_Mapa mapa, String locacion);
        public event _ZMX_SeleccionoUbicacion ZMX_SeleccionoUbicacion;

        public delegate void _ZMX_SeCalcularonDatos(ZMXUC_Mapa mapa, BingApi calculos);
        public event _ZMX_SeCalcularonDatos ZMX_SeCalcularonDatos;

        public delegate void _ZMX_CambioUbicacionOrigen(ZMXUC_Mapa mapa, String locacion, object localidadOrigen);
        public event _ZMX_CambioUbicacionOrigen ZMX_CambioUbicacionOrigen;

        public delegate void _ZMX_CambioUbicacionDestino(ZMXUC_Mapa mapa, String locacion, object localidadDestino);
        public event _ZMX_CambioUbicacionDestino ZMX_CambioUbicacionDestino;

        public delegate List<object> _ZMX_BuscarLocalidadesPorAproximacion(ZMXUC_Mapa mapa, double Latitud, double Longitud);
        public event _ZMX_BuscarLocalidadesPorAproximacion ZMX_BuscarLocalidadesPorAproximacion;

        public delegate List<object> _ZMX_LocalidadesCercanasAlPin(ZMXUC_Mapa mapa, List<String> coordenadasCercanas, double Latitud, double Longitud);
        public event _ZMX_LocalidadesCercanasAlPin ZMX_LocalidadesCercanasAlPin;

        private Brush color;


        public void ZMX_SetGrdCaptura(Grid gridCaptura)
        {
            gridCaptura.Opacity = 0.80;
            panelBusqueda.ZMX_SetGrdCaptura(gridCaptura);
        }

        public void SetColor(Brush color)
        {
            this.color = color;

            panelBusqueda.SetColor(color);
        }
        public String ZMX_CentroMapa
        {
            set
            {
                map.Center = ConvertCoordenadasStringToLocation(value);
            }
        }
        public double ZMX_NivelZoom
        {
            set
            {
                map.ZoomLevel = value;
            }
        }


        public Boolean ZMX_MostrarPanelInformacion
        {
            set
            {
                panelBusqueda.ZMX_MostrarPanelInformacion = value;
            }
        }
        private object zmx_LocalidadOrigen;
        private object zmx_LocalidadDestino;
        public object ZMX_LocalidadOrigen
        {
            get { return zmx_LocalidadOrigen; }
            set
            {
                zmx_LocalidadOrigen = value;
                if (value == null)
                {
                    pin_layer.Children.Remove(pinOrigen);
                    route_layer.Children.Clear();
                    pinOrigen = null;
                }
                else
                {
                    PropertyInfo pNombreOrigen = zmx_LocalidadOrigen.GetType().GetProperty(ZMX_PropiedadLocalidadNombre, BindingFlags.Instance | BindingFlags.Public);
                    String NombreOrigen = pNombreOrigen.GetValue(zmx_LocalidadOrigen).ToString();
                    panelBusqueda.ZMX_SetLocalidadOrigen(NombreOrigen);
                }

                if (ZMX_LocalidadOrigen != null && ZMX_LocalidadDestino != null)
                {
                    ZMX_TrazarRuta();
                }
            }
        }
        public object ZMX_LocalidadDestino
        {
            get { return zmx_LocalidadDestino; }
            set
            {
                zmx_LocalidadDestino = value;
                if (value == null)
                {
                    pin_layer.Children.Remove(pinDestino);
                    route_layer.Children.Clear();
                    pinDestino = null;
                }
                else
                {
                    PropertyInfo pNombreDestino = zmx_LocalidadDestino.GetType().GetProperty(ZMX_PropiedadLocalidadNombre, BindingFlags.Instance | BindingFlags.Public);
                    String NombreDestino = pNombreDestino.GetValue(zmx_LocalidadDestino).ToString();
                    panelBusqueda.ZMX_SetLocalidadDestino(NombreDestino);
                }

                if (ZMX_LocalidadOrigen != null && ZMX_LocalidadDestino != null)
                {
                    ZMX_TrazarRuta();
                }
            }
        }

        private void ZMX_ActualizarTextosBusquedas()
        {
            if (ZMX_LocalidadOrigen == null)
            {
                panelBusqueda.ZMX_SetLocalidadOrigen("");
            }
            if (ZMX_LocalidadDestino == null)
            {
                panelBusqueda.ZMX_SetLocalidadDestino("");
            }
        }
        
        public void ZMX_TrazarRuta()
        {
            PropertyInfo pCoordenadaOrigen = ZMX_LocalidadOrigen.GetType().GetProperty(ZMX_PropiedadCoordenadas, BindingFlags.Instance | BindingFlags.Public);
            PropertyInfo pCoordenadaDestino = ZMX_LocalidadDestino.GetType().GetProperty(ZMX_PropiedadCoordenadas, BindingFlags.Instance | BindingFlags.Public);

            String coordenadasOrigen = pCoordenadaOrigen.GetValue(ZMX_LocalidadOrigen).ToString();
            String coordenadasDestino = pCoordenadaOrigen.GetValue(ZMX_LocalidadDestino).ToString();

            //obteniendo los nombres
            PropertyInfo pNombreOrigen = ZMX_LocalidadOrigen.GetType().GetProperty(ZMX_PropiedadLocalidadNombre, BindingFlags.Instance | BindingFlags.Public);
            PropertyInfo pNombreDestino = ZMX_LocalidadDestino.GetType().GetProperty(ZMX_PropiedadLocalidadNombre, BindingFlags.Instance | BindingFlags.Public);

            String NombreOrigen = pNombreOrigen.GetValue(ZMX_LocalidadOrigen).ToString();
            String NombreDestino = pNombreDestino.GetValue(ZMX_LocalidadDestino).ToString();

            Location locationOrigen = ConvertCoordenadasStringToLocation(coordenadasOrigen);
            Location locationDestino = ConvertCoordenadasStringToLocation(coordenadasDestino);


            //se agregan los pines para cada location ORIGEN
            if (pinOrigen == null)
            {
                pin_layer.Children.Remove(pinOrigen);
                pinOrigen = new ZMXUC_MapaPin();
                pinOrigen.ZMX_Icono = Iconos.IconAwesomeSIZ.AwesomeIcons.fa_circle_o;
                pinOrigen.ZMX_Color = panelBusqueda.ZMX_Color;
                pinOrigen.ZMX_Location = locationOrigen;
                pinOrigen.ZMX_Height = tamOrigen;
                pin_layer.AddChild(pinOrigen, pinOrigen.ZMX_Location);
            }
            //DESTINO
            if (pinDestino == null)
            {
                pin_layer.Children.Remove(pinDestino);
                pinDestino = new ZMXUC_MapaPin();
                pinDestino.ZMX_Icono = Iconos.IconAwesomeSIZ.AwesomeIcons.fa_map_marker;
                pinDestino.ZMX_Color = panelBusqueda.ZMX_Color;
                pinDestino.ZMX_Location = locationDestino;
                pin_layer.AddChild(pinDestino, pinDestino.ZMX_Location);
            }
            //se actualizan los buscadores
            panelBusqueda.ZMX_SetLocalidadOrigen(NombreOrigen);
            panelBusqueda.ZMX_SetLocalidadDestino(NombreDestino);

            if (pinOrigen != null && pinDestino != null)
            {
                route_layer.Children.Clear();
                CalcularRuta(pinOrigen.ZMX_Location, pinDestino.ZMX_Location);
                //map.Center = new Location(pinOrigen.ZMX_Location.Latitude, pinOrigen.ZMX_Location.Longitude);
                //map.ZoomLevel = 12;
            }
        }
        public void ZMX_TrazarRutaPorPin()
        {

            if (pinOrigen != null && pinDestino != null)
            {
                route_layer.Children.Clear();
                CalcularRuta(pinOrigen.ZMX_Location, pinDestino.ZMX_Location);

                PropertyInfo piOrigen = ZMX_LocalidadOrigen.GetType().GetProperty(ZMX_PropiedadLocalidadNombre, BindingFlags.Instance | BindingFlags.Public);
                PropertyInfo piDestino = ZMX_LocalidadDestino.GetType().GetProperty(ZMX_PropiedadLocalidadNombre, BindingFlags.Instance | BindingFlags.Public);

                panelBusqueda.ZMX_SetLocalidadOrigen(piOrigen.GetValue(ZMX_LocalidadOrigen).ToString());
                panelBusqueda.ZMX_SetLocalidadDestino(piDestino.GetValue(ZMX_LocalidadDestino).ToString());

                //map.Center = new Location(pinOrigen.ZMX_Location.Latitude, pinOrigen.ZMX_Location.Longitude);
                //map.ZoomLevel = 12;
            }
        }
        public enum TipoMapa
        {
            BusquedaRuta = 0,
            BusquedaCoordenada = 1
        }

        public TipoMapa ZMX_TipoControlMapa
        {
            set
            {
                if (value == TipoMapa.BusquedaRuta)
                {
                    panel.Visibility = Visibility.Collapsed;
                    panelBusqueda.Visibility = Visibility.Visible;
                }
                else if (value == TipoMapa.BusquedaCoordenada)
                {
                    panel.Visibility = Visibility.Visible;
                    panelBusqueda.Visibility = Visibility.Collapsed;

                }
            }
        }

        private Location ConvertCoordenadasStringToLocation(String coordenadas)
        {
            Location loc = new Location(Convert.ToDouble(coordenadas.Split(',')[0]), Convert.ToDouble(coordenadas.Split(',')[1]));
            return loc;
        }

        private String ConvertCoordenadasLocationToString(Location coordenadas)
        {
            return coordenadas.Latitude + ", " + coordenadas.Longitude;
        }

        public ZMXUC_Mapa()
        {
            InitializeComponent();

            map.MouseDoubleClick += Map_MouseDoubleClick;

            this.Loaded += ZMXUC_Mapa_Loaded;

            map.Center = new Location(23.7221837670829, -102.356085279439);
            map.ZoomLevel = 5;


            panelBusqueda.ZMX_BuscarLocalidades += PanelBusqueda_ZMX_BuscarLocalidades;
            panelBusqueda.ZMX_BuscarLocalidadesPorMunicipio += PanelBusqueda_ZMX_BuscarLocalidadesPorMunicipio;
            panelBusqueda.ZMX_SeleccionoLocalidad += PanelBusqueda_ZMX_SeleccionoLocalidad;

            route_layer = new MapLayer();
            map.Children.Add(route_layer);

            pin_layer = new MapLayer();
            map.Children.Add(pin_layer);

            circles_layer = new MapLayer();
            map.Children.Add(circles_layer);

        }

        private List<object> PanelBusqueda_ZMX_BuscarLocalidadesPorMunicipio(ZMXUC_MapaPanelBusqueda panel, string criterioBusqueda)
        {
            if (ZMX_BuscarLocalidadesPorMunicipio != null)
            {
                List<object> localidadesObjects = ZMX_BuscarLocalidadesPorMunicipio(this, criterioBusqueda);


                if (localidadesObjects.Count > 0)
                {
                    String nombreMunicipio = "";
                    Dictionary<String, String> localidadesEncontradas = new Dictionary<string, string>();
                    double sumaLatitudes = 0;
                    double sumaLongitudes = 0;
                    //dibujamos las localidades del municipio
                    foreach (object obj in localidadesObjects)
                    {
                        PropertyInfo piCoordenadas = obj.GetType().GetProperty(ZMX_PropiedadCoordenadas, BindingFlags.Instance | BindingFlags.Public);
                        String coordenadas = piCoordenadas.GetValue(obj).ToString();

                        PropertyInfo piMunNombre = obj.GetType().GetProperty(ZMX_PropiedadMunicipioNombre, BindingFlags.Instance | BindingFlags.Public);
                        nombreMunicipio = piMunNombre.GetValue(obj).ToString();

                        PropertyInfo piLocNombre = obj.GetType().GetProperty(ZMX_PropiedadLocalidadNombre, BindingFlags.Instance | BindingFlags.Public);
                        String locNombre = piLocNombre.GetValue(obj).ToString();

                        localidadesEncontradas.Add(coordenadas, locNombre);

                        sumaLatitudes += ConvertCoordenadasStringToLocation(coordenadas).Latitude;
                        sumaLongitudes += ConvertCoordenadasStringToLocation(coordenadas).Longitude;

                    }

                    double latitudCentro = sumaLatitudes / localidadesObjects.Count;
                    double longitudCentro = sumaLongitudes / localidadesObjects.Count;


                    map.Center = new Location(latitudCentro, longitudCentro);
                    map.ZoomLevel = 13;

                    ZMX_DibujarLocalidadCirculoDiccionario(localidadesEncontradas);

                    circles_layer.AddChild(new TextBlock() { Text = " " + nombreMunicipio + " ", Foreground = Brushes.White, Background = color, FontSize = 16 }, map.Center);

                }

                return localidadesObjects;
            }
            return new List<object>();
        }

        private void ZMXUC_Mapa_Loaded(object sender, RoutedEventArgs e)
        {
            if (ZMX_PropiedadLocalidadNombre == null)
                throw new Exception("Falta definir 'ZMX_PropiedadLocalidadNombre'.");
            if (ZMX_PropiedadMunicipioNombre == null)
                throw new Exception("Falta definir 'ZMX_PropiedadMunicipioNombre'.");
            if (ZMX_PropiedadEstadoNombre == null)
                throw new Exception("Falta definir 'ZMX_PropiedadEstadoNombre'.");
            if (ZMX_PropiedadPaisNombre == null)
                throw new Exception("Falta definir 'ZMX_PropiedadPaisNombre'.");

            if (ZMX_PropiedadCoordenadas == null)
                throw new Exception("Falta definir 'ZMX_PropiedadCoordenadas'.");
        }

        Boolean panel_esPorBusquedaPanel;
        Boolean panel_seBuscaOrigen;

        private void PanelBusqueda_ZMX_SeleccionoLocalidad(object localidad, Boolean esOrigen, ZMXUC_MapaElementoBusqueda meb)
        {
            PropertyInfo piCoordenadas = localidad.GetType().GetProperty(ZMX_PropiedadCoordenadas, BindingFlags.Public | BindingFlags.Instance);
            String coordenadas = piCoordenadas.GetValue(localidad).ToString();

            PropertyInfo piNombre = localidad.GetType().GetProperty(ZMX_PropiedadLocalidadNombre, BindingFlags.Public | BindingFlags.Instance);
            String nombreLocalidad = piNombre.GetValue(localidad).ToString();

            Location loc = new Location();
            try
            {
                loc = ConvertCoordenadasStringToLocation(coordenadas);
            }
            catch (Exception ex)
            {

            }

            if (esOrigen)
            {
                panel_seBuscaOrigen = true;
                ZMX_LocalidadOrigen = null;
                pin_layer.Children.Remove(pinOrigen);
            }
            else
            {
                panel_seBuscaOrigen = false;
                ZMX_LocalidadDestino = null;
                pin_layer.Children.Remove(pinDestino);
            }

            map.Center = loc;
            map.ZoomLevel = 17;

            //if (ZMX_CambioUbicacionOrigen != null)
            //{
            //    ZMX_CambioUbicacionOrigen(this, coordenadas, localidad);
            //}

            ZMX_DibujarLocalidadCirculo(coordenadas, nombreLocalidad);
            panel_esPorBusquedaPanel = true;
            //si ambas rutas estan asignadas se calcula la ruta
            //if (pinOrigen != null && pinDestino != null)
            //{
            //    route_layer.Children.Clear();
            //    CalcularRuta(pinOrigen.ZMX_Location, pinDestino.ZMX_Location);
            //}
        }

        private List<object> PanelBusqueda_ZMX_BuscarLocalidades(ZMXUC_MapaPanelBusqueda panel, String criterioBusqueda)
        {
            if (ZMX_BuscarLocalidades != null)
            {
                return ZMX_BuscarLocalidades(this, criterioBusqueda);
            }
            return new List<object>();
        }

        public ZMXUC_MapaPin pinOrigen { get; set; }
        public ZMXUC_MapaPin pinDestino { get; set; }
        MapLayer route_layer;
        MapLayer circles_layer;
        MapLayer pin_layer;
        private double tamOrigen = 24;

        public Boolean ZMX_ModoBuscarLocalidadPorCoordenada { get; set; }

        private void Map_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            // Disables the default mouse double-click action.
            e.Handled = true;


            // Determin the location to place the pushpin at on the map.

            //Get the mouse click coordinates
            Point mousePosition = e.GetPosition(this);
            //Convert the mouse coordinates to a locatoin on the map
            Location pinLocation = map.ViewportPointToLocation(mousePosition);

            object localidadSeleccionada = null;

            if (ZMX_ModoBuscarLocalidadPorCoordenada)
            {
                if (ZMX_BuscarLocalidadesPorAproximacion != null)
                {
                    //se solicita a la pantalla las localidades cercanas consultando su servicio
                    List<object> localidadesEncontradasCercanas = ZMX_BuscarLocalidadesPorAproximacion(this, pinLocation.Latitude, pinLocation.Longitude);
                    //de las localidades consultadas, se verifica cuales son tocadas por el pin
                    List<object> localidadesTocadas = ObtenerCoordenadasTocadasPorPin(localidadesEncontradasCercanas, pinLocation);

                    //diccionario para localidades
                    Dictionary<String, String> datosParaCirculo = new Dictionary<string, string>();

                    //aqui dibujamos las localidades cercanas al punto
                    foreach (object localidad in localidadesEncontradasCercanas)
                    {
                        //obteniendo las coordenadas de la localidad
                        PropertyInfo piCoordenadas = localidad.GetType().GetProperty(ZMX_PropiedadCoordenadas, BindingFlags.Instance | BindingFlags.Public);
                        String coordenadas = piCoordenadas.GetValue(localidad).ToString();
                        //obteniendo el nombre de la localidad
                        PropertyInfo piLocalidadNombre = localidad.GetType().GetProperty(ZMX_PropiedadLocalidadNombre, BindingFlags.Instance | BindingFlags.Public);
                        String nombreLocalidad = piLocalidadNombre.GetValue(localidad).ToString();
                        //se agrega la coordenada central de la localidad
                        datosParaCirculo.Add(coordenadas, nombreLocalidad);

                        //DibujarCirculo(radioCirculoFactor, ConvertCoordenadasStringToLocation(coordenadas));
                    }
                    // se hace el dibujado
                    ZMX_DibujarLocalidadCirculoDiccionario(datosParaCirculo);

                    //si se estan tocando localidades, se muestra un menu contextual para seleccionar la deseada
                    //si se estan interceptando localidades, se muestra un menu contextual para seleccion
                    if (localidadesTocadas.Count > 1)
                    {
                        //aqui mostrar el menu contextual
                        //String mensaje = "Elegir:\r\n";
                        //foreach(object localidadTocada in localidadesTocadas)
                        //{
                        //    PropertyInfo piLocalidadNombre = localidadTocada.GetType().GetProperty(ZMX_PropiedadLocalidadNombre, BindingFlags.Instance | BindingFlags.Public);
                        //    String nombreLocalidad = piLocalidadNombre.GetValue(localidadTocada).ToString();
                        //    mensaje += "-" + nombreLocalidad + "\r\n";
                        //}
                        //MessageBox.Show(mensaje);


                        ZMXUC_MapaMenuSeleccion mms = new ZMXUC_MapaMenuSeleccion();
                        mms.ZMX_Location = pinLocation;
                        mms.ZMX_SeSeleccionoLocalidad += Mms_ZMX_SeSeleccionoLocalidad;

                        foreach (object localidadTocada in localidadesTocadas)
                        {
                            PropertyInfo piLocalidadNombre = localidadTocada.GetType().GetProperty(ZMX_PropiedadLocalidadNombre, BindingFlags.Instance | BindingFlags.Public);
                            String nombreLocalidad = piLocalidadNombre.GetValue(localidadTocada).ToString();
                            //mensaje += "-" + nombreLocalidad + "\r\n";
                            mms.ZMX_AgregarLocalidad(localidadTocada, nombreLocalidad);
                        }

                        circles_layer.AddChild(mms, pinLocation);


                        return;
                    }
                    if (localidadesTocadas.Count == 1)
                    {
                        //si solo es una localidad, tomar esta como la localidad elegida y continuar colocando el pin
                        localidadSeleccionada = localidadesTocadas[0];
                    }
                    //si no encontro localidades donde se dió doble click, cancelar el pin.
                    if (localidadesTocadas.Count == 0)
                    {
                        MessageBox.Show("Favor de colocar el pin en una localidad válida (circulos en el mapa)");
                        return;
                    }
                }
            }
            if (panel_esPorBusquedaPanel)
            {
                AgregarPinMapaPorBusqueda(pinLocation, localidadSeleccionada);
            }
            else
            {
                AgregarPinAMapa(pinLocation, localidadSeleccionada);
            }
        }

        private void AgregarPinMapaPorBusqueda(Location pinLocation, object localidadSeleccionada)
        {
            // The pushpin to add to the map.
            ZMXUC_MapaPin pin = new ZMXUC_MapaPin();
            pin.ZMX_Color = panelBusqueda.ZMX_Color;
            pin.ZMX_Location = pinLocation;

            if (panel_seBuscaOrigen)
            {
                pinOrigen = pin;
                pinOrigen.ZMX_Height = tamOrigen;
                pinOrigen.ZMX_Icono = Iconos.IconAwesomeSIZ.AwesomeIcons.fa_circle_o;
                pin_layer.AddChild(pin, pin.ZMX_Location);

                zmx_LocalidadOrigen = localidadSeleccionada;

                PropertyInfo piOrigen = ZMX_LocalidadOrigen.GetType().GetProperty(ZMX_PropiedadLocalidadNombre, BindingFlags.Instance | BindingFlags.Public);
                panelBusqueda.ZMX_SetLocalidadOrigen(piOrigen.GetValue(ZMX_LocalidadOrigen).ToString());

                ZMX_CambioUbicacionOrigen(this, ConvertCoordenadasLocationToString(pin.ZMX_Location), localidadSeleccionada);

            }
            else
            {
                pinDestino = pin;

                zmx_LocalidadDestino = localidadSeleccionada;

                pin_layer.AddChild(pin, pin.ZMX_Location);

                PropertyInfo piDestino = ZMX_LocalidadDestino.GetType().GetProperty(ZMX_PropiedadLocalidadNombre, BindingFlags.Instance | BindingFlags.Public);
                panelBusqueda.ZMX_SetLocalidadDestino(piDestino.GetValue(ZMX_LocalidadDestino).ToString());

                ZMX_CambioUbicacionDestino(this, ConvertCoordenadasLocationToString(pin.ZMX_Location), localidadSeleccionada);
            }

            if (pinOrigen != null && pinDestino != null)
            {
                ZMX_TrazarRutaPorPin();
            }

            panel_esPorBusquedaPanel = false;
        }

        private void AgregarPinAMapa(Location pinLocation, object localidad)
        {
            if (!ZMX_PermiteMarcarPuntosEnMapa)
                return;

            if (ZMX_SeleccionoUbicacion != null)
            {
                ZMX_SeleccionoUbicacion(this, coordinateTostring(pinLocation));
                panel.ZMX_Coordenadas = coordinateTostring(pinLocation);
            }

            // The pushpin to add to the map.
            ZMXUC_MapaPin pin = new ZMXUC_MapaPin();
            pin.ZMX_Color = panelBusqueda.ZMX_Color;
            pin.ZMX_Location = pinLocation;

            if (panelBusqueda.Visibility == Visibility.Visible)
            {

                if (pinOrigen != null && pinDestino != null)
                {

                    pin_layer.Children.Remove(pinOrigen);
                    pin_layer.Children.Remove(pinDestino);
                    pinOrigen = null;
                    pinDestino = null;
                    ZMX_LocalidadOrigen = null;
                    ZMX_LocalidadDestino = null;
                    route_layer.Children.Clear();
                }


                if (pinOrigen == null)
                {
                    pinOrigen = pin;
                    pinOrigen.ZMX_Height = tamOrigen;
                    pinOrigen.ZMX_Icono = Iconos.IconAwesomeSIZ.AwesomeIcons.fa_circle_o;
                    pin_layer.AddChild(pin, pin.ZMX_Location);

                    zmx_LocalidadOrigen = localidad;

                    PropertyInfo piOrigen = ZMX_LocalidadOrigen.GetType().GetProperty(ZMX_PropiedadLocalidadNombre, BindingFlags.Instance | BindingFlags.Public);
                    panelBusqueda.ZMX_SetLocalidadOrigen(piOrigen.GetValue(ZMX_LocalidadOrigen).ToString());

                    ZMX_CambioUbicacionOrigen(this, ConvertCoordenadasLocationToString(pin.ZMX_Location), localidad);

                    return;
                }

                if (pinDestino == null)
                {
                    pinDestino = pin;

                    zmx_LocalidadDestino = localidad;

                    pin_layer.AddChild(pin, pin.ZMX_Location);

                    PropertyInfo piDestino = ZMX_LocalidadDestino.GetType().GetProperty(ZMX_PropiedadLocalidadNombre, BindingFlags.Instance | BindingFlags.Public);
                    panelBusqueda.ZMX_SetLocalidadDestino(piDestino.GetValue(ZMX_LocalidadDestino).ToString());

                    ZMX_CambioUbicacionDestino(this, ConvertCoordenadasLocationToString(pin.ZMX_Location), localidad);

                    ZMX_TrazarRutaPorPin();
                }
            }
            else
            {
                pin_layer.Children.Remove(pinOrigen);
                pin_layer.AddChild(pin, pin.ZMX_Location);
                pinOrigen = pin;
            }
        }
        private void Mms_ZMX_SeSeleccionoLocalidad(ZMXUC_MapaMenuSeleccion mms, object localidad)
        {
            circles_layer.Children.Remove(mms);
            AgregarPinAMapa(mms.ZMX_Location, localidad);
        }

        private void DibujarCirculo(double radio, Location origen)
        {
            double radioPorGrados = Math.PI / 180;
            double radioTierra = 0.235;
            double latitud = origen.Latitude * radioPorGrados;
            double longitud = origen.Longitude * radioPorGrados;
            List<Location> locaciones = new List<Location>();

            double angulo = radio / radioTierra;

            for (int x = 0; x <= 360; x++)
            {
                double puntoLatitud = 0;
                double puntoLongitud = 0;

                double brng = x * radioPorGrados;

                puntoLatitud = Math.Asin(Math.Sin(latitud) * Math.Cos(angulo) + Math.Cos(latitud) * Math.Sin(angulo) * Math.Cos(brng));
                puntoLongitud = longitud + Math.Atan2(Math.Sin(brng) * Math.Sin(angulo) * Math.Cos(latitud), Math.Cos(angulo) - Math.Sin(latitud) * Math.Sin(puntoLatitud));

                puntoLatitud = puntoLatitud / radioPorGrados;
                puntoLongitud = puntoLongitud / radioPorGrados;
                locaciones.Add(new Location(puntoLatitud, puntoLongitud));

            }
            //dibujando el circulo


            MapPolygon circle = new MapPolygon();
            circle.Locations = new LocationCollection();
            circle.Stroke = color;
            circle.Fill = Colores.ConvertirColorABrush(Colores.AclararColor(Colores.ConvertirBrushAColor(color)));
            circle.Opacity = 0.50;
            circle.StrokeThickness = 3;
            locaciones.ForEach(x => circle.Locations.Add(x));
            circles_layer.Children.Add(circle);


        }

        public void ZMX_DibujarLocalidadCirculo(String coordenada, String nombreLocalidad)
        {
            circles_layer.Children.Clear();
            Brush colorOscuro = Colores.ConvertirColorABrush(Colores.OscurecerColor(Colores.ConvertirBrushAColor(color), 20));
            DibujarCirculo(radioCirculoFactor, ConvertCoordenadasStringToLocation(coordenada));
            circles_layer.AddChild(new TextBlock() { Text = nombreLocalidad, Foreground = color, Background = Brushes.Transparent, FontSize = 16, FontWeight = FontWeights.Bold, Margin = new Thickness(coordenada.Length / 2 * 8.8 * -1, -10, 0, 0) }, ConvertCoordenadasStringToLocation(coordenada));

        }

        public void ZMX_DibujarLocalidadCirculoDiccionario(Dictionary<String, String> coordenadas)
        {
            circles_layer.Children.Clear();
            foreach (String coordenada in coordenadas.Keys)
            {
                Brush colorOscuro = Colores.ConvertirColorABrush(Colores.OscurecerColor(Colores.ConvertirBrushAColor(color), 20));
                DibujarCirculo(radioCirculoFactor, ConvertCoordenadasStringToLocation(coordenada));
                circles_layer.AddChild(new TextBlock() { Text = coordenadas[coordenada], Foreground = color, Background = Brushes.Transparent, FontSize = 16, FontWeight = FontWeights.Bold, Margin = new Thickness(coordenadas[coordenada].Length / 2 * 8.8 * -1, -10, 0, 0) }, ConvertCoordenadasStringToLocation(coordenada));

            }
        }


        double radioCirculoFactor = 0.000015;
        private List<object> ObtenerCoordenadasTocadasPorPin(List<object> localidadesBusqueda, Location pinLocation)
        {
            List<object> localidadesTocadas = new List<object>();
            foreach (object localidad in localidadesBusqueda)
            {
                //obteniendo las coordenadas de la localidad
                PropertyInfo piCoordenadas = localidad.GetType().GetProperty(ZMX_PropiedadCoordenadas, BindingFlags.Instance | BindingFlags.Public);
                String coordenadas = piCoordenadas.GetValue(localidad).ToString();

                //se normaliza la coordenada con respecto la coordenada del click
                double latitudCoordenada = Convert.ToDouble(coordenadas.Split(',')[0]);
                double longitudCoordenada = Convert.ToDouble(coordenadas.Split(',')[1]);

                //se normalizan las coordenadas para establecer el punto en 0,0
                double latitudPin = pinLocation.Latitude - latitudCoordenada;
                double longitudPin = pinLocation.Longitude - longitudCoordenada;

                //se determina si el pin esta dentro de de la circunferencia

                //factor de circunferencia
                if (Math.Pow(latitudPin, 2) + Math.Pow(longitudPin, 2) == radioCirculoFactor)
                {
                    //el punto se encuentra al borde de la cincunferencia
                    localidadesTocadas.Add(localidad);

                }
                if (Math.Pow(latitudPin, 2) + Math.Pow(longitudPin, 2) < radioCirculoFactor)
                {
                    //Se encuentra dentro de la cincunferencia
                    localidadesTocadas.Add(localidad);
                }
                else
                {
                    //Se encuentra fuera de la cincunferencia
                }
            }

            return localidadesTocadas;
        }

        public void ZMX_Limpiar()
        {
            ZMX_LocalidadDestino = null;
            ZMX_LocalidadOrigen = null;
            pin_layer.Children.Clear();
            circles_layer.Children.Clear();
            route_layer.Children.Clear();
            panelBusqueda.ZMX_Limpiar();
        }

        public void CalcularRuta(Location origen, Location destino)
        {
            double distancia = 0;
            double duracion = 0;
            List<Location> locations = Points.getPoints(origen, destino, out distancia, out duracion);
            MapPolyline routeline = new MapPolyline();
            routeline.Locations = new LocationCollection();
            routeline.Stroke = color;
            routeline.StrokeThickness = 5;

            foreach (Location i in locations)
            {
                double latitud = i.Latitude;
                double longitud = i.Longitude;

                Location t = new Location(latitud, longitud);
                routeline.Locations.Add(t);
            }

            route_layer.Children.Add(routeline);

            //se crea un template para el mapa
            ////TextBlock tb = new TextBlock();
            ////tb.Text = "Distancia: " + distancia / 1000 + " km\nDuración: " + duracion + " Seg";
            ////tb.FontSize = 25;
            ////tb.Background = Brushes.White;
            ////route_layer.AddChild(tb, routeline.Locations[0]);

            if (distancia < 1000)
            {
                panelBusqueda.Distancia = Math.Round(distancia, 2) + " metros";
            }
            else
            {
                panelBusqueda.Distancia = Math.Round(distancia / 1000, 2) + " Kilometros";
            }

            if (duracion < 60)
            {
                panelBusqueda.Tiempo = Math.Round(duracion, 2) + " segundos";
            }
            else if (duracion < 3600)
            {
                panelBusqueda.Tiempo = Math.Round(duracion / 60, 2) + " minutos";
            }
            else
            {
                panelBusqueda.Tiempo = Math.Round(duracion / 60 / 60, 2) + " horas";
            }

            BingApi mc = new BingApi();
            mc.Distancia = distancia;
            mc.Tiempo = duracion;

            if (ZMX_SeCalcularonDatos != null)
            {


                ZMX_SeCalcularonDatos(this, mc);
            }

        }


        public String coordinateTostring(Location loc)
        {
            return loc.Latitude + "," + loc.Longitude;
        }

        public T ConsultaApi<T>(String url, String json)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

                if (json != null)
                {
                    request.Method = "POST";
                    request.ContentType = "application/json";
                    request.ContentLength = json.Length;
                    using (Stream webStream = request.GetRequestStream())
                    using (StreamWriter requestWriter = new StreamWriter(webStream, System.Text.Encoding.ASCII))
                    {
                        requestWriter.Write(json);
                    }
                }
                else
                {
                    request.Method = "GET";
                }
                try
                {
                    WebResponse webResponse = request.GetResponse();
                    using (Stream webStream = webResponse.GetResponseStream())
                    {
                        if (webStream != null)
                        {
                            using (StreamReader responseReader = new StreamReader(webStream))
                            {
                                string response = responseReader.ReadToEnd();
                                //Console.Out.WriteLine(response);
                                return DeserializarObjeto<T>(response);



                            }
                        }
                        return default(T);
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public T DeserializarObjeto<T>(string json)
        {
            var serializerSettings = new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects, ReferenceLoopHandling = ReferenceLoopHandling.Serialize };

            T resultado = JsonConvert.DeserializeObject<T>(json, serializerSettings);

            return resultado;
        }

        private void panel_ZMX_ClickAceptar(Toolbar.ToolbarBtn btn)
        {

        }

        private void panel_ZMX_ClickLimpiar(Toolbar.ToolbarBtn btn)
        {

        }
    }
}
