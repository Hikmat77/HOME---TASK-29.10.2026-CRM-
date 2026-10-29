using Domain.Models;

namespace Application.Interfaces;

public interface ICourseService
{
    void AddCourse(Courses course);
    void UpdateCourse(Courses course);
    void DeleteCourse(int courseId);
    void GetCourse(int courseId);
    void GetAllCourses();
}