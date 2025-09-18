using Microsoft.EntityFrameworkCore;
using RAPID.DTOs.Customer;
using RAPID.Models;

namespace RAPID.Services;

public class GroupService : IGroupService
{
    private readonly ApplicationDbContext _context;

    public GroupService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<GroupDTO>> GetAllAsync()
    {
        return await _context.Set<Group>()
            .Select(g => new GroupDTO
            {
                Id = g.Id,
                Name = g.Name,
                Description = g.Description
            })
            .ToListAsync();
    }

    public async Task<GroupDTO> GetByIdAsync(byte id)
    {
        var group = await _context.Set<Group>().FindAsync(id);
        if (group == null) return null;

        return new GroupDTO
        {
            Id = group.Id,
            Name = group.Name,
            Description = group.Description
        };
    }

    public async Task<GroupDTO> CreateAsync(GroupDTO dto)
    {
        var group = new Group
        {
            Name = dto.Name,
            Description = dto.Description
        };

        _context.Set<Group>().Add(group);
        await _context.SaveChangesAsync();

        dto.Id = group.Id;
        return dto;
    }

    public async Task<GroupDTO> UpdateAsync(byte id, GroupDTO dto)
    {
        var group = await _context.Set<Group>().FindAsync(id);
        if (group == null) return null;

        group.Name = dto.Name;
        group.Description = dto.Description;

        await _context.SaveChangesAsync();

        dto.Id = group.Id;
        return dto;
    }

    public async Task<bool> DeleteAsync(byte id)
    {
        var group = await _context.Set<Group>().FindAsync(id);
        if (group == null) return false;

        _context.Set<Group>().Remove(group);
        await _context.SaveChangesAsync();

        return true;
    }
}
