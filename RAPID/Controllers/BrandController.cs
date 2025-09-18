using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RAPID.DTOs.Customer;
using RAPID.Services;

namespace RAPID.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BrandController : ControllerBase
{
    private readonly IBrandService _brandService;

    public BrandController(IBrandService brandService)
    {
        _brandService = brandService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var brands = await _brandService.GetAllAsync();
        return Ok(brands);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(byte id)
    {
        var brand = await _brandService.GetByIdAsync(id);
        if (brand == null) return NotFound();

        return Ok(brand);
    }

    [HttpPost]
    public async Task<IActionResult> Create(BrandDTO dto)
    {
        var created = await _brandService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(byte id, BrandDTO dto)
    {
        var updated = await _brandService.UpdateAsync(id, dto);
        if (updated == null) return NotFound();

        return Ok(updated);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(byte id)
    {
        var deleted = await _brandService.DeleteAsync(id);
        if (!deleted) return NotFound();

        return NoContent();
    }
}
