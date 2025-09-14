using RAPID.DTOs.Customer;

namespace RAPID.Services;

public interface ICustomerService
{
    Task<List<CustomerDTO>> GetAllAsync();
    Task<CustomerDTO?> GetByIdAsync(int id);
    Task<CustomerDTO> CreateAsync(CustomerDTO customerDto);
    Task<CustomerDTO?> UpdateAsync(int id, CustomerDTO customerDto);
    Task<bool> DeleteAsync(int id);
}
