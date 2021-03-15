using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using CurrencyConverter.Interfaces;
using CurrencyConverter.Models;
using CurrencyConverter.Models.ApiModels;

namespace CurrencyConverter.Repositories
{
    public class CurrenciesRepository : ICurrenciesRepository
    {
        private readonly HttpClient _exchangeRatesHttpClient;

        private const string BaseExchangeRatesApiUrl = @"https://api.exchangeratesapi.io/";

        private readonly Dictionary<string, HashSet<ExchangeRate>> _exchangeRatesCache = new();

        public CurrenciesRepository()
        {
            if (string.IsNullOrWhiteSpace(BaseExchangeRatesApiUrl))
                throw new ArgumentNullException(BaseExchangeRatesApiUrl);

            _exchangeRatesHttpClient = new HttpClient
            {
                BaseAddress = new Uri(BaseExchangeRatesApiUrl)
            };
        }

        public double? GetCurrencyRateInEuro(string currency, DateTime date)
        {
            if (_exchangeRatesCache.TryGetValue(date.Date.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture), out var rates))
            {
                var exchangeRate = rates.FirstOrDefault(r =>
                    r.Currency.Equals(currency, StringComparison.InvariantCultureIgnoreCase))?.Rate;
                
                return exchangeRate;
            }

            return null;
        }

        public async Task<HashSet<ExchangeRate>> GetExchangeRates(DateTime date)
        {
            if (_exchangeRatesCache.TryGetValue(date.Date.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture), out var rates))
            {
                return rates;
            }

            var dateRates = await GetJsonFromContent<ExchangeRates>("/"+date.Date.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture), new CancellationToken());

            var currencyRates = new HashSet<ExchangeRate>();
            foreach (var propertyInfo in dateRates.Rates.GetType().GetProperties())
            {
                currencyRates.Add(new ExchangeRate
                {
                    Currency = propertyInfo.Name.ToUpperInvariant(),
                    Rate = propertyInfo.GetValue(dateRates.Rates) is double ? (double)propertyInfo.GetValue(dateRates.Rates) : 0.0
                });
            }

            _exchangeRatesCache.TryAdd(date.Date.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture), currencyRates);
            return currencyRates;
        }

        private async Task<T> GetJsonFromContent<T>(string uri, CancellationToken cancellationToken) where T : class
        {
            var request = new HttpRequestMessage(HttpMethod.Get, uri);
            request.Headers.TryAddWithoutValidation("some-header", "some-value");

            var response = await _exchangeRatesHttpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken);

            if (!response.IsSuccessStatusCode) return null;

            try
            {
                return await response.Content.ReadFromJsonAsync<T>(cancellationToken: cancellationToken);
            }
            catch (NotSupportedException)
            {
                Console.WriteLine("The content type is not supported.");
            }
            catch (JsonException)
            {
                Console.WriteLine("Invalid JSON.");
            }

            return null;
        }
    }
}
