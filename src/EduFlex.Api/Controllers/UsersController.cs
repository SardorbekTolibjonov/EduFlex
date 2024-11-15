using EduFlex.Api.Models;
using EduFlex.Domain.Entities.Users;
using EduFlex.Service.DTOs.Users.User;
using EduFlex.Service.Interfaces.Users;
using Microsoft.AspNetCore.Mvc;

namespace EduFlex.Api.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class UsersController : ControllerBase
{
    private readonly IUserService userService;
    public UsersController(IUserService userService)
    {
        this.userService = userService;
    }

    [HttpPost]
    public async Task<IActionResult> Create(UserForCreationDto user)
    {
        var response = new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.userService.CreateUserAsync(user)
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
            Data = await this.userService.GetAllUsersAsync()
        };

        return Ok(response);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(long id)
    {
        var response = new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.userService.GetUserByIdAsync(id)
        };

        return Ok(response);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(long id)
    {
        var response = new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.userService.DeleteUserAsync(id)
        };

        return Ok(response);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser(long id, UserForUpdateDto user)
    {
        var response = new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.userService.UpdateUserAsync(id, user)
        };
        return Ok(response);
    }
}
