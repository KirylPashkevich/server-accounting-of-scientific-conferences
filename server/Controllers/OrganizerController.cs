using Microsoft.AspNetCore.Mvc;
using server.Models;
using server.Repository;

namespace server.Controllers
{
    /// <summary>
    /// Контроллер для управления организаторами конференций
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class OrganizerController : ControllerBase
    {
        private readonly IOrganizerRepository _repository;

        public OrganizerController(IOrganizerRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Получает список всех организаторов
        /// </summary>
        /// <returns>Коллекция организаторов</returns>
        /// <response code="200">Возвращает список организаторов</response>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Organizer>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetOrganizers()
        {
            var organizers = await _repository.GetAllOrganizersAsync(trackChanges: false);
            return Ok(organizers);
        }

        /// <summary>
        /// Получает организатора по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор организатора</param>
        /// <returns>Информация об организаторе</returns>
        /// <response code="200">Организатор найден</response>
        /// <response code="404">Организатор не найден</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Organizer), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetOrganizer(int id)
        {
            var organizer = await _repository.GetOrganizerByIdAsync(id, trackChanges: false);
            if (organizer == null)
                return NotFound();

            return Ok(organizer);
        }

        /// <summary>
        /// Создает нового организатора
        /// </summary>
        /// <param name="organizer">Данные организатора</param>
        /// <returns>Созданный организатор</returns>
        /// <response code="201">Организатор успешно создан</response>
        /// <response code="400">Некорректные данные</response>
        [HttpPost]
        [ProducesResponseType(typeof(Organizer), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateOrganizer([FromBody] Organizer organizer)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _repository.CreateOrganizer(organizer);
            await _repository.SaveAsync();
            return CreatedAtAction(nameof(GetOrganizer), new { id = organizer.OrganizerId }, organizer);
        }

        /// <summary>
        /// Обновляет данные организатора
        /// </summary>
        /// <param name="id">Идентификатор организатора</param>
        /// <param name="organizer">Обновленные данные организатора</param>
        /// <returns>Результат операции</returns>
        /// <response code="204">Данные успешно обновлены</response>
        /// <response code="400">Некорректные данные</response>
        /// <response code="404">Организатор не найден</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateOrganizer(int id, [FromBody] Organizer organizer)
        {
            if (id != organizer.OrganizerId)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingOrganizer = await _repository.GetOrganizerByIdAsync(id, trackChanges: true);
            if (existingOrganizer == null)
                return NotFound();

            _repository.UpdateOrganizer(organizer);
            await _repository.SaveAsync();
            return NoContent();
        }

        /// <summary>
        /// Удаляет организатора
        /// </summary>
        /// <param name="id">Идентификатор организатора</param>
        /// <returns>Результат операции</returns>
        /// <response code="204">Организатор успешно удален</response>
        /// <response code="404">Организатор не найден</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteOrganizer(int id)
        {
            var organizer = await _repository.GetOrganizerByIdAsync(id, trackChanges: false);
            if (organizer == null)
                return NotFound();

            _repository.DeleteOrganizer(organizer);
            await _repository.SaveAsync();
            return NoContent();
        }
    }
} 