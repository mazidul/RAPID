using RAPID.DTOs.Customer;

namespace RAPID.Services;

public interface ISupplierService
{
    Task<List<SupplierDTO>> GetAllAsync();
    Task<SupplierDTO?> GetByIdAsync(int id);
    Task<SupplierDTO> CreateAsync(SupplierDTO dto);
    Task<SupplierDTO?> UpdateAsync(int id, SupplierDTO dto);
    Task<bool> DeleteAsync(int id);
}
