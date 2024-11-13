using EduFlex.Domain.Commons;
using EduFlex.Domain.Entities.Groups;

namespace EduFlex.Domain.Entities.Sessions;

public class Session : Auditable
{
    public long GroupId { get; set; }
    public Group Group { get; set; }
    public DateTime Date { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string Topic { get; set; }
}
