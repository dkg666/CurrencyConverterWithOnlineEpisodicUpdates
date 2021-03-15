using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CurrencyConverter.Interfaces;
using CurrencyConverter.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CurrencyConverter.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICurrenciesService _currenciesService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ICurrenciesService currenciesService, ILogger<HomeController> logger)
        {
            _currenciesService = currenciesService;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var rates = await _currenciesService.GetExchangeRates(DateTime.Now);

            return View(new ExchangeRatesViewModel
            {
                Rates = rates,
                Date = DateTime.Now,
                From = rates.FirstOrDefault(),
                To = rates.FirstOrDefault(),
                Amount = 1
            });
        }

        [HttpPost]
        public async Task<IActionResult> Index(CurrencyConvertViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(new ExchangeRatesViewModel
                {
                    ErrorMessage = "One or more selected values are invalid"
                });
            }

            var rates = await _currenciesService.GetExchangeRates(model.Date.Value);

            var convertionRate = _currenciesService.GetExchangeRate(model.From, model.To, model.Date.Value);
            var convertedAmount = _currenciesService.GetExchangeRate(model.From, model.To, model.Date.Value, model.Amount);

            return View(new ExchangeRatesViewModel
            {
                Rates = rates,
                Date = model.Date.Value,
                From = rates.FirstOrDefault(r => r.Currency == model.From),
                To = rates.FirstOrDefault(r => r.Currency == model.To),
                ConvertionRate = convertionRate,
                ConvertedAmount = convertedAmount
            });
        }

        [HttpGet]
        public async Task<JsonResult> GetCurrencyRate(string from, string to, DateTime date)
        {
            if (string.IsNullOrWhiteSpace(from) || string.IsNullOrWhiteSpace(to))
                return Json("");

            if (!string.IsNullOrWhiteSpace(from) && from.Length != 3 || !string.IsNullOrWhiteSpace(to) && to.Length != 3)
                return Json("");

            if (date < new DateTime(2000, 01, 01) || date > DateTime.Now)
                return Json("");

            await _currenciesService.GetExchangeRates(date);

            var rate = _currenciesService.GetExchangeRate(from, to, date);

            return Json(rate);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
