using EduFlex.Service.DTOs.Groups;

namespace EduFlex.Service.Interfaces.Groups;

public interface IGroupService
{
    Task<GroupForResultDto> AddGroupAsync(GroupForCreationDto dto);
    Task<bool> DeleteGroupAsync(long id);
    Task<IEnumerable<GroupForResultDto>> GetAllGroupsAsync();
    Task<GroupForResultDto> GetGroupByIdAsync(long id);
    Task<GroupForResultDto> UpdateGroupAsync(long id, GroupForUpdateDto dto);
}
