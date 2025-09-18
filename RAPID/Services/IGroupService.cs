using RAPID.DTOs.Customer;

namespace RAPID.Services;

public interface IGroupService
{
    Task<IEnumerable<GroupDTO>> GetAllAsync();
    Task<GroupDTO> GetByIdAsync(byte id);
    Task<GroupDTO> CreateAsync(GroupDTO dto);
    Task<GroupDTO> UpdateAsync(byte id, GroupDTO dto);
    Task<bool> DeleteAsync(byte id);
}
