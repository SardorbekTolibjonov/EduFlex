using EduFlex.Domain.Commons;
using EduFlex.Domain.Entities.Sessions;
using EduFlex.Domain.Entities.Users;
using EduFlex.Domain.Enums;

namespace EduFlex.Domain.Entities.Attendances;

public class Attendance : Auditable
{
    public long StudentId { get; set; } 
    public User User { get; set; }
    public long SessionId { get; set; }
    public Session Session { get; set; }
    public DateTime Date { get; set; }
    public AttendanceStatus Status { get; set; }
}
