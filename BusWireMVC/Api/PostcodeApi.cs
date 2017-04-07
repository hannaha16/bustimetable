using System;
using System.Text.RegularExpressions;
using BusWireMVC.Models;
using RestSharp;

namespace BusWireMVC
{
    class PostcodeApi : ApiHandler<Postcode>
    {
        private const string BaseUrl = "http://api.postcodes.io";

        public Postcode GetPostcodeInfo(String postcode)
        {
            var request = new RestRequest
            {
                Resource = $"postcodes/{postcode}",
                RootElement = "result"
            };
            return Execute(request, BaseUrl);
        }
    }
}
