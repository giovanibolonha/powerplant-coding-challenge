namespace PowerPlant.Domain.Models;

public class GasFiredPowerPlant(string name, decimal efficiency, decimal pmin, decimal pmax, Fuel fuel)
    : PowerPlant(name, efficiency, pmin, pmax, fuel)
{
    public override decimal CalculatePowerProductionCostPerMwh()
        => Efficiency > 0 ? (Fuel.GasEuroMwh / Efficiency) + (Fuel.Co2EuroTon * 0.3m) : 0.0m;

    protected override bool CanGeneratePower(decimal load)
        => Efficiency > 0 && Fuel.GasEuroMwh > 0 && Pmax > 0 && load >= Pmin;
}