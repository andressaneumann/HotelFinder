using HotelFinder.Models;
using HotelFinder.Services;
using NUnit.Framework;
using System.Collections.Generic;

namespace HotelFinder.UnitTests
{
    public class HotelBestOptionSearcherTests
    {
        private HotelBestOptionSearcher _hotelSearcher;

        [SetUp]
        public void Setup()
        {
            _hotelSearcher = new HotelBestOptionSearcher();
        }

        [Test]
        public void CalculateBestHotel_RegularClientWantsMondayTuesdayWednesday_ReturnsLakewood()
        {
            string userInput = "Regular: 16Mar2009(mon), 17Mar2009(tues), 18Mar2009(wed)";
            var result = _hotelSearcher.CalculateBestHotel(userInput);

            Assert.That(result == "Lakewood");
        }

        [Test]
        public void CalculateBestHotel_RegularClientWantsFridaySaturdaySunday_ReturnsBridgewood()
        {
            string userInput = "Regular: 20Mar2009(fri), 21Mar2009(sat), 22Mar2009(sun)";
            var result = _hotelSearcher.CalculateBestHotel(userInput);

            Assert.That(result == "Bridgewood");
        }

        [Test]
        public void CalculateBestHotel_RewardsClientWantsThursdayFridaySaturday_ReturnsRidgewood()
        {
            string userInput = "Rewards: 26Mar2009(thur), 27Mar2009(fri), 28Mar2009(sat)";
            var result = _hotelSearcher.CalculateBestHotel(userInput);

            Assert.That(result == "Ridgewood");
        }

        [Test]
        public void CheckingIfCustomerTypeIsValid_RegularCustomerIsValid_ReturnsTrue()
        {
            //Act
            string customerType = "regular";
            var result = _hotelSearcher.CheckingIfCustomerTypeIsValid(customerType);

            //Assert            
            Assert.That(result, Is.True);
        }

        [Test]
        public void CheckingIfCustomerTypeIsValid_RewardsCustomerIsValid_ReturnsTrue()
        {           
            string customerType = "rewards";
            var result = _hotelSearcher.CheckingIfCustomerTypeIsValid(customerType);

            Assert.That(result, Is.True);
        }

        [Test]
        public void CheckingIfCustomerTypeIsValid_InvalidCustomer_ReturnsFalse()
        {
            string customerType = "abc";
            var result = _hotelSearcher.CheckingIfCustomerTypeIsValid(customerType);

            Assert.That(result, Is.False);
        }

        [Test]
        public void SplitUserInput_WhenCalled_ReturnsAnArrayWithSplittedContent()
        {
            string userInput = "Regular: 16Mar2009(sat), 17Mar2009(tues), 18Mar2009(mon)";
            var result = _hotelSearcher.SplitUserInput(userInput);

            Assert.That(result.GetType() == typeof(string[]));            
        }

        [Test]
        public void GettingRequestedDays_WhenCalled_ReturnsAnListWithRequestedDays()
        {
            string[] spllitedInputs = new string[] { "regular", "16Mar2009", "mon", "17Mar2009", "tue", "18Mar2009", "wed" };

            List<string> result = _hotelSearcher.GettingRequestedDays(spllitedInputs);

            Assert.That(result[0] == "mon" && result[1] == "tue" && result[2] == "wed");
        }

        //[Test]
        //public void WeekTaxCalculation_RegularClient_ReturnsAHotelList()
        //{
        //    bool isRegular = true;

        //    List<Hotel> result = _hotelSearcher.WeekTaxCalculation(isRegular);

        //    Assert.That(result[0].Name == "Lakewood");
        //}

        //[Test]
        //public void WeekTaxCalculation_RewardClient_ReturnsAHotelList()
        //{
        //    bool isRegular = false;

        //    List<Hotel> result = _hotelSearcher.WeekTaxCalculation(isRegular);

        //    Assert.That(result[0].Name == "Lakewood");
        //}

        //[Test]
        //public void WeekendTaxCalculation_RegularClient_ReturnsAHotelList()
        //{
        //    bool isRegular = true;

        //    List<Hotel> result = _hotelSearcher.WeekTaxCalculation(isRegular);

        //    Assert.That(result[0].Name == "Lakewood");
        //}

        //[Test]
        //public void WeekendTaxCalculation_RewardClient_ReturnsAHotelList()
        //{
        //    bool isRegular = false;

        //    List<Hotel> result = _hotelSearcher.WeekTaxCalculation(isRegular);

        //    Assert.That(result[0].Name == "Lakewood");
        //}

        [Test]
        public void CheapestOption_WhenCalled_ShouldReturnAHotel()
        {
            var result = _hotelSearcher.CheapestOption();

            Assert.That(result.GetType() == typeof(Hotel));
        }

    }
}