using EduFlex.Domain.Entities.Users;
using EduFlex.Domain.Enums;

namespace EduFlex.Service.DTOs.Exams;

public class ExamForCreationDto
{
    public string Name { get; set; }
    public long GroupId { get; set; }
    public long StudentId { get; set; }
    public float ExamResult { get; set; }
    public string ExamDate { get; set; }
}
