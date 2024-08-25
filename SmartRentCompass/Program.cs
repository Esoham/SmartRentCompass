using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartRentCompass
{
    class Program
    {
        static void Main(string[] args)
        {
            var compass = new SmartRentCompass();

            // Add test apartments
            foreach (var apartment in TestData.GetTestApartments())
            {
                compass.AddApartment(apartment);
            }

            // Add test users
            foreach (var user in TestData.GetTestUsers())
            {
                compass.AddUser(user);
            }

            Console.WriteLine("Welcome to SmartRentCompass!");
            Console.WriteLine("----------------------------");

            foreach (var user in TestData.GetTestUsers())
            {
                Console.WriteLine($"\nProcessing user: {user.Name}");

                // Perform apartment search
                Console.WriteLine("\nSearching for apartments...");
                var searchResults = compass.SearchApartments(user);
                DisplayApartmentsSummary(searchResults);

                // Compare prices for top 5 apartments
                if (searchResults.Any())
                {
                    Console.WriteLine("\nComparing prices for top 5 apartments:");
                    var top5 = searchResults.OrderBy(a => a.Price).Take(5).ToList();
                    var priceComparison = compass.ComparePrices(top5.Select(a => a.Id).ToList());
                    foreach (var comparison in priceComparison)
                    {
                        Console.WriteLine($"{comparison.Key}: ${comparison.Value}");
                    }
                }

                // Set and check alerts
                Console.WriteLine("\nSetting up an alert...");
                compass.SetAlert(user.Id, user.Preferences);
                Console.WriteLine("Checking alerts...");
                compass.CheckAlerts();

                // Check crime rate
                Console.WriteLine($"\nChecking crime rate for {user.City}...");
                var crimeRate = compass.GetCrimeRate(user.City, user.State);
                Console.WriteLine($"Crime rate in {user.City}, {user.State}: {crimeRate:F2}");

                // Check credit and income for the first apartment
                if (searchResults.Any())
                {
                    var firstApartment = searchResults.First();
                    Console.WriteLine("\nChecking credit and income...");
                    var isEligible = compass.CheckCreditAndIncome(user, firstApartment);
                    Console.WriteLine($"User is {(isEligible ? "eligible" : "not eligible")} for {firstApartment.Name}");
                }

                // Calculate proximity between first two apartments
                if (searchResults.Count >= 2)
                {
                    Console.WriteLine("\nCalculating proximity...");
                    var distance = compass.CalculateProximity(searchResults[0], searchResults[1]);
                    Console.WriteLine($"Distance between {searchResults[0].Name} and {searchResults[1].Name}: {distance:F2} km");
                }

                // Get price optimization tips
                if (searchResults.Any())
                {
                    Console.WriteLine("\nPrice optimization tips for the first search result:");
                    var tips = compass.GetPriceOptimizationTips(searchResults.First());
                    foreach (var tip in tips)
                    {
                        Console.WriteLine($"- {tip}");
                    }
                }

                Console.WriteLine("\n---------------------------------");
            }

            // Add this line to keep the console window open
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        static void DisplayApartmentsSummary(List<Apartment> apartments)
        {
            if (apartments.Count == 0)
            {
                Console.WriteLine("No apartments found matching your criteria.");
            }
            else
            {
                Console.WriteLine($"Found {apartments.Count} matching apartments. Top 5 results:");
                foreach (var apt in apartments.OrderBy(a => a.Price).Take(5))
                {
                    Console.WriteLine($"{apt.Name} - {apt.City}, {apt.State}");
                    Console.WriteLine($"Price: ${apt.Price}, Bedrooms: {apt.Bedrooms}, Bathrooms: {apt.Bathrooms}");
                    Console.WriteLine($"Square Feet: {apt.SquareFeet}, Key Amenities: {string.Join(", ", apt.Amenities.Take(3))}");
                    Console.WriteLine();
                }
            }
        }
    }
}