using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CurrencyConverter.Models;

namespace CurrencyConverter.Interfaces
{
    public interface ICurrenciesService
    {
        public Task<HashSet<ExchangeRate>> GetExchangeRates(DateTime date);
        public double GetExchangeRate(string @from, string to, DateTime date, double amount = 1);
    }
}