using System.Collections.Generic;
using System.Linq;

namespace BusWireMVC.Models
{
    public enum StopType
    {
        NaptanPublicBusCoachTram,
        NaptanMetroStation,
        NaptanRailStation
    }

    public class BusStop
    {
        public StopType StopType { get; set; }
        public string CommonName { get; set; }
        public string Id { get; set; }
        public double Longitude
        {
            get { return Location.Longitude; }
            set { Location.Longitude = value; }
        }

        public double Latitude
        {
            get { return Location.Latitude; }
            set { Location.Latitude = value; }
        }

        public MapCoord Location;

        public List<BusArrival> NextArrivals
        {
            get { return arrivals; }
            set
            {
                arrivals = value.OrderBy(a => a.ExpectedArrival).Take(5).ToList();
            }
        }

        private List<BusArrival> arrivals;

        public override string ToString()
        {
            return $"{CommonName} is a {StopType} with code {Id}";
        }
        
    }
}
