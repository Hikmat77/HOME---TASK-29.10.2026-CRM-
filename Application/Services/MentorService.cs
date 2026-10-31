using Application.Interfaces;
using Domain.Models;
using Infrastructure;
using Infrastructure.Repositories;

namespace Application.Services;

public class MentorService(MentorRepository mentorRepository) : IMentorService
{
    private MentorRepository _repository = mentorRepository;
    public async Task AddMentorAsync(Mentors mentor)
    {
        var result = await _repository.AddMentorAsync(mentor);
        if(result) System.Console.WriteLine("Added successfully!");
        else System.Console.WriteLine("Something went wrong!"); 
    }

    public async Task DeleteMentorAsync(int mentorId)
    {
        var result = await _repository.DeleteMentorAsync(mentorId);
        if(result) System.Console.WriteLine("Deleted successfully!");
        else System.Console.WriteLine("Something went wrong!"); 
    }

    public async Task GetAllMentorsAsync()
    {
       var mentors = await _repository.GetMentorsAsync();
       foreach (var mentor in mentors)
       {
            System.Console.WriteLine(mentor.MentorId+" "+mentor.FullName+" "+mentor.Email+" "+mentor.Phone+" "+mentor.Specialization);
       }
    }

    public async Task GetMentorAsync(int mentorId)
    {
        var mentor = await _repository.GetMentorAsync(mentorId);
        System.Console.WriteLine(mentor.MentorId+" "+mentor.FullName+" "+mentor.Email+" "+mentor.Phone+" "+mentor.Specialization);
    }

    public async Task UpdateMentorAsync(Mentors mentor)
    {
        var result = await _repository.UpdateMentorAsync(mentor);
        if(result) System.Console.WriteLine("Updated successfully!");
        else System.Console.WriteLine("Something went wrong!");
    }

    public async Task GetMentorWithMostStudentsAsync()
    {
        var mentor = await _repository.GetMentorWithMostStudentsAsync();
        if(mentor == null) System.Console.WriteLine("Nothing found!");
        else System.Console.WriteLine(mentor.mentorid+" "+mentor.fullname+" "+mentor.studentcount);
    }

    public async Task GetMentorsWithMultipleCoursesAsync()
    {
       var mentors = await _repository.GetMentorsWithMultipleCoursesAsync();
       foreach (var mentor in mentors)
       {
            System.Console.WriteLine(mentor.mentorid+" "+mentor.fullname+" "+mentor.coursecount);
       }
    }
}
