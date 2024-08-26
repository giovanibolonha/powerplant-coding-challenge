namespace PowerPlant.Domain.Models;

public class TurbojetPowerPlant(string name, decimal efficiency, decimal pmin, decimal pmax, Fuel fuel)
    : PowerPlant(name, efficiency, pmin, pmax, fuel)
{
    public override decimal CalculatePowerProductionCostPerMwh()
        => Efficiency > 0 ? Fuel.KerosineEuroMwh / Efficiency : 0.0m;

    protected override bool CanGeneratePower(decimal load)
        => Efficiency > 0 && Fuel.KerosineEuroMwh > 0 && Pmax > 0;
}