using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BusWireMVC.Models
{
    public class Postcode
    {
        public static bool IsValidPostcode(string postCode)
        {
            // This will match UK postcodes (though it may give 
            // false positives for some invalid codes).
            // Source: http://stackoverflow.com/questions/164979/uk-postcode-regex-comprehensive
            Regex postRegex = new Regex("(GIR 0AA)|((([A-Z-[QVX]][0-9][0-9]?)|(([A-Z-[QVX]][A-Z-[IJZ]][0-9][0-9]?)|(([A-Z-[QVX]][0-9][A-HJKPSTUW])|([A-Z-[QVX]][A-Z-[IJZ]][0-9][ABEHMNPRVWXY])))) [0-9][A-Z-[CIKMOV]]{2})");
            return postRegex.IsMatch(postCode);
        }

        public Postcode(string postCode)
        {
            PostCode = postCode;
        }

        public Postcode()
        {
            // Parameterless constructor required for deserialization
        }

        public string PostCode { get; set; }
        public string Country { get; set; }
        public string ParliamentaryConstituency { get; set; }
        public string AdminWard { get; set; }

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

        private MapCoord Location = new MapCoord(0,0);

        public override string ToString()
        {
            return $"{PostCode} is in {AdminWard}, {Country}, at [{Latitude}, {Longitude}], in {ParliamentaryConstituency}.";
        }

    }
}
