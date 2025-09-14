using Microsoft.EntityFrameworkCore;
using RAPID.DTOs.Customer;
using RAPID.Models;

namespace RAPID.Services;

public class SupplierService : ISupplierService
{
    private readonly ApplicationDbContext _context;
    private const byte SupplierReferenceTypeId = 1; // Supplier = 1

    public SupplierService(ApplicationDbContext context)
    {
        _context = context;
    }

    // সব Supplier আনা
    public async Task<List<SupplierDTO>> GetAllAsync()
    {
        var suppliers = await _context.Suppliers.ToListAsync();
        var result = new List<SupplierDTO>();

        foreach (var s in suppliers)
        {
            var documents = await _context.Documents
                .Where(d => d.ReferenceId == s.Id && d.ReferenceTypeId == SupplierReferenceTypeId)
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

            result.Add(new SupplierDTO
            {
                Id = s.Id,
                SupplierName = s.SupplierName,
                VatNumber = s.VatNumber,
                Website = s.Website,
                Phone = s.Phone,
                Currency = s.Currency,
                Country = s.Country,
                Language = s.Language,
                Street = s.Street,
                PostCode = s.PostCode,
                OpeningBalance = s.OpeningBalance,
                Documents = documents
            });
        }

        return result;
    }

    // ID অনুযায়ী Supplier
    public async Task<SupplierDTO?> GetByIdAsync(int id)
    {
        var supplier = await _context.Suppliers.FindAsync(id);
        if (supplier == null) return null;

        var documents = await _context.Documents
            .Where(d => d.ReferenceId == supplier.Id && d.ReferenceTypeId == SupplierReferenceTypeId)
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

        return new SupplierDTO
        {
            Id = supplier.Id,
            SupplierName = supplier.SupplierName,
            VatNumber = supplier.VatNumber,
            Website = supplier.Website,
            Phone = supplier.Phone,
            Currency = supplier.Currency,
            Country = supplier.Country,
            Language = supplier.Language,
            Street = supplier.Street,
            PostCode = supplier.PostCode,
            OpeningBalance = supplier.OpeningBalance,
            Documents = documents
        };
    }

    // Supplier তৈরি
    public async Task<SupplierDTO> CreateAsync(SupplierDTO dto)
    {
        var supplier = new Supplier
        {
            SupplierName = dto.SupplierName,
            VatNumber = dto.VatNumber,
            Website = dto.Website,
            Phone = dto.Phone,
            Currency = dto.Currency,
            Country = dto.Country,
            Language = dto.Language,
            Street = dto.Street,
            PostCode = dto.PostCode,
            OpeningBalance = dto.OpeningBalance
        };

        _context.Suppliers.Add(supplier);
        await _context.SaveChangesAsync();

        // Document সংরক্ষণ
        foreach (var docDto in dto.Documents)
        {
            var doc = new Document
            {
                ReferenceId = supplier.Id,
                ReferenceTypeId = SupplierReferenceTypeId,
                FileName = docDto.FileName,
                FilePath = docDto.FilePath,
                IssueDate = docDto.IssueDate,
                ExpiryDate = docDto.ExpiryDate
            };
            _context.Documents.Add(doc);
        }

        await _context.SaveChangesAsync();

        dto.Id = supplier.Id;
        return dto;
    }

    // Supplier আপডেট
    public async Task<SupplierDTO?> UpdateAsync(int id, SupplierDTO dto)
    {
        var supplier = await _context.Suppliers.FindAsync(id);
        if (supplier == null) return null;

        supplier.SupplierName = dto.SupplierName;
        supplier.VatNumber = dto.VatNumber;
        supplier.Website = dto.Website;
        supplier.Phone = dto.Phone;
        supplier.Currency = dto.Currency;
        supplier.Country = dto.Country;
        supplier.Language = dto.Language;
        supplier.Street = dto.Street;
        supplier.PostCode = dto.PostCode;
        supplier.OpeningBalance = dto.OpeningBalance;

        _context.Entry(supplier).State = EntityState.Modified;

        // Document আপডেট
        var existingDocs = await _context.Documents
            .Where(d => d.ReferenceId == supplier.Id && d.ReferenceTypeId == SupplierReferenceTypeId)
            .ToListAsync();

        // Delete removed
        var toDelete = existingDocs.Where(ed => !dto.Documents.Any(d => d.Id == ed.Id)).ToList();
        if (toDelete.Any()) _context.Documents.RemoveRange(toDelete);

        // Update existing & add new
        foreach (var docDto in dto.Documents)
        {
            var existingDoc = existingDocs.FirstOrDefault(ed => ed.Id == docDto.Id);
            if (existingDoc != null)
            {
                existingDoc.FileName = docDto.FileName;
                existingDoc.FilePath = docDto.FilePath;
                existingDoc.IssueDate = docDto.IssueDate;
                existingDoc.ExpiryDate = docDto.ExpiryDate;
            }
            else
            {
                _context.Documents.Add(new Document
                {
                    ReferenceId = supplier.Id,
                    ReferenceTypeId = SupplierReferenceTypeId,
                    FileName = docDto.FileName,
                    FilePath = docDto.FilePath,
                    IssueDate = docDto.IssueDate,
                    ExpiryDate = docDto.ExpiryDate
                });
            }
        }

        await _context.SaveChangesAsync();
        return dto;
    }

    // Supplier মুছে ফেলা
    public async Task<bool> DeleteAsync(int id)
    {
        var supplier = await _context.Suppliers.FindAsync(id);
        if (supplier == null) return false;

        var documents = _context.Documents
            .Where(d => d.ReferenceId == supplier.Id && d.ReferenceTypeId == SupplierReferenceTypeId);
        _context.Documents.RemoveRange(documents);

        _context.Suppliers.Remove(supplier);
        await _context.SaveChangesAsync();

        return true;
    }
}
