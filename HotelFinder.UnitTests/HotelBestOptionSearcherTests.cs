using HotelFinder.Services;
using NUnit.Framework;

namespace HotelFinder.UnitTests
{
    public class HotelBestOptionSearcherTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CheckingIfCustomerTypeIsValid_RegularCustomerIsValid_ReturnsTrue()
        {
            //Arrange
            var hotelSearcher = new HotelBestOptionSearcher();

            //Act
            string customerType = "regular";
            var result = hotelSearcher.CheckingIfCustomerTypeIsValid(customerType);

            //Assert            
            Assert.That(result, Is.True);
        }

        [Test]
        public void CheckingIfCustomerTypeIsValid_RewardsCustomerIsValid_ReturnsTrue()
        {            
            var hotelSearcher = new HotelBestOptionSearcher();

            string customerType = "rewards";
            var result = hotelSearcher.CheckingIfCustomerTypeIsValid(customerType);

            Assert.That(result, Is.True);
        }

        [Test]
        public void CheckingIfCustomerTypeIsValid_InvalidCustomer_ReturnsFalse()
        {
            var hotelSearcher = new HotelBestOptionSearcher();

            string customerType = "invalid";
            var result = hotelSearcher.CheckingIfCustomerTypeIsValid(customerType);

            Assert.That(result, Is.False);
        }


    }
}