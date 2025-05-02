using Microsoft.AspNetCore.Mvc;
using server.Models;
using server.Repository;

namespace server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConferenceController : ControllerBase
    {
        private readonly IRepositoryManager _repository;

        public ConferenceController(IRepositoryManager repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllConferences()
        {
            try
            {
                var conferences = await _repository.Conference.GetAllConferencesAsync(trackChanges: false);
                return Ok(conferences);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetConferenceById(int id)
        {
            try
            {
                var conference = await _repository.Conference.GetConferenceByIdAsync(id, trackChanges: false);
                if (conference == null)
                {
                    return NotFound($"Conference with id: {id} doesn't exist in the database.");
                }

                return Ok(conference);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("location/{locationId}")]
        public async Task<IActionResult> GetConferencesByLocation(int locationId)
        {
            try
            {
                var conferences = await _repository.Conference.GetConferencesByLocationAsync(locationId, trackChanges: false);
                return Ok(conferences);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("organizer/{organizerId}")]
        public async Task<IActionResult> GetConferencesByOrganizer(int organizerId)
        {
            try
            {
                var conferences = await _repository.Conference.GetConferencesByOrganizerAsync(organizerId, trackChanges: false);
                return Ok(conferences);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateConference([FromBody] Conference conference)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                _repository.Conference.CreateConference(conference);
                await _repository.SaveAsync();

                return CreatedAtAction(nameof(GetConferenceById), 
                    new { id = conference.ConferenceId }, 
                    conference);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Удаляет конференцию
        /// </summary>
        /// <param name="id">Идентификатор конференции</param>
        /// <returns>Результат операции</returns>
        /// <response code="204">Конференция успешно удалена</response>
        /// <response code="404">Конференция не найдена</response>
        /// <response code="500">Внутренняя ошибка сервера</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteConference(int id)
        {
            try
            {
                var conference = await _repository.Conference.GetConferenceByIdAsync(id, trackChanges: false);
                if (conference == null)
                {
                    return NotFound($"Конференция с id: {id} не найдена в базе данных.");
                }

                _repository.Conference.DeleteConference(conference);
                await _repository.SaveAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Обновляет данные конференции
        /// </summary>
        /// <param name="id">Идентификатор конференции</param>
        /// <param name="conference">Обновленные данные конференции</param>
        /// <returns>Результат операции</returns>
        /// <response code="204">Данные успешно обновлены</response>
        /// <response code="400">Некорректные данные</response>
        /// <response code="404">Конференция не найдена</response>
        /// <response code="500">Внутренняя ошибка сервера</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateConference(int id, [FromBody] Conference conference)
        {
            try
            {
                if (id != conference.ConferenceId)
                {
                    return BadRequest("ID в URL не соответствует ID в теле запроса");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var existingConference = await _repository.Conference.GetConferenceByIdAsync(id, trackChanges: false);
                if (existingConference == null)
                {
                    return NotFound($"Конференция с id: {id} не найдена в базе данных.");
                }

                // Проверка существования связанных сущностей
                var location = await _repository.Location.GetLocationByIdAsync(conference.LocationId, trackChanges: false);
                if (location == null)
                {
                    return BadRequest($"Локация с id: {conference.LocationId} не найдена в базе данных.");
                }

                var organizer = await _repository.Organizer.GetOrganizerByIdAsync(conference.OrganizerId, trackChanges: false);
                if (organizer == null)
                {
                    return BadRequest($"Организатор с id: {conference.OrganizerId} не найден в базе данных.");
                }

                var report = await _repository.Report.GetReportByIdAsync(conference.ReportId, trackChanges: false);
                if (report == null)
                {
                    return BadRequest($"Отчет с id: {conference.ReportId} не найден в базе данных.");
                }

                _repository.Conference.UpdateConference(conference);
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