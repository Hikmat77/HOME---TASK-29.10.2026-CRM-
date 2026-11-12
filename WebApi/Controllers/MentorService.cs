using Application.DTOs;
using Application.Interfaces;
using Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MentorsController(
    IMentorService mentorService,
    ILogger<MentorsController> logger) : ControllerBase
{
    private IMentorService service = mentorService;
    private ILogger<MentorsController> _logger = logger;

    [HttpPost]
    public async Task<ApiResponse<bool>> AddMentor(CreateMentorDto dto)
    {
        _logger.LogInformation("POST api/Mentors {date}", DateTime.Now);
        return await service.AddMentorAsync(dto);
    }

    [HttpPut("{id:int}")]
    public async Task<ApiResponse<bool>> UpdateMentor(int id, UpdateMentorDto dto)
    {
        _logger.LogInformation("PUT api/Mentors/{id} {date}", id, DateTime.Now);
        return await service.UpdateMentorAsync(id, dto);
    }

    [HttpDelete]
    public async Task<ApiResponse<bool>> DeleteMentor(int id)
    {
        _logger.LogInformation("DELETE api/Mentors?id={id} {date}", id, DateTime.Now);
        return await service.DeleteMentorAsync(id);
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<MentorDto>> GetMentor(int id)
    {
        _logger.LogInformation("GET api/Mentors/{id} {date}", id, DateTime.Now);
        return await service.GetMentorAsync(id);
    }

    [HttpGet]
    public async Task<ApiResponse<List<MentorDto>>> GetMentors()
    {
        _logger.LogInformation("GET api/Mentors {date}", DateTime.Now);
        return await service.GetAllMentorsAsync();
    }

    [HttpGet("with-most-students")]
    public async Task<ApiResponse<dynamic>> GetMentorWithMostStudents()
    {
        _logger.LogInformation("GET api/Mentors/with-most-students {date}", DateTime.Now);
        return await service.GetMentorWithMostStudentsAsync();
    }

    [HttpGet("with-multiple-courses")]
    public async Task<ApiResponse<List<dynamic>>> GetMentorsWithMultipleCourses()
    {
        _logger.LogInformation("GET api/Mentors/with-multiple-courses {date}", DateTime.Now);
        return await service.GetMentorsWithMultipleCoursesAsync();
    }

    [HttpGet("total-count")]
    public async Task<ApiResponse<int>> GetTotalMentorsCount()
    {
        _logger.LogInformation("GET api/Mentors/total-count {date}", DateTime.Now);
        return await service.GetTotalMentorsCountAsync();
    }
}
