using Microsoft.EntityFrameworkCore;
using RAPID.DTOs.Customer;
using RAPID.Models;

namespace RAPID.Services;

public class CategoryService : ICategoryService
{
    private readonly ApplicationDbContext _context;

    public CategoryService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<CategoryDTO>> GetAllAsync()
    {
        return await _context.Categories
            .Include(c => c.Group) // Group name সহ আনার জন্য
            .Select(c => new CategoryDTO
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description,
                GroupId = c.GroupId,
                GroupName = c.Group != null ? c.Group.Name : null
            })
            .ToListAsync();
    }

    public async Task<CategoryDTO> GetByIdAsync(byte id)
    {
        var category = await _context.Categories
            .Include(c => c.Group)
            .FirstOrDefaultAsync(c => c.Id == id);

        if (category == null) return null;

        return new CategoryDTO
        {
            Id = category.Id,
            Name = category.Name,
            Description = category.Description,
            GroupId = category.GroupId,
            GroupName = category.Group != null ? category.Group.Name : null
        };
    }

    public async Task<CategoryDTO> CreateAsync(CategoryDTO dto)
    {
        var category = new Category
        {
            Name = dto.Name,
            Description = dto.Description,
            GroupId = dto.GroupId
        };

        _context.Categories.Add(category);
        await _context.SaveChangesAsync();

        dto.Id = category.Id;
        return dto;
    }

    public async Task<CategoryDTO> UpdateAsync(byte id, CategoryDTO dto)
    {
        var category = await _context.Categories.FindAsync(id);
        if (category == null) return null;

        category.Name = dto.Name;
        category.Description = dto.Description;
        category.GroupId = dto.GroupId;

        await _context.SaveChangesAsync();

        dto.Id = category.Id;
        return dto;
    }

    public async Task<bool> DeleteAsync(byte id)
    {
        var category = await _context.Categories.FindAsync(id);
        if (category == null) return false;

        _context.Categories.Remove(category);
        await _context.SaveChangesAsync();

        return true;
    }
}
