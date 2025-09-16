using Microsoft.EntityFrameworkCore;
using RAPID.DTOs.Generic;
using RAPID.Models;

namespace RAPID.Services;

public class TableCountService : ITableCountService
{
    private readonly ApplicationDbContext _context;

    public TableCountService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<TableCountDto?> GetCountsAsync(string modelName)
    {
        var entityType = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(a => a.GetTypes())
            .FirstOrDefault(t => t.Name.Equals(modelName, StringComparison.OrdinalIgnoreCase));

        if (entityType == null)
            return null;

        var method = typeof(TableCountService).GetMethod(nameof(GetCountsGeneric), System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)!
            .MakeGenericMethod(entityType);

        var task = (Task<TableCountDto>)method.Invoke(this, null)!;
        return await task;
    }

    private async Task<TableCountDto> GetCountsGeneric<TEntity>() where TEntity : class
    {
        var dbSet = _context.Set<TEntity>();

        var total = await dbSet.CountAsync();
        var active = await dbSet.CountAsync(e => EF.Property<bool>(e, "IsActive") == true);
        var inactive = await dbSet.CountAsync(e => EF.Property<bool>(e, "IsActive") == false);
        var draft = await dbSet.CountAsync(e => EF.Property<bool>(e, "IsDraft") == true);
        var updated = await dbSet.CountAsync(e => EF.Property<DateTime?>(e, "UpdatedAt") != null);
        var deleted = await dbSet.CountAsync(e =>
            EF.Property<bool>(e, "IsDelete") == true ||
            EF.Property<DateTime?>(e, "Deleted") != null);

        return new TableCountDto
        {
            Total = total,
            Active = active,
            Inactive = inactive,
            Draft = draft,
            Updated = updated,
            Deleted = deleted
        };
    }
}
