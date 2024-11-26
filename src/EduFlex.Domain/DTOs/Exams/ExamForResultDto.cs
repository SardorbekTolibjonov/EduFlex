using EduFlex.Domain.Entities.Users;
using EduFlex.Domain.Enums;

namespace EduFlex.Domain.DTOs.Exams;

public class ExamForResultDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public long GroupId { get; set; }
    public long StudentId { get; set; }
    public float ExamResult { get; set; }
    public DateTime ExamDate { get; set; }
    public ExamStatus Status { get; set; }
}
