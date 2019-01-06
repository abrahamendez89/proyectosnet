using Microsoft.Maps.MapControl.WPF;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace loctTarifaFlete.Models
{

    public class Points
    {

        public static List<Location> getPoints(Location origen, Location destino, out double distancia, out double duracion)
        {
            distancia = 0;
            duracion = 0;
            List<Location> locations = new List<Location>();
            try
            {
                string _pointOrigen = origen.Latitude.ToString() + "," + origen.Longitude.ToString();
                string _pointDestino = destino.Latitude.ToString() + "," + destino.Longitude.ToString();
                string _urlResponse;
                string _urlRequest = "https://maps.googleapis.com/maps/api/directions/json?mode=driving&origin=[0]&destination=[1]&key=AIzaSyCpg3qKOE856BvHlYj3I70CbpyeSAEqrsY";

                _urlRequest = _urlRequest.Replace("[0]", _pointOrigen).Replace("[1]", _pointDestino);

                RootObject estructura = new RootObject();
                var request = (HttpWebRequest)WebRequest.Create(_urlRequest);

                

                request.UserAgent = "curl"; // this simulate curl linux command

                request.Method = "GET";
                using (WebResponse response = request.GetResponse())
                {
                    using (var reader = new StreamReader(response.GetResponseStream()))
                    {
                        _urlResponse = reader.ReadToEnd();
                    }
                }
                estructura = DeserializarObjeto<RootObject>(_urlResponse);



                if (estructura.status == "OK")
                {
                    locations = _myPoints(estructura.routes[0].legs);
                    distancia = estructura.routes[0].legs[0].distance.value;
                    duracion = estructura.routes[0].legs[0].duration.value;
                }
            }
            catch (Exception ex)
            {
                
            }
            return locations;
        }

        private static List<Location> _myPoints(List<Leg> leg)
        {
            List<Location> locations = new List<Location>();

            foreach (Leg l in leg)
            {
                l.steps.ForEach(s =>
                {
                    List<Location> lo = (Decode(s.polyline.points));
                    lo.ForEach(ll => locations.Add(ll));
                });

            }
            return locations;
        }
        public static T DeserializarObjeto<T>(string json)
        {
            var serializerSettings = new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects, ReferenceLoopHandling = ReferenceLoopHandling.Serialize };

            T resultado = JsonConvert.DeserializeObject<T>(json, serializerSettings);

            return resultado;
        }
        public static List<Location> Decode(string polylineString)
        {
            if (string.IsNullOrEmpty(polylineString))
                throw new ArgumentNullException(nameof(polylineString));

            List<Location> l = new List<Location>();

            var polylineChars = polylineString.ToCharArray();
            var index = 0;

            var currentLat = 0;
            var currentLng = 0;

            while (index < polylineChars.Length)
            {
                var sum = 0;
                var shifter = 0;
                int nextFiveBits;
                do
                {
                    nextFiveBits = polylineChars[index++] - 63;
                    sum |= (nextFiveBits & 31) << shifter;
                    shifter += 5;
                } while (nextFiveBits >= 32 && index < polylineChars.Length);

                if (index >= polylineChars.Length)
                    break;

                currentLat += (sum & 1) == 1 ? ~(sum >> 1) : (sum >> 1);
                sum = 0;
                shifter = 0;
                do
                {
                    nextFiveBits = polylineChars[index++] - 63;
                    sum |= (nextFiveBits & 31) << shifter;
                    shifter += 5;
                } while (nextFiveBits >= 32 && index < polylineChars.Length);

                if (index >= polylineChars.Length && nextFiveBits >= 32)
                    break;

                currentLng += (sum & 1) == 1 ? ~(sum >> 1) : (sum >> 1);

                l.Add(new Location
                {
                    Latitude = Convert.ToDouble(currentLat) / 1E5,
                    Longitude = Convert.ToDouble(currentLng) / 1E5
                });
            }

            return l;
        }
    }

    public class GeocodedWaypoint
    {
        public string geocoder_status { get; set; }
        public string place_id { get; set; }
        public List<string> types { get; set; }
    }

    public class Northeast
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }

    public class Southwest
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }

    public class Bounds
    {
        public Northeast northeast { get; set; }
        public Southwest southwest { get; set; }
    }

    public class Distance
    {
        public string text { get; set; }
        public int value { get; set; }
    }

    public class Duration
    {
        public string text { get; set; }
        public int value { get; set; }
    }

    public class EndLocation
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }

    public class StartLocation
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }

    public class Distance2
    {
        public string text { get; set; }
        public int value { get; set; }
    }

    public class Duration2
    {
        public string text { get; set; }
        public int value { get; set; }
    }

    public class EndLocation2
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }

    public class Polyline
    {
        public string points { get; set; }
    }

    public class StartLocation2
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }

    public class Step
    {
        public Distance2 distance { get; set; }
        public Duration2 duration { get; set; }
        public EndLocation2 end_location { get; set; }
        public string html_instructions { get; set; }
        public Polyline polyline { get; set; }
        public StartLocation2 start_location { get; set; }
        public string travel_mode { get; set; }
        public string maneuver { get; set; }
    }

    public class Leg
    {
        public Distance distance { get; set; }
        public Duration duration { get; set; }
        public string end_address { get; set; }
        public EndLocation end_location { get; set; }
        public string start_address { get; set; }
        public StartLocation start_location { get; set; }
        public List<Step> steps { get; set; }
        public List<object> traffic_speed_entry { get; set; }
        public List<object> via_waypoint { get; set; }
    }

    public class OverviewPolyline
    {
        public string points { get; set; }
    }

    public class Route
    {
        public Bounds bounds { get; set; }
        public string copyrights { get; set; }
        public List<Leg> legs { get; set; }
        public OverviewPolyline overview_polyline { get; set; }
        public string summary { get; set; }
        public List<object> warnings { get; set; }
        public List<object> waypoint_order { get; set; }
    }

    public class RootObject
    {
        public List<GeocodedWaypoint> geocoded_waypoints { get; set; }
        public List<Route> routes { get; set; }
        public string status { get; set; }
    }



}
