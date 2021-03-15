using Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public class CurrenciesService : ICurrenciesService
    {
        private readonly ICurrenciesRepository _currenciesRepository;

        public CurrenciesService(ICurrenciesRepository currenciesRepository)
        {
            _currenciesRepository = currenciesRepository;
        }

        public Task<HashSet<ExchangeRate>> GetExchangeRates(DateTime date)
        {
            if (date < new DateTime(2000, 01, 01))
                return null;

            return _currenciesRepository.GetExchangeRates(date);
        }

        public double GetExchangeRate(string from, string to, DateTime date, double amount = 1)
        {
            if (string.IsNullOrWhiteSpace(from) || string.IsNullOrWhiteSpace(to))
                return 0;

            if (from.Equals("EUR", StringComparison.InvariantCultureIgnoreCase) && to.Equals("EUR", StringComparison.InvariantCultureIgnoreCase))
                return amount;

            try
            {
                var toRate = _currenciesRepository.GetCurrencyRateInEuro(to, date);
                var fromRate = _currenciesRepository.GetCurrencyRateInEuro(from, date);

                if (from.Equals("EUR", StringComparison.InvariantCultureIgnoreCase) && toRate.HasValue) 
                    return amount * toRate.Value;

                if (to.Equals("EUR", StringComparison.InvariantCultureIgnoreCase) && fromRate.HasValue)
                    return amount / fromRate.Value;

                if (toRate.HasValue && fromRate.HasValue && fromRate.Value > 0) 
                    return amount * toRate.Value / fromRate.Value;
            }
            catch { return 0; }

            return 0;
        }
    }
}
