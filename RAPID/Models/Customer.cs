using Mono.TextTemplating;

namespace RAPID.Models;

public class Customer : CommonProperty
{
    public int Id { get; set; }
    public string CustomerNo { get; set; }
    public string CustomerName { get; set; }
    public string ShortName { get; set; }
    public string VatNumber { get; set; }
    public string VendorCode { get; set; }

    public byte? PaymentModeId { get; set; }   // FK
    public PaymentMode PaymentMode { get; set; }  // Navigation

    public byte? CurrencyId { get; set; } //FK
    public Currency Currency { get; set; } //Navigation

    public string Phone { get; set; }
    public string Fax { get; set; }
    public string Mobile { get; set; }
    public string Whatsapp { get; set; }

    public byte? CountryId { get; set; }   // FK
    public Country Country { get; set; }   //Navigation

    public byte? StateId { get; set; } //FK
    public State State { get; set; } //Navigation

    public string PostCode { get; set; }
    public string Address { get; set; }
    public string Email { get; set; }
    public string Website { get; set; }

    public byte? LanguageId { get; set; }//FK
    public Language Language { get; set; }//Navigation

    public string LocationUrl { get; set; }
    public decimal OpeningBalance { get; set; } = 0m;
    public string CustomerLogoPath { get; set; }

}
