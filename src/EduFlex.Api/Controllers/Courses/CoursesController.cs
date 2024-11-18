using EduFlex.Api.Models;
using EduFlex.Service.DTOs.Courses;
using EduFlex.Service.Interfaces.Courses;
using Microsoft.AspNetCore.Mvc;

namespace EduFlex.Api.Controllers.Courses;

[ApiController]
[Route("api/[controller]/[action]")]
public class CoursesController : ControllerBase
{
    private readonly ICourseService courseService;
    public CoursesController(ICourseService courseService)
    {
        this.courseService = courseService;
    }
    [HttpPost]
    public async Task<IActionResult> Create(CourseForCreationDto course)
    {
        var response = new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await courseService.AddCourseAsync(course)
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
            Data = await courseService.GetAllCoursesAsync()
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
            Data = await courseService.GetCourseByIdAsync(id)
        };
        return Ok(response);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCourse(long id)
    {
        var response = new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await courseService.DeleteCourseAsync(id)
        };
        return Ok(response);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCourse(long id, CourseForUpdateDto course)
    {
        var response = new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await courseService.UpdateCourseAsync(id, course)
        };
        return Ok(response);
    }
}
