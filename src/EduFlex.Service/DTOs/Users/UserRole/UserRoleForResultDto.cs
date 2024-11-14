using EduFlex.Domain.Enums;

namespace EduFlex.Service.DTOs.Users.UserRole;

public class UserRoleForResultDto
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public Role Role { get; set; }
}
