using Application.Interfaces;
using Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AnalyticsController(
    IAnalyticsService analyticsService,
    ILogger<AnalyticsController> logger) : ControllerBase
{
    private IAnalyticsService service = analyticsService;
    private ILogger<AnalyticsController> _logger = logger;

    [HttpGet("completion-rate")]
    public async Task<ApiResponse<decimal>> GetCompletionRate()
    {
        _logger.LogInformation("GET api/Analytics/completion-rate {date}", DateTime.Now);
        return await service.GetCompletionRateAsync();
    }
}

