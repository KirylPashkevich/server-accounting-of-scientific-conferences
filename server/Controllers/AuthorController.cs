using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.Models;
using server.Models.DTOs;
using server.Repository;

namespace server.Controllers
{
    /// <summary>
    /// Контроллер для управления авторами докладов
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorController : ControllerBase
    {
        private readonly IRepositoryManager _repository;

        public AuthorController(IRepositoryManager repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Получает список всех авторов
        /// </summary>
        /// <returns>Коллекция авторов</returns>
        /// <response code="200">Возвращает список авторов</response>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Author>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAuthors()
        {
            var authors = await _repository.Author.GetAllAuthorsAsync(trackChanges: false);
            return Ok(authors);
        }

        /// <summary>
        /// Получает автора по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор автора</param>
        /// <returns>Информация об авторе</returns>
        /// <response code="200">Автор найден</response>
        /// <response code="404">Автор не найден</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Author), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAuthor(int id)
        {
            var author = await _repository.Author.GetAuthorByIdAsync(id, trackChanges: false);
            if (author == null)
                return NotFound($"Автор с ID {id} не найден");

            return Ok(author);
        }

        /// <summary>
        /// Создает нового автора
        /// </summary>
        /// <param name="author">Данные автора</param>
        /// <returns>Созданный автор</returns>
        /// <response code="201">Автор успешно создан</response>
        /// <response code="400">Некорректные данные</response>
        [HttpPost]
        [ProducesResponseType(typeof(Author), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateAuthor([FromBody] Author author)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _repository.Author.CreateAuthor(author);
            await _repository.SaveAsync();
            return CreatedAtAction(nameof(GetAuthor), new { id = author.AuthorId }, author);
        }

        /// <summary>
        /// Обновляет данные автора
        /// </summary>
        /// <param name="id">Идентификатор автора</param>
        /// <param name="authorDto">Новые данные автора</param>
        /// <returns>Обновленный автор</returns>
        /// <response code="200">Автор успешно обновлен</response>
        /// <response code="400">Некорректные данные</response>
        /// <response code="404">Автор не найден</response>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Author), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateAuthor(int id, [FromBody] AuthorUpdateDto authorDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var author = await _repository.Author.GetAuthorByIdAsync(id, trackChanges: true);
            if (author == null)
                return NotFound($"Автор с ID {id} не найден");

            author.Name = authorDto.Name;
            author.Surname = authorDto.Surname;
            author.Organization = authorDto.Organization;

            await _repository.SaveAsync();
            return Ok(author);
        }

        /// <summary>
        /// Удаляет автора
        /// </summary>
        /// <param name="id">Идентификатор автора</param>
        /// <returns>Результат операции</returns>
        /// <response code="204">Автор успешно удален</response>
        /// <response code="404">Автор не найден</response>
        /// <response code="400">Невозможно удалить автора, так как у него есть связанные доклады</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            var author = await _repository.Author.GetAuthorByIdAsync(id, trackChanges: true);
            if (author == null)
                return NotFound($"Автор с ID {id} не найден");

            // Проверяем наличие связанных докладов
            if (author.Reports != null && author.Reports.Any())
            {
                return BadRequest("Невозможно удалить автора, так как у него есть связанные доклады. Сначала удалите или измените связанные доклады.");
            }

            _repository.Author.DeleteAuthor(author);
            await _repository.SaveAsync();
            return NoContent();
        }
    }
} 