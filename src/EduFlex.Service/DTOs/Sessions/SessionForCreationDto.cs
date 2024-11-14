namespace EduFlex.Service.DTOs.Sessions;

public class SessionForCreationDto
{
    public long GroupId { get; set; }
    public DateTime Date { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string Topic { get; set; }
}
