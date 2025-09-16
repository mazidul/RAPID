using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RAPID.Services;

namespace RAPID.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableCountController : ControllerBase
    {
        private readonly ITableCountService _service;

        public TableCountController(ITableCountService service)
        {
            _service = service;
        }

        [HttpGet("{modelName}")]
        public async Task<IActionResult> GetCounts(string modelName)
        {
            var result = await _service.GetCountsAsync(modelName);

            if (result == null)
                return NotFound(new { Message = $"Model '{modelName}' not found" });

            return Ok(result);
        }
    }
}
