using Microsoft.EntityFrameworkCore;
using RAPID.Models;

namespace RAPID.Services;

public class ItemService : IItemService
{
    private readonly ApplicationDbContext _context;

    public ItemService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ItemDTO>> GetAllAsync()
    {
        return await _context.Items
            .Include(i => i.Group)
            .Include(i => i.Category)
            .Include(i => i.SubCategory)
            .Include(i => i.Unit)
            .Include(i => i.Brand)
            .Include(i => i.Color)
            .Select(i => new ItemDTO
            {
                Id = i.Id,
                ItemCode = i.ItemCode,
                Barcode = i.Barcode,
                ShortName = i.ShortName,
                FullName = i.FullName,
                CostPrice = i.CostPrice,
                SalePrice = i.SalePrice,
                OpeningStock = i.OpeningStock,
                GroupId = i.GroupId,
                GroupName = i.Group != null ? i.Group.Name : null,
                CategoryId = i.CategoryId,
                CategoryName = i.Category != null ? i.Category.Name : null,
                SubCategoryId = i.SubCategoryId,
                SubCategoryName = i.SubCategory != null ? i.SubCategory.Name : null,
                UnitId = i.UnitId,
                UnitName = i.Unit != null ? i.Unit.Name : null,
                BrandId = i.BrandId,
                BrandName = i.Brand != null ? i.Brand.Name : null,
                ColorId = i.ColorId,
                ColorName = i.Color != null ? i.Color.Name : null,
                ItemImageURL = i.ItemImageURL,
                Description = i.Description
            })
            .ToListAsync();
    }

    public async Task<ItemDTO> GetByIdAsync(int id)
    {
        var i = await _context.Items
            .Include(x => x.Group)
            .Include(x => x.Category)
            .Include(x => x.SubCategory)
            .Include(x => x.Unit)
            .Include(x => x.Brand)
            .Include(x => x.Color)
            .FirstOrDefaultAsync(x => x.Id == id);

        if (i == null) return null;

        return new ItemDTO
        {
            Id = i.Id,
            ItemCode = i.ItemCode,
            Barcode = i.Barcode,
            ShortName = i.ShortName,
            FullName = i.FullName,
            CostPrice = i.CostPrice,
            SalePrice = i.SalePrice,
            OpeningStock = i.OpeningStock,
            GroupId = i.GroupId,
            GroupName = i.Group?.Name,
            CategoryId = i.CategoryId,
            CategoryName = i.Category?.Name,
            SubCategoryId = i.SubCategoryId,
            SubCategoryName = i.SubCategory?.Name,
            UnitId = i.UnitId,
            UnitName = i.Unit?.Name,
            BrandId = i.BrandId,
            BrandName = i.Brand?.Name,
            ColorId = i.ColorId,
            ColorName = i.Color?.Name,
            ItemImageURL = i.ItemImageURL,
            Description = i.Description
        };
    }

    public async Task<ItemDTO> CreateAsync(ItemDTO dto)
    {
        var item = new Item
        {
            ItemCode = dto.ItemCode,
            Barcode = dto.Barcode,
            ShortName = dto.ShortName,
            FullName = dto.FullName,
            CostPrice = dto.CostPrice,
            SalePrice = dto.SalePrice,
            OpeningStock = dto.OpeningStock,
            GroupId = dto.GroupId,
            CategoryId = dto.CategoryId,
            SubCategoryId = dto.SubCategoryId,
            UnitId = dto.UnitId,
            BrandId = dto.BrandId,
            ColorId = dto.ColorId,
            ItemImageURL = dto.ItemImageURL,
            Description = dto.Description
        };

        _context.Items.Add(item);
        await _context.SaveChangesAsync();

        dto.Id = item.Id;
        return dto;
    }

    public async Task<ItemDTO> UpdateAsync(int id, ItemDTO dto)
    {
        var item = await _context.Items.FindAsync(id);
        if (item == null) return null;

        item.ItemCode = dto.ItemCode;
        item.Barcode = dto.Barcode;
        item.ShortName = dto.ShortName;
        item.FullName = dto.FullName;
        item.CostPrice = dto.CostPrice;
        item.SalePrice = dto.SalePrice;
        item.OpeningStock = dto.OpeningStock;
        item.GroupId = dto.GroupId;
        item.CategoryId = dto.CategoryId;
        item.SubCategoryId = dto.SubCategoryId;
        item.UnitId = dto.UnitId;
        item.BrandId = dto.BrandId;
        item.ColorId = dto.ColorId;
        item.ItemImageURL = dto.ItemImageURL;
        item.Description = dto.Description;

        await _context.SaveChangesAsync();

        dto.Id = item.Id;
        return dto;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var item = await _context.Items.FindAsync(id);
        if (item == null) return false;

        _context.Items.Remove(item);
        await _context.SaveChangesAsync();

        return true;
    }
}
