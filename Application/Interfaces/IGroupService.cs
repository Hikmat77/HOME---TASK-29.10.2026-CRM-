using Domain.Models;

namespace Application.Interfaces;

public interface IGroupService
{
    void AddGroup(Groups group);
    void UpdateGroup(Groups group);
    void DeleteGroup(int groupId);
    void GetGroup(int groupId);
    void GetAllGroups();
}