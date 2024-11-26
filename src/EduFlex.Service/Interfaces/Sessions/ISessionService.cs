using EduFlex.Domain.DTOs.Sessions;

namespace EduFlex.Domain.Interfaces.Sessions;

public interface ISessionService
{
    Task<SessionForResultDto> AddSessionAsync(SessionForCreationDto dto);
    Task<SessionForResultDto> UpdateSessionAsync(long id, SessionForCreationDto dto);
    Task<bool> DeleteSessionAsync(long id);
    Task<SessionForResultDto> GetSessionByIdAsync(long id);
    Task<IEnumerable<SessionForResultDto>> GetAllSessionsAsync();
}
