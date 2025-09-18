using Microsoft.EntityFrameworkCore;
using RAPID.DTOs.Customer;
using RAPID.Models;

namespace RAPID.Services;

public class UnitService : IUnitService
{
    private readonly ApplicationDbContext _context;

    public UnitService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<UnitDTO>> GetAllAsync()
    {
        return await _context.Units
            .Select(u => new UnitDTO
            {
                Id = u.Id,
                Name = u.Name,
                Description = u.Description
            })
            .ToListAsync();
    }

    public async Task<UnitDTO> GetByIdAsync(byte id)
    {
        var unit = await _context.Units.FindAsync(id);
        if (unit == null) return null;

        return new UnitDTO
        {
            Id = unit.Id,
            Name = unit.Name,
            Description = unit.Description
        };
    }

    public async Task<UnitDTO> CreateAsync(UnitDTO dto)
    {
        var unit = new Unit
        {
            Name = dto.Name,
            Description = dto.Description
        };

        _context.Units.Add(unit);
        await _context.SaveChangesAsync();

        dto.Id = unit.Id;
        return dto;
    }

    public async Task<UnitDTO> UpdateAsync(byte id, UnitDTO dto)
    {
        var unit = await _context.Units.FindAsync(id);
        if (unit == null) return null;

        unit.Name = dto.Name;
        unit.Description = dto.Description;

        await _context.SaveChangesAsync();

        dto.Id = unit.Id;
        return dto;
    }

    public async Task<bool> DeleteAsync(byte id)
    {
        var unit = await _context.Units.FindAsync(id);
        if (unit == null) return false;

        _context.Units.Remove(unit);
        await _context.SaveChangesAsync();

        return true;
    }
}
