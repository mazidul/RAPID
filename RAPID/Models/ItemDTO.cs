namespace RAPID.Models;

public class ItemDTO
{
    public int Id { get; set; }
    public string ItemCode { get; set; }
    public string Barcode { get; set; }
    public string ShortName { get; set; }
    public string FullName { get; set; }
    public decimal CostPrice { get; set; }
    public decimal SalePrice { get; set; }
    public decimal OpeningStock { get; set; }

    public byte? GroupId { get; set; }
    public string GroupName { get; set; }

    public byte? CategoryId { get; set; }
    public string CategoryName { get; set; }

    public byte? SubCategoryId { get; set; }
    public string SubCategoryName { get; set; }

    public byte? UnitId { get; set; }
    public string UnitName { get; set; }

    public byte? BrandId { get; set; }
    public string BrandName { get; set; }

    public byte? ColorId { get; set; }
    public string ColorName { get; set; }

    public string ItemImageURL { get; set; }
    public string Description { get; set; }
}
