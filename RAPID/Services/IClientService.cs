using RAPID.DTOs.Customer;

namespace RAPID.Services;

public interface IClientService
{
    Task<IEnumerable<ClientDTO>> GetAllAsync();
    Task<ClientDTO?> GetByIdAsync(int id);
    Task<ClientDTO> CreateAsync(ClientDTO dto);
    Task<ClientDTO?> UpdateAsync(int id, ClientDTO dto);
    Task<bool> DeleteAsync(int id);
}
