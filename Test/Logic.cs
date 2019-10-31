using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Test.Models;

namespace Test
{
    public class Logic
    {

        float LakewoodWeekTaxRegularCustomer = 110;
        float LakewoodWeekTaxFidelityCustomer = 80;
        float LakewoodWeekendTaxRegularCustomer = 90;
        float LakewoodWeekendTaxFidelityCustomer = 80;


        float BridgewoodWeekTaxRegularCustomer = 160;
        float BridgewoodWeekTaxFidelityCustomer = 110;
        float BridgewoodWeekendTaxRegularCustomer = 60;
        float BridgewoodWeekendTaxFidelityCustomer = 50;

        float RidgewoodWeekTaxRegularCustomer = 220;
        float RidgewoodWeekTaxFidelityCustomer = 100;
        float RidgewoodWeekendTaxRegularCustomer = 150;
        float RidgewoodWeekendTaxFidelityCustomer = 40;

        string[] dayOfTheWeek;

        public string CalculateBestHotel(string userInput)
        {        

            string[] splittedUserInputs = SplitUserInput(userInput);
            string CustomerType = splittedUserInputs[0];

            var numberOfEntriesOnUserInput = splittedUserInputs.Length;
            for(int i = 1; i <= numberOfEntriesOnUserInput; i++)
            {
                if (i % 2 == 0)
                    dayOfTheWeek[d] = splittedUserInputs[i];

                d++;
            }

            foreach (var day in dayOfTheWeek)
                Console.WriteLine(day);

            return "a";
        }

        public string[] SplitUserInput(string userInput)
        {
            string[] separators = { ": ", "(", ")", ","," " };            
            string[] splittedUserInputs = userInput.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            return splittedUserInputs;
        }
    }
}
