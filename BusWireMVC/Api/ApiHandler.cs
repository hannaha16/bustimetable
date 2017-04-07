using System;
using RestSharp;
using System.Net;

namespace BusWireMVC
{
    public abstract class ApiHandler<T> where T : new()
    {
        public T Execute(RestRequest request, string baseUrl)
        {
            var client = new RestClient
            {
                BaseUrl = new Uri(baseUrl),
            };
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            var response = client.Execute<T>(request);

            if (response.ErrorException != null)
            {
                const string message = "Error retrieving response.  Check inner details for more info.";
                var tflException = new Exception(message, response.ErrorException);
                throw tflException;
            }
            return response.Data;
        }

    }
}