using EduFlex.Service.DTOs.Users.UserRole;

namespace EduFlex.Service.Interfaces.Users;

public interface IUserRoleService
{
    Task<bool> DeleteUserRoleAsync(long id);
    Task<UserRoleForResultDto> GetUserRoleByIdAsync(long id);
    Task<IEnumerable<UserRoleForResultDto>> GetAllUserRolesAsync();
    Task<UserRoleForResultDto> AddUserRoleAsync(UserRoleForCreationDto userRole);
    Task<UserRoleForResultDto> UpdateUserRoleAsync(UserRoleForUpdateDto userRole);
}
