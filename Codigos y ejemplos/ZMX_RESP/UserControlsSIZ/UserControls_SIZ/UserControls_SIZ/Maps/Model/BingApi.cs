using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Microsoft.Maps.MapControl.WPF;
using Newtonsoft.Json;

namespace UserControlsSIZ.Maps.Model
{
    public class BingApi
    {
        public double Distancia { get; set; }
        public double Tiempo { get; set; }

        public static String coordinateTostring(Location loc)
        {
            return loc.Latitude + "," + loc.Longitude;
        }

        public static T ConsultaApi<T>(String url, String json)
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
        public static T DeserializarObjeto<T>(string json)
        {
            var serializerSettings = new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects, ReferenceLoopHandling = ReferenceLoopHandling.Serialize };

            T resultado = JsonConvert.DeserializeObject<T>(json, serializerSettings);

            return resultado;
        }
        public static List<Location> CalcularRuta(Location origen, Location destino)
        {
            String url = "http://dev.virtualearth.net/REST/V1/Routes/Driving?o=json&wp.0=@origen&wp.1=@destino&optmz=distance&routeAttributes=routePath&tl=0.00000344978,0.0000218840,0.000220577,0.00188803,0.0169860,0.0950130,0.846703&key=AvfnXnq_qEOOUMEvjvqjvGd1LUIOOKIjzo6zPxcxVDp0-w6azuF60QPNEYM8Vi7o";


            url = url.Replace("@origen", coordinateTostring(origen));
            url = url.Replace("@destino", coordinateTostring(destino));

            RootObject ro = ConsultaApi<RootObject>(url, null);
            List<Location> lista = new List<Location>();
            //MapPolyline routeline = new MapPolyline();
            //routeline.Locations = new LocationCollection();
            //routeline.Stroke = new SolidColorBrush(Colors.Blue);
            //routeline.StrokeThickness = 5;

            foreach (List<double> i in ro.resourceSets[0].resources[0].routePath.line.coordinates)
            {
                double latitud = i[0];
                double longitud = i[1];

                Location t = new Location(latitud, longitud);
                //routeline.Locations.Add(t);
                lista.Add(t);
            }
            //route_layer = new MapLayer();
            //route_layer.Children.Add(routeline);



            //foreach (ItineraryItem i in ro.resourceSets[0].resources[0].routeLegs[0].itineraryItems)
            //{
            //    double latitud = i.maneuverPoint.coordinates[0];
            //    double longitud = i.maneuverPoint.coordinates[1];

            //    Location t = new Location(latitud, longitud);
            //    //routeline.Locations.Add(t);
            //    TextBlock tbRuta = new TextBlock();
            //    tbRuta.Text = i.instruction.text;
            //    tbRuta.FontSize = 16;
            //    tbRuta.Background = Brushes.LightYellow;
            //    route_layer.AddChild(tbRuta, t);

            //}





            ////se crea un template para el mapa
            //TextBlock tb = new TextBlock();
            //tb.Text = "Distancia: " + ro.resourceSets[0].resources[0].travelDistance + " km";
            //tb.FontSize = 25;
            //tb.Background = Brushes.White;
            //route_layer.AddChild(tb, routeline.Locations[0]);



            //map.Children.Add(route_layer);
            //map.Center = routeline.Locations[0];
            //map.ZoomLevel = 16;

            return lista;
        }

    }
}
