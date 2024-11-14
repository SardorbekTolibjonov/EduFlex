using EduFlex.Domain.Enums;

namespace EduFlex.Service.DTOs.Attendances;

public class AttendanceForCreationDto
{
    public long StudentId { get; set; }
    public long CourseId { get; set; }
    public DateTime Date { get; set; }
    public AttendanceStatus Status { get; set; }
}
