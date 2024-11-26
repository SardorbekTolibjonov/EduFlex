namespace EduFlex.Domain.DTOs.Sessions;

public class SessionForUpdateDto
{
    public long GroupId { get; set; }
    public string Date { get; set; }
    public string StartTime { get; set; }
    public string EndTime { get; set; }
    public string Topic { get; set; }
}
