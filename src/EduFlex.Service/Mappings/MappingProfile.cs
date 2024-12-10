using AutoMapper;
using EduFlex.Domain.Entities.Attendances;
using EduFlex.Domain.Entities.Courses;
using EduFlex.Domain.Entities.Exams;
using EduFlex.Domain.Entities.Groups;
using EduFlex.Domain.Entities.Sessions;
using EduFlex.Domain.Entities.Users;
using EduFlex.Domain.DTOs.Attendances;
using EduFlex.Domain.DTOs.Courses;
using EduFlex.Domain.DTOs.Exams;
using EduFlex.Domain.DTOs.Groups;
using EduFlex.Domain.DTOs.Sessions;
using EduFlex.Domain.DTOs.Users.User;
using EduFlex.Domain.DTOs.Users.UserGroup;
using EduFlex.Domain.DTOs.Users.UserRole;

namespace EduFlex.Domain.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Users Mapping
        CreateMap<User, UserForUpdateDto>().ReverseMap();
        CreateMap<User, UserForResultDto>().ReverseMap();
        CreateMap<User, UserForCreationDto>().ReverseMap();

        // UserRoles Mapping
        CreateMap<UserRole, UserRoleForCreationDto>().ReverseMap();
        CreateMap<UserRole, UserRoleForResultDto>().ReverseMap();
        CreateMap<UserRole, UserRoleForUpdateDto>().ReverseMap();

        // Courses Mapping
        CreateMap<Course, CourseForCreationDto>().ReverseMap();
        CreateMap<Course, CourseForResultDto>().ReverseMap();
        CreateMap<Course, CourseForUpdateDto>().ReverseMap();

        // Groups Mapping
        CreateMap<Group, GroupForCreationDto>().ReverseMap();
        CreateMap<Group, GroupForResultDto>().ReverseMap();
        CreateMap<Group, GroupForUpdateDto>().ReverseMap();

        // UserGroups Mapping
        CreateMap<UserGroup, UserGroupDto>().ReverseMap();
        CreateMap<UserGroup, UserGroupForResultDto>().ReverseMap();

        // Attendances Mapping
        CreateMap<Attendance, AttendanceForCreationDto>().ReverseMap();
        CreateMap<Attendance, AttendanceForResultDto>().ReverseMap();
        CreateMap<Attendance, AttendanceForUpdateDto>().ReverseMap();

        // Exams Mapping
        CreateMap<Exam, ExamForCreationDto>().ReverseMap();
        CreateMap<Exam, ExamForResultDto>().ReverseMap();
        CreateMap<Exam, ExamForUpdateDto>().ReverseMap();

        // Sessions Mapping
        CreateMap<Session, SessionForCreationDto>().ReverseMap();
        CreateMap<Session, SessionForResultDto>().ReverseMap();
        CreateMap<Session, SessionForUpdateDto>().ReverseMap();

    }
}
