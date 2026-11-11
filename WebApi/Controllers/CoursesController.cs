using Application.DTOs;
using Application.Interfaces;
using Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CoursesController(ICourseService courseService) : ControllerBase
{
    private ICourseService service = courseService;

    [HttpPost]
    public async Task<ApiResponse<bool>> AddCourse(CreateCourseDto dto)
    {
        return await service.AddCourseAsync(dto);
    }

    [HttpPut("{id:int}")]
    public async Task<ApiResponse<bool>> UpdateCourse(int id, UpdateCourseDto dto)
    {
        return await service.UpdateCourseAsync(id, dto);
    }

    [HttpDelete]
    public async Task<ApiResponse<bool>> DeleteCourse(int id)
    {
        return await service.DeleteCourseAsync(id);
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<CourseDto>> GetCourse(int id)
    {
        return await service.GetCourseAsync(id);
    }

    [HttpGet]
    public async Task<ApiResponse<List<CourseDto>>> GetCourses()
    {
        return await service.GetAllCoursesAsync();
    }

    [HttpGet("students-per-course")]
    public async Task<ApiResponse<List<CourseWithStudentCount>>> GetStudentsPerCourse()
    {
        return await service.GetStudentsPerCourseAsync();
    }

    [HttpGet("most-popular")]
    public async Task<ApiResponse<CourseWithStudentCount>> GetMostPopularCourse()
    {
        return await service.GetMostPopularCourseAsync();
    }

    [HttpGet("least-popular")]
    public async Task<ApiResponse<List<CourseWithStudentCount>>> GetLeastPopularCourses()
    {
        return await service.GetLeastPopularCoursesAsync();
    }

    [HttpGet("top-three")]
    public async Task<ApiResponse<List<CourseWithStudentCount>>> GetTopThreeCourses()
    {
        return await service.GetTopThreeCoursesAsync();
    }

    [HttpGet("total-count")]
    public async Task<ApiResponse<int>> GetTotalCoursesCount()
    {
        return await service.GetTotalCoursesCountAsync();
    }
}
