namespace RAPID.DTOs.Customer
{
    public class CustomerDTO
    {
        public int Id { get; set; }
        public string CustomerNo { get; set; }
        public string CustomerName { get; set; }
        public string ShortName { get; set; }
        public string VatNumber { get; set; }
        public string VendorCode { get; set; }
        public byte? PaymentModeId { get; set; }
        public byte? CurrencyId { get; set; }
        public byte? CountryId { get; set; }
        public byte? StateId { get; set; }
        public byte? LanguageId { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Mobile { get; set; }
        public string Whatsapp { get; set; }
        public string PostCode { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string LocationUrl { get; set; }
        public decimal OpeningBalance { get; set; }
        public string CustomerLogoPath { get; set; }

        // Nested Documents
        public List<DocumentDTO> Documents { get; set; } = new();
    }
}
