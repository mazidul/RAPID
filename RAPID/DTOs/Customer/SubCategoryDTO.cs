namespace RAPID.DTOs.Customer;

public class SubCategoryDTO
{
    public byte Id { get; set; }
    public string Name { get; set; }
    public byte? GroupId { get; set; }
    public string GroupName { get; set; }
    public byte? CategoryId { get; set; }
    public string CategoryName { get; set; }
    public string Description { get; set; }
}
