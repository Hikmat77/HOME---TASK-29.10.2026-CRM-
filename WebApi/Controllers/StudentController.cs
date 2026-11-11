using Application.DTOs;
using Application.Interfaces;
using Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentsController(IStudentService studentService) : ControllerBase
{
    private IStudentService service = studentService;

    [HttpPost]
    public async Task<ApiResponse<bool>> AddStudent(CreateStudentDto dto)
    {
        return await service.AddStudentAsync(dto);
    }

    [HttpPut("{id:int}")]
    public async Task<ApiResponse<bool>> UpdateStudent(int id, UpdateStudentDto dto)
    {
        return await service.UpdateStudentAsync(id, dto);
    }

    [HttpDelete]
    public async Task<ApiResponse<bool>> DeleteStudent(int id)
    {
        return await service.DeleteStudentAsync(id);
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<StudentDto>> GetStudent(int id)
    {
        return await service.GetStudentAsync(id);
    }

    [HttpGet]
    public async Task<ApiResponse<List<StudentDto>>> GetStudents()
    {
        return await service.GetAllStudentsAsync();
    }

    [HttpGet("students-with-groups")]
    public async Task<ApiResponse<List<StudentWithGroup>>> GetStudentsWithGroups()
    {
        return await service.GetStudentsWithGroupsAsync();
    }

    [HttpGet("students-without-groups")]
    public async Task<ApiResponse<List<StudentDto>>> GetStudentsWithoutGroups()
    {
        return await service.GetStudentsWithoutGroupsAsync();
    }

    [HttpGet("dropped-out")]
    public async Task<ApiResponse<List<StudentDto>>> GetDroppedOutStudents()
    {
        return await service.GetDroppedOutStudentsAsync();
    }

    [HttpGet("graduated")]
    public async Task<ApiResponse<List<StudentDto>>> GetGraduatedStudents()
    {
        return await service.GetGraduatedStudentsAsync();
    }
}
