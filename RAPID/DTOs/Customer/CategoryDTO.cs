namespace RAPID.DTOs.Customer;

public class CategoryDTO
{
    public byte Id { get; set; }
    public string Name { get; set; }
    public byte? GroupId { get; set; }
    public string GroupName { get; set; }
    public string Description { get; set; }
}
