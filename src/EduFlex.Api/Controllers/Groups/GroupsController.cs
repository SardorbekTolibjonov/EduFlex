using EduFlex.Api.Models;
using EduFlex.Domain.DTOs.Groups;
using EduFlex.Domain.Interfaces.Groups;
using Microsoft.AspNetCore.Mvc;

namespace EduFlex.Api.Controllers.Groups;

[ApiController]
[Route("api/[controller]/[action]")]
public class GroupsController : ControllerBase
{
    private readonly IGroupService groupService;

    public GroupsController(IGroupService groupService)
    {
        this.groupService = groupService;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] GroupForCreationDto dto)
    {
        var response = new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.groupService.AddGroupAsync(dto)
        };

        return Ok(response);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(long id, [FromBody] GroupForUpdateDto dto)
    {
        var response = new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.groupService.UpdateGroupAsync(id, dto)
        };
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(long id)
    {
        var response = new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.groupService.DeleteGroupAsync(id)
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
            Data = await this.groupService.GetAllGroupsAsync()
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
            Data = await this.groupService.GetGroupByIdAsync(id)
        };
        return Ok(response);
    }
}
