using EduFlex.Api.Models;
using EduFlex.Service.DTOs.Attendances;
using EduFlex.Service.Interfaces.Attendances;
using Microsoft.AspNetCore.Mvc;

namespace EduFlex.Api.Controllers.Attendances;

[ApiController]
[Route("api/[controller]/[action]")]
public class Attendance : ControllerBase
{
    private readonly IAttendanceService attendanceService;

    public Attendance(IAttendanceService attendanceService)
    {
        this.attendanceService = attendanceService;
    }

    [HttpPost]
    public async Task<IActionResult> AddAttendance(AttendanceForCreationDto dto)
    {
        var response = new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.attendanceService.AddAttendanceAsync(dto)
        };

        return Ok(response);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAttendance(long id, AttendanceForUpdateDto dto)
    {
        var response = new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.attendanceService.UpdateAttendanceAsync(id, dto)
        };
        return Ok(response);
    }

    [HttpGet("{sessionId}")]
    public async Task<IActionResult> GetAttendanceBySession(long sessionId)
    {
        var response = new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.attendanceService.GetAttendanceBySessionAsync(sessionId)
        };
        return Ok(response);
    }

    [HttpGet("{studentId}")]
    public async Task<IActionResult> GetAttendanceByStudent(long studentId)
    {
        var response = new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.attendanceService.GetAttendanceByStudentAsync(studentId)
        };
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAttendance(long id)
    {
        var response = new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.attendanceService.DeleteAttendanceAsync(id)
        };
        return Ok(response);
    }

}
