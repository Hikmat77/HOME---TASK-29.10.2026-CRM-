using Dapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class StudentRepository(AppDbContext appDbContext) : IStudentRepository
{
    private AppDbContext _context = appDbContext;
    public async Task<bool> AddStudentAsync(Students student)
    {
        using var connection = _context.Connection();
        var query = "insert into students(fullname, email, phone, enrollmentdate) values(@fullname, @email, @phone, @enrollmentdate)";
        var result = await connection.ExecuteAsync(query, student);
        return result>0;
    }

    public async Task<bool> DeleteStudentAsync(int studentId)
    {
        using var connection = _context.Connection();
        var query = "delete from students where studentid=@studentid";
        var result = await connection.ExecuteAsync(query, new{studentId});
        return result>0;
    }

    public async Task<Students> GetStudentAsync(int studentId)
    {
        using var connection = _context.Connection();
        var query = "select * from students where studentid=@studentid";
        var result = await connection.QuerySingleAsync<Students>(query, new{studentId});
        return result;
    }

    public async Task<List<Students>> GetStudentsAsync()
    {
        using var connection = _context.Connection();
        var query = "select * from students";
        var result = (await connection.QueryAsync<Students>(query)).ToList();
        return result;
    }

    public async Task<bool> UpdateStudentAsync(Students student)
    {
        using var connection = _context.Connection();
        var query = "update students set fullname=@fullname, email=@email, phone=@phone, enrollmentdate=@enrollmentdate where studentid=@studentid";
        var result = await connection.ExecuteAsync(query, student);
        return result>0;
    }
}