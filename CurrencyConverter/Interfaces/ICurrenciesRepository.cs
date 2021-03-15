﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CurrencyConverter.Models;

namespace CurrencyConverter.Interfaces
{
    public interface ICurrenciesRepository
    {
        public double? GetCurrencyRateInEuro(string currency, DateTime date);
        public Task<HashSet<ExchangeRate>> GetExchangeRates(DateTime date);
    }
}