using RAPID.Models;

namespace RAPID.DTOs.Customer;

public class BranchDTO
{
    public int Id { get; set; }
    public string BranchCode { get; set; }
    public int? CompanyId { get; set; }
    public string BranchName { get; set; }
    public string VatNumber { get; set; }
    public string Website { get; set; }
    public string Phone { get; set; }
    public byte? CurrencyId { get; set; }
    public byte? CountryId { get; set; }
    public byte? StateId { get; set; }
    public string City { get; set; }
    public string PostCode { get; set; }
    public string Bank { get; set; }
    public string Address { get; set; }
    public string AddressArabic { get; set; }
}
