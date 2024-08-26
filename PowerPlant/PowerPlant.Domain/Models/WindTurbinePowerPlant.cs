namespace PowerPlant.Domain.Models;

public class WindTurbinePowerPlant(string name, decimal efficiency, decimal pmin, decimal pmax, Fuel fuel)
    : PowerPlant(name, efficiency, pmin, pmax, fuel)
{
    protected override decimal CalculatePowerProduction(decimal load)
        => CanGeneratePower(load) ? Math.Min(load, Pmax * (Fuel.WindPercentage / 100)) : 0.0m;

    public override decimal CalculatePowerProductionCostPerMwh()
        => 0.0m;

    protected override bool CanGeneratePower(decimal load)
        => Efficiency > 0 && Fuel.WindPercentage > 0 && Pmax > 0;
}