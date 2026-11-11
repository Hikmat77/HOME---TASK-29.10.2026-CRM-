using System.Net;
using Application.DTOs;
using Application.Interfaces;
using Application.Responses;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Services;

public class MentorService(IMentorRepository mentorRepository) : IMentorService
{
    private IMentorRepository repository = mentorRepository;
    public async Task<ApiResponse<bool>> AddMentorAsync(CreateMentorDto dto)
    {
        var mentor = new Mentors()
        {
            FullName = dto.FullName,
            Email = dto.Email,
            Phone = dto.Phone,
            Specialization = dto.Specialization
        };
        var res = await repository.AddMentorAsync(mentor);
        return res==true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Added!", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not added.", res);
    }

    public async Task<ApiResponse<bool>> DeleteMentorAsync(int mentorId)
    {
        var res = await repository.DeleteMentorAsync(mentorId);
        return res==true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Deleted!", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not deleted.", res);
    }

    public async Task<ApiResponse<MentorDto>> GetMentorAsync(int mentorId)
    {
        var mentor = await repository.GetMentorAsync(mentorId);
        var res = new MentorDto()
        {
            MentorId = mentor.MentorId,
            FullName = mentor.FullName,
            Email = mentor.Email,
            Phone = mentor.Phone,
            Specialization = mentor.Specialization
        };
        return new ApiResponse<MentorDto>(HttpStatusCode.OK, "Mentor with given id.", res);
    }

    public async Task<ApiResponse<List<MentorDto>>> GetAllMentorsAsync()
    {
        var mentors = await repository.GetMentorsAsync();
        var res = mentors.Select(x=>new MentorDto()
        {
            MentorId = x.MentorId,
            FullName = x.FullName,
            Email = x.Email,
            Phone = x.Phone,
            Specialization = x.Specialization
        }).ToList();
        return new ApiResponse<List<MentorDto>>(HttpStatusCode.OK, "List of mentors.", res);
    }

    public async Task<ApiResponse<dynamic>> GetMentorWithMostStudentsAsync()
    {
        object? res = await repository.GetMentorWithMostStudentsAsync();
        return res == null
        ? new ApiResponse<dynamic>(HttpStatusCode.NotFound, "Nothing found!", res)
        : new ApiResponse<dynamic>(HttpStatusCode.OK, "Mentor with most students.", res);
    }

    public async Task<ApiResponse<List<dynamic>>> GetMentorsWithMultipleCoursesAsync()
    {
        var res = await repository.GetMentorsWithMultipleCoursesAsync();
        return new ApiResponse<List<dynamic>>(HttpStatusCode.OK, "Mentors with multiple courses.", res);
    }

    public async Task<ApiResponse<int>> GetTotalMentorsCountAsync()
    {
        var res = await repository.GetTotalMentorsCountAsync();
        return new ApiResponse<int>(HttpStatusCode.OK, "Total mentors.", res);
    }

    public async Task<ApiResponse<bool>> UpdateMentorAsync(int mentorId, UpdateMentorDto dto)
    {
        var mentor = new Mentors()
        {
            MentorId = mentorId,
            FullName = dto.FullName,
            Email = dto.Email,
            Phone = dto.Phone,
            Specialization = dto.Specialization
        };
        var res = await repository.UpdateMentorAsync(mentor);
        return res==true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Updated!", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not updated.", res);
    }
}
