using EduFlex.Data.IRepositories;
using EduFlex.Data.Repositories;
using EduFlex.Service.Interfaces.Courses;
using EduFlex.Service.Interfaces.Exams;
using EduFlex.Service.Interfaces.Groups;
using EduFlex.Service.Interfaces.Sessions;
using EduFlex.Service.Interfaces.Users;
using EduFlex.Service.Mappings;
using EduFlex.Service.Services.Courses;
using EduFlex.Service.Services.Exams;
using EduFlex.Service.Services.Groups;
using EduFlex.Service.Services.Sessions;
using EduFlex.Service.Services.Users;

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
        services.AddScoped<ICourseService, CourseService>();
        services.AddScoped<IGroupService, GroupService>();
        services.AddScoped<IUserGroupService, UserGroupService>();
        services.AddScoped<IExamService, ExamService>();
        services.AddScoped<ISessionService,SessionService>();
    }
}
