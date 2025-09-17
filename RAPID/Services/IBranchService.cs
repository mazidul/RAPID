using RAPID.DTOs.Customer;

namespace RAPID.Services;

public interface IBranchService
{
    Task<IEnumerable<BranchDTO>> GetAllAsync();
    Task<BranchDTO?> GetByIdAsync(int id);
    Task<BranchDTO> CreateAsync(BranchDTO dto);
    Task<BranchDTO?> UpdateAsync(int id, BranchDTO dto);
    Task<bool> DeleteAsync(int id);
}
