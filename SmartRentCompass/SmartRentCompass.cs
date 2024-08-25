using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartRentCompass
{
    public class SmartRentCompass
    {
        private List<Apartment> apartments;
        private List<User> users;
        private Dictionary<string, List<Alert>> alerts;

        public SmartRentCompass()
        {
            apartments = new List<Apartment>();
            users = new List<User>();
            alerts = new Dictionary<string, List<Alert>>();
        }

        public void AddApartment(Apartment apartment)
        {
            apartments.Add(apartment);
        }

        public void AddUser(User user)
        {
            users.Add(user);
        }

        public List<Apartment> SearchApartments(User user)
        {
            return apartments.Where(a =>
                a.Price >= (decimal)user.Preferences["minPrice"] &&
                a.Price <= (decimal)user.Preferences["maxPrice"] &&
                a.Bedrooms >= (int)user.Preferences["minBedrooms"] &&
                a.City.Equals((string)user.Preferences["city"], StringComparison.OrdinalIgnoreCase) &&
                a.State.Equals((string)user.Preferences["state"], StringComparison.OrdinalIgnoreCase)
            ).ToList();
        }

        public Dictionary<string, decimal> ComparePrices(List<string> apartmentIds)
        {
            return apartments
                .Where(a => apartmentIds.Contains(a.Id))
                .ToDictionary(a => a.Name, a => a.Price);
        }

        public void SetAlert(string userId, Dictionary<string, object> criteria)
        {
            if (!alerts.ContainsKey(userId))
            {
                alerts[userId] = new List<Alert>();
            }
            alerts[userId].Add(new Alert { Criteria = criteria, CreatedAt = DateTime.Now });
        }

        public void CheckAlerts()
        {
            foreach (var user in users)
            {
                if (alerts.ContainsKey(user.Id))
                {
                    foreach (var alert in alerts[user.Id])
                    {
                        var matches = SearchApartments(new User { Preferences = alert.Criteria });
                        if (matches.Any())
                        {
                            Console.WriteLine($"Alert for user {user.Name}: {matches.Count} new matches found!");
                            foreach (var match in matches)
                            {
                                Console.WriteLine($"- {match.Name}: ${match.Price}");
                            }
                        }
                    }
                }
            }
        }

        public double GetCrimeRate(string city, string state)
        {
            // Simulated crime rate data
            var random = new Random();
            return random.NextDouble() * 100;
        }

        public bool CheckCreditAndIncome(User user, Apartment apartment)
        {
            // Simple credit and income check
            return user.CreditScore >= 600 && user.Income >= apartment.Price * 12 * 3;
        }

        public double CalculateProximity(Apartment apt1, Apartment apt2)
        {
            const double EarthRadius = 6371; // in kilometers

            var lat1 = ToRadians(apt1.Latitude);
            var lon1 = ToRadians(apt1.Longitude);
            var lat2 = ToRadians(apt2.Latitude);
            var lon2 = ToRadians(apt2.Longitude);

            var dLat = lat2 - lat1;
            var dLon = lon2 - lon1;

            var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                    Math.Cos(lat1) * Math.Cos(lat2) *
                    Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            return EarthRadius * c;
        }

        private double ToRadians(double degrees)
        {
            return degrees * Math.PI / 180;
        }

        public List<string> GetPriceOptimizationTips(Apartment apartment)
        {
            var tips = new List<string>();
            var similarApartments = apartments.Where(a =>
                a.City == apartment.City &&
                a.Bedrooms == apartment.Bedrooms &&
                Math.Abs(a.SquareFeet - apartment.SquareFeet) < 100
            ).ToList();

            var avgPrice = similarApartments.Average(a => a.Price);

            if (apartment.Price > avgPrice)
            {
                tips.Add($"The price is above average for similar apartments. Consider negotiating.");
            }

            tips.Add("Ask about discounts for longer lease terms.");
            tips.Add("Inquire about move-in specials or promotions.");

            if (apartment.Amenities.Count > 3)
            {
                tips.Add("This apartment offers multiple amenities. Ensure you're utilizing them to get full value.");
            }

            return tips;
        }
    }

    public class Alert
    {
        public Dictionary<string, object> Criteria { get; set; } = new Dictionary<string, object>();
        public DateTime CreatedAt { get; set; }
    }
}