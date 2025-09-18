using Microsoft.EntityFrameworkCore;
using RAPID.DTOs.Customer;
using RAPID.Models;

namespace RAPID.Services;

public class BrandService : IBrandService
{
    private readonly ApplicationDbContext _context;

    public BrandService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<BrandDTO>> GetAllAsync()
    {
        return await _context.Brands
            .Select(b => new BrandDTO
            {
                Id = b.Id,
                Name = b.Name,
                Description = b.Description
            })
            .ToListAsync();
    }

    public async Task<BrandDTO> GetByIdAsync(byte id)
    {
        var brand = await _context.Brands.FindAsync(id);
        if (brand == null) return null;

        return new BrandDTO
        {
            Id = brand.Id,
            Name = brand.Name,
            Description = brand.Description
        };
    }

    public async Task<BrandDTO> CreateAsync(BrandDTO dto)
    {
        var brand = new Brand
        {
            Name = dto.Name,
            Description = dto.Description
        };

        _context.Brands.Add(brand);
        await _context.SaveChangesAsync();

        dto.Id = brand.Id;
        return dto;
    }

    public async Task<BrandDTO> UpdateAsync(byte id, BrandDTO dto)
    {
        var brand = await _context.Brands.FindAsync(id);
        if (brand == null) return null;

        brand.Name = dto.Name;
        brand.Description = dto.Description;

        await _context.SaveChangesAsync();

        dto.Id = brand.Id;
        return dto;
    }

    public async Task<bool> DeleteAsync(byte id)
    {
        var brand = await _context.Brands.FindAsync(id);
        if (brand == null) return false;

        _context.Brands.Remove(brand);
        await _context.SaveChangesAsync();

        return true;
    }
}
