using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CurrencyConverter.Models
{
    public class ExchangeRatesViewModel
    {
        public HashSet<ExchangeRate> Rates { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        public ExchangeRate From { get; set; }
        public ExchangeRate To { get; set; }
        public double ConvertionRate { get; set; }
        public double Amount { get; set; }
        public double ConvertedAmount { get; set; }
        public string ErrorMessage { get; set; }
    }
}