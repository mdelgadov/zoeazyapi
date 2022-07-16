//using System.Data.Entity.Spatial;

using System.ComponentModel.DataAnnotations;

namespace ZoEazy.Api.Model
{
    public class LatLng
    {
        [Required]
        public double Latitude { get; set; }
        [Required]
        public double Longitude { get; set; }
        public LatLng()
        {
            // the center of the earth, somewhere in the middle of the atlantic, next to coute d'ivorie
            // Latitude = 0;
            // Longitude = 0;
            // the (somewhat arbitrary) center of the USA, somewhere in the middle of kansas

            Latitude = 41.120235;
            Longitude = -100.314082;
        }
        public LatLng(double lat, double lng)
        {
            if (Invalid())
            {
                throw new System.ArgumentException(Properties.Resources.InvalidLatLng);
            }
            Latitude = lat;
            Longitude = lng;
        }
        public bool Valid()
        {
            return
                   Latitude >= -90 &&
                   Latitude <= 90 &&
                   Longitude >= -180 &&
                   Longitude <= 180;
        }
        public bool Invalid() { return !Valid(); }

    }
}