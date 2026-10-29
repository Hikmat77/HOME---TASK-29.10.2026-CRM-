using Application.Interfaces;
using Domain.Models;
using Infrastructure;
using Infrastructure.Repositories;

namespace Application.Services;

public class GroupService(GroupRepository groupRepository) : IGroupService
{
    private GroupRepository _repository = groupRepository;
    public void AddGroup(Groups group)
    {
        var result =  _repository.AddGroup(group);
        if(result) System.Console.WriteLine("Added successfully!");
        else System.Console.WriteLine("Something went wrong!"); 
    }

    public void DeleteGroup(int groupId)
    {
        var result =  _repository.DeleteGroup(groupId);
        if(result) System.Console.WriteLine("Deleted successfully!");
        else System.Console.WriteLine("Something went wrong!"); 
    }

    public void GetAllGroups()
    {
       var groups = _repository.GetGroups();
       foreach (var group in groups)
       {
            System.Console.WriteLine(group.GroupId+" "+group.GroupName+" "+group.CourseId+" "+group.MentorId+" "+group.StartDate+" "+group.EndDate);
       }
    }

    public void GetGroup(int groupId)
    {
        var group = _repository.GetGroup(groupId);
        System.Console.WriteLine(group.GroupId+" "+group.GroupName+" "+group.CourseId+" "+group.MentorId+" "+group.StartDate+" "+group.EndDate);
    }

    public void UpdateGroup(Groups group)
    {
        var result = _repository.UpdateGroup(group);
        if(result) System.Console.WriteLine("Updated successfully!");
        else System.Console.WriteLine("Something went wrong!");
    }
}