using System.Collections.Generic;
namespace SmartRentCompass
{
    public class Apartment
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Bedrooms { get; set; }
        public int Bathrooms { get; set; }
        public double SquareFeet { get; set; }
        public List<string> Amenities { get; set; } = new List<string>();
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}