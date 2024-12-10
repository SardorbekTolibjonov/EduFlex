using EduFlex.Domain.Enums;
using EduFlex.Domain.DTOs.Users.UserRole;

namespace EduFlex.Domain.Interfaces.Users;

public interface IUserRoleService
{
    Task<bool> DeleteUserRoleAsync(long id);
    Task<IEnumerable<UserRoleForResultDto>> GetUserRoleByRoleNameAsync(Role role);
    Task<IEnumerable<UserRoleForResultDto>> GetAllUserRolesAsync();
    Task<UserRoleForResultDto> AddUserRoleAsync(UserRoleForCreationDto userRole);
    Task<UserRoleForResultDto> UpdateUserRoleAsync(long id,UserRoleForUpdateDto userRole);
}
