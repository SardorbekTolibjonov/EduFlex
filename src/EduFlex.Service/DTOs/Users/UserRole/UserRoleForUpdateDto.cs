using EduFlex.Domain.Enums;

namespace EduFlex.Service.DTOs.Users.UserRole;

public class UserRoleForUpdateDto
{
    public long UserId { get; set; }
    public Role Role { get; set; }
}
