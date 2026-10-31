using Application.Interfaces;
using Domain.Models;
using Infrastructure;
using Infrastructure.Repositories;

namespace Application.Services;

public class CourseService(CourseRepository courseRepository) : ICourseService
{
    private CourseRepository _repository = courseRepository;
    public async Task AddCourseAsync(Courses course)
    {
        var result = await _repository.AddCourseAsync(course);
        if(result) System.Console.WriteLine("Added successfully!");
        else System.Console.WriteLine("Something went wrong!"); 
    }

    public async Task DeleteCourseAsync(int courseId)
    {
        var result = await _repository.DeleteCourseAsync(courseId);
        if(result) System.Console.WriteLine("Deleted successfully!");
        else System.Console.WriteLine("Something went wrong!"); 
    }

    public async Task GetAllCoursesAsync()
    {
       var courses = await _repository.GetCoursesAsync();
       foreach (var course in courses)
       {
            System.Console.WriteLine(course.CourseId+" "+course.Title+" "+course.Description+" "+course.DurationWeeks);
       }
    }

    public async Task GetCourseAsync(int courseId)
    {
        var course = await _repository.GetCourseAsync(courseId);
        System.Console.WriteLine(course.CourseId+" "+course.Title+" "+course.Description+" "+course.DurationWeeks);
    }

    public async Task UpdateCourseAsync(Courses course)
    {
        var result = await _repository.UpdateCourseAsync(course);
        if(result) System.Console.WriteLine("Updated successfully!");
        else System.Console.WriteLine("Something went wrong!");
    }

    public async Task GetStudentsPerCourseAsync()
    {
       var courses = await _repository.GetStudentsPerCourseAsync();
       foreach (var course in courses)
       {
            System.Console.WriteLine(course.courseid+" "+course.title+" "+course.studentcount);
       }
    }

    public async Task GetMostPopularCourseAsync()
    {
        var course = await _repository.GetMostPopularCourseAsync();
        if(course == null) System.Console.WriteLine("Nothing found!");
        else System.Console.WriteLine(course.courseid+" "+course.title+" "+course.studentcount);
    }

    public async Task GetLeastPopularCoursesAsync()
    {
       var courses = await _repository.GetLeastPopularCoursesAsync();
       foreach (var course in courses)
       {
            System.Console.WriteLine(course.courseid+" "+course.title+" "+course.studentcount);
       }
    }

    public async Task GetTopThreeCoursesAsync()
    {
       var courses = await _repository.GetTopThreeCoursesAsync();
       foreach (var course in courses)
       {
            System.Console.WriteLine(course.courseid+" "+course.title+" "+course.studentcount);
       }
    }
}
