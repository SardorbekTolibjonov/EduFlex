using EduFlex.Domain.Commons;
using EduFlex.Domain.Enums;

namespace EduFlex.Domain.Entities.Users;

public class UserRole : Auditable
{
    public long UserId { get; set; }
    public User User { get; set; }

    public Role Role { get; set; }
}
