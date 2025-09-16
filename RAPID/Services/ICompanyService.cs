using RAPID.DTOs.Customer;

namespace RAPID.Services
{
    public interface ICompanyService
    {
        Task<IEnumerable<CompanyDTO>> GetAllAsync();
        Task<CompanyDTO> GetByIdAsync(int id);
        Task<CompanyDTO> CreateAsync(CompanyDTO dto);
        Task<CompanyDTO> UpdateAsync(int id, CompanyDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}
