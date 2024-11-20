using AutoMapper;
using EduFlex.Data.IRepositories;
using EduFlex.Domain.Entities.Groups;
using EduFlex.Domain.Entities.Users;
using EduFlex.Service.DTOs.Groups;
using EduFlex.Service.DTOs.Users.User;
using EduFlex.Service.DTOs.Users.UserGroup;
using EduFlex.Service.Exceptions;
using EduFlex.Service.Interfaces.Users;
using Microsoft.EntityFrameworkCore;

namespace EduFlex.Service.Services.Users;

public class UserGroupService : IUserGroupService
{
    private readonly IMapper mapper;
    private readonly IRepositoryBase<User> userRepository;
    private readonly IRepositoryBase<Group> groupRepository;
    private readonly IRepositoryBase<UserGroup> userGroupRepository;

    public UserGroupService(
        IMapper mapper,
        IRepositoryBase<User> userRepository,
        IRepositoryBase<Group> groupRepository,
        IRepositoryBase<UserGroup> userGroupRepository)
    {
        this.mapper = mapper;
        this.userRepository = userRepository;
        this.groupRepository = groupRepository;
        this.userGroupRepository = userGroupRepository;
    }
    public async Task<UserGroupForResultDto> AddUserGroupAsync(UserGroupDto dto)
    {
        var user  = await this.userRepository.GetAllAsync()
                                       .Where(c => c.Id == dto.UserId)
                                       .AsNoTracking()
                                       .FirstOrDefaultAsync();

        if (user == null)
            throw new EduFlexException(404, "User not found");

        var group = await this.groupRepository.GetAllAsync()
                                        .Where(c => c.Id == dto.GroupId)
                                        .AsNoTracking()
                                        .FirstOrDefaultAsync();
        if (group == null)
            throw new EduFlexException(404, "Group not found");

        var userGroup = await this.userGroupRepository.GetAllAsync()
                                                      .Where(c => c.UserId == dto.UserId && c.GroupId == dto.GroupId)
                                                      .AsNoTracking()
                                                      .FirstOrDefaultAsync();
        if (userGroup != null)
            throw new EduFlexException(409, "User already in group");

        var mappedUserGroup = mapper.Map<UserGroup>(dto);
        mappedUserGroup.CreatedAt = DateTime.UtcNow;

        var result = await userGroupRepository.AddAsync(mappedUserGroup);

        return this.mapper.Map<UserGroupForResultDto>(result);

    }

    public async Task<bool> DeleteUserGroupAsync(UserGroupDto dto)
    {
        var user = await this.userRepository.GetAllAsync()
                                       .Where(c => c.Id == dto.UserId)
                                       .AsNoTracking()
                                       .FirstOrDefaultAsync();

        if (user == null)
            throw new EduFlexException(404, "User not found");

        var group = await this.groupRepository.GetAllAsync()
                                        .Where(c => c.Id == dto.GroupId)
                                        .AsNoTracking()
                                        .FirstOrDefaultAsync();
        if (group == null)
            throw new EduFlexException(404, "Group not found");

        var userGroup = await this.userGroupRepository.GetAllAsync()
                                                      .Where(c => c.UserId == dto.UserId && c.GroupId == dto.GroupId)
                                                      .AsNoTracking()
                                                      .FirstOrDefaultAsync();

        if (userGroup == null)
            throw new EduFlexException(404, "User not in group");

        return await this.userGroupRepository.RemoveAsync(userGroup.Id);
    }

    public async Task<IEnumerable<GroupForResultDto>> GetGroupsByUserIdAsync(long userId)
    {
        var groups = await this.userGroupRepository.GetAllAsync()
                                                   .Include(ug => ug.Group) 
                                                   .Where(ug => ug.UserId == userId) 
                                                   .Select(ug => ug.Group) 
                                                   .AsNoTracking() 
                                                   .ToListAsync();

        return this.mapper.Map<IEnumerable<GroupForResultDto>>(groups);
    }

    public async Task<IEnumerable<UserForResultDto>> GetUsersByGroupIdAsync(long groupId)
    {
        var users = await this.userGroupRepository.GetAllAsync()
                                            .Include(c => c.User)
                                            .Where(c => c.GroupId == groupId)
                                            .Select(c => c.User)
                                            .AsNoTracking()
                                            .ToListAsync();

        return this.mapper.Map<IEnumerable<UserForResultDto>>(users);
    }
}
