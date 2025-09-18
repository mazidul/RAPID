using RAPID.Models;

namespace RAPID.Services;

public interface IItemService
{
    Task<IEnumerable<ItemDTO>> GetAllAsync();
    Task<ItemDTO> GetByIdAsync(int id);
    Task<ItemDTO> CreateAsync(ItemDTO dto);
    Task<ItemDTO> UpdateAsync(int id, ItemDTO dto);
    Task<bool> DeleteAsync(int id);
}
