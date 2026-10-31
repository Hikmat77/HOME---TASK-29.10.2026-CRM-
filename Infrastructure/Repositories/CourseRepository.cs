using Dapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class CourseRepository(AppDbContext appDbContext) : ICourseRepository
{
    private AppDbContext _context = appDbContext;
    public async Task<bool> AddCourseAsync(Courses course)
    {
        using var connection = _context.Connection();
        var query = "insert into courses(title, description, durationweeks) values(@title, @description, @durationweeks)";
        var result = await connection.ExecuteAsync(query, course);
        return result > 0;
    }

    public async Task<bool> DeleteCourseAsync(int courseId)
    {
        using var connection = _context.Connection();
        var query = "delete from courses where courseid=@courseid";
        var result = await connection.ExecuteAsync(query, new { courseId });
        return result > 0;
    }

    public async Task<Courses> GetCourseAsync(int courseId)
    {
        using var connection = _context.Connection();
        var query = "select * from courses where courseid=@courseid";
        var result = await connection.QuerySingleAsync<Courses>(query, new { courseId });
        return result;
    }

    public async Task<List<Courses>> GetCoursesAsync()
    {
        using var connection = _context.Connection();
        var query = "select * from courses";
        var result = (await connection.QueryAsync<Courses>(query)).ToList();
        return result;
    }

    public async Task<bool> UpdateCourseAsync(Courses course)
    {
        using var connection = _context.Connection();
        var query = "update courses set title=@title, description=@description, durationweeks=@durationweeks where courseid=@courseid";
        var result = await connection.ExecuteAsync(query, course);
        return result > 0;
    }

    public async Task<List<dynamic>> GetStudentsPerCourseAsync()
    {
        using var connection = _context.Connection();
        var query = "select c.courseid, c.title, count(distinct sg.studentid)::int as studentcount from courses c left join groups g on g.courseid=c.courseid left join studentgroups sg on sg.groupid=g.groupid group by c.courseid, c.title order by c.courseid";
        var result = (await connection.QueryAsync(query)).ToList();
        return result;
    }

    public async Task<dynamic> GetMostPopularCourseAsync()
    {
        using var connection = _context.Connection();
        var query = "select c.courseid, c.title, count(distinct sg.studentid)::int as studentcount from courses c left join groups g on g.courseid=c.courseid left join studentgroups sg on sg.groupid=g.groupid group by c.courseid, c.title order by studentcount desc, c.courseid limit 1";
        var result = await connection.QueryFirstOrDefaultAsync(query);
        return result;
    }

    public async Task<List<dynamic>> GetLeastPopularCoursesAsync()
    {
        using var connection = _context.Connection();
        var query = "select c.courseid, c.title, count(distinct sg.studentid)::int as studentcount from courses c left join groups g on g.courseid=c.courseid left join studentgroups sg on sg.groupid=g.groupid group by c.courseid, c.title order by studentcount asc, c.courseid limit 3";
        var result = (await connection.QueryAsync(query)).ToList();
        return result;
    }

    public async Task<List<dynamic>> GetTopThreeCoursesAsync()
    {
        using var connection = _context.Connection();
        var query = "select c.courseid, c.title, count(distinct sg.studentid)::int as studentcount from courses c left join groups g on g.courseid=c.courseid left join studentgroups sg on sg.groupid=g.groupid group by c.courseid, c.title order by studentcount desc, c.courseid limit 3";
        var result = (await connection.QueryAsync(query)).ToList();
        return result;
    }
}