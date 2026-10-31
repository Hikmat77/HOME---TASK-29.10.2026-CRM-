using Application.Interfaces;
using Infrastructure;
using Infrastructure.Repositories;

namespace Application.Services;

public class AnalyticsService(AnalyticsRepository analyticsRepository) : IAnalyticsService
{
    private AnalyticsRepository _repository = analyticsRepository;
    public async Task GetCompletionRateAsync()
    {
        var result = await _repository.GetCompletionRateAsync();
        System.Console.WriteLine("Completion rate: "+result+"%");
    }
}
