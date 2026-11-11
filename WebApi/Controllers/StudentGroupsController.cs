using Application.DTOs;
using Application.Interfaces;
using Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentGroupsController(IStudentGroupService studentGroupService) : ControllerBase
{
    private IStudentGroupService service = studentGroupService;

    [HttpPost]
    public async Task<ApiResponse<bool>> AddStudentGroup(CreateStudentGroupDto dto)
    {
        return await service.AddStudentGroupAsync(dto);
    }

    [HttpPut("{id:int}")]
    public async Task<ApiResponse<bool>> UpdateStudentGroup(int id, UpdateStudentGroupDto dto)
    {
        return await service.UpdateStudentGroupAsync(id, dto);
    }

    [HttpDelete]
    public async Task<ApiResponse<bool>> DeleteStudentGroup(int id)
    {
        return await service.DeleteStudentGroupAsync(id);
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<StudentGroupDto>> GetStudentGroup(int id)
    {
        return await service.GetStudentGroupAsync(id);
    }

    [HttpGet]
    public async Task<ApiResponse<List<StudentGroupDto>>> GetStudentGroups()
    {
        return await service.GetAllStudentGroupsAsync();
    }
}
