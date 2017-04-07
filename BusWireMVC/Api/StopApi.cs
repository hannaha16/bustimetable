using System.Collections.Generic;
using BusWireMVC.Models;
using RestSharp;

namespace BusWireMVC
{
    public class StopApi : TflApi<List<BusStop>>
    {

        public List<BusStop> GetStopsNear(double latitude, double longitude)
        {
            int radius = 500;
            var request = new RestRequest
            {
                Resource = $"StopPoint",
                RootElement = "stopPoints"
            };
            request.AddParameter("radius", radius, ParameterType.GetOrPost);
            request.AddParameter("lat", latitude, ParameterType.GetOrPost);
            request.AddParameter("lon", longitude, ParameterType.GetOrPost);
            request.AddParameter("stoptypes", "NaptanPublicBusCoachTram",
                ParameterType.GetOrPost);
            // TODO this only displays bus (and coach, and tram) stops; could add NaptanMetroStation for tubes too
            return Execute(request);
        }

        public List<BusStop> GetStopsNear(Postcode postcode)
        {
            return GetStopsNear(postcode.Latitude, postcode.Longitude);
        }

        public List<BusStop> GetStopsOn(string line)
        {
            var request = new RestRequest
            {
                Resource = $"line/{line}/stoppoints"
            };
            return Execute(request);
        }

    }
}