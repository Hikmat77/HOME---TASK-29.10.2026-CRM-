using Domain.Models;

namespace Domain.Interfaces;

public interface ICourseRepository
{
    Task<bool> AddCourseAsync(Courses course);
    Task<bool> UpdateCourseAsync(Courses course);
    Task<bool> DeleteCourseAsync(int courseId);
    Task<Courses> GetCourseAsync(int courseId);
    Task<List<Courses>> GetCoursesAsync();
    Task<List<dynamic>> GetStudentsPerCourseAsync();
    Task<dynamic> GetMostPopularCourseAsync();
    Task<List<dynamic>> GetLeastPopularCoursesAsync();
    Task<List<dynamic>> GetTopThreeCoursesAsync();
}
