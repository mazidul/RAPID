using Microsoft.EntityFrameworkCore;
using RAPID.DTOs.Customer;
using RAPID.Models;
using System.Diagnostics.Metrics;

namespace RAPID.Services;

public class CustomerService : ICustomerService
{
    private readonly ApplicationDbContext _context;
    private const byte CustomerReferenceTypeId = 0; // 0 = Customer

    public CustomerService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<CustomerDTO>> GetAllAsync(int? pageNumber = null, int? pageSize = null)
    {

        var query = _context.Customers.AsQueryable();


        if (pageNumber.HasValue && pageSize.HasValue)
        {
            int skip = (pageNumber.Value - 1) * pageSize.Value;
            query = query.Skip(skip).Take(pageSize.Value);
        }

        // Get paginated customers
        var customers = await query.ToListAsync();

        var result = new List<CustomerDTO>();

        foreach (var c in customers)
        {
            // Fetch documents for each customer
            var documents = await _context.Documents
                .Where(d => d.ReferenceId == c.Id && d.ReferenceTypeId == CustomerReferenceTypeId)
                .Select(d => new DocumentDTO
                {
                    Id = d.Id,
                    ReferenceId = d.ReferenceId,
                    ReferenceTypeId = d.ReferenceTypeId,
                    FileName = d.FileName,
                    FilePath = d.FilePath,
                    IssueDate = d.IssueDate,
                    ExpiryDate = d.ExpiryDate
                }).ToListAsync();

            result.Add(new CustomerDTO
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
                Documents = documents
            });
        }

        return result;
    }

    public async Task<CustomerDTO?> GetByIdAsync(int id)
    {
        var customer = await _context.Customers.FindAsync(id);
        if (customer == null) return null;

        var documents = await _context.Documents
            .Where(d => d.ReferenceId == customer.Id && d.ReferenceTypeId == CustomerReferenceTypeId)
            .Select(d => new DocumentDTO
            {
                Id = d.Id,
                ReferenceId = d.ReferenceId,
                ReferenceTypeId = d.ReferenceTypeId,
                FileName = d.FileName,
                FilePath = d.FilePath,
                IssueDate = d.IssueDate,
                ExpiryDate = d.ExpiryDate
            }).ToListAsync();

        return new CustomerDTO
        {
            Id = customer.Id,
            CustomerNo = customer.CustomerNo,
            CustomerName = customer.CustomerName,
            ShortName = customer.ShortName,
            VatNumber = customer.VatNumber,
            VendorCode = customer.VendorCode,
            PaymentModeId = customer.PaymentModeId,
            CurrencyId = customer.CurrencyId,
            CountryId = customer.CountryId,
            StateId = customer.StateId,
            LanguageId = customer.LanguageId,
            Phone = customer.Phone,
            Fax = customer.Fax,
            Mobile = customer.Mobile,
            Whatsapp = customer.Whatsapp,
            PostCode = customer.PostCode,
            Address = customer.Address,
            Email = customer.Email,
            Website = customer.Website,
            LocationUrl = customer.LocationUrl,
            OpeningBalance = customer.OpeningBalance,
            CustomerLogoPath = customer.CustomerLogoPath,
            Documents = documents
        };
    }

    public async Task<CustomerDTO> CreateAsync(CustomerDTO dto)
    {
        using var transaction = await _context.Database.BeginTransactionAsync();
        try
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

            foreach (var d in dto.Documents)
            {
                var doc = new Document
                {
                    ReferenceId = customer.Id,
                    ReferenceTypeId = CustomerReferenceTypeId,
                    FileName = d.FileName,
                    FilePath = d.FilePath,
                    IssueDate = d.IssueDate,
                    ExpiryDate = d.ExpiryDate
                };
                _context.Documents.Add(doc);
            }

            await _context.SaveChangesAsync();
            await transaction.CommitAsync();

            dto.Id = customer.Id;
            return dto;
        }
        catch
        {
            await transaction.RollbackAsync();
            throw;
        }
    }

    public async Task<CustomerDTO?> UpdateAsync(int id, CustomerDTO dto)
    {
        var customer = await _context.Customers.FindAsync(id);
        if (customer == null) return null;

        _context.Entry(customer).CurrentValues.SetValues(dto);

        var existingDocs = await _context.Documents
            .Where(d => d.ReferenceId == id && d.ReferenceTypeId == 0)
            .ToListAsync();

        foreach (var docDto in dto.Documents)
        {
            if (docDto.Id == 0)
            {
                _context.Documents.Add(new Document
                {
                    ReferenceId = id,
                    ReferenceTypeId = 0,
                    FileName = docDto.FileName,
                    FilePath = docDto.FilePath,
                    IssueDate = docDto.IssueDate,
                    ExpiryDate = docDto.ExpiryDate
                });
            }
            else
            {
                var existingDoc = existingDocs.FirstOrDefault(d => d.Id == docDto.Id);
                if (existingDoc != null)
                {
                    _context.Entry(existingDoc).CurrentValues.SetValues(docDto);
                }
            }
        }

        var docIds = dto.Documents.Where(d => d.Id != 0).Select(d => d.Id).ToList();
        var toDelete = existingDocs.Where(d => !docIds.Contains(d.Id)).ToList();
        if (toDelete.Any()) _context.Documents.RemoveRange(toDelete);

        await _context.SaveChangesAsync();
        return dto;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        //using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null) return false;

            // Delete related documents
            var documents = _context.Documents
                .Where(d => d.ReferenceId == customer.Id && d.ReferenceTypeId == CustomerReferenceTypeId);
            _context.Documents.RemoveRange(documents);

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            //await transaction.CommitAsync();

            return true;
        }
        catch
        {
            //await transaction.RollbackAsync();
            throw;
        }
    }
}
