using System.Net;
using Application.DTOs;
using Application.Interfaces;
using Application.Responses;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Services;

public class GroupService(IGroupRepository groupRepository) : IGroupService
{
    private IGroupRepository repository = groupRepository;
    public async Task<ApiResponse<bool>> AddGroupAsync(CreateGroupDto dto)
    {
        var group = new Groups()
        {
            GroupName = dto.GroupName,
            CourseId = dto.CourseId,
            MentorId = dto.MentorId,
            StartDate = dto.StartDate,
            EndDate = dto.EndDate
        };
        var res = await repository.AddGroupAsync(group);
        return res==true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Added!", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not added.", res);
    }

    public async Task<ApiResponse<bool>> DeleteGroupAsync(int groupId)
    {
        var res = await repository.DeleteGroupAsync(groupId);
        return res==true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Deleted!", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not deleted.", res);
    }

    public async Task<ApiResponse<GroupDto>> GetGroupAsync(int groupId)
    {
        var group = await repository.GetGroupAsync(groupId);
        var res = new GroupDto()
        {
            GroupId = group.GroupId,
            GroupName = group.GroupName,
            CourseId = group.CourseId,
            MentorId = group.MentorId,
            StartDate = group.StartDate,
            EndDate = group.EndDate
        };
        return new ApiResponse<GroupDto>(HttpStatusCode.OK, "Group with given id.", res);
    }

    public async Task<ApiResponse<List<GroupDto>>> GetAllGroupsAsync()
    {
        var groups = await repository.GetGroupsAsync();
        var res = groups.Select(x=>new GroupDto()
        {
            GroupId = x.GroupId,
            GroupName = x.GroupName,
            CourseId = x.CourseId,
            MentorId = x.MentorId,
            StartDate = x.StartDate,
            EndDate = x.EndDate
        }).ToList();
        return new ApiResponse<List<GroupDto>>(HttpStatusCode.OK, "List of groups.", res);
    }

    public async Task<ApiResponse<List<GroupWithStudentCount>>> GetStudentsPerGroupAsync()
    {
        var groups = await repository.GetStudentsPerGroupAsync();
        var res = groups.Select(x=>new GroupWithStudentCount()
        {
            GroupId = x.groupid,
            GroupName = x.groupname,
            StudentCount = x.studentcount
        }).ToList();
        return new ApiResponse<List<GroupWithStudentCount>>(HttpStatusCode.OK, "Students per group.", res);
    }

    public async Task<ApiResponse<List<GroupDto>>> GetEmptyGroupsAsync()
    {
        var groups = await repository.GetEmptyGroupsAsync();
        var res = groups.Select(x=>new GroupDto()
        {
            GroupId = x.GroupId,
            GroupName = x.GroupName,
            CourseId = x.CourseId,
            MentorId = x.MentorId,
            StartDate = x.StartDate,
            EndDate = x.EndDate
        }).ToList();
        return new ApiResponse<List<GroupDto>>(HttpStatusCode.OK, "Empty groups.", res);
    }

    public async Task<ApiResponse<int>> GetTotalGroupsCountAsync()
    {
        var res = await repository.GetTotalGroupsCountAsync();
        return new ApiResponse<int>(HttpStatusCode.OK, "Total groups.", res);
    }

    public async Task<ApiResponse<List<DateTime>>> GetAllStartDatesAsync()
    {
        var res = await repository.GetAllStartDatesAsync();
        return new ApiResponse<List<DateTime>>(HttpStatusCode.OK, "List of start dates.", res);
    }

    public async Task<ApiResponse<bool>> UpdateGroupAsync(int groupId, UpdateGroupDto dto)
    {
        var group = new Groups()
        {
            GroupId = groupId,
            GroupName = dto.GroupName,
            CourseId = dto.CourseId,
            MentorId = dto.MentorId,
            StartDate = dto.StartDate,
            EndDate = dto.EndDate
        };
        var res = await repository.UpdateGroupAsync(group);
        return res==true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Updated!", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not updated.", res);
    }
}
