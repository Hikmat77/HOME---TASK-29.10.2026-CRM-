using System.Net.Security;
using Application.Interfaces;
using Application.Responses;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentController(IStudentService studentService) : ControllerBase
{
    IStudentService service = studentService;

    [HttpPost]
    public async Task<ApiResponse<bool>> AddStudent(Students students)
    {
        return await service.AddStudentAsync(students);
    }

    [HttpDelete]
    public async Task<ApiResponse<bool>> DeleteStudent(int id)
    {
        return await service.DeleteStudentAsync(id);
    }

    [HttpPut]
    public async Task<ApiResponse<bool>> UpdateStudent(Students students)
    {
        return await service.UpdateStudentAsync(students);
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<Students>> GetStudent(int id)
    {
        return await service.GetStudentAsync(id);
    }

    [HttpGet]
    public async Task<ApiResponse<List<Students>>> GetStudents()
    {
        return await service.GetStudentsAsync();
    }
}