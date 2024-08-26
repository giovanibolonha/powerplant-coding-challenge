namespace PowerPlant.Domain.Models;

public class ProductionPlan
{
    public PowerPlant PowerPlant { get; init; }

    public decimal Production { get; init; }
}
