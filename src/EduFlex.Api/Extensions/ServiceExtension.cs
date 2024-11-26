using EduFlex.Data.IRepositories;
using EduFlex.Data.Repositories;
using EduFlex.Domain.Interfaces.Attendances;
using EduFlex.Domain.Interfaces.Courses;
using EduFlex.Domain.Interfaces.Exams;
using EduFlex.Domain.Interfaces.Groups;
using EduFlex.Domain.Interfaces.Sessions;
using EduFlex.Domain.Interfaces.Users;
using EduFlex.Domain.Mappings;
using EduFlex.Domain.Services.Attendances;
using EduFlex.Domain.Services.Courses;
using EduFlex.Domain.Services.Exams;
using EduFlex.Domain.Services.Groups;
using EduFlex.Domain.Services.Sessions;
using EduFlex.Domain.Services.Users;

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
        services.AddScoped<IAttendanceService, AttendanceService>();
    }
}
