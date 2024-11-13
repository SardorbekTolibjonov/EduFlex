using EduFlex.Domain.Commons;
using EduFlex.Domain.Entities.Groups;

namespace EduFlex.Domain.Entities.Users;

public class UserGroup : Auditable
{
    public long GroupId { get; set; }
    public Group Group { get; set; }
    public long UserId { get; set; }
    public User User { get; set; }
}
