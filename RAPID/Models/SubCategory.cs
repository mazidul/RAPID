namespace RAPID.Models;

public class SubCategory : MasterProperty
{
    public byte? GroupId { get; set; }
    public Group Group { get; set; }

    public byte? CategoryId { get; set; }
    public Category Category { get; set; }

    public string Description { get; set; }
}
