using RAPID.DTOs.Customer;

namespace RAPID.Services;

public interface ICategoryService
{
    Task<IEnumerable<CategoryDTO>> GetAllAsync();
    Task<CategoryDTO> GetByIdAsync(byte id);
    Task<CategoryDTO> CreateAsync(CategoryDTO dto);
    Task<CategoryDTO> UpdateAsync(byte id, CategoryDTO dto);
    Task<bool> DeleteAsync(byte id);
}
