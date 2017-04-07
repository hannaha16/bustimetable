using System.Collections.Generic;
using BusWireMVC.Models;
using RestSharp;

namespace BusWireMVC
{
    public class ArrivalApi : TflApi<List<BusArrival>>
    {
        public List<BusArrival> GetBusArrivals(string busStopId)
        {
            var request = new RestRequest
            {
                Resource = $"StopPoint/{busStopId}/Arrivals",
            };
            return Execute(request);
        }
    }
}