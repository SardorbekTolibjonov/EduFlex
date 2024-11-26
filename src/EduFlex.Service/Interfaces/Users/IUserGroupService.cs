using EduFlex.Domain.DTOs.Groups;
using EduFlex.Domain.DTOs.Users.User;
using EduFlex.Domain.DTOs.Users.UserGroup;

namespace EduFlex.Domain.Interfaces.Users;

public interface IUserGroupService
{
    Task<UserGroupForResultDto> AddUserGroupAsync(UserGroupDto dto);
    Task<bool> DeleteUserGroupAsync(UserGroupDto dto);
    Task<IEnumerable<UserForResultDto>> GetUsersByGroupIdAsync(long groupId);
    Task<IEnumerable<GroupForResultDto>> GetGroupsByUserIdAsync(long userId);
}
