using AutoMapper;
using EduFlex.Data.IRepositories;
using EduFlex.Domain.Entities.Users;
using EduFlex.Domain.Enums;
using EduFlex.Service.DTOs.Users.UserRole;
using EduFlex.Service.Exceptions;
using EduFlex.Service.Interfaces.Users;
using Microsoft.EntityFrameworkCore;

namespace EduFlex.Service.Services.Users;

public class UserRoleService : IUserRoleService
{
    private readonly IRepositoryBase<UserRole> repository;
    private readonly IRepositoryBase<User> userRepository;
    private readonly IMapper mapper;

    public UserRoleService(
        IMapper mapper,
        IRepositoryBase<UserRole> repository,
        IRepositoryBase<User> userRepository)
    {
        this.mapper = mapper;
        this.repository = repository;
        this.userRepository = userRepository;
    }
    public async Task<UserRoleForResultDto> AddUserRoleAsync(UserRoleForCreationDto userRole)
    {
        var user = await userRepository.GetAllAsync()
                                       .Where(u => u.Id == userRole.UserId)
                                       .AsNoTracking()
                                       .FirstOrDefaultAsync();

        if (user == null)
            throw new EduFlexException(404, "User not found");

        var mappedUserRole = mapper.Map<UserRole>(userRole);
        mappedUserRole.CreatedAt = DateTime.UtcNow;

        var result = await repository.AddAsync(mappedUserRole);

        return mapper.Map<UserRoleForResultDto>(result);
    }

    public async Task<bool> DeleteUserRoleAsync(long id)
    {
        var check = await repository.GetAllAsync()
                                        .Where(u => u.Id == id)
                                        .AsNoTracking()
                                        .FirstOrDefaultAsync();

        if (check == null)
            throw new EduFlexException(404, "UserRole not found");

        return await repository.RemoveAsync(id);
    }

    public async Task<IEnumerable<UserRoleForResultDto>> GetAllUserRolesAsync()
    {
        var userRoles = await repository.GetAllAsync()
                                            .AsNoTracking()
                                            .ToListAsync();

        return mapper.Map<IEnumerable<UserRoleForResultDto>>(userRoles);
    }

    public async Task<IEnumerable<UserRoleForResultDto>> GetUserRoleByRoleNameAsync(Role role)
    {
        var result = await repository.GetAllAsync()
                                   .Where(u => u.Role == role)
                                   .AsNoTracking()
                                   .ToListAsync();

        if (result == null)
            throw new EduFlexException(404, "Role not found");

        return mapper.Map<IEnumerable<UserRoleForResultDto>>(result);
    }

    public async Task<UserRoleForResultDto> UpdateUserRoleAsync(long id, UserRoleForUpdateDto userRole)
    {
        var user = await userRepository.GetAllAsync()
                                        .Where(u => u.Id == userRole.UserId)
                                        .AsNoTracking()
                                        .FirstOrDefaultAsync();

        if (user == null)
            throw new EduFlexException(404, "User not found");
        var check = await repository.GetAllAsync()
                                         .Where(ur => ur.Id == id)
                                         .AsNoTracking()
                                         .FirstOrDefaultAsync();

        if (check == null)
            throw new EduFlexException(404, "UserRole not found");

        var entity = await repository.GetAllAsync()
                                         .Where(ur => ur.UserId == userRole.UserId && ur.Role == userRole.Role)
                                         .AsNoTracking()
                                         .FirstOrDefaultAsync();
        if (entity != null)
            throw new EduFlexException(409, "UserRole already exists");

        var mappedUserRole = mapper.Map(userRole, check);
        mappedUserRole.UpdatedAt = DateTime.UtcNow;

        var result = await repository.UpdateAsync(mappedUserRole);

        return mapper.Map<UserRoleForResultDto>(result);
    }
}
