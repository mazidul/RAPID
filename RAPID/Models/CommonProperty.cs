namespace RAPID.Models;

public class CommonProperty
{
    public bool IsDefault { get; set; }=true;
    public bool IsDraft { get; set; } = false;
    public bool IsActive { get; set; } = true;
    public bool IsDelete { get; set; } = false;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? Drafted { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? Deleted { get; set; }


}
