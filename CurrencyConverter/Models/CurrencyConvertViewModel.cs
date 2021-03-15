using System;
using System.ComponentModel.DataAnnotations;

namespace CurrencyConverter.Models
{
    public class CurrencyConvertViewModel
    {
        [Required]
        [StringLength(3)]
        public string To { get; set; }
        [Required]
        [StringLength(3)]
        public string From { get; set; }
        [Required]
        [Range(typeof(DateTime), "1/1/2000", "1/1/2122", ErrorMessage="Date is out of Range")]
        public DateTime? Date { get; set; }
        [Required]
        [Range(0, double.MaxValue)]
        public double Amount { get; set; }
    }
}
