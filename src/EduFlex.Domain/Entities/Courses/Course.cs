using EduFlex.Domain.Commons;
using EduFlex.Domain.Entities.Groups;

namespace EduFlex.Domain.Entities.Courses;

public class Course : Auditable
{
    public string Name { get; set; }
    public string Description { get; set; }
    public ICollection<Group> Groups { get; set; }
}
