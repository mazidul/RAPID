using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RAPID.DTOs.Customer;
using RAPID.Services;

namespace RAPID.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SubCategoryController : ControllerBase
{
    private readonly ISubCategoryService _subCategoryService;

    public SubCategoryController(ISubCategoryService subCategoryService)
    {
        _subCategoryService = subCategoryService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var subCategories = await _subCategoryService.GetAllAsync();
        return Ok(subCategories);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(byte id)
    {
        var subCategory = await _subCategoryService.GetByIdAsync(id);
        if (subCategory == null) return NotFound();

        return Ok(subCategory);
    }

    [HttpPost]
    public async Task<IActionResult> Create(SubCategoryDTO dto)
    {
        var created = await _subCategoryService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(byte id, SubCategoryDTO dto)
    {
        var updated = await _subCategoryService.UpdateAsync(id, dto);
        if (updated == null) return NotFound();

        return Ok(updated);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(byte id)
    {
        var deleted = await _subCategoryService.DeleteAsync(id);
        if (!deleted) return NotFound();

        return NoContent();
    }
}
