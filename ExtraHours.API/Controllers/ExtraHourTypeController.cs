using ExtraHours.Core.Models;
using ExtraHours.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExtraHours.API.Controllers
{
    [Route("api/extra-hour-types")]
    [ApiController]
    public class ExtraHourTypeController : ControllerBase
    {
        private readonly IExtraHourTypeService _extraHourTypeService;

        public ExtraHourTypeController(IExtraHourTypeService extraHourTypeService)
        {
            _extraHourTypeService = extraHourTypeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var types = await _extraHourTypeService.GetAllTypes();
            return Ok(types);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var type = await _extraHourTypeService.GetTypeById(id);
            if (type == null) return NotFound();
            return Ok(type);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ExtraHourType extraHourType)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdType = await _extraHourTypeService.CreateType(extraHourType);
            return CreatedAtAction(nameof(GetById), new { id = createdType.Id }, createdType);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ExtraHourType updatedType)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var type = await _extraHourTypeService.UpdateType(id, updatedType);
            if (type == null) return NotFound();
            return Ok(type);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _extraHourTypeService.DeleteType(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}