using AutoMapper;
using EduFlex.Service.Exceptions;
using EduFlex.Data.IRepositories;
using EduFlex.Service.DTOs.Groups;
using Microsoft.EntityFrameworkCore;
using EduFlex.Domain.Entities.Users;
using EduFlex.Domain.Entities.Groups;
using EduFlex.Domain.Entities.Courses;
using EduFlex.Service.Interfaces.Groups;

namespace EduFlex.Service.Services.Groups;

public class GroupService : IGroupService
{
    private readonly IMapper mapper;
    private readonly IRepositoryBase<Group> repository;
    private readonly IRepositoryBase<User> userRepository;
    private readonly IRepositoryBase<Course> courseRepository;
    private readonly IRepositoryBase<UserRole> userRoleRepository;

    public GroupService(
        IMapper mapper,
        IRepositoryBase<Group> repository,
        IRepositoryBase<User> userRepository,
        IRepositoryBase<Course> courseRepository,
        IRepositoryBase<UserRole> userRoleRepository)
    {
        this.mapper = mapper;
        this.repository = repository;
        this.userRepository = userRepository;
        this.courseRepository = courseRepository;
        this.userRoleRepository = userRoleRepository;
    }
    public async Task<GroupForResultDto> AddGroupAsync(GroupForCreationDto dto)
    {
        if (IsValidGroupStatus((int)dto.Status) is false)
            throw new EduFlexException(400, "Invalid group status");

        var teacher = await this.userRepository.GetAllAsync()
                                               .Where(c => c.Id == dto.TeacherId)
                                               .AsNoTracking()
                                               .FirstOrDefaultAsync();
        if (teacher == null)
            throw new EduFlexException(404, "Teacher not found");

        var teacherRole = await this.userRoleRepository.GetAllAsync()
                                                       .Where(c => c.UserId == teacher.Id && (int)c.Role == 1)
                                                       .AsNoTracking()
                                                       .FirstOrDefaultAsync();
        if (teacherRole == null)
            throw new EduFlexException(404, "Teacher not found");



        var course = await this.courseRepository.GetAllAsync()
                                                .Where(c => c.Id == dto.CourseId)
                                                .AsNoTracking()
                                                .FirstOrDefaultAsync();
        if (course == null)
            throw new EduFlexException(404, "Course not found");

        var group = await this.repository.GetAllAsync()
                                         .Where(c => c.Name == dto.Name)
                                         .AsNoTracking()
                                         .FirstOrDefaultAsync();

        if (group != null)
            throw new EduFlexException(409, "Group already exists");

        var mappedGroup = this.mapper.Map<Group>(dto);
        mappedGroup.CreatedAt = DateTime.UtcNow;

        var result = await this.repository.AddAsync(mappedGroup);

        return this.mapper.Map<GroupForResultDto>(result);
    }

    public async Task<bool> DeleteGroupAsync(long id)
    {
        var group = await this.repository.GetAllAsync()
                                          .Where(c => c.Id == id)
                                          .AsNoTracking()
                                          .FirstOrDefaultAsync();

        if (group == null)
            throw new EduFlexException(404, "Group not found");

        return await this.repository.RemoveAsync(id);
    }

    public async Task<IEnumerable<GroupForResultDto>> GetAllGroupsAsync()
    {
        var groups = await this.repository.GetAllAsync()
                                          .AsNoTracking()
                                          .ToListAsync();


        return this.mapper.Map<IEnumerable<GroupForResultDto>>(groups);
    }

    public async Task<GroupForResultDto> GetGroupByIdAsync(long id)
    {
        var group = await this.repository.GetAllAsync()
                                          .Where(c => c.Id == id)
                                          .AsNoTracking()
                                          .FirstOrDefaultAsync();

        if (group == null)
            throw new EduFlexException(404, "Group not found");

        return this.mapper.Map<GroupForResultDto>(group);
    }

    public async Task<GroupForResultDto> UpdateGroupAsync(long id, GroupForUpdateDto dto)
    {
        if (IsValidGroupStatus((int)dto.Status) is false)
            throw new EduFlexException(400, "Invalid group status");

        var teacher = await this.userRepository.GetAllAsync()
                                               .Where(c => c.Id == dto.TeacherId)
                                               .AsNoTracking()
                                               .FirstOrDefaultAsync();
        if (teacher == null)
            throw new EduFlexException(404, "Teacher not found");

        var teacherRole = await this.userRoleRepository.GetAllAsync()
                                                       .Where(c => c.UserId == teacher.Id && (int)c.Role == 1)
                                                       .AsNoTracking()
                                                       .FirstOrDefaultAsync();
        if (teacherRole == null)
            throw new EduFlexException(404, "Teacher not found");

        var group = await this.repository.GetAllAsync()
                                         .Where(c => c.Id == id)
                                         .AsNoTracking()
                                         .FirstOrDefaultAsync();
        if (group == null)
            throw new EduFlexException(404, "Group not found");

        var course = await this.courseRepository.GetAllAsync()
                                                .Where(c => c.Id == dto.CourseId)
                                                .AsNoTracking()
                                                .FirstOrDefaultAsync();
        if (course == null)
            throw new EduFlexException(404, "Course not found");

        var mappedGroup = this.mapper.Map(dto, group);
        mappedGroup.UpdatedAt = DateTime.UtcNow;

        var result = await this.repository.UpdateAsync(mappedGroup);

        return this.mapper.Map<GroupForResultDto>(result);
    }

    private bool IsValidGroupStatus(int status)
    {
        if (status == 0 || status == 1 || status == 2 )
            return true;

        return false;
    }
}
