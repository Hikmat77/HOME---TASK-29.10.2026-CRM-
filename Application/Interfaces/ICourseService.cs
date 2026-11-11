using Application.DTOs;
using Application.Responses;

namespace Application.Interfaces;

public interface ICourseService
{
    Task<ApiResponse<bool>> AddCourseAsync(CreateCourseDto dto);
    Task<ApiResponse<bool>> UpdateCourseAsync(int courseId, UpdateCourseDto dto);
    Task<ApiResponse<bool>> DeleteCourseAsync(int courseId);
    Task<ApiResponse<CourseDto>> GetCourseAsync(int courseId);
    Task<ApiResponse<List<CourseDto>>> GetAllCoursesAsync();

    Task<ApiResponse<List<CourseWithStudentCount>>> GetStudentsPerCourseAsync();
    Task<ApiResponse<CourseWithStudentCount>> GetMostPopularCourseAsync();
    Task<ApiResponse<List<CourseWithStudentCount>>> GetLeastPopularCoursesAsync();
    Task<ApiResponse<List<CourseWithStudentCount>>> GetTopThreeCoursesAsync();
    Task<ApiResponse<int>> GetTotalCoursesCountAsync();
}
