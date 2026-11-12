using Application.DTOs;
using Application.Interfaces;
using Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GroupsController(
    IGroupService groupService,
    ILogger<GroupsController> logger) : ControllerBase
{
    private IGroupService service = groupService;
    private ILogger<GroupsController> _logger = logger;

    [HttpPost]
    public async Task<ApiResponse<bool>> AddGroup(CreateGroupDto dto)
    {
        _logger.LogInformation("POST api/Groups {date}", DateTime.Now);
        return await service.AddGroupAsync(dto);
    }

    [HttpPut("{id:int}")]
    public async Task<ApiResponse<bool>> UpdateGroup(int id, UpdateGroupDto dto)
    {
        _logger.LogInformation("PUT api/Groups/{id} {date}", id, DateTime.Now);
        return await service.UpdateGroupAsync(id, dto);
    }

    [HttpDelete]
    public async Task<ApiResponse<bool>> DeleteGroup(int id)
    {
        _logger.LogInformation("DELETE api/Groups?id={id} {date}", id, DateTime.Now);
        return await service.DeleteGroupAsync(id);
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<GroupDto>> GetGroup(int id)
    {
        _logger.LogInformation("GET api/Groups/{id} {date}", id, DateTime.Now);
        return await service.GetGroupAsync(id);
    }

    [HttpGet]
    public async Task<ApiResponse<List<GroupDto>>> GetGroups()
    {
        _logger.LogInformation("GET api/Groups {date}", DateTime.Now);
        return await service.GetAllGroupsAsync();
    }

    [HttpGet("students-per-group")]
    public async Task<ApiResponse<List<GroupWithStudentCount>>> GetStudentsPerGroup()
    {
        _logger.LogInformation("GET api/Groups/students-per-group {date}", DateTime.Now);
        return await service.GetStudentsPerGroupAsync();
    }

    [HttpGet("empty")]
    public async Task<ApiResponse<List<GroupDto>>> GetEmptyGroups()
    {
        _logger.LogInformation("GET api/Groups/empty {date}", DateTime.Now);
        return await service.GetEmptyGroupsAsync();
    }

    [HttpGet("total-count")]
    public async Task<ApiResponse<int>> GetTotalGroupsCount()
    {
        _logger.LogInformation("GET api/Groups/total-count {date}", DateTime.Now);
        return await service.GetTotalGroupsCountAsync();
    }

    [HttpGet("start-dates")]
    public async Task<ApiResponse<List<DateTime>>> GetAllStartDates()
    {
        _logger.LogInformation("GET api/Groups/start-dates {date}", DateTime.Now);
        return await service.GetAllStartDatesAsync();
    }
}
