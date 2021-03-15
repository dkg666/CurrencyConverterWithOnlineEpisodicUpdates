using System;
using System.Threading.Tasks;
using CurrencyConverter.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CurrencyConverterTests.Repositories
{
    [TestClass()]
    public class CurrenciesRepositoryTests
    {
        [TestMethod("GetCurrencyRateInEuro Returns Null If Cache Is Empty")]
        public void GetCurrencyRateInEuroReturnsNull_IfCacheIsEmptyTest()
        {
            //Arrange
            var repository = new CurrenciesRepository();

            //Act
            var exchangeRate = repository.GetCurrencyRateInEuro("USD", DateTime.Now);

            //Assert
            Assert.IsNull(exchangeRate);
        }

        [TestMethod("GetCurrencyRateInEuro Returns Not Null If Cache Was Prefilled")]
        public async Task GetCurrencyRateInEuroReturnsNull_IfCacheIsNotEmptyTest()
        {
            //Arrange
            var repository = new CurrenciesRepository();

            //Act
            var exchangeRates = await repository.GetExchangeRates(DateTime.Now);
            var exchangeRate = repository.GetCurrencyRateInEuro("USD", DateTime.Now);

            //Assert
            Assert.IsNotNull(exchangeRate);
        }

        [TestMethod("Current date exchange rates should always be available")]
        public async Task GetExchangeRatesTest()
        {
            //Arrange
            var repository = new CurrenciesRepository();

            //Act
            var exchangeRates = await repository.GetExchangeRates(DateTime.Now);

            //Assert
            Assert.IsNotNull(exchangeRates);
        }
    }
}