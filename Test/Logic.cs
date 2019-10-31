using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Test.Models;

namespace Test
{
    public class Logic
    {
        public string CalculateBestHotel(string userInput)
        {
            string[] splittedUserInputs = SplitUserInput(userInput);

            foreach (var word in splittedUserInputs)
                Console.WriteLine(word);

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
