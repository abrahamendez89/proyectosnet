using InterfazWPF.AdministracionSistema;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml;
using System.Xml.Linq;
using Telerik.Windows.Controls.Map;

namespace InterfazWPF.Modulos.ControlesUsuarioGenerales
{
    /// <summary>
    /// Lógica de interacción para win_testMaps.xaml
    /// </summary>
    public partial class win_testMaps : Window
    {
        public win_testMaps()
        {
            InitializeComponent();
            //setMapPolygon();
            radMap.MapMouseDoubleClick += radMap_MapMouseDoubleClick;
            radMap.MouseDoubleClickMode = MouseBehavior.ZoomPointToCenter;
            radMap.MouseClickMode = MouseBehavior.None;
            radMap.MaxZoomLevel = 19;
            radMap.DistanceUnit = DistanceUnit.Kilometer;
           

            radMap.ZoomingFinished += radMap_ZoomingFinished;
            radMap.ZoomChanged += radMap_ZoomChanged;

            chb_modoCoordenadas.Checked += chb_modoCoordenadas_Checked;
            chb_modoCoordenadas.Unchecked += chb_modoCoordenadas_Unchecked;


            btn_CampoCardenal.MouseDown += btn_CampoCardenal_MouseDown;
            btn_Imuris.MouseDown += btn_Imuris_MouseDown;

            btn_CampoCardenal_MouseDown(null, null);

        }
        Boolean visible;
        void radMap_ZoomChanged(object sender, EventArgs e)
        {
            if (radMap.ZoomLevel >= 18 && !visible)
            {
                visible = true;
                for (int i = 0; i < map.Items.Count; i++)
                {
                    MapPolygon poligono = (MapPolygon)map.Items[i];
                    poligono.CaptionTemplate = templates[i];
                    poligono.CaptionLocation = poligono.Points[0];

                }
                map.Items.Refresh();
            }
            else if (radMap.ZoomLevel < 18 && visible)
            {
                visible = false;
                for (int i = 0; i < map.Items.Count; i++)
                {
                    MapPolygon poligono = (MapPolygon)map.Items[i];
                    poligono.CaptionTemplate = null;
                }
                map.Items.Refresh();
            }
        }

        private void zoomin()
        {
            radMap.ZoomLevel = 19;
            control = false;
        }
        void btn_Imuris_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //Thread animarCoorde = new Thread(AnimarCoordenada);
            IrACoordenada(new Location(30.843385, -110.840296));
        }
        Location loc;
        Boolean control;
        private void IrACoordenada(Location location)
        {
            //control = true;
            loc = (Location)location;
            radMap.Center = loc;
            radMap.ZoomLevel = 17;
        }

        void radMap_ZoomingFinished(object sender, RoutedEventArgs e)
        {
            if (control)
            {
                radMap.Center = loc;
                control = false;
            }
            
        }


        void btn_CampoCardenal_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //Thread animarCoorde = new Thread(AnimarCoordenada);
            IrACoordenada(new Location(24.754083, -107.474519));
        }
        LocationCollection puntosTemp;
        List<DataTemplate> templates = new List<DataTemplate>();
        void chb_modoCoordenadas_Unchecked(object sender, RoutedEventArgs e)
        {
            if (puntosTemp.Count > 0)
            {
                //double area = ;
                String area = Math.Round(CalcularArea() / 10000, 2) + " Ha(s)";
                String perimetro = Math.Round(CalcularPerimetro(), 2) + " m";
                AgregaPolygono(puntosTemp, txt_nombre.Text,area,perimetro);
                HerramientasWindow.MostrarNotificacion("Zona agregada.","Maps");
                txt_nombre.Text = "";

            }
            radMap.MouseDoubleClickMode = MouseBehavior.ZoomPointToCenter;
            //radMap.MouseClickMode = MouseBehavior.Center;
        }

        void chb_modoCoordenadas_Checked(object sender, RoutedEventArgs e)
        {
            puntosTemp = new LocationCollection();
            radMap.MouseDoubleClickMode = MouseBehavior.None;
            //radMap.MouseClickMode = MouseBehavior.None;
        }

        void radMap_MapMouseDoubleClick(object sender, MapMouseRoutedEventArgs eventArgs)
        {
            if ((Boolean)chb_modoCoordenadas.IsChecked)
            {
                puntosTemp.Add(eventArgs.Location);
                //HerramientasWindow.MostrarNotificacion("Maps", "Coordenada agregada: " + eventArgs.Location.ToString());
            }


        }

        private Color oscurecerColor(Color color)
        {

            String stCol = color.ToString().Replace("#","");

            String r = stCol.Substring(0, 2);
            String v = stCol.Substring(2, 2);
            String a = stCol.Substring(4, 2);

            double ir = color.R;//Convert.ToInt32(r, 16);
            double iv = color.G;//Convert.ToInt32(v, 16);
            double ia = color.B;//Convert.ToInt32(a, 16);

            double factor = 40;

            if (ir - factor >= 0) ir -= factor;
            if (iv - factor >= 0) iv -= factor;
            if (ia - factor >= 0) ia -= factor;

            Color colorNuevo = Color.FromRgb((byte)ir, (byte)iv, (byte)ia);

            return colorNuevo;
        }

        private void AgregaPolygono(LocationCollection puntos, String nombre, String area, String perimetro)
        {
            MapPolygon mp = new MapPolygon();
            mp.Points = puntos;
            mp.Opacity = 0.6;
            mp.MouseLeftButtonDown += mp_MouseLeftButtonDown;
            mp.Fill = rtg_color.Fill;

            
            Color color = ((SolidColorBrush)rtg_color.Fill).Color;

            color = oscurecerColor(color);

            mp.Stroke = new SolidColorBrush(color);
            mp.StrokeThickness = 6;
            mp.Cursor = Cursors.Hand;

            
            Grid grContent = new Grid();
            //grContent.Opacity = 0.5;
            grContent.Background = new SolidColorBrush(Colors.White);
            StackPanel stack = new StackPanel();
            grContent.Children.Add(stack);
            stack.Children.Add(new TextBlock() { Text = "Nombre: "+nombre });
            stack.Children.Add(new TextBlock() { Text = "Area: "+area });
            stack.Children.Add(new TextBlock() { Text = "Perimetro: "+perimetro });



            string controlesPersonalizados = XamlWriter.Save(grContent);


            DataTemplate template = XamlReader.Parse(""
                + "<DataTemplate "
                + " xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\""
                + " xmlns:telerik=\"http://schemas.telerik.com/2008/xaml/presentation\">"
                //+ " xmlns:InterfazWPF=\"clr-namespace:InterfazWPF\">"
                + controlesPersonalizados
                //+ " <Grid Background=\"White\" telerik:MapLayer.HotSpot=\"0.5, 0.5\">"
                //+ "  <StackPanel>"
                //+ "   <TextBlock Text=\"Nombre: " + nombre + "\" />"
                //+ "   <TextBlock Text=\"Area: " + area + "\" />"
                //+ "   <TextBlock Text=\"Perimetro: " + perimetro + "\" />"
                //+ "   <Button>test</Button>"
                //+     botonPersonalizado
                //+ "   </StackPanel>"
                //+ " </Grid>"
                + "</DataTemplate>") as DataTemplate;
            if (radMap.ZoomLevel >= 18)
            {
                mp.CaptionTemplate = template;
                mp.CaptionLocation = mp.Points[0];
            }
            map.Items.Add(mp);
            templates.Add(template);
            puntosTemp.Add(puntosTemp[0]);


        }

        void btn_Click(object sender, RoutedEventArgs e)
        {
            HerramientasWindow.Mensaje("", "");
        }

        void mp_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MapPolygon poligono = (MapPolygon)sender;
            if (poligono.CaptionTemplate != null)
            {
                String controles = XamlWriter.Save(poligono.CaptionTemplate);

                XmlDocument xml = new XmlDocument();
                xml.LoadXml(controles); // suppose that myXmlString contains "<Names>...</Names>"

                XmlNode texto = xml.ChildNodes[0].ChildNodes[0].ChildNodes[0].ChildNodes[0];

                Stream strmt = new MemoryStream(ASCIIEncoding.Default.GetBytes(texto.OuterXml));
                TextBlock t = (TextBlock)System.Windows.Markup.XamlReader.Load(strmt);

                HerramientasWindow.Mensaje("Le diste click a: " + t.Text.Replace("Nombre: ", ""), "");
            }
        }

        long circunferencia = 40091147;
        long radio = 6378137;
        long diametro = 12756274;


        private void CargarCoordenadasEjemplo()
        {
            puntosTemp = new LocationCollection();
            puntosTemp.Add(new Location(-6.177570, 106.825820));
            puntosTemp.Add(new Location(-6.176810, 106.824920));
            puntosTemp.Add(new Location(-6.173840, 106.824970));
            puntosTemp.Add(new Location(-6.173130, 106.825700));
            puntosTemp.Add(new Location(-6.173180, 106.828800));
            puntosTemp.Add(new Location(-6.173900, 106.829430));
            puntosTemp.Add(new Location(-6.176730, 106.829390));
            puntosTemp.Add(new Location(-6.177660, 106.828450));
            double area = CalcularArea();
            HerramientasWindow.Mensaje(Math.Round(area, 2) + " Metros^2 - " + Math.Round(area / 1000, 2) + " Has", "Area");
            puntosTemp = null;

        }


        public double CalcularArea()
        {

            //A = (1/2)(x1*y2 - x2*y1 + x2*y3 - x3*y2 + x3y4 - x4y3 + x4*y5 -x5*y4 + x5*y1 - x1*y5).
            double sum = 0.0;
            for (int i = 1; i < puntosTemp.Count; i++)
            {
                double radianes = puntosTemp[i].Latitude / 180.0 * (22.0 / 7.0);

                double YAnterior = (puntosTemp[i - 1].Latitude - puntosTemp[0].Latitude) / 360 * circunferencia;
                double XAnterior = (puntosTemp[i - 1].Longitude - puntosTemp[0].Longitude) / 360 * circunferencia * Math.Cos(radianes);

                double YActual = (puntosTemp[i].Latitude - puntosTemp[0].Latitude) / 360 * circunferencia;
                double XActual = (puntosTemp[i].Longitude - puntosTemp[0].Longitude) / 360 * circunferencia * Math.Cos(radianes);

                //YAnterior = Math.Abs(YAnterior);
                //XAnterior = Math.Abs(XAnterior);
                //YActual = Math.Abs(YActual);
                //XActual = Math.Abs(XActual);

                sum = sum + ((YAnterior * XActual) - (XAnterior * YActual)) * 0.5;

                //sum = sum + (puntosTemp[i].Latitude * puntosTemp[i + 1].Longitude) - (puntosTemp[i].Longitude * puntosTemp[i + 1].Latitude);
            }
            return sum;
        }
        public double CalcularPerimetro()
        {

            //A = (1/2)(x1*y2 - x2*y1 + x2*y3 - x3*y2 + x3y4 - x4y3 + x4*y5 -x5*y4 + x5*y1 - x1*y5).
            double sum = 0.0;
            for (int i = 1; i < puntosTemp.Count; i++)
            {
                double radianes = puntosTemp[i].Latitude / 180.0 * (22.0 / 7.0);

                double YAnterior = (puntosTemp[i - 1].Latitude - puntosTemp[0].Latitude) / 360 * circunferencia;
                double XAnterior = (puntosTemp[i - 1].Longitude - puntosTemp[0].Longitude) / 360 * circunferencia * Math.Cos(radianes);

                double YActual = (puntosTemp[i].Latitude - puntosTemp[0].Latitude) / 360 * circunferencia;
                double XActual = (puntosTemp[i].Longitude - puntosTemp[0].Longitude) / 360 * circunferencia * Math.Cos(radianes);

                //YAnterior = Math.Abs(YAnterior);
                //XAnterior = Math.Abs(XAnterior);
                //YActual = Math.Abs(YActual);
                //XActual = Math.Abs(XActual);

                sum = sum + Math.Pow(Math.Pow((XActual - XAnterior), 2) + Math.Pow((YActual - YAnterior), 2), 0.5);

                //sum = sum + (puntosTemp[i].Latitude * puntosTemp[i + 1].Longitude) - (puntosTemp[i].Longitude * puntosTemp[i + 1].Latitude);
            }
            return sum;
        }

        private void Rectangle_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            radColorPicker.Visibility = System.Windows.Visibility.Visible;
            radColorPicker.SelectedColorChanged += radColorPicker_SelectedColorChanged;
        }

        void radColorPicker_SelectedColorChanged(object sender, EventArgs e)
        {
            radColorPicker.Visibility = System.Windows.Visibility.Collapsed;
            rtg_color.Fill = new SolidColorBrush(radColorPicker.SelectedColor);
        }
    }
}
