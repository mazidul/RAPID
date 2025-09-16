using Microsoft.AspNetCore.Mvc;
using RAPID.DTOs.Customer;
using RAPID.Services;

namespace RAPID.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _customerService;

    public CustomerController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    [HttpGet]
    public async Task<ActionResult<List<CustomerDTO>>> GetAll(int? pageNumber = null, int? pageSize = null)
    {
        return Ok(await _customerService.GetAllAsync(pageNumber, pageSize));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CustomerDTO>> GetById(int id)
    {
        var customer = await _customerService.GetByIdAsync(id);
        if (customer == null) return NotFound();
        return Ok(customer);
    }

    [HttpPost]
    public async Task<ActionResult<CustomerDTO>> Create(CustomerDTO dto)
    {
        var created = await _customerService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<CustomerDTO>> Update(int id, CustomerDTO dto)
    {
        var updated = await _customerService.UpdateAsync(id, dto);
        if (updated == null) return NotFound();
        return Ok(updated);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _customerService.DeleteAsync(id);
        if (!deleted) return NotFound();
        return NoContent();
    }
}
