using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using HotelFinder.Models;
using HotelFinder.Repositories;

namespace HotelFinder.Services
{
    public class HotelBestOptionSearcher
    {
        //Getting all hotels from repository
        List<Hotel> _availableHotels = HotelRepository.GetAvailableHotels();

        //Function to calculate the best hotel option - uses the auxiliary functions to find the best option
        public string CalculateBestHotel(string userInput)
        {
            string[] splittedUserInputs = SplitUserInput(userInput);
            string customerType = splittedUserInputs[0].ToLower();

            if (!CheckingIfCustomerTypeIsValid(customerType))
                return "Invalid";

            List<string> requestedDays = GettingRequestedDays(splittedUserInputs);

            CheckingCustomerTypeAndDayOfTheWeek(requestedDays, customerType);
            Hotel bestOption = CheapestOption();

            return bestOption.Name;
        }

        //Validation of the customer type
        public bool CheckingIfCustomerTypeIsValid(string customerType)
        {
            return (customerType == "regular" || customerType == "rewards");
        }

        //This function splits the user input into an array of relevant information
        public string[] SplitUserInput(string userInput)
        {
            string[] separators = { ": ", "(", ")", ","," " };            
            string[] splittedUserInputs = userInput.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            return splittedUserInputs;
        }

        //This function extracts the days that the user inserted on the input
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

        //Here we determine the customer type and the specified day of the week, 
        //and pass the necessary information to the correct function
        public void CheckingCustomerTypeAndDayOfTheWeek(List<string> requestedDays, string customerType)
        {
            bool isRegular = customerType == "regular" ? true : false;

            foreach (var day in requestedDays)
            {
                if (day == "sat" || day == "sun")                
                    WeekendTaxCalculation(isRegular);                
                else                
                    WeekTaxCalculation(isRegular);                                                    
            }
        }

        //Calculates the Weekend tax value for a regular or fidelity client
        public List<Hotel> WeekendTaxCalculation(bool isRegular)
        {
            if (isRegular)
            {
                foreach (Hotel hotel in _availableHotels)
                    hotel.TotalValueReservation += hotel.WeekendTaxValueRegularClient;               

                return _availableHotels;
            }

            foreach (Hotel hotel in _availableHotels)
                hotel.TotalValueReservation += hotel.WeekendTaxValueFidelityClient;     
            
            return _availableHotels;
        }

        //Calculates the Week tax value for a regular or fidelity client
        public List<Hotel> WeekTaxCalculation(bool isRegular)
        {
            if (isRegular)
            {
                foreach (Hotel hotel in _availableHotels)                
                    hotel.TotalValueReservation += hotel.WeekTaxValueRegularClient;                

                return _availableHotels;
            }

            foreach (Hotel hotel in _availableHotels)            
                hotel.TotalValueReservation += hotel.WeekTaxValueFidelityClient;
            
            return _availableHotels;
        }

        //Checks the best option for the client
        public Hotel CheapestOption() 
        {
            List<Hotel> allHotels = _availableHotels;

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
