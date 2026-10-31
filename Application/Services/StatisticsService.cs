using Application.Interfaces;
using Infrastructure;
using Infrastructure.Repositories;

namespace Application.Services;

public class StatisticsService(StatisticsRepository statisticsRepository) : IStatisticsService
{
    private StatisticsRepository _repository = statisticsRepository;
    public async Task GetTotalStudentsCountAsync()
    {
        var result = await _repository.GetTotalStudentsCountAsync();
        System.Console.WriteLine("Total students: "+result);
    }

    public async Task GetTotalGroupsCountAsync()
    {
        var result = await _repository.GetTotalGroupsCountAsync();
        System.Console.WriteLine("Total groups: "+result);
    }

    public async Task GetTotalCoursesCountAsync()
    {
        var result = await _repository.GetTotalCoursesCountAsync();
        System.Console.WriteLine("Total courses: "+result);
    }

    public async Task GetTotalMentorsCountAsync()
    {
        var result = await _repository.GetTotalMentorsCountAsync();
        System.Console.WriteLine("Total mentors: "+result);
    }

    public async Task GetAllStartDatesAsync()
    {
       var dates = await _repository.GetAllStartDatesAsync();
       foreach (var date in dates)
       {
            System.Console.WriteLine(DateOnly.FromDateTime(date));
       }
    }
}
