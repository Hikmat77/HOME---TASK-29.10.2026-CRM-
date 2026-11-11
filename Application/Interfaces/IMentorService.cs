using Application.DTOs;
using Application.Responses;

namespace Application.Interfaces;

public interface IMentorService
{
    Task<ApiResponse<bool>> AddMentorAsync(CreateMentorDto dto);
    Task<ApiResponse<bool>> UpdateMentorAsync(int mentorId, UpdateMentorDto dto);
    Task<ApiResponse<bool>> DeleteMentorAsync(int mentorId);
    Task<ApiResponse<MentorDto>> GetMentorAsync(int mentorId);
    Task<ApiResponse<List<MentorDto>>> GetAllMentorsAsync();

    Task<ApiResponse<dynamic>> GetMentorWithMostStudentsAsync();
    Task<ApiResponse<List<dynamic>>> GetMentorsWithMultipleCoursesAsync();
    Task<ApiResponse<int>> GetTotalMentorsCountAsync();
}
