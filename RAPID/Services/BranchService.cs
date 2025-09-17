using Microsoft.EntityFrameworkCore;
using RAPID.DTOs.Customer;
using RAPID.Models;

namespace RAPID.Services;

public class BranchService : IBranchService
{
    private readonly ApplicationDbContext _context;

    public BranchService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<BranchDTO>> GetAllAsync()
    {
        return await _context.Branches
            .Select(b => new BranchDTO
            {
                Id = b.Id,
                BranchCode = b.BranchCode,
                BranchName = b.BranchName,
                CompanyId = b.CompanyId,
                VatNumber = b.VatNumber,
                Website = b.Website,
                Phone = b.Phone,
                CurrencyId = b.CurrencyId,
                CountryId = b.CountryId,
                StateId = b.StateId,
                City = b.City,
                PostCode = b.PostCode,
                Bank = b.Bank,
                Address = b.Address,
                AddressArabic = b.AddressArabic
            })
            .ToListAsync();
    }

    public async Task<BranchDTO?> GetByIdAsync(int id)
    {
        var b = await _context.Branches.FindAsync(id);
        if (b == null) return null;

        return new BranchDTO
        {
            Id = b.Id,
            BranchCode = b.BranchCode,
            BranchName = b.BranchName,
            CompanyId = b.CompanyId,
            VatNumber = b.VatNumber,
            Website = b.Website,
            Phone = b.Phone,
            CurrencyId = b.CurrencyId,
            CountryId = b.CountryId,
            StateId = b.StateId,
            City = b.City,
            PostCode = b.PostCode,
            Bank = b.Bank,
            Address = b.Address,
            AddressArabic = b.AddressArabic
        };
    }

    public async Task<BranchDTO> CreateAsync(BranchDTO dto)
    {
        var branch = new Branch
        {
            BranchCode = dto.BranchCode,
            BranchName = dto.BranchName,
            CompanyId = dto.CompanyId,
            VatNumber = dto.VatNumber,
            Website = dto.Website,
            Phone = dto.Phone,
            CurrencyId = dto.CurrencyId,
            CountryId = dto.CountryId,
            StateId = dto.StateId,
            City = dto.City,
            PostCode = dto.PostCode,
            Bank = dto.Bank,
            Address = dto.Address,
            AddressArabic = dto.AddressArabic
        };

        _context.Branches.Add(branch);
        await _context.SaveChangesAsync();
        dto.Id = branch.Id;
        return dto;
    }

    public async Task<BranchDTO?> UpdateAsync(int id, BranchDTO dto)
    {
        var branch = await _context.Branches.FindAsync(id);
        if (branch == null) return null;

        branch.BranchCode = dto.BranchCode;
        branch.BranchName = dto.BranchName;
        branch.CompanyId = dto.CompanyId;
        branch.VatNumber = dto.VatNumber;
        branch.Website = dto.Website;
        branch.Phone = dto.Phone;
        branch.CurrencyId = dto.CurrencyId;
        branch.CountryId = dto.CountryId;
        branch.StateId = dto.StateId;
        branch.City = dto.City;
        branch.PostCode = dto.PostCode;
        branch.Bank = dto.Bank;
        branch.Address = dto.Address;
        branch.AddressArabic = dto.AddressArabic;

        await _context.SaveChangesAsync();
        return dto;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var branch = await _context.Branches.FindAsync(id);
        if (branch == null) return false;

        _context.Branches.Remove(branch);
        await _context.SaveChangesAsync();
        return true;
    }
}
