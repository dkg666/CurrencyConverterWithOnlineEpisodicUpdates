using System.Text.Json.Serialization;

namespace CurrencyConverter.Models.ApiModels
{
    public class Rates
    {
        [JsonPropertyName("CAD")]
        public double Cad { get; set; }

        [JsonPropertyName("HKD")]
        public double Hkd { get; set; }

        [JsonPropertyName("ISK")]
        public double Isk { get; set; }

        [JsonPropertyName("PHP")]
        public double Php { get; set; }

        [JsonPropertyName("DKK")]
        public double Dkk { get; set; }

        [JsonPropertyName("HUF")]
        public double Huf { get; set; }

        [JsonPropertyName("CZK")]
        public double Czk { get; set; }

        [JsonPropertyName("AUD")]
        public double Aud { get; set; }

        [JsonPropertyName("RON")]
        public double Ron { get; set; }

        [JsonPropertyName("SEK")]
        public double Sek { get; set; }

        [JsonPropertyName("IDR")]
        public double Idr { get; set; }

        [JsonPropertyName("INR")]
        public double Inr { get; set; }

        [JsonPropertyName("BRL")]
        public double Brl { get; set; }

        [JsonPropertyName("RUB")]
        public double Rub { get; set; }

        [JsonPropertyName("HRK")]
        public double Hrk { get; set; }

        [JsonPropertyName("JPY")]
        public double Jpy { get; set; }

        [JsonPropertyName("THB")]
        public double Thb { get; set; }

        [JsonPropertyName("CHF")]
        public double Chf { get; set; }

        [JsonPropertyName("SGD")]
        public double Sgd { get; set; }

        [JsonPropertyName("PLN")]
        public double Pln { get; set; }

        [JsonPropertyName("BGN")]
        public double Bgn { get; set; }

        [JsonPropertyName("TRY")]
        public double Try { get; set; }

        [JsonPropertyName("CNY")]
        public double Cny { get; set; }

        [JsonPropertyName("NOK")]
        public double Nok { get; set; }

        [JsonPropertyName("NZD")]
        public double Nzd { get; set; }

        [JsonPropertyName("ZAR")]
        public double Zar { get; set; }

        [JsonPropertyName("USD")]
        public double Usd { get; set; }

        [JsonPropertyName("MXN")]
        public double Mxn { get; set; }

        [JsonPropertyName("ILS")]
        public double Ils { get; set; }

        [JsonPropertyName("GBP")]
        public double Gbp { get; set; }

        [JsonPropertyName("KRW")]
        public double Krw { get; set; }

        [JsonPropertyName("MYR")]
        public double Myr { get; set; }

        [JsonPropertyName("EUR")]
        public double Eur => 1;
    }
}