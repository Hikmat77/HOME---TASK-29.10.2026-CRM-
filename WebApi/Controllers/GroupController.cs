using System.Text.RegularExpressions;
using Application.Interfaces;
using Application.Responses;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GroupController(IGroupService groupService) : ControllerBase
{
    IGroupService service = groupService;

    [HttpPost]
    public async Task<ApiResponse<bool>> AddGroups(Groups groups)
    {
        return await service.AddGroupAsync(groups);
    }

    [HttpDelete]
    public async Task<ApiResponse<bool>> DeleteGroups(int groupId)
    {
        return await service.DeleteGroupAsync(groupId);
    }

    [HttpPut]
    public async Task<ApiResponse<bool>> UpdateGroups(Groups groups)
    {
        return await service.UpdateGroupAsync(groups);
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<Groups>> GetGroups(int id)
    {
        return await service.GetGroupAsync(id);
    }

    [HttpGet]
    public async Task<ApiResponse<List<Groups>>> GetGroups()
    {
        return await service.GetGroupsAsync();
    }
}