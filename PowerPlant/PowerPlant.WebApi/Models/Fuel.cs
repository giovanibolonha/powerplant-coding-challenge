using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PowerPlant.WebApi.Models;

public class Fuel
{

    [JsonPropertyName("gas(euro/MWh)"), Required]
    public decimal GasEuroMwh { get; init; }

    [JsonPropertyName("kerosine(euro/MWh)"), Required]
    public decimal KerosineEuroMwh { get; init; }

    [JsonPropertyName("co2(euro/ton)"), Required]
    public decimal Co2EuroTon { get; init; }

    [JsonPropertyName("wind(%)"), Required]
    public decimal WindPercentage { get; init; }
}
