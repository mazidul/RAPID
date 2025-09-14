namespace RAPID.Models;

public class Supplier
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

    public int? DocumentId { get; set; }//FK
    public Document Document { get; set; }//Navigation
}
