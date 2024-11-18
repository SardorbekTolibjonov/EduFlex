using AutoMapper;
using EduFlex.Data.IRepositories;
using EduFlex.Domain.Entities.Courses;
using EduFlex.Service.DTOs.Courses;
using EduFlex.Service.Exceptions;
using EduFlex.Service.Interfaces.Courses;
using Microsoft.EntityFrameworkCore;

namespace EduFlex.Service.Services.Courses;

public class CourseService : ICourseService
{
    private readonly IRepositoryBase<Course> repository;
    private readonly IMapper mapper;

    public CourseService(IRepositoryBase<Course> repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }
    public async Task<CourseForResultDto> AddCourseAsync(CourseForCreationDto dto)
    {
        var course = await this.repository.GetAllAsync()
                                          .Where(c => c.Name == dto.Name)
                                          .AsNoTracking()
                                          .FirstOrDefaultAsync();

        if (course != null)
            throw new EduFlexException(409, "Course already exists");
        var mappedCourse = mapper.Map<Course>(dto);
        mappedCourse.CreatedAt = DateTime.UtcNow;

        var result = await repository.AddAsync(mappedCourse);

        return this.mapper.Map<CourseForResultDto>(result);
    }

    public async Task<bool> DeleteCourseAsync(long id)
    {
        var course = await  this.repository.GetAllAsync()
                                           .Where(c => c.Id == id)
                                           .AsNoTracking()
                                           .FirstOrDefaultAsync();
        if (course == null)
            throw new EduFlexException(404, "Course not found");

        return await this.repository.RemoveAsync(id);
    }

    public async Task<IEnumerable<CourseForResultDto>> GetAllCoursesAsync()
    {
        var courses = await this.repository.GetAllAsync()
                                           .AsNoTracking()
                                           .ToListAsync();

        return this.mapper.Map<IEnumerable<CourseForResultDto>>(courses);
    }

    public async Task<CourseForResultDto> GetCourseByIdAsync(long id)
    {
        var course = await this.repository.GetAllAsync()
                                          .Include(c => c.Groups)
                                          .Where(c => c.Id == id)
                                          .AsNoTracking()
                                          .FirstOrDefaultAsync();
        if (course == null)
            throw new EduFlexException(404, "Course not found");

        return this.mapper.Map<CourseForResultDto>(course);
    }

    public async Task<CourseForResultDto> UpdateCourseAsync(long id, CourseForUpdateDto dto)
    {
        var course = await this.repository.GetAllAsync()
                                          .Where(c => c.Id == id)
                                          .AsNoTracking()
                                          .FirstOrDefaultAsync();

        if (course == null)
            throw new EduFlexException(404, "Course not found");

        var mappedCourse = this.mapper.Map(dto,course);
        mappedCourse.UpdatedAt = DateTime.UtcNow;

        var result = await this.repository.UpdateAsync(mappedCourse);

        return this.mapper.Map<CourseForResultDto>(result);
    }
}
