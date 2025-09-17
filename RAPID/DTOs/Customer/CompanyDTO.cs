using RAPID.Models;

namespace RAPID.DTOs.Customer
{
    public class CompanyDTO
    {
        public int Id { get; set; }

        public string Code { get; set; }
        public string Name { get; set; }
        public string TaxNumber { get; set; }
        public int? ClientId { get; set; }
        public byte? CurrencyId { get; set; }
        public byte? CountryId { get; set; }
        public byte? StateId { get; set; }
        public byte? LanguageId { get; set; }
        public string BankName { get; set; }
        public string BankAccountName { get; set; }
        public string BankAccountNumber { get; set; }
        public string IBAN { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
        public string Address { get; set; }
        public string Timezone { get; set; }
        public string DateFormat { get; set; }
        public string CompanyLogoPath { get; set; }
        public string FaviconPath { get; set; }
        public decimal OvertimeRate { get; set; } = 0m;
        public bool EnableRounding { get; set; } = false;
    }
}
