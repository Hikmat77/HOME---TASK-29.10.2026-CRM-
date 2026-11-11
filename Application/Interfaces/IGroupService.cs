using Application.DTOs;
using Application.Responses;

namespace Application.Interfaces;

public interface IGroupService
{
    Task<ApiResponse<bool>> AddGroupAsync(CreateGroupDto dto);
    Task<ApiResponse<bool>> UpdateGroupAsync(int groupId, UpdateGroupDto dto);
    Task<ApiResponse<bool>> DeleteGroupAsync(int groupId);
    Task<ApiResponse<GroupDto>> GetGroupAsync(int groupId);
    Task<ApiResponse<List<GroupDto>>> GetAllGroupsAsync();

    Task<ApiResponse<List<GroupWithStudentCount>>> GetStudentsPerGroupAsync();
    Task<ApiResponse<List<GroupDto>>> GetEmptyGroupsAsync();
    Task<ApiResponse<int>> GetTotalGroupsCountAsync();
    Task<ApiResponse<List<DateTime>>> GetAllStartDatesAsync();
}
