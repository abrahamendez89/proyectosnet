using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserControlsSIZ.Maps.Model
{
    public class ActualEnd
    {
        public string type { get; set; }
        public List<double> coordinates { get; set; }
    }

    public class ActualStart
    {
        public string type { get; set; }
        public List<double> coordinates { get; set; }
    }

    public class Shield
    {
        public List<string> labels { get; set; }
        public int roadShieldType { get; set; }
    }

    public class RoadShieldRequestParameters
    {
        public int bucket { get; set; }
        public List<Shield> shields { get; set; }
    }

    public class Detail
    {
        public int compassDegrees { get; set; }
        public List<int> endPathIndices { get; set; }
        public List<string> locationCodes { get; set; }
        public string maneuverType { get; set; }
        public string mode { get; set; }
        public List<string> names { get; set; }
        public string roadType { get; set; }
        public List<int> startPathIndices { get; set; }
        public RoadShieldRequestParameters roadShieldRequestParameters { get; set; }
    }

    public class Instruction
    {
        public object formattedText { get; set; }
        public string maneuverType { get; set; }
        public string text { get; set; }
    }

    public class ManeuverPoint
    {
        public string type { get; set; }
        public List<double> coordinates { get; set; }
    }

    public class Warning
    {
        public string origin { get; set; }
        public string severity { get; set; }
        public string text { get; set; }
        public string to { get; set; }
        public string warningType { get; set; }
    }

    public class Hint
    {
        public string hintType { get; set; }
        public string text { get; set; }
    }

    public class ItineraryItem
    {
        public string compassDirection { get; set; }
        public List<Detail> details { get; set; }
        public string exit { get; set; }
        public string iconType { get; set; }
        public Instruction instruction { get; set; }
        public ManeuverPoint maneuverPoint { get; set; }
        public string sideOfStreet { get; set; }
        public string tollZone { get; set; }
        public string towardsRoadName { get; set; }
        public string transitTerminus { get; set; }
        public double travelDistance { get; set; }
        public int travelDuration { get; set; }
        public string travelMode { get; set; }
        public List<string> signs { get; set; }
        public List<Warning> warnings { get; set; }
        public List<Hint> hints { get; set; }
    }

    public class EndWaypoint
    {
        public string type { get; set; }
        public List<double> coordinates { get; set; }
        public string description { get; set; }
        public bool isVia { get; set; }
        public string locationIdentifier { get; set; }
        public int routePathIndex { get; set; }
    }

    public class StartWaypoint
    {
        public string type { get; set; }
        public List<double> coordinates { get; set; }
        public string description { get; set; }
        public bool isVia { get; set; }
        public string locationIdentifier { get; set; }
        public int routePathIndex { get; set; }
    }

    public class RouteSubLeg
    {
        public EndWaypoint endWaypoint { get; set; }
        public StartWaypoint startWaypoint { get; set; }
        public double travelDistance { get; set; }
        public int travelDuration { get; set; }
    }

    public class RouteLeg
    {
        public ActualEnd actualEnd { get; set; }
        public ActualStart actualStart { get; set; }
        public List<object> alternateVias { get; set; }
        public int cost { get; set; }
        public string description { get; set; }
        public List<ItineraryItem> itineraryItems { get; set; }
        public string routeRegion { get; set; }
        public List<RouteSubLeg> routeSubLegs { get; set; }
        public double travelDistance { get; set; }
        public int travelDuration { get; set; }
    }

    public class Generalization
    {
        public double latLongTolerance { get; set; }
        public List<int> pathIndices { get; set; }
    }

    public class Line
    {
        public string type { get; set; }
        public List<List<double>> coordinates { get; set; }
    }

    public class RoutePath
    {
        public List<Generalization> generalizations { get; set; }
        public Line line { get; set; }
    }

    public class Resource
    {
        public string __type { get; set; }
        public List<double> bbox { get; set; }
        public string id { get; set; }
        public string distanceUnit { get; set; }
        public string durationUnit { get; set; }
        public List<RouteLeg> routeLegs { get; set; }
        public RoutePath routePath { get; set; }
        public string trafficCongestion { get; set; }
        public string trafficDataUsed { get; set; }
        public double travelDistance { get; set; }
        public int travelDuration { get; set; }
        public int travelDurationTraffic { get; set; }
    }

    public class ResourceSet
    {
        public int estimatedTotal { get; set; }
        public List<Resource> resources { get; set; }
    }

    public class RootObject
    {
        public string authenticationResultCode { get; set; }
        public string brandLogoUri { get; set; }
        public string copyright { get; set; }
        public List<ResourceSet> resourceSets { get; set; }
        public int statusCode { get; set; }
        public string statusDescription { get; set; }
        public string traceId { get; set; }
    }
}
