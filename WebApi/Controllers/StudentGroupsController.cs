using Application.DTOs;
using Application.Interfaces;
using Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentGroupsController(
    IStudentGroupService studentGroupService,
    ILogger<StudentGroupsController> logger) : ControllerBase
{
    private IStudentGroupService service = studentGroupService;
    private ILogger<StudentGroupsController> _logger = logger;

    [HttpPost]
    public async Task<ApiResponse<bool>> AddStudentGroup(CreateStudentGroupDto dto)
    {
        _logger.LogInformation("POST api/StudentGroups {date}", DateTime.Now);
        return await service.AddStudentGroupAsync(dto);
    }

    [HttpPut("{id:int}")]
    public async Task<ApiResponse<bool>> UpdateStudentGroup(int id, UpdateStudentGroupDto dto)
    {
        _logger.LogInformation("PUT api/StudentGroups/{id} {date}", id, DateTime.Now);
        return await service.UpdateStudentGroupAsync(id, dto);
    }

    [HttpDelete]
    public async Task<ApiResponse<bool>> DeleteStudentGroup(int id)
    {
        _logger.LogInformation("DELETE api/StudentGroups?id={id} {date}", id, DateTime.Now);
        return await service.DeleteStudentGroupAsync(id);
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<StudentGroupDto>> GetStudentGroup(int id)
    {
        _logger.LogInformation("GET api/StudentGroups/{id} {date}", id, DateTime.Now);
        return await service.GetStudentGroupAsync(id);
    }

    [HttpGet]
    public async Task<ApiResponse<List<StudentGroupDto>>> GetStudentGroups()
    {
        _logger.LogInformation("GET api/StudentGroups {date}", DateTime.Now);
        return await service.GetAllStudentGroupsAsync();
    }
}
