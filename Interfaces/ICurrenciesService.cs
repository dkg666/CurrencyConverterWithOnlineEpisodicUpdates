using Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface ICurrenciesService
    {
        public Task<HashSet<ExchangeRate>> GetExchangeRates(DateTime date);
        public double GetExchangeRate(string from, string to, DateTime date, double amount = 1);
    }
}