﻿namespace EduFlex.Service.DTOs.Sessions;

public class SessionForResultDto
{
    public long Id { get; set; }
    public long GroupId { get; set; }
    public DateTime Date { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string Topic { get; set; }
}
