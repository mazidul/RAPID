using Microsoft.EntityFrameworkCore;
using RAPID.DTOs.Customer;
using RAPID.Models;

namespace RAPID.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ApplicationDbContext _context;

        public CompanyService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CompanyDTO>> GetAllAsync()
        {
            return await _context.Companies
                .Select(c => new CompanyDTO
                {
                    Id = c.Id,
                    Code = c.Code,
                    Name = c.Name,
                    TaxNumber = c.TaxNumber,
                    ClientId = c.ClientId,
                    CurrencyId = c.CurrencyId,
                    CountryId = c.CountryId,
                    StateId = c.StateId,
                    LanguageId = c.LanguageId,
                    BankName = c.BankName,
                    BankAccountName = c.BankAccountName,
                    BankAccountNumber = c.BankAccountNumber,
                    IBAN = c.IBAN,
                    Phone = c.Phone,
                    Fax = c.Fax,
                    Mobile = c.Mobile,
                    Email = c.Email,
                    Website = c.Website,
                    City = c.City,
                    PostCode = c.PostCode,
                    Address = c.Address,
                    Timezone = c.Timezone,
                    DateFormat = c.DateFormat,
                    CompanyLogoPath = c.CompanyLogoPath,
                    FaviconPath = c.FaviconPath,
                    OvertimeRate = c.OvertimeRate,
                    EnableRounding = c.EnableRounding
                })
                .ToListAsync();
        }

        public async Task<CompanyDTO?> GetByIdAsync(int id)
        {
            var c = await _context.Companies.FindAsync(id);
            if (c == null) return null;

            return new CompanyDTO
            {
                Id = c.Id,
                Code = c.Code,
                Name = c.Name,
                TaxNumber = c.TaxNumber,
                ClientId = c.ClientId,
                CurrencyId = c.CurrencyId,
                CountryId = c.CountryId,
                StateId = c.StateId,
                LanguageId = c.LanguageId,
                BankName = c.BankName,
                BankAccountName = c.BankAccountName,
                BankAccountNumber = c.BankAccountNumber,
                IBAN = c.IBAN,
                Phone = c.Phone,
                Fax = c.Fax,
                Mobile = c.Mobile,
                Email = c.Email,
                Website = c.Website,
                City = c.City,
                PostCode = c.PostCode,
                Address = c.Address,
                Timezone = c.Timezone,
                DateFormat = c.DateFormat,
                CompanyLogoPath = c.CompanyLogoPath,
                FaviconPath = c.FaviconPath,
                OvertimeRate = c.OvertimeRate,
                EnableRounding = c.EnableRounding
            };
        }

        public async Task<CompanyDTO> CreateAsync(CompanyDTO dto)
        {
            var company = new Company
            {
                Code = dto.Code,
                Name = dto.Name,
                TaxNumber = dto.TaxNumber,
                ClientId = dto.ClientId,
                CurrencyId = dto.CurrencyId,
                CountryId = dto.CountryId,
                StateId = dto.StateId,
                LanguageId = dto.LanguageId,
                BankName = dto.BankName,
                BankAccountName = dto.BankAccountName,
                BankAccountNumber = dto.BankAccountNumber,
                IBAN = dto.IBAN,
                Phone = dto.Phone,
                Fax = dto.Fax,
                Mobile = dto.Mobile,
                Email = dto.Email,
                Website = dto.Website,
                City = dto.City,
                PostCode = dto.PostCode,
                Address = dto.Address,
                Timezone = dto.Timezone,
                DateFormat = dto.DateFormat,
                CompanyLogoPath = dto.CompanyLogoPath,
                FaviconPath = dto.FaviconPath,
                OvertimeRate = dto.OvertimeRate,
                EnableRounding = dto.EnableRounding
            };

            _context.Companies.Add(company);
            await _context.SaveChangesAsync();

            dto.Id = company.Id;
            return dto;
        }

        public async Task<CompanyDTO?> UpdateAsync(int id, CompanyDTO dto)
        {
            var company = await _context.Companies.FindAsync(id);
            if (company == null) return null;

            company.Code = dto.Code;
            company.Name = dto.Name;
            company.TaxNumber = dto.TaxNumber;
            company.ClientId = dto.ClientId;
            company.CurrencyId = dto.CurrencyId;
            company.CountryId = dto.CountryId;
            company.StateId = dto.StateId;
            company.LanguageId = dto.LanguageId;
            company.BankName = dto.BankName;
            company.BankAccountName = dto.BankAccountName;
            company.BankAccountNumber = dto.BankAccountNumber;
            company.IBAN = dto.IBAN;
            company.Phone = dto.Phone;
            company.Fax = dto.Fax;
            company.Mobile = dto.Mobile;
            company.Email = dto.Email;
            company.Website = dto.Website;
            company.City = dto.City;
            company.PostCode = dto.PostCode;
            company.Address = dto.Address;
            company.Timezone = dto.Timezone;
            company.DateFormat = dto.DateFormat;
            company.CompanyLogoPath = dto.CompanyLogoPath;
            company.FaviconPath = dto.FaviconPath;
            company.OvertimeRate = dto.OvertimeRate;
            company.EnableRounding = dto.EnableRounding;

            await _context.SaveChangesAsync();

            return dto;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var company = await _context.Companies.FindAsync(id);
            if (company == null) return false;

            _context.Companies.Remove(company);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
