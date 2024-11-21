using EduFlex.Service.DTOs.Attendances;

namespace EduFlex.Service.Interfaces.Attendances;

public interface IAttendanceService
{
    Task<AttendanceForResultDto> AddAttendanceAsync(AttendanceForCreationDto dto);
    Task<AttendanceForResultDto> UpdateAttendanceAsync(long id, AttendanceForUpdateDto dto);
    Task<IEnumerable<AttendanceForResultDto>> GetAttendanceBySessionAsync(long sessionId);
    Task<IEnumerable<AttendanceForResultDto>> GetAttendanceByStudentAsync(long studentId);
    Task<bool> DeleteAttendanceAsync(long id);
}
