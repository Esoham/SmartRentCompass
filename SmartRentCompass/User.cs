using System.Collections.Generic;

namespace SmartRentCompass
{
    public class User
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public int CreditScore { get; set; }
        public decimal Income { get; set; }
        public Dictionary<string, object> Preferences { get; set; } = new Dictionary<string, object>();
    }
}