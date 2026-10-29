using Domain.Models;

namespace Application.Interfaces;

public interface IMentorService
{
    void AddMentor(Mentors mentor);
    void UpdateMentor(Mentors mentor);
    void DeleteMentor(int mentorId);
    void GetMentor(int mentorId);
    void GetAllMentors();
}