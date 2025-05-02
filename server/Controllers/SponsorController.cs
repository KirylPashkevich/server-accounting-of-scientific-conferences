using Microsoft.AspNetCore.Mvc;
using server.Models;
using server.Models.DTOs;
using server.Service;
using server.Repository;

namespace server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SponsorController : ControllerBase
    {
        private readonly ISponsorService _sponsorService;

        public SponsorController(ISponsorService sponsorService)
        {
            _sponsorService = sponsorService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sponsor>>> GetSponsors()
        {
            try
            {
                var sponsors = await _sponsorService.GetAllSponsorsAsync();
                return Ok(sponsors);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Sponsor>> GetSponsor(int id)
        {
            try
            {
                var sponsor = await _sponsorService.GetSponsorByIdAsync(id);
                if (sponsor == null)
                {
                    return NotFound($"Sponsor with ID {id} not found");
                }
                return Ok(sponsor);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Создает нового спонсора
        /// </summary>
        /// <param name="sponsorDto">Данные нового спонсора</param>
        /// <returns>Созданный спонсор</returns>
        /// <response code="201">Спонсор успешно создан</response>
        /// <response code="400">Некорректные данные</response>
        [HttpPost]
        [ProducesResponseType(typeof(Sponsor), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Sponsor>> CreateSponsor([FromBody] SponsorCreateDto sponsorDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var createdSponsor = await _sponsorService.CreateSponsorAsync(sponsorDto);
                return CreatedAtAction(nameof(GetSponsor), new { id = createdSponsor.SponsorId }, createdSponsor);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Внутренняя ошибка сервера: {ex.Message}");
            }
        }

        /// <summary>
        /// Обновляет данные спонсора
        /// </summary>
        /// <param name="id">Идентификатор спонсора</param>
        /// <param name="sponsorDto">Обновленные данные спонсора</param>
        /// <returns>Результат операции</returns>
        /// <response code="204">Данные успешно обновлены</response>
        /// <response code="400">Некорректные данные</response>
        /// <response code="404">Спонсор не найден</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateSponsor(int id, [FromBody] SponsorUpdateDto sponsorDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                await _sponsorService.UpdateSponsorAsync(id, sponsorDto);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound($"Спонсор с ID {id} не найден");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Внутренняя ошибка сервера: {ex.Message}");
            }
        }

        /// <summary>
        /// Удаляет спонсора
        /// </summary>
        /// <param name="id">Идентификатор спонсора</param>
        /// <returns>Результат операции</returns>
        /// <response code="204">Спонсор успешно удален</response>
        /// <response code="404">Спонсор не найден</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteSponsor(int id)
        {
            try
            {
                await _sponsorService.DeleteSponsorAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound($"Спонсор с ID {id} не найден");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Внутренняя ошибка сервера: {ex.Message}");
            }
        }
    }
} 