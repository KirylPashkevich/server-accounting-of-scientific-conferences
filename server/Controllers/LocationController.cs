using Microsoft.AspNetCore.Mvc;
using server.Models;
using server.Repository;

namespace server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LocationController : ControllerBase
    {
        private readonly IRepositoryManager _repository;

        public LocationController(IRepositoryManager repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLocations()
        {
            try
            {
                var locations = await _repository.Location.GetAllLocationsAsync(trackChanges: false);
                return Ok(locations);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLocationById(int id)
        {
            try
            {
                var location = await _repository.Location.GetLocationByIdAsync(id, trackChanges: false);
                if (location == null)
                {
                    return NotFound($"Location with id: {id} doesn't exist in the database.");
                }

                return Ok(location);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Создает новую локацию
        /// </summary>
        /// <param name="location">Данные локации</param>
        /// <returns>Созданная локация</returns>
        /// <response code="201">Локация успешно создана</response>
        /// <response code="400">Некорректные данные</response>
        [HttpPost]
        [ProducesResponseType(typeof(Location), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateLocation([FromBody] Location location)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                _repository.Location.CreateLocation(location);
                await _repository.SaveAsync();

                return CreatedAtAction(nameof(GetLocationById), 
                    new { id = location.LocationId }, 
                    location);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Удаляет локацию
        /// </summary>
        /// <param name="id">Идентификатор локации</param>
        /// <returns>Результат операции</returns>
        /// <response code="204">Локация успешно удалена</response>
        /// <response code="404">Локация не найдена</response>
        /// <response code="500">Внутренняя ошибка сервера</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteLocation(int id)
        {
            try
            {
                var location = await _repository.Location.GetLocationByIdAsync(id, trackChanges: false);
                if (location == null)
                {
                    return NotFound($"Локация с id: {id} не найдена в базе данных.");
                }

                _repository.Location.DeleteLocation(location);
                await _repository.SaveAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Обновляет данные локации
        /// </summary>
        /// <param name="id">Идентификатор локации</param>
        /// <param name="location">Обновленные данные локации</param>
        /// <returns>Результат операции</returns>
        /// <response code="204">Данные успешно обновлены</response>
        /// <response code="400">Некорректные данные</response>
        /// <response code="404">Локация не найдена</response>
        /// <response code="500">Внутренняя ошибка сервера</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateLocation(int id, [FromBody] Location location)
        {
            try
            {
                if (id != location.LocationId)
                {
                    return BadRequest("ID в URL не соответствует ID в теле запроса");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var existingLocation = await _repository.Location.GetLocationByIdAsync(id, trackChanges: false);
                if (existingLocation == null)
                {
                    return NotFound($"Локация с id: {id} не найдена в базе данных.");
                }

                _repository.Location.UpdateLocation(location);
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