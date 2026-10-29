using Application.Interfaces;
using Domain.Models;
using Infrastructure;
using Infrastructure.Repositories;

namespace Application.Services;

public class StudentGroupService(StudentGroupRepository studentGroupRepository) : IStudentGroupService
{
    private StudentGroupRepository _repository = studentGroupRepository;
    public void AddStudentGroup(StudentGroups studentGroup)
    {
        var result =  _repository.AddStudentGroup(studentGroup);
        if(result) System.Console.WriteLine("Added successfully!");
        else System.Console.WriteLine("Something went wrong!"); 
    }

    public void DeleteStudentGroup(int studentGroupId)
    {
        var result =  _repository.DeleteStudentGroup(studentGroupId);
        if(result) System.Console.WriteLine("Deleted successfully!");
        else System.Console.WriteLine("Something went wrong!"); 
    }

    public void GetAllStudentGroups()
    {
       var studentGroups = _repository.GetStudentGroups();
       foreach (var studentGroup in studentGroups)
       {
            System.Console.WriteLine(studentGroup.StudentGroupId+" "+studentGroup.StudentId+" "+studentGroup.GroupId+" "+studentGroup.Status);
       }
    }

    public void GetStudentGroup(int studentGroupId)
    {
        var studentGroup = _repository.GetStudentGroup(studentGroupId);
        System.Console.WriteLine(studentGroup.StudentGroupId+" "+studentGroup.StudentId+" "+studentGroup.GroupId+" "+studentGroup.Status);
    }

    public void UpdateStudentGroup(StudentGroups studentGroup)
    {
        var result = _repository.UpdateStudentGroup(studentGroup);
        if(result) System.Console.WriteLine("Updated successfully!");
        else System.Console.WriteLine("Something went wrong!");
    }
}