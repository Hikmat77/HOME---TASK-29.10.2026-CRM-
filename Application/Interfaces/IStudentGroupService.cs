using Domain.Models;

namespace Application.Interfaces;

public interface IStudentGroupService
{
    void AddStudentGroup(StudentGroups studentGroup);
    void UpdateStudentGroup(StudentGroups studentGroup);
    void DeleteStudentGroup(int studentGroupId);
    void GetStudentGroup(int studentGroupId);
    void GetAllStudentGroups();
}