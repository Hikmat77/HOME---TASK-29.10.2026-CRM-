using Application.DTOs;
using Application.Interfaces;
using Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CoursesController(
    ICourseService courseService,
    ILogger<CoursesController> logger) : ControllerBase
{
    private ICourseService service = courseService;
    private ILogger<CoursesController> _logger = logger;

    [HttpPost]
    public async Task<ApiResponse<bool>> AddCourse(CreateCourseDto dto)
    {
        _logger.LogInformation("POST api/Courses {date}", DateTime.Now);
        return await service.AddCourseAsync(dto);
    }

    [HttpPut("{id:int}")]
    public async Task<ApiResponse<bool>> UpdateCourse(int id, UpdateCourseDto dto)
    {
        _logger.LogInformation("PUT api/Courses/{id} {date}", id, DateTime.Now);
        return await service.UpdateCourseAsync(id, dto);
    }

    [HttpDelete]
    public async Task<ApiResponse<bool>> DeleteCourse(int id)
    {
        _logger.LogInformation("DELETE api/Courses?id={id} {date}", id, DateTime.Now);
        return await service.DeleteCourseAsync(id);
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<CourseDto>> GetCourse(int id)
    {
        _logger.LogInformation("GET api/Courses/{id} {date}", id, DateTime.Now);
        return await service.GetCourseAsync(id);
    }

    [HttpGet]
    public async Task<ApiResponse<List<CourseDto>>> GetCourses()
    {
        _logger.LogInformation("GET api/Courses {date}", DateTime.Now);
        return await service.GetAllCoursesAsync();
    }

    [HttpGet("students-per-course")]
    public async Task<ApiResponse<List<CourseWithStudentCount>>> GetStudentsPerCourse()
    {
        _logger.LogInformation("GET api/Courses/students-per-course {date}", DateTime.Now);
        return await service.GetStudentsPerCourseAsync();
    }

    [HttpGet("most-popular")]
    public async Task<ApiResponse<CourseWithStudentCount>> GetMostPopularCourse()
    {
        _logger.LogInformation("GET api/Courses/most-popular {date}", DateTime.Now);
        return await service.GetMostPopularCourseAsync();
    }

    [HttpGet("least-popular")]
    public async Task<ApiResponse<List<CourseWithStudentCount>>> GetLeastPopularCourses()
    {
        _logger.LogInformation("GET api/Courses/least-popular {date}", DateTime.Now);
        return await service.GetLeastPopularCoursesAsync();
    }

    [HttpGet("top-three")]
    public async Task<ApiResponse<List<CourseWithStudentCount>>> GetTopThreeCourses()
    {
        _logger.LogInformation("GET api/Courses/top-three {date}", DateTime.Now);
        return await service.GetTopThreeCoursesAsync();
    }

    [HttpGet("total-count")]
    public async Task<ApiResponse<int>> GetTotalCoursesCount()
    {
        _logger.LogInformation("GET api/Courses/total-count {date}", DateTime.Now);
        return await service.GetTotalCoursesCountAsync();
    }
}
