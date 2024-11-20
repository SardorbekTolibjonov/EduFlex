namespace EduFlex.Service.DTOs.Sessions;

public class SessionForCreationDto
{
    public long GroupId { get; set; }
    public string Date { get; set; } // qaysi kuni
    public string StartTime { get; set; } // boshlanish vaqti
    public string EndTime { get; set; } // tugash vaqti
    public string Topic { get; set; }
}
