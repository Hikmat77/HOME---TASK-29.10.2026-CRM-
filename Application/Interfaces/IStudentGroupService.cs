using Domain.Models;

namespace Application.Interfaces;

public interface IStudentGroupService
{
    Task AddStudentGroupAsync(StudentGroups studentGroup);
    Task UpdateStudentGroupAsync(StudentGroups studentGroup);
    Task DeleteStudentGroupAsync(int studentGroupId);
    Task GetStudentGroupAsync(int studentGroupId);
    Task GetAllStudentGroupsAsync();
}
