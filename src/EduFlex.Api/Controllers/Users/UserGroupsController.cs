using EduFlex.Api.Models;
using EduFlex.Service.DTOs.Users.UserGroup;
using EduFlex.Service.Interfaces.Users;
using Microsoft.AspNetCore.Mvc;

namespace EduFlex.Api.Controllers.Users;

[ApiController]
[Route("api/[controller]/[action]")]
public class UserGroupsController : ControllerBase
{
    private readonly IUserGroupService userGroupService;

    public UserGroupsController(IUserGroupService userGroupService)
    {
        this.userGroupService = userGroupService;
    }

    [HttpPost]
    public async Task<IActionResult> AddUserGroup(UserGroupDto dto)
    {
        var response = new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.userGroupService.AddUserGroupAsync(dto)
        };

        return Ok(response);
    }
    [HttpDelete("{userId}/{groupId}")]
    public async Task<IActionResult> DeleteUserGroup(UserGroupDto dto)
    {
        var response = new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.userGroupService.DeleteUserGroupAsync(dto)
        };
        return Ok(response);
    }
    [HttpGet("{groupId}")]
    public async Task<IActionResult> GetUsersByGroupId(long groupId)
    {
        var response = new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.userGroupService.GetUsersByGroupIdAsync(groupId)
        };
        return Ok(response);
    }
    [HttpGet("{userId}")]
    public async Task<IActionResult> GetGroupsByUserId(long userId)
    {
        var response = new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.userGroupService.GetGroupsByUserIdAsync(userId)
        };
        return Ok(response);
    }
}
