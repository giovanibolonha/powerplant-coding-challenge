using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PowerPlant.WebApi.Models;

public class ProductionPlanRequest
{
    [JsonPropertyName("load"), Required]
    public decimal Load { get; init; }

    [JsonPropertyName("fuels"), Required]
    public Fuel Fuel { get; init; }

    [JsonPropertyName("powerplants"), Required]
    public  List<PowerPlant> PowerPlants { get; init; }
}
