using Application.Interfaces;
using Application.Responses;
using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;


[ApiController]
[Route("api/[controller]")]
public class CoursesController(ICourseService courseService) : ControllerBase
{
    ICourseService service = courseService;

    [HttpPost]
    public async Task<ApiResponse<bool>> AddCourses(Courses courses)
    {
        return await service.AddCourseAsync(courses);
    }

    [HttpDelete]
    public async Task<ApiResponse<bool>> DeleteCourses(int courseId)
    {
        return await service.DeleteCourseAsync(courseId);
    }

    [HttpPut]
    public async Task<ApiResponse<bool>> UpdateCourses(Courses courses)
    {
        return await service.UpdateCourseAsync(courses);
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<Courses>> GetCourse(int id)
    {
        return await service.GetCourseAsync(id);
    }

    [HttpGet]
    public async Task<ApiResponse<List<Courses>>> GetCourses()
    {
        return await service.GetCoursesAsync();
    }
}