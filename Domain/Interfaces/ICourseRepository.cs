using Domain.Models;

namespace Domain.Interfaces;

public interface ICourseRepository
{
    bool AddCourse(Courses course);
    bool UpdateCourse(Courses course);
    bool DeleteCourse(int courseId);
    Courses GetCourse(int courseId);
    List<Courses> GetCourses();
}