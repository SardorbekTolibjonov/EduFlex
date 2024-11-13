using EduFlex.Domain.Commons;
using EduFlex.Domain.Entities.Groups;
using EduFlex.Domain.Entities.Users;
using EduFlex.Domain.Enums;

namespace EduFlex.Domain.Entities.Exams;

public class Exam : Auditable
{
    public string Name { get; set; }
    public long GroupId { get; set; }
    public Group Group { get; set; }
    public long StudentId { get; set; }
    public User User { get; set; }
    public float ExamResult { get; set; }
    public ExamStatus Status { get; set; }
}
