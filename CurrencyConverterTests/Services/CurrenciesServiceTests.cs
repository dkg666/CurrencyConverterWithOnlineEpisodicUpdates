using System;
using System.Threading.Tasks;
using CurrencyConverter.Repositories;
using CurrencyConverter.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CurrencyConverterTests.Services
{
    [TestClass()]
    public class CurrenciesServiceTests
    {
        [TestMethod("GetExchangeRates returns null if date is below 2000")]
        public void GetExchangeRates_ReturnsNull_IfDateIsBelow2000_Test()
        {
            //Arrange
            var repository = new CurrenciesRepository();
            var service = new CurrenciesService(repository);

            //Act
            var exchangeRates = service.GetExchangeRates(new DateTime(1998, 01 ,01));

            Assert.IsNull(exchangeRates);
        }

        [TestMethod("GetExchangeRate_Tests")]
        [DataRow("", "", 0)]
        [DataRow(" ", " ", 0)]
        [DataRow(null, null, 0)]
        [DataRow("EUR", "EUR", 1)]
        public void GetExchangeRateTest(string from, string to, double amount)
        {
            //Arrange
            var repository = new CurrenciesRepository();
            var service = new CurrenciesService(repository);

            //Act
            var rate = service.GetExchangeRate(from, to, DateTime.Now, amount);

            //Assert
            Assert.AreEqual(amount, rate);
        }
    }
}