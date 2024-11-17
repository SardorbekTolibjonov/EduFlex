using EduFlex.Data.IRepositories;
using EduFlex.Data.Repositories;
using EduFlex.Service.Interfaces.Users;
using EduFlex.Service.Mappings;
using EduFlex.Service.Services;

namespace EduFlex.Api.Extensions;

public static class ServiceExtension
{
    public static void AddCustomServices(this IServiceCollection services)
    {
        // Repository 
        services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));

        // Automapper
        services.AddAutoMapper(typeof(MappingProfile));

        // Entity Services
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IUserRoleService, UserRoleService>();
    }
}
