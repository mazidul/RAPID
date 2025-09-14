using RAPID.DTOs.Customer;

namespace RAPID.Services;

public interface ICustomerService
{
    Task<IEnumerable<CustomerDTO>> GetAllAsync();
    Task<CustomerDTO?> GetByIdAsync(int id);
    Task<CustomerDTO> AddAsync(CustomerDTO dto);
    Task<CustomerDTO?> UpdateAsync(CustomerDTO dto);
    Task<bool> DeleteAsync(int id);
}
