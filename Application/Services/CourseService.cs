using Application.Interfaces;
using Domain.Models;
using Infrastructure;
using Infrastructure.Repositories;

namespace Application.Services;

public class CourseService(CourseRepository courseRepository) : ICourseService
{
    private CourseRepository _repository = courseRepository;
    public void AddCourse(Courses course)
    {
        var result =  _repository.AddCourse(course);
        if(result) System.Console.WriteLine("Added successfully!");
        else System.Console.WriteLine("Something went wrong!"); 
    }

    public void DeleteCourse(int courseId)
    {
        var result =  _repository.DeleteCourse(courseId);
        if(result) System.Console.WriteLine("Deleted successfully!");
        else System.Console.WriteLine("Something went wrong!"); 
    }

    public void GetAllCourses()
    {
       var courses = _repository.GetCourses();
       foreach (var course in courses)
       {
            System.Console.WriteLine(course.CourseId+" "+course.Title+" "+course.Description+" "+course.DurationWeeks);
       }
    }

    public void GetCourse(int courseId)
    {
        var course = _repository.GetCourse(courseId);
        System.Console.WriteLine(course.CourseId+" "+course.Title+" "+course.Description+" "+course.DurationWeeks);
    }

    public void UpdateCourse(Courses course)
    {
        var result = _repository.UpdateCourse(course);
        if(result) System.Console.WriteLine("Updated successfully!");
        else System.Console.WriteLine("Something went wrong!");
    }

}