using RAPID.DTOs.Customer;

namespace RAPID.Services;

public interface IUnitService
{
    Task<IEnumerable<UnitDTO>> GetAllAsync();
    Task<UnitDTO> GetByIdAsync(byte id);
    Task<UnitDTO> CreateAsync(UnitDTO dto);
    Task<UnitDTO> UpdateAsync(byte id, UnitDTO dto);
    Task<bool> DeleteAsync(byte id);
}
