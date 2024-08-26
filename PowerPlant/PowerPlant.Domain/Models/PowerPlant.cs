namespace PowerPlant.Domain.Models;

public abstract class PowerPlant(string name, decimal efficiency, decimal pmin, decimal pmax, Fuel fuel)
{
    public string Name { get; init; } = name;

    public decimal Efficiency { get; init; } = efficiency;

    public decimal Pmin { get; init; } = pmin;

    public decimal Pmax { get; init; } = pmax;

    public Fuel Fuel { get; init; } = fuel;

    protected abstract bool CanGeneratePower(decimal load);

    public abstract decimal CalculatePowerProductionCostPerMwh();

    protected virtual decimal CalculatePowerProduction(decimal load)
        => CanGeneratePower(load) ? Math.Min(load, Pmax) : 0.0m;

    public decimal CalculatePowerProduction(decimal load, PowerPlant nextPowerPlant)
    {
        var production = CalculatePowerProduction(load);
        if (production == 0)
            return 0.0m;

        var remaningLoag = load - production;
        if (remaningLoag > 0 && nextPowerPlant?.Pmin > remaningLoag)
            production -= nextPowerPlant.Pmin - remaningLoag;

        if (production < Pmin)
            production = Pmin;

        return production;
    }

    public static PowerPlant Create(string type, string name, decimal efficiency, decimal pmin, decimal pmax, Fuel fuel)
        => type.ToLowerInvariant() switch
        {
            "gasfired" => new GasFiredPowerPlant(name, efficiency, pmin, pmax, fuel),
            "turbojet" => new TurbojetPowerPlant(name, efficiency, pmin, pmax, fuel),
            "windturbine" => new WindTurbinePowerPlant(name, efficiency, pmin, pmax, fuel),
            _ => throw new ArgumentOutOfRangeException(type)
        };
}
