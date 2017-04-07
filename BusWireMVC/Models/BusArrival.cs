using System;

namespace BusWireMVC.Models
{
    public class BusArrival
    {
        public string VehicleId { get; set; }
        public string StationName { get; set; }
        public string LineId { get; set; }
        public string LineName { get; set; }
        public string Direction { get; set; }
        public string Towards { get; set; }
        public string DestinationName { get; set; }
        public int TimeToStation { get; set; }
        public DateTime ExpectedArrival { get; set; }

        public override string ToString()
        {
            return $"Bus {LineName} will arrive at {StationName} in {(int)(ExpectedArrival - DateTime.Now).TotalMinutes} minutes, heading towards {Towards}";
        }

        public string UntilArrival()
        {
            TimeSpan untilSpan = ExpectedArrival - DateTime.Now;
            return $"{(int)untilSpan.TotalMinutes} mins {untilSpan.Seconds} secs";
        }
    }
}
