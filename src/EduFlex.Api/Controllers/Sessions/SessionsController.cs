using EduFlex.Api.Models;
using EduFlex.Service.DTOs.Sessions;
using EduFlex.Service.Interfaces.Sessions;
using Microsoft.AspNetCore.Mvc;

namespace EduFlex.Api.Controllers.Sessions;

[ApiController]
[Route("api/[controller]/[action]")]
public class SessionsController : ControllerBase
{
    private readonly ISessionService sessionService;

    public SessionsController(ISessionService sessionService)
    {
        this.sessionService = sessionService;
    }
    [HttpPost]
    public async Task<IActionResult> AddSession(SessionForCreationDto dto)
    {
        var response = new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.sessionService.AddSessionAsync(dto)
        };
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSession(long sessionId)
    {
        var response = new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.sessionService.DeleteSessionAsync(sessionId)
        };
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetSessionById(long id)
    {
        var response = new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.sessionService.GetSessionByIdAsync(id)
        };
        return Ok(response);
    }
    [HttpGet]
    public async Task<IActionResult> GetAllSessions()
    {
        var response = new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.sessionService.GetAllSessionsAsync()
        };
        return Ok(response);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateSession(long id, SessionForCreationDto dto)
    {
        var response = new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.sessionService.UpdateSessionAsync(id, dto)
        };
        return Ok(response);
    }
}
