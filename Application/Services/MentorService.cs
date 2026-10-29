using Application.Interfaces;
using Domain.Models;
using Infrastructure;
using Infrastructure.Repositories;

namespace Application.Services;

public class MentorService(MentorRepository mentorRepository) : IMentorService
{
    private MentorRepository _repository = mentorRepository;
    public void AddMentor(Mentors mentor)
    {
        var result =  _repository.AddMentor(mentor);
        if(result) System.Console.WriteLine("Added successfully!");
        else System.Console.WriteLine("Something went wrong!"); 
    }

    public void DeleteMentor(int mentorId)
    {
        var result =  _repository.DeleteMentor(mentorId);
        if(result) System.Console.WriteLine("Deleted successfully!");
        else System.Console.WriteLine("Something went wrong!"); 
    }

    public void GetAllMentors()
    {
       var mentors = _repository.GetMentors();
       foreach (var mentor in mentors)
       {
            System.Console.WriteLine(mentor.MentorId+" "+mentor.FullName+" "+mentor.Email+" "+mentor.Phone+" "+mentor.Specialization);
       }
    }

    public void GetMentor(int mentorId)
    {
        var mentor = _repository.GetMentor(mentorId);
        System.Console.WriteLine(mentor.MentorId+" "+mentor.FullName+" "+mentor.Email+" "+mentor.Phone+" "+mentor.Specialization);
    }

    public void UpdateMentor(Mentors mentor)
    {
        var result = _repository.UpdateMentor(mentor);
        if(result) System.Console.WriteLine("Updated successfully!");
        else System.Console.WriteLine("Something went wrong!");
    }
}