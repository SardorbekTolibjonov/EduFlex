namespace EduFlex.Domain.DTOs.Sessions;

public class SessionForResultDto
{
    public long Id { get; set; }
    public long GroupId { get; set; }
    public DateTime Date { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
    public string Topic { get; set; }
}
