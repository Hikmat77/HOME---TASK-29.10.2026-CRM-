using Dapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class StudentGroupRepository(AppDbContext appDbContext) : IStudentGroupRepository
{
    private AppDbContext _context = appDbContext;
    public async Task<bool> AddStudentGroupAsync(StudentGroups studentGroup)
    {
        using var connection = _context.Connection();
        var query = "insert into studentgroups(studentid, groupid, status) values(@studentid, @groupid, @status)";
        var result = await connection.ExecuteAsync(query, studentGroup);
        return result > 0;
    }

    public async Task<bool> DeleteStudentGroupAsync(int studentGroupId)
    {
        using var connection = _context.Connection();
        var query = "delete from studentgroups where studentgroupid=@studentgroupid";
        var result = await connection.ExecuteAsync(query, new { studentGroupId });
        return result > 0;
    }

    public async Task<StudentGroups> GetStudentGroupAsync(int studentGroupId)
    {
        using var connection = _context.Connection();
        var query = "select * from studentgroups where studentgroupid=@studentgroupid";
        var result = await connection.QuerySingleAsync<StudentGroups>(query, new { studentGroupId });
        return result;
    }

    public async Task<List<StudentGroups>> GetStudentGroupsAsync()
    {
        using var connection = _context.Connection();
        var query = "select * from studentgroups";
        var result = (await connection.QueryAsync<StudentGroups>(query)).ToList();
        return result;
    }

    public async Task<bool> UpdateStudentGroupAsync(StudentGroups studentGroup)
    {
        using var connection = _context.Connection();
        var query = "update studentgroups set studentid=@studentid, groupid=@groupid, status=@status where studentgroupid=@studentgroupid";
        var result = await connection.ExecuteAsync(query, studentGroup);
        return result > 0;
    }
}
