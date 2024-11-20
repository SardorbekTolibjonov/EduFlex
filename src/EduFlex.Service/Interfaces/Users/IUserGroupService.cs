using EduFlex.Service.DTOs.Groups;
using EduFlex.Service.DTOs.Users.User;
using EduFlex.Service.DTOs.Users.UserGroup;

namespace EduFlex.Service.Interfaces.Users;

public interface IUserGroupService
{
    Task<UserGroupForResultDto> AddUserGroupAsync(UserGroupDto dto);
    Task<bool> DeleteUserGroupAsync(UserGroupDto dto);
    Task<IEnumerable<UserForResultDto>> GetUsersByGroupIdAsync(long groupId);
    Task<IEnumerable<GroupForResultDto>> GetGroupsByUserIdAsync(long userId);
}
