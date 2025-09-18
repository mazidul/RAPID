using RAPID.DTOs.Customer;

namespace RAPID.Services;

public interface IBrandService
{
    Task<IEnumerable<BrandDTO>> GetAllAsync();
    Task<BrandDTO> GetByIdAsync(byte id);
    Task<BrandDTO> CreateAsync(BrandDTO dto);
    Task<BrandDTO> UpdateAsync(byte id, BrandDTO dto);
    Task<bool> DeleteAsync(byte id);
}
