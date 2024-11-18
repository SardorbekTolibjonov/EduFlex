using EduFlex.Domain.Enums;
using EduFlex.Service.DTOs.Users.UserRole;

namespace EduFlex.Service.Interfaces.Users;

public interface IUserRoleService
{
    Task<bool> DeleteUserRoleAsync(long id);
    Task<IEnumerable<UserRoleForResultDto>> GetUserRoleByRoleNameAsync(Role role);
    Task<IEnumerable<UserRoleForResultDto>> GetAllUserRolesAsync();
    Task<UserRoleForResultDto> AddUserRoleAsync(UserRoleForCreationDto userRole);
    Task<UserRoleForResultDto> UpdateUserRoleAsync(long id,UserRoleForUpdateDto userRole);
}
