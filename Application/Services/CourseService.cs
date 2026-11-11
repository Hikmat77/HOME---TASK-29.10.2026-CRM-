using System.Net;
using Application.DTOs;
using Application.Interfaces;
using Application.Responses;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Services;

public class CourseService(ICourseRepository courseRepository) : ICourseService
{
    private ICourseRepository repository = courseRepository;
    public async Task<ApiResponse<bool>> AddCourseAsync(CreateCourseDto dto)
    {
        var course = new Courses()
        {
            Title = dto.Title,
            Description = dto.Description,
            DurationWeeks = dto.DurationWeeks
        };
        var res = await repository.AddCourseAsync(course);
        return res==true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Added!", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not added.", res);
    }

    public async Task<ApiResponse<bool>> DeleteCourseAsync(int courseId)
    {
        var res = await repository.DeleteCourseAsync(courseId);
        return res==true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Deleted!", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not deleted.", res);
    }

    public async Task<ApiResponse<CourseDto>> GetCourseAsync(int courseId)
    {
        var course = await repository.GetCourseAsync(courseId);
        var res = new CourseDto()
        {
            CourseId = course.CourseId,
            Title = course.Title,
            Description = course.Description,
            DurationWeeks = course.DurationWeeks
        };
        return new ApiResponse<CourseDto>(HttpStatusCode.OK, "Course with given id.", res);
    }

    public async Task<ApiResponse<List<CourseDto>>> GetAllCoursesAsync()
    {
        var courses = await repository.GetCoursesAsync();
        var res = courses.Select(x=>new CourseDto()
        {
            CourseId = x.CourseId,
            Title = x.Title,
            Description = x.Description,
            DurationWeeks = x.DurationWeeks
        }).ToList();
        return new ApiResponse<List<CourseDto>>(HttpStatusCode.OK, "List of courses.", res);
    }

    public async Task<ApiResponse<List<CourseWithStudentCount>>> GetStudentsPerCourseAsync()
    {
        var courses = await repository.GetStudentsPerCourseAsync();
        var res = courses.Select(x=>new CourseWithStudentCount()
        {
            CourseId = x.courseid,
            Title = x.title,
            StudentCount = x.studentcount
        }).ToList();
        return new ApiResponse<List<CourseWithStudentCount>>(HttpStatusCode.OK, "Students per course.", res);
    }

    public async Task<ApiResponse<CourseWithStudentCount>> GetMostPopularCourseAsync()
    {
        var course = await repository.GetMostPopularCourseAsync();
        if (course == null)
        {
            return new ApiResponse<CourseWithStudentCount>(HttpStatusCode.NotFound, "Nothing found!", course);
        }
        var res = new CourseWithStudentCount()
        {
            CourseId = course.courseid,
            Title = course.title,
            StudentCount = course.studentcount
        };
        return new ApiResponse<CourseWithStudentCount>(HttpStatusCode.OK, "Most popular course.", res);
    }

    public async Task<ApiResponse<List<CourseWithStudentCount>>> GetLeastPopularCoursesAsync()
    {
        var courses = await repository.GetLeastPopularCoursesAsync();
        var res = courses.Select(x=>new CourseWithStudentCount()
        {
            CourseId = x.courseid,
            Title = x.title,
            StudentCount = x.studentcount
        }).ToList();
        return new ApiResponse<List<CourseWithStudentCount>>(HttpStatusCode.OK, "Least popular courses.", res);
    }

    public async Task<ApiResponse<List<CourseWithStudentCount>>> GetTopThreeCoursesAsync()
    {
        var courses = await repository.GetTopThreeCoursesAsync();
        var res = courses.Select(x=>new CourseWithStudentCount()
        {
            CourseId = x.courseid,
            Title = x.title,
            StudentCount = x.studentcount
        }).ToList();
        return new ApiResponse<List<CourseWithStudentCount>>(HttpStatusCode.OK, "Top three courses.", res);
    }

    public async Task<ApiResponse<int>> GetTotalCoursesCountAsync()
    {
        var res = await repository.GetTotalCoursesCountAsync();
        return new ApiResponse<int>(HttpStatusCode.OK, "Total courses.", res);
    }

    public async Task<ApiResponse<bool>> UpdateCourseAsync(int courseId, UpdateCourseDto dto)
    {
        var course = new Courses()
        {
            CourseId = courseId,
            Title = dto.Title,
            Description = dto.Description,
            DurationWeeks = dto.DurationWeeks
        };
        var res = await repository.UpdateCourseAsync(course);
        return res==true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Updated!", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not updated.", res);
    }
}
