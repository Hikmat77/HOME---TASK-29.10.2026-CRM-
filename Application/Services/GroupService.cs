using Application.Interfaces;
using Domain.Models;
using Infrastructure;
using Infrastructure.Repositories;

namespace Application.Services;

public class GroupService(GroupRepository groupRepository) : IGroupService
{
    private GroupRepository _repository = groupRepository;
    public async Task AddGroupAsync(Groups group)
    {
        var result = await _repository.AddGroupAsync(group);
        if(result) System.Console.WriteLine("Added successfully!");
        else System.Console.WriteLine("Something went wrong!"); 
    }

    public async Task DeleteGroupAsync(int groupId)
    {
        var result = await _repository.DeleteGroupAsync(groupId);
        if(result) System.Console.WriteLine("Deleted successfully!");
        else System.Console.WriteLine("Something went wrong!"); 
    }

    public async Task GetAllGroupsAsync()
    {
       var groups = await _repository.GetGroupsAsync();
       foreach (var group in groups)
       {
            System.Console.WriteLine(group.GroupId+" "+group.GroupName+" "+group.CourseId+" "+group.MentorId+" "+group.StartDate+" "+group.EndDate);
       }
    }

    public async Task GetGroupAsync(int groupId)
    {
        var group = await _repository.GetGroupAsync(groupId);
        System.Console.WriteLine(group.GroupId+" "+group.GroupName+" "+group.CourseId+" "+group.MentorId+" "+group.StartDate+" "+group.EndDate);
    }

    public async Task UpdateGroupAsync(Groups group)
    {
        var result = await _repository.UpdateGroupAsync(group);
        if(result) System.Console.WriteLine("Updated successfully!");
        else System.Console.WriteLine("Something went wrong!");
    }

    public async Task GetStudentsPerGroupAsync()
    {
       var groups = await _repository.GetStudentsPerGroupAsync();
       foreach (var group in groups)
       {
            System.Console.WriteLine(group.groupid+" "+group.groupname+" "+group.studentcount);
       }
    }

    public async Task GetEmptyGroupsAsync()
    {
       var groups = await _repository.GetEmptyGroupsAsync();
       foreach (var group in groups)
       {
            System.Console.WriteLine(group.GroupId+" "+group.GroupName+" "+group.CourseId+" "+group.MentorId+" "+group.StartDate+" "+group.EndDate);
       }
    }
}
