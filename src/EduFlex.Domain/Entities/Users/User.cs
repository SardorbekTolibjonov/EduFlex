using EduFlex.Domain.Commons;
using EduFlex.Domain.Entities.Groups;

namespace EduFlex.Domain.Entities.Users;

public class User : Auditable
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string DateOfBirth { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }

    public ICollection<Group> Groups { get; set; }

}
