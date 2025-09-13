using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RAPID.DTOs.Customer;
using RAPID.Models;

namespace RAPID.Services;

public class CustomerService : ICustomerService
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public CustomerService(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<CustomerDTO> GetByIdAsync(int id)
    {
        var customer = await _context.Customers
            .Include(c => c.Documents)
            .FirstOrDefaultAsync(c => c.Id == id);

        return _mapper.Map<CustomerDTO>(customer);
    }

    public async Task<IEnumerable<CustomerDTO>> GetAllAsync()
    {
        var customers = await _context.Customers
            .Include(c => c.Documents)
            .ToListAsync();

        return _mapper.Map<IEnumerable<CustomerDTO>>(customers);
    }

    public async Task<CustomerDTO> CreateAsync(CustomerDTO dto)
    {
        var entity = _mapper.Map<Customer>(dto);
        _context.Customers.Add(entity);
        await _context.SaveChangesAsync();

        return _mapper.Map<CustomerDTO>(entity);
    }

    public async Task<CustomerDTO> UpdateAsync(int id, CustomerDTO dto)
    {
        var entity = await _context.Customers
            .Include(c => c.Documents)
            .FirstOrDefaultAsync(c => c.Id == id);

        if (entity == null) return null;

        _mapper.Map(dto, entity); // update entity
        await _context.SaveChangesAsync();

        return _mapper.Map<CustomerDTO>(entity);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await _context.Customers.FindAsync(id);
        if (entity == null) return false;

        _context.Customers.Remove(entity);
        await _context.SaveChangesAsync();
        return true;
    }
}
