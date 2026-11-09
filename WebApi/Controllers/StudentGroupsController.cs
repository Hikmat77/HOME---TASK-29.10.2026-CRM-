using Application.Interfaces;
using Application.Responses;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentGroupsController(IStudentGroupService studentGroupService) : ControllerBase
{
    IStudentGroupService service = studentGroupService;

    [HttpPost]
    public async Task<ApiResponse<bool>> AddStudentGroups(StudentGroups studentGroups)
    {
        return await service.AddStudentGroupAsync(studentGroups);
    }

    [HttpDelete]
    public async Task<ApiResponse<bool>> DeleteStudentGroups(int id)
    {
        return await service.DeleteStudentGroupAsync(id);
    }

    [HttpPut]
    public async Task<ApiResponse<bool>> UpdateStudentGroups(StudentGroups studentGroups)
    {
        return await service.UpdateStudentGroupAsync(studentGroups);
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<StudentGroups>> GetStudentGroups(int id)
    {
        return await service.GetStudentGroupAsync(id);
    }

    [HttpGet]
    public async Task<ApiResponse<List<StudentGroups>>> GetStudentGroups()
    {
        return await service.GetStudentGroupsAsync();
    }
}