using System;
using Test.Models;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {  //DateTime dt = new DateTime(2009, 03, 13);

            //var dayOfWeek = dt.DayOfWeek;

            //Console.WriteLine(dayOfWeek.ToString());

            Console.WriteLine("Please enter the client type and the requested dates, respectively: ");
            string userInput = Console.ReadLine();

            Logic operation = new Logic();
            var result = operation.CalculateBestHotel(userInput);            

            //Hotel Lakewood = new Hotel("Lakewood", 3, )
        }
        
    }
}
