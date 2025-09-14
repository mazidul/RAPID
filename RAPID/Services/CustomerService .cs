using Microsoft.EntityFrameworkCore;
using RAPID.DTOs.Customer;
using RAPID.Models;
using System;

namespace RAPID.Services;

public class CustomerService : ICustomerService
{
    private readonly ApplicationDbContext _context;

    public CustomerService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<CustomerDTO>> GetAllAsync()
    {
        return await _context.Customers
            .Include(c => c.Document)
            .Select(c => new CustomerDTO
            {
                Id = c.Id,
                CustomerNo = c.CustomerNo,
                CustomerName = c.CustomerName,
                ShortName = c.ShortName,
                VatNumber = c.VatNumber,
                VendorCode = c.VendorCode,
                PaymentModeId = c.PaymentModeId,
                CurrencyId = c.CurrencyId,
                CountryId = c.CountryId,
                StateId = c.StateId,
                LanguageId = c.LanguageId,
                Phone = c.Phone,
                Fax = c.Fax,
                Mobile = c.Mobile,
                Whatsapp = c.Whatsapp,
                PostCode = c.PostCode,
                Address = c.Address,
                Email = c.Email,
                Website = c.Website,
                LocationUrl = c.LocationUrl,
                OpeningBalance = c.OpeningBalance,
                CustomerLogoPath = c.CustomerLogoPath,
                Documents = c.Document != null
                    ? new List<DocumentDTO> {
                        new DocumentDTO {
                            Id = c.Document.Id,
                            FileName = c.Document.FileName,
                            FilePath = c.Document.FilePath,
                            IssueDate = c.Document.IssueDate,
                            ExpiryDate = c.Document.ExpiryDate
                        }
                    }
                    : new List<DocumentDTO>()
            })
            .ToListAsync();
    }

    public async Task<CustomerDTO?> GetByIdAsync(int id)
    {
        var c = await _context.Customers
            .Include(x => x.Document)
            .FirstOrDefaultAsync(x => x.Id == id);

        if (c == null) return null;

        return new CustomerDTO
        {
            Id = c.Id,
            CustomerNo = c.CustomerNo,
            CustomerName = c.CustomerName,
            ShortName = c.ShortName,
            VatNumber = c.VatNumber,
            VendorCode = c.VendorCode,
            PaymentModeId = c.PaymentModeId,
            CurrencyId = c.CurrencyId,
            CountryId = c.CountryId,
            StateId = c.StateId,
            LanguageId = c.LanguageId,
            Phone = c.Phone,
            Fax = c.Fax,
            Mobile = c.Mobile,
            Whatsapp = c.Whatsapp,
            PostCode = c.PostCode,
            Address = c.Address,
            Email = c.Email,
            Website = c.Website,
            LocationUrl = c.LocationUrl,
            OpeningBalance = c.OpeningBalance,
            CustomerLogoPath = c.CustomerLogoPath,
            Documents = c.Document != null
                ? new List<DocumentDTO> {
                    new DocumentDTO {
                        Id = c.Document.Id,
                        FileName = c.Document.FileName,
                        FilePath = c.Document.FilePath,
                        IssueDate = c.Document.IssueDate,
                        ExpiryDate = c.Document.ExpiryDate
                    }
                }
                : new List<DocumentDTO>()
        };
    }

    public async Task<CustomerDTO> AddAsync(CustomerDTO dto)
    {
        var customer = new Customer
        {
            CustomerNo = dto.CustomerNo,
            CustomerName = dto.CustomerName,
            ShortName = dto.ShortName,
            VatNumber = dto.VatNumber,
            VendorCode = dto.VendorCode,
            PaymentModeId = dto.PaymentModeId,
            CurrencyId = dto.CurrencyId,
            CountryId = dto.CountryId,
            StateId = dto.StateId,
            LanguageId = dto.LanguageId,
            Phone = dto.Phone,
            Fax = dto.Fax,
            Mobile = dto.Mobile,
            Whatsapp = dto.Whatsapp,
            PostCode = dto.PostCode,
            Address = dto.Address,
            Email = dto.Email,
            Website = dto.Website,
            LocationUrl = dto.LocationUrl,
            OpeningBalance = dto.OpeningBalance,
            CustomerLogoPath = dto.CustomerLogoPath
        };

        _context.Customers.Add(customer);
        await _context.SaveChangesAsync();

        dto.Id = customer.Id;
        return dto;
    }

    public async Task<CustomerDTO?> UpdateAsync(CustomerDTO dto)
    {
        var customer = await _context.Customers.FindAsync(dto.Id);
        if (customer == null) return null;

        customer.CustomerNo = dto.CustomerNo;
        customer.CustomerName = dto.CustomerName;
        customer.ShortName = dto.ShortName;
        customer.VatNumber = dto.VatNumber;
        customer.VendorCode = dto.VendorCode;
        customer.PaymentModeId = dto.PaymentModeId;
        customer.CurrencyId = dto.CurrencyId;
        customer.CountryId = dto.CountryId;
        customer.StateId = dto.StateId;
        customer.LanguageId = dto.LanguageId;
        customer.Phone = dto.Phone;
        customer.Fax = dto.Fax;
        customer.Mobile = dto.Mobile;
        customer.Whatsapp = dto.Whatsapp;
        customer.PostCode = dto.PostCode;
        customer.Address = dto.Address;
        customer.Email = dto.Email;
        customer.Website = dto.Website;
        customer.LocationUrl = dto.LocationUrl;
        customer.OpeningBalance = dto.OpeningBalance;
        customer.CustomerLogoPath = dto.CustomerLogoPath;

        _context.Customers.Update(customer);
        await _context.SaveChangesAsync();

        return dto;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var customer = await _context.Customers.FindAsync(id);
        if (customer == null) return false;

        _context.Customers.Remove(customer);
        await _context.SaveChangesAsync();
        return true;
    }
}
