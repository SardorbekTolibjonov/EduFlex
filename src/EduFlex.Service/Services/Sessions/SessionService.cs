using AutoMapper;
using EduFlex.Data.IRepositories;
using EduFlex.Domain.Entities.Groups;
using EduFlex.Domain.Entities.Sessions;
using EduFlex.Service.DTOs.Sessions;
using EduFlex.Service.Exceptions;
using EduFlex.Service.Interfaces.Sessions;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace EduFlex.Service.Services.Sessions;

public class SessionService : ISessionService
{
    private readonly IMapper mapper;
    private readonly IRepositoryBase<Session> repository;
    private readonly IRepositoryBase<Group> groupRepository;

    public SessionService(
        IMapper mapper,
        IRepositoryBase<Session> repository,
        IRepositoryBase<Group> groupRepository)
    {
        this.mapper = mapper;
        this.repository = repository;
        this.groupRepository = groupRepository;
    }
    public async Task<SessionForResultDto> AddSessionAsync(SessionForCreationDto dto)
    {
        var group = await this.groupRepository.GetAllAsync()
                                              .Where(g => g.Id == dto.GroupId)
                                              .AsNoTracking()
                                              .FirstOrDefaultAsync();

        if (group == null)
            throw new EduFlexException(404,"Group not found");

        var date = DateTime.ParseExact(dto.Date, "yyyy-MM-dd", CultureInfo.InvariantCulture);
        var session = await this.repository.GetAllAsync()
                                          .Where(s => s.Date == date && s.GroupId == dto.GroupId)
                                          .AsNoTracking()
                                          .FirstOrDefaultAsync();

        if (session != null)
            throw new EduFlexException(409, "Session already exists");

        var startTime = TimeSpan.ParseExact(dto.StartTime, "hh\\:mm", CultureInfo.InvariantCulture);
        var endTime = TimeSpan.ParseExact(dto.EndTime, "hh\\:mm", CultureInfo.InvariantCulture);

        if((startTime.Hours == endTime.Hours && startTime.Minutes>=endTime.Minutes)
            || (startTime.Hours > endTime.Hours))
            throw new EduFlexException(400, "Invalid time range");

        var entity = this.mapper.Map<Session>(dto);
        entity.CreatedAt = DateTime.UtcNow;
        entity.StartTime = startTime;
        entity.EndTime = endTime;
        entity.Date = date;

        var result = await this.repository.AddAsync(entity);

        return this.mapper.Map<SessionForResultDto>(result);
    }

    public async Task<bool> DeleteSessionAsync(long id)
    {
        var session = await this.repository.GetAllAsync()
                                           .Where(s => s.Id == id)
                                           .AsNoTracking()
                                           .FirstOrDefaultAsync();

        if (session == null)
            throw new EduFlexException(404, "Session not found");

        return await this.repository.RemoveAsync(id);
    }

    public async Task<IEnumerable<SessionForResultDto>> GetAllSessionsAsync()
    {
        var sessions = await this.repository.GetAllAsync()
                                            .AsNoTracking()
                                            .ToListAsync();


        return this.mapper.Map<IEnumerable<SessionForResultDto>>(sessions);
    }

    public async Task<SessionForResultDto> GetSessionByIdAsync(long id)
    {
        var session = await this.repository.GetAllAsync()
                                           .Where(s => s.Id == id)
                                           .AsNoTracking()
                                           .FirstOrDefaultAsync();

        if (session == null)
            throw new EduFlexException(404, "Session not found");

        return this.mapper.Map<SessionForResultDto>(session);
    }

    public async Task<SessionForResultDto> UpdateSessionAsync(long id, SessionForCreationDto dto)
    {
        var group = await this.groupRepository.GetAllAsync()
                                              .Where(g => g.Id == dto.GroupId)
                                              .AsNoTracking()
                                              .FirstOrDefaultAsync();

        if (group == null)
            throw new EduFlexException(404, "Group not found");

        var session = await this.repository.GetAllAsync()
                                   .Where(s => s.Id == id)
                                   .AsNoTracking()
                                   .FirstOrDefaultAsync();

        if (session == null)
            throw new EduFlexException(404, "Session not found");

        var entity = this.mapper.Map(dto, session);
        entity.UpdatedAt = DateTime.UtcNow;
        entity.StartTime = TimeSpan.ParseExact(dto.StartTime, "hh\\:mm", CultureInfo.InvariantCulture);
        entity.EndTime = TimeSpan.ParseExact(dto.EndTime, "hh\\:mm", CultureInfo.InvariantCulture);
        entity.Date = DateTime.ParseExact(dto.Date, "yyyy-MM-dd", CultureInfo.InvariantCulture);

        var result = await this.repository.UpdateAsync(entity);

        return this.mapper.Map<SessionForResultDto>(result);
    }
}
