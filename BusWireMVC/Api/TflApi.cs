using RestSharp;
using BusWireMVC.Properties;

namespace BusWireMVC
{

    public abstract class TflApi<T> : ApiHandler<T> where T : new()
    {
        private string _accountId = Resources.TflAccountId;
        private string _secretKey = Resources.TflKey;

        private const string BaseUrl = "https://api.tfl.gov.uk";

        public T Execute(RestRequest request)
        {
            request.AddParameter("app_id", _accountId);
            request.AddParameter("app_key", _secretKey);
            return Execute(request, BaseUrl);
        }

    }
}
