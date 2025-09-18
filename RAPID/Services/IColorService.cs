using RAPID.DTOs.Customer;

namespace RAPID.Services;

public interface IColorService
{
    Task<IEnumerable<ColorDTO>> GetAllAsync();
    Task<ColorDTO> GetByIdAsync(byte id);
    Task<ColorDTO> CreateAsync(ColorDTO dto);
    Task<ColorDTO> UpdateAsync(byte id, ColorDTO dto);
    Task<bool> DeleteAsync(byte id);
}
