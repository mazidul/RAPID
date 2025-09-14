namespace RAPID.Models;

public class Document : CommonProperty
{
    public int Id { get; set; }
    public string FileName { get; set; }
    public string FilePath { get; set; }
    public DateTime? IssueDate { get; set; }
    public DateTime? ExpiryDate { get; set; }
}
