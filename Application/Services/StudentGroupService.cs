using Application.Interfaces;
using Domain.Models;
using Infrastructure;
using Infrastructure.Repositories;

namespace Application.Services;

public class StudentGroupService(StudentGroupRepository studentGroupRepository) : IStudentGroupService
{
    private StudentGroupRepository _repository = studentGroupRepository;
    public async Task AddStudentGroupAsync(StudentGroups studentGroup)
    {
        var result = await _repository.AddStudentGroupAsync(studentGroup);
        if(result) System.Console.WriteLine("Added successfully!");
        else System.Console.WriteLine("Something went wrong!"); 
    }

    public async Task DeleteStudentGroupAsync(int studentGroupId)
    {
        var result = await _repository.DeleteStudentGroupAsync(studentGroupId);
        if(result) System.Console.WriteLine("Deleted successfully!");
        else System.Console.WriteLine("Something went wrong!"); 
    }

    public async Task GetAllStudentGroupsAsync()
    {
       var studentGroups = await _repository.GetStudentGroupsAsync();
       foreach (var studentGroup in studentGroups)
       {
            System.Console.WriteLine(studentGroup.StudentGroupId+" "+studentGroup.StudentId+" "+studentGroup.GroupId+" "+studentGroup.Status);
       }
    }

    public async Task GetStudentGroupAsync(int studentGroupId)
    {
        var studentGroup = await _repository.GetStudentGroupAsync(studentGroupId);
        System.Console.WriteLine(studentGroup.StudentGroupId+" "+studentGroup.StudentId+" "+studentGroup.GroupId+" "+studentGroup.Status);
    }

    public async Task UpdateStudentGroupAsync(StudentGroups studentGroup)
    {
        var result = await _repository.UpdateStudentGroupAsync(studentGroup);
        if(result) System.Console.WriteLine("Updated successfully!");
        else System.Console.WriteLine("Something went wrong!");
    }

}
