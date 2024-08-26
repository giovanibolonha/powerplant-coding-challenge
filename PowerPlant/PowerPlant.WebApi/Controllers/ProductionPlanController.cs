using Microsoft.AspNetCore.Mvc;
using PowerPlant.WebApi.Mappers;
using PowerPlant.WebApi.Models;

namespace PowerPlant.WebApi.Controllers;

[ApiController]
public class ProductionPlanController(ILogger<ProductionPlanController> logger) : ControllerBase
{
    private readonly ILogger<ProductionPlanController> _logger = logger;

    [HttpPost]
    [Route("productionplan")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ProductionPlanResponse>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult GenerateProductionPlan([FromBody] ProductionPlanRequest request)
    {
        _logger.LogDebug("GenerateProductionPlan request:{@Request}", request);

        try
        {
            var generator = request
                .ToDomainProductionPlanGenerator();

            var response = generator
                .GenerateProductionPlan(request.Load)
                .ToApiProductionPlanResponse();

            _logger.LogDebug("GenerateProductionPlan response:{@Response}", response);

            return Ok(response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unexpected Exception was raised while trying to GenerateProductionPlan");
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}
