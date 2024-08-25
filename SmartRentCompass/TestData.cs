using System;
using System.Collections.Generic;

namespace SmartRentCompass
{
    public static class TestData
    {
        public static List<Apartment> GetTestApartments()
        {
            return new List<Apartment>
            {
                new Apartment
                {
                    Id = "A001",
                    Name = "Sunny Side Apartments",
                    Address = "123 Main St",
                    City = "Austin",
                    State = "TX",
                    Price = 1200m,
                    Bedrooms = 2,
                    Bathrooms = 1,
                    SquareFeet = 800,
                    Amenities = new List<string> { "Pool", "Gym", "Parking" },
                    Latitude = 30.2672,
                    Longitude = -97.7431
                },
                new Apartment
                {
                    Id = "A002",
                    Name = "Downtown Lofts",
                    Address = "456 Congress Ave",
                    City = "Austin",
                    State = "TX",
                    Price = 1800m,
                    Bedrooms = 1,
                    Bathrooms = 1,
                    SquareFeet = 650,
                    Amenities = new List<string> { "Rooftop Terrace", "Pet Friendly", "Bike Storage" },
                    Latitude = 30.2657,
                    Longitude = -97.7453
                },
                new Apartment
                {
                    Id = "A003",
                    Name = "Green Valley Residences",
                    Address = "789 Oak Rd",
                    City = "Austin",
                    State = "TX",
                    Price = 1500m,
                    Bedrooms = 2,
                    Bathrooms = 2,
                    SquareFeet = 950,
                    Amenities = new List<string> { "Garden", "Playground", "Laundry Facility" },
                    Latitude = 30.2772,
                    Longitude = -97.7381
                },
                new Apartment
                {
                    Id = "A004",
                    Name = "Tech Hub Apartments",
                    Address = "101 Silicon Hills Blvd",
                    City = "Austin",
                    State = "TX",
                    Price = 2200m,
                    Bedrooms = 3,
                    Bathrooms = 2,
                    SquareFeet = 1200,
                    Amenities = new List<string> { "Co-working Space", "Smart Home Features", "EV Charging" },
                    Latitude = 30.2742,
                    Longitude = -97.7407
                },
                new Apartment
                {
                    Id = "A005",
                    Name = "Riverside Retreat",
                    Address = "222 Waterfront Dr",
                    City = "Austin",
                    State = "TX",
                    Price = 1700m,
                    Bedrooms = 2,
                    Bathrooms = 2,
                    SquareFeet = 900,
                    Amenities = new List<string> { "River View", "Kayak Rental", "Fitness Center" },
                    Latitude = 30.2562,
                    Longitude = -97.7477
                }
            };
        }

        public static List<User> GetTestUsers()
        {
            return new List<User>
            {
                new User
                {
                    Id = "U001",
                    Name = "Alice Johnson",
                    Email = "alice@example.com",
                    City = "Austin",
                    State = "TX",
                    CreditScore = 720,
                    Income = 65000m,
                    Preferences = new Dictionary<string, object>
                    {
                        { "minPrice", 1000m },
                        { "maxPrice", 1500m },
                        { "minBedrooms", 1 },
                        { "city", "Austin" },
                        { "state", "TX" }
                    }
                },
                new User
                {
                    Id = "U002",
                    Name = "Bob Smith",
                    Email = "bob@example.com",
                    City = "Austin",
                    State = "TX",
                    CreditScore = 680,
                    Income = 55000m,
                    Preferences = new Dictionary<string, object>
                    {
                        { "minPrice", 800m },
                        { "maxPrice", 1200m },
                        { "minBedrooms", 2 },
                        { "city", "Austin" },
                        { "state", "TX" }
                    }
                },
                new User
                {
                    Id = "U003",
                    Name = "Charlie Brown",
                    Email = "charlie@example.com",
                    City = "Austin",
                    State = "TX",
                    CreditScore = 750,
                    Income = 80000m,
                    Preferences = new Dictionary<string, object>
                    {
                        { "minPrice", 1500m },
                        { "maxPrice", 2500m },
                        { "minBedrooms", 2 },
                        { "city", "Austin" },
                        { "state", "TX" }
                    }
                }
            };
        }
    }
}