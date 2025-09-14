namespace RAPID.Models;

public class Document : CommonProperty
{
    public int Id { get; set; }

    public int ReferenceId { get; set; }   // কোন entity এর PK
    public byte ReferenceTypeId { get; set; }  // FK -> DocumentReferenceType.Id

    public DocumentReferenceType ReferenceType { get; set; } // Navigation

    public string FileName { get; set; }
    public string FilePath { get; set; }
    public DateTime? IssueDate { get; set; }
    public DateTime? ExpiryDate { get; set; }
}
