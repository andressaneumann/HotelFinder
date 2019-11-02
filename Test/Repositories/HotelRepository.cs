using System;
using System.Collections.Generic;
using System.Text;
using Test.Models;

namespace Test.Repositories
{
    public static class HotelRepository
    {
        public static List<Hotel> GetAvailableHotels()
        {
            return new List<Hotel>()
            {
                new Hotel()
                {
                    Name = "Lakewood",
                    ClassificationLevel = 3,
                    WeekTaxValueRegularClient = 110,
                    WeekTaxValueFidelityClient = 80,
                    WeekendTaxValueRegularClient = 90,
                    WeekendTaxValueFidelityClient = 80
                },

                new Hotel()
                {
                    Name = "Bridgewood",
                    ClassificationLevel = 4,
                    WeekTaxValueRegularClient = 160,
                    WeekTaxValueFidelityClient = 110,
                    WeekendTaxValueRegularClient = 60,
                    WeekendTaxValueFidelityClient = 50
                },

                new Hotel()
                {
                    Name = "Ridgewood",
                    ClassificationLevel = 5,
                    WeekTaxValueRegularClient = 220,
                    WeekTaxValueFidelityClient = 100,
                    WeekendTaxValueRegularClient = 150,
                    WeekendTaxValueFidelityClient = 40
                }
            };
        }
    }
}
