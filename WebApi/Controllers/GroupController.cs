using Application.DTOs;
using Application.Interfaces;
using Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GroupsController(IGroupService groupService) : ControllerBase
{
    private IGroupService service = groupService;

    [HttpPost]
    public async Task<ApiResponse<bool>> AddGroup(CreateGroupDto dto)
    {
        return await service.AddGroupAsync(dto);
    }

    [HttpPut("{id:int}")]
    public async Task<ApiResponse<bool>> UpdateGroup(int id, UpdateGroupDto dto)
    {
        return await service.UpdateGroupAsync(id, dto);
    }

    [HttpDelete]
    public async Task<ApiResponse<bool>> DeleteGroup(int id)
    {
        return await service.DeleteGroupAsync(id);
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<GroupDto>> GetGroup(int id)
    {
        return await service.GetGroupAsync(id);
    }

    [HttpGet]
    public async Task<ApiResponse<List<GroupDto>>> GetGroups()
    {
        return await service.GetAllGroupsAsync();
    }

    [HttpGet("students-per-group")]
    public async Task<ApiResponse<List<GroupWithStudentCount>>> GetStudentsPerGroup()
    {
        return await service.GetStudentsPerGroupAsync();
    }

    [HttpGet("empty")]
    public async Task<ApiResponse<List<GroupDto>>> GetEmptyGroups()
    {
        return await service.GetEmptyGroupsAsync();
    }

    [HttpGet("total-count")]
    public async Task<ApiResponse<int>> GetTotalGroupsCount()
    {
        return await service.GetTotalGroupsCountAsync();
    }

    [HttpGet("start-dates")]
    public async Task<ApiResponse<List<DateTime>>> GetAllStartDates()
    {
        return await service.GetAllStartDatesAsync();
    }
}
