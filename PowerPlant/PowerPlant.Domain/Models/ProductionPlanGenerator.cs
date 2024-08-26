namespace PowerPlant.Domain.Models;

public class ProductionPlanGenerator(IEnumerable<PowerPlant> powerPlants)
{
    private readonly IEnumerable<PowerPlant> _powerPlants = powerPlants;

    public IEnumerable<ProductionPlan> GenerateProductionPlan(decimal load)
    {
        var remainingLoad = load;
        var productionPlans = new List<ProductionPlan>();

        var meritOrder = _powerPlants
            .OrderBy(x => x.CalculatePowerProductionCostPerMwh())
            .ThenByDescending(x => x.Pmin)
            .ToArray();

        for (int index = 0; index < meritOrder.Length; index++)
        {
            var currentPowerPlant = meritOrder[index];
            var nextPowerPlant = meritOrder.Length - 1 > index ? meritOrder[index + 1] : null;
            var currentPowerPlantProduction = currentPowerPlant.CalculatePowerProduction(remainingLoad, nextPowerPlant);

            remainingLoad -= currentPowerPlantProduction;

            productionPlans.Add(new ProductionPlan
            {
                PowerPlant = currentPowerPlant,
                Production = currentPowerPlantProduction
            });
        }

        return productionPlans;
    }
}
