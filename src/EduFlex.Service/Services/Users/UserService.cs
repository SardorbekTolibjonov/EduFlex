using AutoMapper;
using EduFlex.Service.Exceptions;
using EduFlex.Data.IRepositories;
using EduFlex.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using EduFlex.Service.DTOs.Users.User;
using EduFlex.Service.Interfaces.Users;

namespace EduFlex.Service.Services.Users;

public class UserService : IUserService
{
    private readonly IRepositoryBase<User> repository;
    private readonly IMapper mapper;

    public UserService(IRepositoryBase<User> repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }
    public async Task<UserForResultDto> CreateUserAsync(UserForCreationDto user)
    {
        var checkUser = await repository.GetAllAsync()
                                             .Where(u => u.Username == user.Username)
                                             .AsNoTracking()
                                             .FirstOrDefaultAsync();
        if (checkUser != null)
            throw new EduFlexException(409, "Username already exists");

        var mappedUser = mapper.Map<User>(user);
        mappedUser.CreatedAt = DateTime.UtcNow;

        var result = await repository.AddAsync(mappedUser);

        return mapper.Map<UserForResultDto>(result);
    }

    public async Task<bool> DeleteUserAsync(long id)
    {
        var user = await repository.GetAllAsync()
                                        .Where(u => u.Id == id)
                                        .AsNoTracking()
                                        .FirstOrDefaultAsync();

        if (user == null)
            throw new EduFlexException(404, "User not found");

        return await repository.RemoveAsync(id);
    }

    public async Task<IEnumerable<UserForResultDto>> GetAllUsersAsync()
    {
        var users = await repository.GetAllAsync()
                                        .AsNoTracking()
                                        .ToListAsync();

        return mapper.Map<IEnumerable<UserForResultDto>>(users);
    }

    public async Task<UserForResultDto> GetUserByIdAsync(long id)
    {
        var user = await repository.GetAllAsync()
                                        .Where(u => u.Id == id)
                                        .AsNoTracking()
                                        .FirstOrDefaultAsync();

        if (user == null)
            throw new EduFlexException(404, "User not found");

        return mapper.Map<UserForResultDto>(user);
    }

    public async Task<UserForResultDto> UpdateUserAsync(long id, UserForUpdateDto user)
    {
        var checkUser = await repository.GetAllAsync()
                                        .Where(u => u.Id == id)
                                        .AsNoTracking()
                                        .FirstOrDefaultAsync();

        if (checkUser == null)
            throw new EduFlexException(404, "User not found");

        var mappedUser = mapper.Map(user, checkUser);
        mappedUser.UpdatedAt = DateTime.UtcNow;

        var result = await repository.UpdateAsync(mappedUser);

        return mapper.Map<UserForResultDto>(result);
    }
}
