using System.Net;
using Application.DTOs;
using Application.Interfaces;
using Application.Responses;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Services;

public class StudentGroupService(IStudentGroupRepository studentGroupRepository) : IStudentGroupService
{
    private IStudentGroupRepository repository = studentGroupRepository;
    public async Task<ApiResponse<bool>> AddStudentGroupAsync(CreateStudentGroupDto dto)
    {
        var studentGroup = new StudentGroups()
        {
            StudentId = dto.StudentId,
            GroupId = dto.GroupId,
            Status = dto.Status
        };
        var res = await repository.AddStudentGroupAsync(studentGroup);
        return res==true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Added!", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not added.", res);
    }

    public async Task<ApiResponse<bool>> DeleteStudentGroupAsync(int studentGroupId)
    {
        var res = await repository.DeleteStudentGroupAsync(studentGroupId);
        return res==true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Deleted!", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not deleted.", res);
    }

    public async Task<ApiResponse<StudentGroupDto>> GetStudentGroupAsync(int studentGroupId)
    {
        var studentGroup = await repository.GetStudentGroupAsync(studentGroupId);
        var res = new StudentGroupDto()
        {
            StudentGroupId = studentGroup.StudentGroupId,
            StudentId = studentGroup.StudentId,
            GroupId = studentGroup.GroupId,
            Status = studentGroup.Status
        };
        return new ApiResponse<StudentGroupDto>(HttpStatusCode.OK, "Student group with given id.", res);
    }

    public async Task<ApiResponse<List<StudentGroupDto>>> GetAllStudentGroupsAsync()
    {
        var studentGroups = await repository.GetStudentGroupsAsync();
        var res = studentGroups.Select(x=>new StudentGroupDto()
        {
            StudentGroupId = x.StudentGroupId,
            StudentId = x.StudentId,
            GroupId = x.GroupId,
            Status = x.Status
        }).ToList();
        return new ApiResponse<List<StudentGroupDto>>(HttpStatusCode.OK, "List of student groups.", res);
    }

    public async Task<ApiResponse<bool>> UpdateStudentGroupAsync(int studentGroupId, UpdateStudentGroupDto dto)
    {
        var studentGroup = new StudentGroups()
        {
            StudentGroupId = studentGroupId,
            StudentId = dto.StudentId,
            GroupId = dto.GroupId,
            Status = dto.Status
        };
        var res = await repository.UpdateStudentGroupAsync(studentGroup);
        return res==true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Updated!", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not updated.", res);
    }
}
