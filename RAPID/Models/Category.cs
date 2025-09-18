namespace RAPID.Models;

public class Category : MasterProperty
{
    public byte? GroupId { get; set; }
    public Group Group { get; set; }

    public string Description { get; set; }
}
