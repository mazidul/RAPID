using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RAPID.DTOs.Customer;
using RAPID.Services;

namespace RAPID.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ColorController : ControllerBase
{
    private readonly IColorService _colorService;

    public ColorController(IColorService colorService)
    {
        _colorService = colorService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var colors = await _colorService.GetAllAsync();
        return Ok(colors);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(byte id)
    {
        var color = await _colorService.GetByIdAsync(id);
        if (color == null) return NotFound();

        return Ok(color);
    }

    [HttpPost]
    public async Task<IActionResult> Create(ColorDTO dto)
    {
        var created = await _colorService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(byte id, ColorDTO dto)
    {
        var updated = await _colorService.UpdateAsync(id, dto);
        if (updated == null) return NotFound();

        return Ok(updated);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(byte id)
    {
        var deleted = await _colorService.DeleteAsync(id);
        if (!deleted) return NotFound();

        return NoContent();
    }
}
