using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PowerPlant.WebApi.Models;

public class ProductionPlanResponse
{
    [JsonPropertyName("name"), Required]
    public string Name { get; init; }

    [JsonPropertyName("p"), Required]
    public decimal P { get; init; }
}
