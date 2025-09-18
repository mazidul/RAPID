using Microsoft.EntityFrameworkCore;
using RAPID.DTOs.Customer;
using RAPID.Models;

namespace RAPID.Services;

public class SubCategoryService : ISubCategoryService
{
    private readonly ApplicationDbContext _context;

    public SubCategoryService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<SubCategoryDTO>> GetAllAsync()
    {
        return await _context.SubCategories
            .Include(sc => sc.Group)
            .Include(sc => sc.Category)
            .Select(sc => new SubCategoryDTO
            {
                Id = sc.Id,
                Name = sc.Name,
                Description = sc.Description,
                GroupId = sc.GroupId,
                GroupName = sc.Group != null ? sc.Group.Name : null,
                CategoryId = sc.CategoryId,
                CategoryName = sc.Category != null ? sc.Category.Name : null
            })
            .ToListAsync();
    }

    public async Task<SubCategoryDTO> GetByIdAsync(byte id)
    {
        var subCategory = await _context.SubCategories
            .Include(sc => sc.Group)
            .Include(sc => sc.Category)
            .FirstOrDefaultAsync(sc => sc.Id == id);

        if (subCategory == null) return null;

        return new SubCategoryDTO
        {
            Id = subCategory.Id,
            Name = subCategory.Name,
            Description = subCategory.Description,
            GroupId = subCategory.GroupId,
            GroupName = subCategory.Group != null ? subCategory.Group.Name : null,
            CategoryId = subCategory.CategoryId,
            CategoryName = subCategory.Category != null ? subCategory.Category.Name : null
        };
    }

    public async Task<SubCategoryDTO> CreateAsync(SubCategoryDTO dto)
    {
        var subCategory = new SubCategory
        {
            Name = dto.Name,
            Description = dto.Description,
            GroupId = dto.GroupId,
            CategoryId = dto.CategoryId
        };

        _context.SubCategories.Add(subCategory);
        await _context.SaveChangesAsync();

        dto.Id = subCategory.Id;
        return dto;
    }

    public async Task<SubCategoryDTO> UpdateAsync(byte id, SubCategoryDTO dto)
    {
        var subCategory = await _context.SubCategories.FindAsync(id);
        if (subCategory == null) return null;

        subCategory.Name = dto.Name;
        subCategory.Description = dto.Description;
        subCategory.GroupId = dto.GroupId;
        subCategory.CategoryId = dto.CategoryId;

        await _context.SaveChangesAsync();

        dto.Id = subCategory.Id;
        return dto;
    }

    public async Task<bool> DeleteAsync(byte id)
    {
        var subCategory = await _context.SubCategories.FindAsync(id);
        if (subCategory == null) return false;

        _context.SubCategories.Remove(subCategory);
        await _context.SaveChangesAsync();

        return true;
    }
}
