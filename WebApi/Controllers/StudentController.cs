using Application.DTOs;
using Application.Interfaces;
using Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentsController(
    IStudentService studentService,
    ILogger<StudentsController> logger) : ControllerBase
{
    private IStudentService service = studentService;
    private ILogger<StudentsController> _logger = logger;

    [HttpPost]
    public async Task<ApiResponse<bool>> AddStudent(CreateStudentDto dto)
    {
        _logger.LogInformation("POST api/Students {date}", DateTime.Now);
        return await service.AddStudentAsync(dto);
    }

    [HttpPut("{id:int}")]
    public async Task<ApiResponse<bool>> UpdateStudent(int id, UpdateStudentDto dto)
    {
        _logger.LogInformation("PUT api/Students/{id} {date}", id, DateTime.Now);
        return await service.UpdateStudentAsync(id, dto);
    }

    [HttpDelete]
    public async Task<ApiResponse<bool>> DeleteStudent(int id)
    {
        _logger.LogInformation("DELETE api/Students?id={id} {date}", id, DateTime.Now);
        return await service.DeleteStudentAsync(id);
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<StudentDto>> GetStudent(int id)
    {
        _logger.LogInformation("GET api/Students/{id} {date}", id, DateTime.Now);
        return await service.GetStudentAsync(id);
    }

    [HttpGet]
    public async Task<ApiResponse<List<StudentDto>>> GetStudents()
    {
        _logger.LogInformation("GET api/Students {date}", DateTime.Now);
        return await service.GetAllStudentsAsync();
    }

    [HttpGet("students-with-groups")]
    public async Task<ApiResponse<List<StudentWithGroup>>> GetStudentsWithGroups()
    {
        _logger.LogInformation("GET api/Students/students-with-groups {date}", DateTime.Now);
        return await service.GetStudentsWithGroupsAsync();
    }

    [HttpGet("students-without-groups")]
    public async Task<ApiResponse<List<StudentDto>>> GetStudentsWithoutGroups()
    {
        _logger.LogInformation("GET api/Students/students-without-groups {date}", DateTime.Now);
        return await service.GetStudentsWithoutGroupsAsync();
    }

    [HttpGet("dropped-out")]
    public async Task<ApiResponse<List<StudentDto>>> GetDroppedOutStudents()
    {
        _logger.LogInformation("GET api/Students/dropped-out {date}", DateTime.Now);
        return await service.GetDroppedOutStudentsAsync();
    }

    [HttpGet("graduated")]
    public async Task<ApiResponse<List<StudentDto>>> GetGraduatedStudents()
    {
        _logger.LogInformation("GET api/Students/graduated {date}", DateTime.Now);
        return await service.GetGraduatedStudentsAsync();
    }
}
