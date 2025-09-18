namespace RAPID.Models;

public class Item : CommonProperty
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
    public Group Group { get; set; }

    public byte? CategoryId { get; set; }
    public string Category { get; set; }


    public byte? SubCategoryId { get; set; }
    public SubCategory SubCategory { get; set; }

    public byte? UnitId { get; set; }
    public Unit Unit { get; set; }

    public byte? BrandId { get; set; }
    public Brand Brand { get; set; }

    public byte? ColorId { get; set; }
    public Color Color { get; set; }

    public string ItemImageURL { get; set; }
    public string Description { get; set; }
}
