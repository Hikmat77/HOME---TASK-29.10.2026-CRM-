using Application.DTOs;
using Application.Interfaces;
using Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MentorsController(IMentorService mentorService) : ControllerBase
{
    private IMentorService service = mentorService;

    [HttpPost]
    public async Task<ApiResponse<bool>> AddMentor(CreateMentorDto dto)
    {
        return await service.AddMentorAsync(dto);
    }

    [HttpPut("{id:int}")]
    public async Task<ApiResponse<bool>> UpdateMentor(int id, UpdateMentorDto dto)
    {
        return await service.UpdateMentorAsync(id, dto);
    }

    [HttpDelete]
    public async Task<ApiResponse<bool>> DeleteMentor(int id)
    {
        return await service.DeleteMentorAsync(id);
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<MentorDto>> GetMentor(int id)
    {
        return await service.GetMentorAsync(id);
    }

    [HttpGet]
    public async Task<ApiResponse<List<MentorDto>>> GetMentors()
    {
        return await service.GetAllMentorsAsync();
    }

    [HttpGet("with-most-students")]
    public async Task<ApiResponse<dynamic>> GetMentorWithMostStudents()
    {
        return await service.GetMentorWithMostStudentsAsync();
    }

    [HttpGet("with-multiple-courses")]
    public async Task<ApiResponse<List<dynamic>>> GetMentorsWithMultipleCourses()
    {
        return await service.GetMentorsWithMultipleCoursesAsync();
    }

    [HttpGet("total-count")]
    public async Task<ApiResponse<int>> GetTotalMentorsCount()
    {
        return await service.GetTotalMentorsCountAsync();
    }
}
