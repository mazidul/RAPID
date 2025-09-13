using RAPID.DTOs.Customer;

namespace RAPID.Services
{
    public interface ICustomerService
    {
        Task<CustomerDTO> GetByIdAsync(int id);
        Task<IEnumerable<CustomerDTO>> GetAllAsync();
        Task<CustomerDTO> CreateAsync(CustomerDTO dto);
        Task<CustomerDTO> UpdateAsync(int id, CustomerDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}