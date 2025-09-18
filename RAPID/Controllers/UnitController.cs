using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RAPID.DTOs.Customer;
using RAPID.Services;

namespace RAPID.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UnitController : ControllerBase
{
    private readonly IUnitService _unitService;

    public UnitController(IUnitService unitService)
    {
        _unitService = unitService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var units = await _unitService.GetAllAsync();
        return Ok(units);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(byte id)
    {
        var unit = await _unitService.GetByIdAsync(id);
        if (unit == null) return NotFound();

        return Ok(unit);
    }

    [HttpPost]
    public async Task<IActionResult> Create(UnitDTO dto)
    {
        var created = await _unitService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(byte id, UnitDTO dto)
    {
        var updated = await _unitService.UpdateAsync(id, dto);
        if (updated == null) return NotFound();

        return Ok(updated);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(byte id)
    {
        var deleted = await _unitService.DeleteAsync(id);
        if (!deleted) return NotFound();

        return NoContent();
    }
}
