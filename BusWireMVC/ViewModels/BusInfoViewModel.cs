using System.Collections.Generic;
using BusWireMVC.Models;

namespace BusWireMVC.ViewModels
{
    public class BusInfoViewModel
    {
        public List<BusStop> BusStops;

        private readonly ArrivalApi arrivalApi = new ArrivalApi();
        private readonly StopApi stopApi = new StopApi();
        private readonly PostcodeApi pApi = new PostcodeApi();


        public Postcode PostCode { get; set; }

        public BusInfoViewModel(string postCode)
        {
            PostCode = pApi.GetPostcodeInfo(postCode);
        }

        public void Update()
        {
            BusStops = stopApi.GetStopsNear(PostCode);
            foreach (BusStop b in BusStops)
            {
                b.NextArrivals = arrivalApi.GetBusArrivals(b.Id);
            }
        }

    }
}