using System.Net.Http.Headers;
using Application.Interfaces;
using Application.Responses;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Properties;

[ApiController]
[Route("api/[controller]")]
public class MentorService(IMentorService mentorService) : ControllerBase
{
    IMentorService service = mentorService;

    [HttpPost]
    public async Task<ApiResponse<bool>> AddMentors(Mentors mentors)
    {
        return await service.AddMentorAsync(mentors);
    }

    [HttpDelete]
    public async Task<ApiResponse<bool>> DeleteMentors(int id)
    {
        return await service.DeleteMentorAsync(id);
    }

    [HttpPut]
    public async Task<ApiResponse<bool>> UpdateMentors(Mentors mentors)
    {
        return await service.UpdateMentorAsync(mentors);
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<Mentors>> GetMentor(int id)
    {
        return await service.GetMentorAsync(id);
    }

    [HttpGet]
    public async Task<ApiResponse<List<Mentors>>> GetMentors()
    {
        return await service.GetMentorsAsync();
    }
}