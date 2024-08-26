using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PowerPlant.WebApi.Models;

public class PowerPlant
{
    [JsonPropertyName("name"), Required]
    public string Name { get; init; }

    [JsonPropertyName("type"), Required]
    public string Type { get; init; }

    [JsonPropertyName("efficiency"), Required]
    public decimal Efficiency { get; init; }

    [JsonPropertyName("pmin"), Required]
    public decimal Pmin { get; init; }

    [JsonPropertyName("pmax"), Required]
    public decimal Pmax { get; init; }
}
