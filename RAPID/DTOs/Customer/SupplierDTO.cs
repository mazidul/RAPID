namespace RAPID.DTOs.Customer;

public class SupplierDTO
{
    public int Id { get; set; }
    public string SupplierName { get; set; }
    public string VatNumber { get; set; }
    public string Website { get; set; }
    public string Phone { get; set; }
    public string Currency { get; set; }
    public string Country { get; set; }
    public string Language { get; set; }
    public string Street { get; set; }
    public string PostCode { get; set; }
    public decimal OpeningBalance { get; set; } = 0m;

    public List<DocumentDTO> Documents { get; set; } = new();
}
