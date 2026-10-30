using Domain.Models;

namespace Application.Interfaces;

public interface ICourseService
{
    Task AddCourseAsync(Courses course);
    Task UpdateCourseAsync(Courses course);
    Task DeleteCourseAsync(int courseId);
    Task GetCourseAsync(int courseId);
    Task GetAllCoursesAsync();
}
