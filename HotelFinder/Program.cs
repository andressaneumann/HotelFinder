using System;
using HotelFinder.Models;
using HotelFinder.Services;

namespace HotelFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the client type and the requested dates, respectively: ");
            string userInput = Console.ReadLine();

            HotelBestOptionSearcher operation = new HotelBestOptionSearcher();
            var result = operation.CalculateBestHotel(userInput);

            var output = result == "Invalid" ? "Invalid customer" : result;

            Console.WriteLine(result);
        }        
    }
}
