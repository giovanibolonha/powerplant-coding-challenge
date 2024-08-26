using PowerPlant.Domain.Models;
using PowerPlant.WebApi.Models;

namespace PowerPlant.WebApi.Mappers;

public static class ProductionPlanMapper
{
    public static List<ProductionPlanResponse> ToApiProductionPlanResponse(this IEnumerable<ProductionPlan> productionPlans)
        => productionPlans.Select(productionPlan => new ProductionPlanResponse
        {
            Name = productionPlan.PowerPlant.Name,
            P = productionPlan.Production
        }).ToList();
}