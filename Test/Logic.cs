using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Test.Models;

namespace Test
{
    public class Logic
    {
        Hotel Lakewood = new Hotel()
        {
            Name = "Lakewood",
            ClassificationLevel = 3,
            WeekTaxValueRegularClient = 110,
            WeekTaxValueFidelityClient = 80,
            WeekendTaxValueRegularClient = 90,
            WeekendTaxValueFidelityClient = 80
        };

        Hotel Bridgewood = new Hotel()
        {
            Name = "Bridgewood",
            ClassificationLevel = 4,
            WeekTaxValueRegularClient = 160,
            WeekTaxValueFidelityClient = 110,
            WeekendTaxValueRegularClient = 60,
            WeekendTaxValueFidelityClient = 50
        };

        Hotel Ridgewood = new Hotel()
        {
            Name = "Ridgewood",
            ClassificationLevel = 5,
            WeekTaxValueRegularClient = 220,
            WeekTaxValueFidelityClient = 100,
            WeekendTaxValueRegularClient = 150,
            WeekendTaxValueFidelityClient = 40
        };

        public string CalculateBestHotel(string userInput)
        {
            string[] splittedUserInputs = SplitUserInput(userInput);
            string customerType = splittedUserInputs[0].ToLower();

            if (customerType != "regular" && customerType != "rewards")
            {
                return "Invalid";
            }

            List<string> requestedDays = GettingRequestedDays(splittedUserInputs);

            CustomerHotelsTaxValues(requestedDays, customerType);
            Hotel bestOption = CheapestOption();

            return bestOption.Name;
        }

        public string[] SplitUserInput(string userInput)
        {
            string[] separators = { ": ", "(", ")", ","," " };            
            string[] splittedUserInputs = userInput.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            return splittedUserInputs;
        }

        public List<string> GettingRequestedDays(string[] splittedUserInputs)
        {
            List<string> daysOfTheWeek = new List<string>();
            var numberOfEntriesOnUserInput = splittedUserInputs.Length;

            for (int i = 1; i <= numberOfEntriesOnUserInput; i++)
            {
                if (i % 2 == 0)
                    daysOfTheWeek.Add(splittedUserInputs[i].ToLower());
            }

            return daysOfTheWeek;
        }

        public void CustomerHotelsTaxValues(List<string> requestedDays, string customerType)
        {
            foreach (var day in requestedDays)
            {
                switch (customerType)
                {
                    case "regular":

                        if (day == "sat" || day == "sun")
                        {
                            Lakewood.TotalValueReservation += Lakewood.WeekendTaxValueRegularClient;
                            Bridgewood.TotalValueReservation += Bridgewood.WeekendTaxValueRegularClient;
                            Ridgewood.TotalValueReservation += Ridgewood.WeekendTaxValueRegularClient;
                        }
                        else
                        {
                            Lakewood.TotalValueReservation += Lakewood.WeekTaxValueRegularClient;
                            Bridgewood.TotalValueReservation += Bridgewood.WeekTaxValueRegularClient;
                            Ridgewood.TotalValueReservation += Ridgewood.WeekTaxValueRegularClient;
                        }

                        break;

                    case "rewards":

                        if (day == "sat" || day == "sun")
                        {
                            Lakewood.TotalValueReservation += Lakewood.WeekendTaxValueFidelityClient;
                            Bridgewood.TotalValueReservation += Bridgewood.WeekendTaxValueFidelityClient;
                            Ridgewood.TotalValueReservation += Ridgewood.WeekendTaxValueFidelityClient;
                        }
                        else
                        {
                            Lakewood.TotalValueReservation += Lakewood.WeekTaxValueFidelityClient;
                            Bridgewood.TotalValueReservation += Bridgewood.WeekTaxValueFidelityClient;
                            Ridgewood.TotalValueReservation += Ridgewood.WeekTaxValueFidelityClient;
                        }

                        break;
                }                
            }
        }

        public Hotel CheapestOption() 
        {
            List<Hotel> allHotels = new List<Hotel>();
            allHotels.Add(Lakewood);
            allHotels.Add(Bridgewood);
            allHotels.Add(Ridgewood);

            Hotel CheapestHotel = new Hotel
            {
                Name = allHotels[0].Name,
                ClassificationLevel = allHotels[0].ClassificationLevel,
                TotalValueReservation = allHotels[0].TotalValueReservation
            };

            foreach (var hotel in allHotels)
            {
                if(hotel.TotalValueReservation < CheapestHotel.TotalValueReservation)
                {
                    CheapestHotel.TotalValueReservation = hotel.TotalValueReservation;
                    CheapestHotel.Name = hotel.Name;
                    CheapestHotel.ClassificationLevel = hotel.ClassificationLevel;
                }
                else
                {
                    if(hotel.TotalValueReservation == CheapestHotel.TotalValueReservation)
                    {                        
                        if(hotel.ClassificationLevel > CheapestHotel.ClassificationLevel)
                        {
                            CheapestHotel.Name = hotel.Name;
                            CheapestHotel.ClassificationLevel = hotel.ClassificationLevel;
                            CheapestHotel.TotalValueReservation = hotel.TotalValueReservation;
                        }                            
                    }
                }
            }

            return CheapestHotel;
        }
    }
}
