namespace RAPID.Models;

public class Branch : CommonProperty
{
    public int Id { get; set; }
    public string BranchCode { get; set; }

    public int? CompanyId { get; set; }
    public Company Company { get; set; }

    public string BranchName { get; set; }
    public string VatNumber { get; set; }
    public string Website { get; set; }
    public string Phone { get; set; }

    public byte? CurrencyId { get; set; }
    public Currency Currency { get; set; }

    public byte? CountryId { get; set; }
    public Country Country { get; set; }

    public byte? StateId { get; set; } 
    public State State { get; set; }

    public string City { get; set; }
    
    public string PostCode { get; set; }
    public string Bank { get; set; }
    public string Address { get; set; }
    public string AddressArabic { get; set; }
}
