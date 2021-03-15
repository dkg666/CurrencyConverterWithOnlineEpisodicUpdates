using System.Text.Json.Serialization;

namespace Models.ApiModels
{
    public class ExchangeRates
    {
        [JsonPropertyName("rates")]
        public Rates Rates { get; set; }

        [JsonPropertyName("base")]
        public string Base { get; set; }

        [JsonPropertyName("date")]
        public string Date { get; set; }
    }
}
