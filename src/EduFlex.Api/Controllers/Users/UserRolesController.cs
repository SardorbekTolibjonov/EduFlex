using EduFlex.Api.Models;
using EduFlex.Domain.Enums;
using EduFlex.Service.DTOs.Users.UserRole;
using EduFlex.Service.Interfaces.Users;
using Microsoft.AspNetCore.Mvc;

namespace EduFlex.Api.Controllers.Users;

[ApiController]
[Route("api/[controller]/[action]")]
public class UserRolesController : ControllerBase
{
    private readonly IUserRoleService userRoleService;
    public UserRolesController(IUserRoleService userRoleService)
    {
        this.userRoleService = userRoleService;
    }
    [HttpPost]
    public async Task<IActionResult> Create([FromQuery] UserRoleForCreationDto userRole)
    {
        var response = new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await userRoleService.AddUserRoleAsync(userRole)
        };
        return Ok(response);
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var response = new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await userRoleService.GetAllUserRolesAsync()
        };
        return Ok(response);
    }
    [HttpGet("{role}")]
    public async Task<IActionResult> GetByRoleName(Role role)
    {
        var response = new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await userRoleService.GetUserRoleByRoleNameAsync(role)
        };
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUserRole(long id)
    {
        var response = new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await userRoleService.DeleteUserRoleAsync(id)
        };
        return Ok(response);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUserRole(long id, [FromQuery] UserRoleForUpdateDto userRole)
    {
        var response = new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await userRoleService.UpdateUserRoleAsync(id, userRole)
        };
        return Ok(response);
    }
}
