
using Application.Interfaces;
using Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StatisticsController(IStatisticsService statisticsService) : ControllerBase
{
    private IStatisticsService _statisticsService = statisticsService;

    [HttpGet("total-students")]
    public async Task<ApiResponse<int>> GetTotalStudentsCountAsync()
    {
        return await _statisticsService.GetTotalStudentsCountAsync();
    }

    [HttpGet("total-groups")]
    public async Task<ApiResponse<int>> GetTotalGroupsCountAsync()
    {
        return await _statisticsService.GetTotalGroupsCountAsync();
    }

    [HttpGet("total-courses")]
    public async Task<ApiResponse<int>> GetTotalCoursesCountAsync()
    {
        return await _statisticsService.GetTotalCoursesCountAsync();
    }

    [HttpGet("total-mentors")]
    public async Task<ApiResponse<int>> GetTotalMentorsCountAsync()
    {
        return await _statisticsService.GetTotalMentorsCountAsync();
    }

    [HttpGet("start-dates")]
    public async Task<ApiResponse<List<DateTime>>> GetAllStartDatesAsync()
    {
        return await _statisticsService.GetAllStartDatesAsync();
    }
}
