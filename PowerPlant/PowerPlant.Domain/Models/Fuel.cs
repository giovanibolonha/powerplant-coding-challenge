namespace PowerPlant.Domain.Models;

public class Fuel
{
    public decimal GasEuroMwh { get; init; }

    public decimal KerosineEuroMwh { get; init; }

    public decimal Co2EuroTon { get; init; }

    public decimal WindPercentage { get; init; }
}