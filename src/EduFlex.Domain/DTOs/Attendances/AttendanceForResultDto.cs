using EduFlex.Domain.Enums;

namespace EduFlex.Domain.DTOs.Attendances;

public class AttendanceForResultDto
{
    public long Id { get; set; }
    public long StudentId { get; set; }
    public long SessionId { get; set; }
    public DateTime Date { get; set; }
    public AttendanceStatus Status { get; set; }
}
