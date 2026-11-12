using Application.Interfaces;
using Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StatisticsController(
    IStatisticsService statisticsService,
    ILogger<StatisticsController> logger) : ControllerBase
{
    private IStatisticsService _statisticsService = statisticsService;
    private ILogger<StatisticsController> _logger = logger;

    [HttpGet("total-students")]
    public async Task<ApiResponse<int>> GetTotalStudentsCountAsync()
    {
        _logger.LogInformation("GET api/Statistics/total-students {date}", DateTime.Now);
        return await _statisticsService.GetTotalStudentsCountAsync();
    }

    [HttpGet("total-groups")]
    public async Task<ApiResponse<int>> GetTotalGroupsCountAsync()
    {
        _logger.LogInformation("GET api/Statistics/total-groups {date}", DateTime.Now);
        return await _statisticsService.GetTotalGroupsCountAsync();
    }

    [HttpGet("total-courses")]
    public async Task<ApiResponse<int>> GetTotalCoursesCountAsync()
    {
        _logger.LogInformation("GET api/Statistics/total-courses {date}", DateTime.Now);
        return await _statisticsService.GetTotalCoursesCountAsync();
    }

    [HttpGet("total-mentors")]
    public async Task<ApiResponse<int>> GetTotalMentorsCountAsync()
    {
        _logger.LogInformation("GET api/Statistics/total-mentors {date}", DateTime.Now);
        return await _statisticsService.GetTotalMentorsCountAsync();
    }

    [HttpGet("start-dates")]
    public async Task<ApiResponse<List<DateTime>>> GetAllStartDatesAsync()
    {
        _logger.LogInformation("GET api/Statistics/start-dates {date}", DateTime.Now);
        return await _statisticsService.GetAllStartDatesAsync();
    }
}
