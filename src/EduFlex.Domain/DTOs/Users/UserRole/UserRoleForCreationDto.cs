using EduFlex.Domain.Enums;

namespace EduFlex.Domain.DTOs.Users.UserRole;

public class UserRoleForCreationDto
{
    public long UserId { get; set; }
    public Role Role { get; set; }
}
