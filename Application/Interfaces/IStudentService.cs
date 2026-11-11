using Application.DTOs;
using Application.Responses;

namespace Application.Interfaces;

public interface IStudentService
{
    Task<ApiResponse<bool>> AddStudentAsync(CreateStudentDto dto);
    Task<ApiResponse<bool>> UpdateStudentAsync(int studentId, UpdateStudentDto dto);
    Task<ApiResponse<bool>> DeleteStudentAsync(int studentId);
    Task<ApiResponse<StudentDto>> GetStudentAsync(int studentId);
    Task<ApiResponse<List<StudentDto>>> GetAllStudentsAsync();

    Task<ApiResponse<List<StudentWithGroup>>> GetStudentsWithGroupsAsync();
    Task<ApiResponse<List<StudentDto>>> GetStudentsWithoutGroupsAsync();
    Task<ApiResponse<List<StudentDto>>> GetDroppedOutStudentsAsync();
    Task<ApiResponse<List<StudentDto>>> GetGraduatedStudentsAsync();
}
