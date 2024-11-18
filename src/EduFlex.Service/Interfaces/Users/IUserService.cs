using EduFlex.Service.DTOs.Users.User;

namespace EduFlex.Service.Interfaces.Users;

public interface IUserService
{
    Task<bool> DeleteUserAsync(long id);
    Task<UserForResultDto> GetUserByIdAsync(long id);
    Task<IEnumerable<UserForResultDto>> GetAllUsersAsync();
    Task<UserForResultDto> CreateUserAsync(UserForCreationDto user);
    Task<UserForResultDto> UpdateUserAsync(long id, UserForUpdateDto user);
}
