using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RAPID.DTOs.Customer;
using RAPID.Services;

namespace RAPID.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GroupController : ControllerBase
{
    private readonly IGroupService _groupService;

    public GroupController(IGroupService groupService)
    {
        _groupService = groupService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var groups = await _groupService.GetAllAsync();
        return Ok(groups);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(byte id)
    {
        var group = await _groupService.GetByIdAsync(id);
        if (group == null) return NotFound();

        return Ok(group);
    }

    [HttpPost]
    public async Task<IActionResult> Create(GroupDTO dto)
    {
        var created = await _groupService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(byte id, GroupDTO dto)
    {
        var updated = await _groupService.UpdateAsync(id, dto);
        if (updated == null) return NotFound();

        return Ok(updated);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(byte id)
    {
        var deleted = await _groupService.DeleteAsync(id);
        if (!deleted) return NotFound();

        return NoContent();
    }
}
