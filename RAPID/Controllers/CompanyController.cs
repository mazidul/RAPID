using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RAPID.DTOs.Customer;
using RAPID.Services;

namespace RAPID.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var companies = await _companyService.GetAllAsync();
            return Ok(companies);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var company = await _companyService.GetByIdAsync(id);
            if (company == null) return NotFound();
            return Ok(company);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CompanyDTO dto)
        {
            var company = await _companyService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = company.Id }, company);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CompanyDTO dto)
        {
            var company = await _companyService.UpdateAsync(id, dto);
            if (company == null) return NotFound();
            return Ok(company);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _companyService.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
