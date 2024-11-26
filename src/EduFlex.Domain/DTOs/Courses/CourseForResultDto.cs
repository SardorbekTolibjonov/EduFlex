using EduFlex.Domain.DTOs.Groups;

namespace EduFlex.Domain.DTOs.Courses;

public class CourseForResultDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public ICollection<GroupForResultDto> Groups { get; set; }
}
