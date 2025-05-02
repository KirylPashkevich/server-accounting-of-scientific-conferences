using Microsoft.AspNetCore.Mvc;
using server.Models;
using server.Models.DTOs;
using server.Repository;

namespace server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConfirmedController : ControllerBase
    {
        private readonly IRepositoryManager _repository;

        public ConfirmedController(IRepositoryManager repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetConfirmations()
        {
            try
            {
                var confirmations = await _repository.Confirmed.GetAllConfirmedAsync(trackChanges: false);
                return Ok(confirmations);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetConfirmation(int id)
        {
            try
            {
                var confirmation = await _repository.Confirmed.GetConfirmedByIdAsync(id, trackChanges: false);
                if (confirmation == null)
                {
                    return NotFound($"Confirmation with ID {id} not found");
                }
                return Ok(confirmation);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateConfirmation([FromBody] ConfirmedCreateDto confirmationDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var confirmation = new Confirmed
                {
                    OrganizerId = confirmationDto.OrganizerId,
                    Date = DateTime.UtcNow
                };

                _repository.Confirmed.CreateConfirmed(confirmation);
                await _repository.SaveAsync();

                return CreatedAtAction(nameof(GetConfirmation), new { id = confirmation.ConfirmationId }, confirmation);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateConfirmation(int id, [FromBody] ConfirmedCreateDto confirmationDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var confirmation = await _repository.Confirmed.GetConfirmedByIdAsync(id, trackChanges: true);
                if (confirmation == null)
                {
                    return NotFound($"Confirmation with ID {id} not found");
                }

                confirmation.OrganizerId = confirmationDto.OrganizerId;
                _repository.Confirmed.UpdateConfirmed(confirmation);
                await _repository.SaveAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConfirmation(int id)
        {
            try
            {
                var confirmation = await _repository.Confirmed.GetConfirmedByIdAsync(id, trackChanges: true);
                if (confirmation == null)
                {
                    return NotFound($"Confirmation with ID {id} not found");
                }

                _repository.Confirmed.DeleteConfirmed(confirmation);
                await _repository.SaveAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
} 