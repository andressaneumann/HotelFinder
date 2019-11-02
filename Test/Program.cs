using System;
using Test.Models;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the client type and the requested dates, respectively: ");
            string userInput = Console.ReadLine();

            Logic operation = new Logic();
            var result = operation.CalculateBestHotel(userInput);

            if (result == "Invalid")
                Console.WriteLine("Invalid customer type.");
            else
                Console.WriteLine(result);
        }        
    }
}
