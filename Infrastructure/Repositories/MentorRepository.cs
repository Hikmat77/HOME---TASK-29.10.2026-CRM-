using Dapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class MentorRepository(AppDbContext appDbContext) : IMentorRepository
{
    private AppDbContext _context = appDbContext;
    public async Task<bool> AddMentorAsync(Mentors mentor)
    {
        using var connection = _context.Connection();
        var query = "insert into mentors(fullname, email, phone, specialization) values(@fullname, @email, @phone, @specialization)";
        var result = await connection.ExecuteAsync(query, mentor);
        return result > 0;
    }

    public async Task<bool> DeleteMentorAsync(int mentorId)
    {
        using var connection = _context.Connection();
        var query = "delete from mentors where mentorid=@mentorid";
        var result = await connection.ExecuteAsync(query, new { mentorId });
        return result > 0;
    }

    public async Task<Mentors> GetMentorAsync(int mentorId)
    {
        using var connection = _context.Connection();
        var query = "select * from mentors where mentorid=@mentorid";
        var result = await connection.QuerySingleAsync<Mentors>(query, new { mentorId });
        return result;
    }

    public async Task<List<Mentors>> GetMentorsAsync()
    {
        using var connection = _context.Connection();
        var query = "select * from mentors";
        var result = (await connection.QueryAsync<Mentors>(query)).ToList();
        return result;
    }

    public Task<List<dynamic>> GetMentorsWithMultipleCoursesAsync()
    {
        throw new NotImplementedException();
    }

    public Task<dynamic> GetMentorWithMostStudentsAsync()
    {
        throw new NotImplementedException();
    }


    public async Task<bool> UpdateMentorAsync(Mentors mentor)
    {
        using var connection = _context.Connection();
        var query = "update mentors set fullname=@fullname, email=@email, phone=@phone, specialization=@specialization where mentorid=@mentorid";
        var result = await connection.ExecuteAsync(query, mentor);
        return result > 0;
    }
}
