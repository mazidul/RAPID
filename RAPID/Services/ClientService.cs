using Microsoft.EntityFrameworkCore;
using RAPID.DTOs.Customer;
using RAPID.Models;

namespace RAPID.Services
{
    public class ClientService : IClientService
    {
        private readonly ApplicationDbContext _context;

        public ClientService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ClientDTO>> GetAllAsync()
        {
            return await _context.Clients
                .Select(c => new ClientDTO
                {
                    Id = c.Id,
                    ClientNo = c.ClientNo,
                    ClientName = c.ClientName,
                    ShortName = c.ShortName,
                    VatNumber = c.VatNumber,
                    VendorCode = c.VendorCode,
                    PaymentModeId = c.PaymentModeId,
                    CurrencyId = c.CurrencyId,
                    Phone = c.Phone,
                    Fax = c.Fax,
                    Mobile = c.Mobile,
                    Whatsapp = c.Whatsapp,
                    CountryId = c.CountryId,
                    StateId = c.StateId,
                    PostCode = c.PostCode,
                    Address = c.Address,
                    Email = c.Email,
                    Website = c.Website,
                    LanguageId = c.LanguageId,
                    LocationUrl = c.LocationUrl,
                    OpeningBalance = c.OpeningBalance,
                    CustomerLogoPath = c.CustomerLogoPath
                })
                .ToListAsync();
        }

        public async Task<ClientDTO?> GetByIdAsync(int id)
        {
            var c = await _context.Clients.FindAsync(id);
            if (c == null) return null;

            return new ClientDTO
            {
                Id = c.Id,
                ClientNo = c.ClientNo,
                ClientName = c.ClientName,
                ShortName = c.ShortName,
                VatNumber = c.VatNumber,
                VendorCode = c.VendorCode,
                PaymentModeId = c.PaymentModeId,
                CurrencyId = c.CurrencyId,
                Phone = c.Phone,
                Fax = c.Fax,
                Mobile = c.Mobile,
                Whatsapp = c.Whatsapp,
                CountryId = c.CountryId,
                StateId = c.StateId,
                PostCode = c.PostCode,
                Address = c.Address,
                Email = c.Email,
                Website = c.Website,
                LanguageId = c.LanguageId,
                LocationUrl = c.LocationUrl,
                OpeningBalance = c.OpeningBalance,
                CustomerLogoPath = c.CustomerLogoPath
            };
        }

        public async Task<ClientDTO> CreateAsync(ClientDTO dto)
        {
            var client = new Client
            {
                ClientNo = dto.ClientNo,
                ClientName = dto.ClientName,
                ShortName = dto.ShortName,
                VatNumber = dto.VatNumber,
                VendorCode = dto.VendorCode,
                PaymentModeId = dto.PaymentModeId,
                CurrencyId = dto.CurrencyId,
                Phone = dto.Phone,
                Fax = dto.Fax,
                Mobile = dto.Mobile,
                Whatsapp = dto.Whatsapp,
                CountryId = dto.CountryId,
                StateId = dto.StateId,
                PostCode = dto.PostCode,
                Address = dto.Address,
                Email = dto.Email,
                Website = dto.Website,
                LanguageId = dto.LanguageId,
                LocationUrl = dto.LocationUrl,
                OpeningBalance = dto.OpeningBalance,
                CustomerLogoPath = dto.CustomerLogoPath
            };

            _context.Clients.Add(client);
            await _context.SaveChangesAsync();

            dto.Id = client.Id;
            return dto;
        }

        public async Task<ClientDTO?> UpdateAsync(int id, ClientDTO dto)
        {
            var client = await _context.Clients.FindAsync(id);
            if (client == null) return null;

            client.ClientNo = dto.ClientNo;
            client.ClientName = dto.ClientName;
            client.ShortName = dto.ShortName;
            client.VatNumber = dto.VatNumber;
            client.VendorCode = dto.VendorCode;
            client.PaymentModeId = dto.PaymentModeId;
            client.CurrencyId = dto.CurrencyId;
            client.Phone = dto.Phone;
            client.Fax = dto.Fax;
            client.Mobile = dto.Mobile;
            client.Whatsapp = dto.Whatsapp;
            client.CountryId = dto.CountryId;
            client.StateId = dto.StateId;
            client.PostCode = dto.PostCode;
            client.Address = dto.Address;
            client.Email = dto.Email;
            client.Website = dto.Website;
            client.LanguageId = dto.LanguageId;
            client.LocationUrl = dto.LocationUrl;
            client.OpeningBalance = dto.OpeningBalance;
            client.CustomerLogoPath = dto.CustomerLogoPath;

            await _context.SaveChangesAsync();

            return dto;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var client = await _context.Clients.FindAsync(id);
            if (client == null) return false;

            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
