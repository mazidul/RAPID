using Microsoft.EntityFrameworkCore;
using RAPID.DTOs.Customer;
using RAPID.Models;

namespace RAPID.Services;

public class ColorService : IColorService
{
    private readonly ApplicationDbContext _context;

    public ColorService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ColorDTO>> GetAllAsync()
    {
        return await _context.Colors
            .Select(c => new ColorDTO
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description
            })
            .ToListAsync();
    }

    public async Task<ColorDTO> GetByIdAsync(byte id)
    {
        var color = await _context.Colors.FindAsync(id);
        if (color == null) return null;

        return new ColorDTO
        {
            Id = color.Id,
            Name = color.Name,
            Description = color.Description
        };
    }

    public async Task<ColorDTO> CreateAsync(ColorDTO dto)
    {
        var color = new Color
        {
            Name = dto.Name,
            Description = dto.Description
        };

        _context.Colors.Add(color);
        await _context.SaveChangesAsync();

        dto.Id = color.Id;
        return dto;
    }

    public async Task<ColorDTO> UpdateAsync(byte id, ColorDTO dto)
    {
        var color = await _context.Colors.FindAsync(id);
        if (color == null) return null;

        color.Name = dto.Name;
        color.Description = dto.Description;

        await _context.SaveChangesAsync();

        dto.Id = color.Id;
        return dto;
    }

    public async Task<bool> DeleteAsync(byte id)
    {
        var color = await _context.Colors.FindAsync(id);
        if (color == null) return false;

        _context.Colors.Remove(color);
        await _context.SaveChangesAsync();

        return true;
    }
}
