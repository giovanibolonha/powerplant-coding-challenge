namespace PowerPlant.WebApi.Mappers;

public static class ProductionPlanGeneratorMapper
{
    public static Domain.Models.ProductionPlanGenerator ToDomainProductionPlanGenerator(this WebApi.Models.ProductionPlanRequest request)
        => new(request.PowerPlants.ToDomainPowerPlants(request.Fuel));

    public static IEnumerable<Domain.Models.PowerPlant> ToDomainPowerPlants(this IEnumerable<WebApi.Models.PowerPlant> powerPlants, WebApi.Models.Fuel fuel)
        => powerPlants
            .Select(powerPlant => Domain.Models.PowerPlant
                .Create(
                    powerPlant.Type,
                    powerPlant.Name,
                    powerPlant.Efficiency,
                    powerPlant.Pmin,
                    powerPlant.Pmax,
                    fuel.ToDomainFuel())).ToList();

    public static Domain.Models.Fuel ToDomainFuel(this WebApi.Models.Fuel fuel)
        => new()
        {
            GasEuroMwh = fuel.GasEuroMwh,
            KerosineEuroMwh = fuel.KerosineEuroMwh,
            Co2EuroTon = fuel.Co2EuroTon,
            WindPercentage = fuel.WindPercentage
        };
}
