using EduFlex.Service.DTOs.Courses;

namespace EduFlex.Service.Interfaces.Courses;

public interface ICourseService
{
    Task<CourseForResultDto> AddCourseAsync(CourseForCreationDto dto);
    Task<bool> DeleteCourseAsync(long id);
    Task<IEnumerable<CourseForResultDto>> GetAllCoursesAsync();
    Task<CourseForResultDto> GetCourseByIdAsync(long id);
    Task<CourseForResultDto> UpdateCourseAsync(long id, CourseForUpdateDto dto);
}
