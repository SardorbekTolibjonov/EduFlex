using EduFlex.Domain.Entities.Users;
using EduFlex.Domain.Enums;

namespace EduFlex.Domain.DTOs.Exams;

public class ExamForUpdateDto
{
    public string Name { get; set; }
    public long GroupId { get; set; }
    public long StudentId { get; set; }
    public float ExamResult { get; set; }
    public string ExamDate { get; set; }
}
