namespace BusWireMVC.Models
{
    public class MapCoord
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public MapCoord(double newLongitude, double newLatitude)
        {
            this.Longitude = newLongitude;
            this.Latitude = newLatitude;
        }

        public override string ToString()
        {
            return $"{Longitude}, {Latitude}";
        }
    }
}
