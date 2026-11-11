using Application.DTOs;
using Application.Responses;

namespace Application.Interfaces;

public interface IStudentGroupService
{
    Task<ApiResponse<bool>> AddStudentGroupAsync(CreateStudentGroupDto dto);
    Task<ApiResponse<bool>> UpdateStudentGroupAsync(int studentGroupId, UpdateStudentGroupDto dto);
    Task<ApiResponse<bool>> DeleteStudentGroupAsync(int studentGroupId);
    Task<ApiResponse<StudentGroupDto>> GetStudentGroupAsync(int studentGroupId);
    Task<ApiResponse<List<StudentGroupDto>>> GetAllStudentGroupsAsync();
}
