namespace RAPID.Models;

public class CustomerDocument : CommonProperty
{
    public int Id { get; set; }
    public int CustomerId { get; set; }   // FK
    public string FileName { get; set; }
    public string FilePath { get; set; }
    public DateTime? IssueDate { get; set; }
    public DateTime? ExpiryDate { get; set; }

    public Customer Customer { get; set; }
}
