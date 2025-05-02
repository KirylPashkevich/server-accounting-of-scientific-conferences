using Microsoft.AspNetCore.Mvc;
using server.Models;
using server.Models.DTOs;
using server.Repository;

namespace server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SpectatorController : ControllerBase
    {
        private readonly IRepositoryManager _repository;

        public SpectatorController(IRepositoryManager repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetSpectators()
        {
            try
            {
                var spectators = await _repository.Spectator.GetAllSpectatorsAsync(trackChanges: false);
                return Ok(spectators);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSpectator(int id)
        {
            try
            {
                var spectator = await _repository.Spectator.GetSpectatorByIdAsync(id, trackChanges: false);
                if (spectator == null)
                {
                    return NotFound($"Spectator with ID {id} not found");
                }
                return Ok(spectator);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateSpectator([FromBody] SpectatorCreateDto spectatorDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var spectator = new Spectator
                {
                    ConferenceId = spectatorDto.ConferenceId,
                    NumberOfSpectators = spectatorDto.NumberOfSpectators
                };

                _repository.Spectator.CreateSpectator(spectator);
                await _repository.SaveAsync();

                return CreatedAtAction(nameof(GetSpectator), new { id = spectator.SpectatorId }, spectator);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSpectator(int id, [FromBody] SpectatorCreateDto spectatorDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var spectator = await _repository.Spectator.GetSpectatorByIdAsync(id, trackChanges: true);
                if (spectator == null)
                {
                    return NotFound($"Spectator with ID {id} not found");
                }

                spectator.ConferenceId = spectatorDto.ConferenceId;
                spectator.NumberOfSpectators = spectatorDto.NumberOfSpectators;

                _repository.Spectator.UpdateSpectator(spectator);
                await _repository.SaveAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSpectator(int id)
        {
            try
            {
                var spectator = await _repository.Spectator.GetSpectatorByIdAsync(id, trackChanges: true);
                if (spectator == null)
                {
                    return NotFound($"Spectator with ID {id} not found");
                }

                _repository.Spectator.DeleteSpectator(spectator);
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