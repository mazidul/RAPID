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

        public async Task<CompanyDTO> GetByIdAsync(int id)
        {
            var c = await _context.Companies.FindAsync(id);
            if (c == null) return null;

            return new CompanyDTO
            {
                Id = c.Id,
                Code = c.Code,
                Name = c.Name,
                TaxNumber = c.TaxNumber,
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
            var entity = new Company
            {
                Code = dto.Code,
                Name = dto.Name,
                TaxNumber = dto.TaxNumber,
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

            _context.Companies.Add(entity);
            await _context.SaveChangesAsync();

            dto.Id = entity.Id;
            return dto;
        }

        public async Task<CompanyDTO> UpdateAsync(int id, CompanyDTO dto)
        {
            var entity = await _context.Companies.FindAsync(id);
            if (entity == null) return null;

            entity.Code = dto.Code;
            entity.Name = dto.Name;
            entity.TaxNumber = dto.TaxNumber;
            entity.CurrencyId = dto.CurrencyId;
            entity.CountryId = dto.CountryId;
            entity.StateId = dto.StateId;
            entity.LanguageId = dto.LanguageId;
            entity.BankName = dto.BankName;
            entity.BankAccountName = dto.BankAccountName;
            entity.BankAccountNumber = dto.BankAccountNumber;
            entity.IBAN = dto.IBAN;
            entity.Phone = dto.Phone;
            entity.Fax = dto.Fax;
            entity.Mobile = dto.Mobile;
            entity.Email = dto.Email;
            entity.Website = dto.Website;
            entity.City = dto.City;
            entity.PostCode = dto.PostCode;
            entity.Address = dto.Address;
            entity.Timezone = dto.Timezone;
            entity.DateFormat = dto.DateFormat;
            entity.CompanyLogoPath = dto.CompanyLogoPath;
            entity.FaviconPath = dto.FaviconPath;
            entity.OvertimeRate = dto.OvertimeRate;
            entity.EnableRounding = dto.EnableRounding;

            await _context.SaveChangesAsync();

            return dto;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Companies.FindAsync(id);
            if (entity == null) return false;

            _context.Companies.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
