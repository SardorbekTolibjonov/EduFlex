﻿using EduFlex.Domain.Enums;

namespace EduFlex.Domain.DTOs.Attendances;

public class AttendanceForUpdateDto
{
    public long StudentId { get; set; }
    public long SessionId { get; set; }
    public string Date { get; set; }
    public AttendanceStatus Status { get; set; }
}
