using EduFlex.Domain.Commons;
using EduFlex.Domain.Entities.Courses;
using EduFlex.Domain.Entities.Users;
using EduFlex.Domain.Enums;

namespace EduFlex.Domain.Entities.Groups;

public class Group : Auditable
{
    public string Name { get; set; }
    public long TeacherId { get; set; }
    public User Teacher { get; set; }
    public long CourseId { get; set; }
    public Course Course { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int Duration { get; set; }
    public int Capacity { get; set; }
    public GroupStatus Status { get; set; }

}
