using Microsoft.AspNetCore.Mvc;
using NotesAPI.DTOs;
using NotesAPI.Interafces;
using static NotesAPI.DTOs.NoteDtos;

namespace NotesAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotesController : ControllerBase
    {
        private readonly INoteService _service;
        public NotesController(INoteService service)
        {
            _service = service;
        }
        [HttpGet] 
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var note = await _service.GetByIdAsync(id);
            if (note == null) return NotFound();

            return Ok(note);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Guid id, CreateNoteDto dto)
        {
            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateNoteDto dto)
        {
            var updated = await _service.UpdateAsync(id, dto);
            if(!updated) return NotFound();

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleted = await _service.DeleteAsync(id);

            if (!deleted)
                return NotFound();

            return NoContent();
        }

    }
}
