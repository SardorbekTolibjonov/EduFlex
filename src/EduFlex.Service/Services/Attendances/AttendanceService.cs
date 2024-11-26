using AutoMapper;
using EduFlex.Data.IRepositories;
using EduFlex.Domain.Entities.Attendances;
using EduFlex.Domain.Entities.Sessions;
using EduFlex.Domain.Entities.Users;
using EduFlex.Domain.Exceptions;
using EduFlex.Domain.DTOs.Attendances;
using EduFlex.Domain.Interfaces.Attendances;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace EduFlex.Domain.Services.Attendances;

public class AttendanceService : IAttendanceService
{
    private readonly IMapper mapper;
    private readonly IRepositoryBase<User> userRepository;
    private readonly IRepositoryBase<Attendance> repository;
    private readonly IRepositoryBase<UserRole> roleRepository;
    private readonly IRepositoryBase<Session> sessionRepository;

    public AttendanceService(
        IMapper mapper,
        IRepositoryBase<User> userRepository,
        IRepositoryBase<Attendance> repository,
        IRepositoryBase<UserRole> roleRepository,
        IRepositoryBase<Session> sessionRepository)
    {
        this.mapper = mapper;
        this.repository = repository;
        this.userRepository = userRepository;
        this.roleRepository = roleRepository;
        this.sessionRepository = sessionRepository;
    }
    public async Task<AttendanceForResultDto> AddAttendanceAsync(AttendanceForCreationDto dto)
    {
        var user = await this.userRepository.GetAllAsync()
                                             .Where(u => u.Id == dto.StudentId)
                                             .AsNoTracking()
                                             .FirstOrDefaultAsync();

        if (user == null)
            throw new EduFlexException(404, "User not found");

        var role = await this.roleRepository.GetAllAsync()
                                            .Where(r => r.UserId == dto.StudentId && r.Role == 0)
                                            .AsNoTracking()
                                            .FirstOrDefaultAsync();
        if (role == null)
            throw new EduFlexException(403, "User is not a student");

        var session = await this.sessionRepository.GetAllAsync()
                                                  .Where(s => s.Id == dto.SessionId)
                                                  .AsNoTracking()
                                                  .FirstOrDefaultAsync();
        if (session == null)
            throw new EduFlexException(404, "Session not found");

        if (IsValidAttendanceStatus((int)dto.Status) is false)
            throw new EduFlexException(400, "Invalid attendance status");

        var attendance = await this.repository.GetAllAsync()
                                             .Where(a => a.StudentId == dto.StudentId && a.SessionId == dto.SessionId)
                                             .AsNoTracking()
                                             .FirstOrDefaultAsync();
        if (attendance != null)
            throw new EduFlexException(409, "Attendance already exists");

        var date = DateTime.ParseExact(dto.Date, "yyyy-MM-dd", CultureInfo.InvariantCulture);

        var entity = this.mapper.Map<Attendance>(dto);
        entity.CreatedAt = DateTime.UtcNow;
        entity.Date = date;

        var result = await this.repository.AddAsync(entity);

        return this.mapper.Map<AttendanceForResultDto>(result);
    }

    public async Task<bool> DeleteAttendanceAsync(long id)
    {
        var attendance = await this.repository.GetAllAsync()
                                       .Where(a => a.Id == id)
                                       .AsNoTracking()
                                       .FirstOrDefaultAsync();

        if (attendance == null)
            throw new EduFlexException(404, "Attendance not found");

        return await this.repository.RemoveAsync(id);
    }

    public async Task<IEnumerable<AttendanceForResultDto>> GetAttendanceBySessionAsync(long sessionId)
    {
        var attendances = await this.repository.GetAllAsync()
                                        .Where(a => a.SessionId == sessionId)
                                        .Include(a => a.User)
                                        .Include(a => a.Session)
                                        .AsNoTracking()
                                        .ToListAsync();

        return this.mapper.Map<IEnumerable<AttendanceForResultDto>>(attendances);
    }

    public async Task<IEnumerable<AttendanceForResultDto>> GetAttendanceByStudentAsync(long studentId)
    {
        var attendances = await this.repository.GetAllAsync()
                                        .Where(a => a.StudentId == studentId)
                                        .Include(a => a.User)
                                        .Include(a => a.Session)
                                        .AsNoTracking()
                                        .ToListAsync();

        return this.mapper.Map<IEnumerable<AttendanceForResultDto>>(attendances);
    }

    public async Task<AttendanceForResultDto> UpdateAttendanceAsync(long id, AttendanceForUpdateDto dto)
    {
        var user = await this.userRepository.GetAllAsync()
                                             .Where(u => u.Id == dto.StudentId)
                                             .AsNoTracking()
                                             .FirstOrDefaultAsync();

        if (user == null)
            throw new EduFlexException(404, "User not found");

        var role = await this.roleRepository.GetAllAsync()
                                            .Where(r => r.UserId == dto.StudentId && r.Role == 0)
                                            .AsNoTracking()
                                            .FirstOrDefaultAsync();
        if (role == null)
            throw new EduFlexException(403, "User is not a student");

        var session = await this.sessionRepository.GetAllAsync()
                                                  .Where(s => s.Id == dto.SessionId)
                                                  .AsNoTracking()
                                                  .FirstOrDefaultAsync();
        if (session == null)
            throw new EduFlexException(404, "Session not found");

        if (IsValidAttendanceStatus((int)dto.Status) is false)
            throw new EduFlexException(400, "Invalid attendance status");

        var attendance = await this.repository.GetAllAsync()
                                             .Where(a => a.Id == id)
                                             .AsNoTracking()
                                             .FirstOrDefaultAsync();
        if (attendance == null)
            throw new EduFlexException(404, "Attendance not found");

        var date = DateTime.ParseExact(dto.Date, "yyyy-MM-dd", CultureInfo.InvariantCulture);

        var entity = this.mapper.Map(dto, attendance);
        entity.UpdatedAt = DateTime.UtcNow;
        entity.Date = date;

        var result = await this.repository.UpdateAsync(entity);

        return this.mapper.Map<AttendanceForResultDto>(result);
    }

    private bool IsValidAttendanceStatus(int status)
    {
        if (status == 0 || status == 1 || status == 2 || status == 3)
            return true;

        return false;
    }
}
