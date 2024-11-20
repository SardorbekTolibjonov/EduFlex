using EduFlex.Api.Models;
using EduFlex.Service.DTOs.Exams;
using EduFlex.Service.Interfaces.Exams;
using Microsoft.AspNetCore.Mvc;

namespace EduFlex.Api.Controllers.Exams;

[ApiController]
[Route("api/[controller]/[action]")]
public class ExamsController : ControllerBase
{
    private readonly IExamService examService;

    public ExamsController(IExamService examService)
    {
        this.examService = examService;
    }

    [HttpPost]
    public async Task<IActionResult> AddExam(ExamForCreationDto dto)
    {
        var response = new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.examService.AddExamAsync(dto)
        };
        return Ok(response);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteExam(long id)
    {
        var response = new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.examService.DeleteExamAsync(id)
        };
        return Ok(response);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateExam(long id, ExamForUpdateDto dto)
    {
        var response = new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.examService.UpdateExamAsync(id, dto)
        };
        return Ok(response);
    }

    [HttpGet("{groupId}")]
    public async Task<IActionResult> GetExamsByGroupId(long groupId)
    {
        var response = new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.examService.GetExamsByGroupIdAsync(groupId)
        };
        return Ok(response);
    }


}
