using AutoMapper;
using EduFlex.Service.Exceptions;
using EduFlex.Data.IRepositories;
using EduFlex.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using EduFlex.Service.DTOs.Users.User;
using EduFlex.Service.Interfaces.Users;

namespace EduFlex.Service.Services;

public class UserService : IUserService
{
    private readonly IRepositoryBase<User> repository;
    private readonly IMapper mapper;

    public UserService(IRepositoryBase<User> repository,IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }
    public async Task<UserForResultDto> CreateUserAsync(UserForCreationDto user)
    {
        var checkUser = await this.repository.GetAllAsync()
                                             .Where(u => u.Username == user.Username)
                                             .AsNoTracking()
                                             .FirstOrDefaultAsync();
        if (checkUser != null) 
            throw new EduFlexException(409,"Username already exists");

        var mappedUser = this.mapper.Map<User>(user);
        mappedUser.CreatedAt = DateTime.UtcNow;

        var result = await this.repository.AddAsync(mappedUser);

        return this.mapper.Map<UserForResultDto>(result);
    }

    public async Task<bool> DeleteUserAsync(long id)
    {
        var user =  await this.repository.GetAllAsync()
                                        .Where(u => u.Id == id)
                                        .AsNoTracking()
                                        .FirstOrDefaultAsync();

        if (user == null)
            throw new EduFlexException(404, "User not found");

        return await this.repository.RemoveAsync(id);
    }

    public async Task<IEnumerable<UserForResultDto>> GetAllUsersAsync()
    {
        var users = await this.repository.GetAllAsync()
                                        .AsNoTracking()
                                        .ToListAsync();

        return this.mapper.Map<IEnumerable<UserForResultDto>>(users);
    }

    public async Task<UserForResultDto> GetUserByIdAsync(long id)
    {
        var user = await this.repository.GetAllAsync()
                                        .Where(u => u.Id == id)
                                        .AsNoTracking()
                                        .FirstOrDefaultAsync();

        if (user == null)
            throw new EduFlexException(404, "User not found");

        return this.mapper.Map<UserForResultDto>(user);
    }

    public async Task<UserForResultDto> UpdateUserAsync(long id, UserForUpdateDto user)
    {
        var checkUser = await this.repository.GetAllAsync()
                                        .Where(u => u.Id == id)
                                        .AsNoTracking()
                                        .FirstOrDefaultAsync();

        if (checkUser == null)
            throw new EduFlexException(404, "User not found");

        var mappedUser = this.mapper.Map(user,checkUser);
        mappedUser.UpdatedAt = DateTime.UtcNow;

        var result = await this.repository.UpdateAsync(mappedUser);

        return this.mapper.Map<UserForResultDto>(result);
    }
}
