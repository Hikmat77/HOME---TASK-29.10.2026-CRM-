using Dapper;
using Domain.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class AnalyticsRepository(AppDbContext appDbContext) : IAnalyticsRepository
{
    private AppDbContext _context = appDbContext;
    public async Task<decimal> GetCompletionRateAsync()
    {
        using var connection = _context.Connection();
        var query = "select case when count(distinct studentid)=0 then 0 else round(100.0 * count(distinct studentid) filter (where status=2) / count(distinct studentid), 2) end from studentgroups";
        var result = await connection.ExecuteScalarAsync<decimal>(query);
        return result;
    }
}