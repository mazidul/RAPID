using RAPID.DTOs.Customer;

namespace RAPID.Services;

public interface ISubCategoryService
{
    Task<IEnumerable<SubCategoryDTO>> GetAllAsync();
    Task<SubCategoryDTO> GetByIdAsync(byte id);
    Task<SubCategoryDTO> CreateAsync(SubCategoryDTO dto);
    Task<SubCategoryDTO> UpdateAsync(byte id, SubCategoryDTO dto);
    Task<bool> DeleteAsync(byte id);
}
