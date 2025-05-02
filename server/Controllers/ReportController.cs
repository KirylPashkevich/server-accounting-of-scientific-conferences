using Microsoft.AspNetCore.Mvc;
using server.Models;
using server.Repository;

namespace server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportController : ControllerBase
    {
        private readonly IRepositoryManager _repository;

        public ReportController(IRepositoryManager repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllReports()
        {
            try
            {
                var reports = await _repository.Report.GetAllReportsAsync(trackChanges: false);
                return Ok(reports);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReportById(int id)
        {
            try
            {
                var report = await _repository.Report.GetReportByIdAsync(id, trackChanges: false);
                if (report == null)
                {
                    return NotFound($"Report with id: {id} doesn't exist in the database.");
                }

                return Ok(report);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Создает новый отчет
        /// </summary>
        /// <param name="report">Данные отчета</param>
        /// <returns>Созданный отчет</returns>
        /// <response code="201">Отчет успешно создан</response>
        /// <response code="400">Некорректные данные</response>
        [HttpPost]
        [ProducesResponseType(typeof(Report), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateReport([FromBody] Report report)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                _repository.Report.CreateReport(report);
                await _repository.SaveAsync();

                return CreatedAtAction(nameof(GetReportById), 
                    new { id = report.ReportId }, 
                    report);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Удаляет отчет
        /// </summary>
        /// <param name="id">Идентификатор отчета</param>
        /// <returns>Результат операции</returns>
        /// <response code="204">Отчет успешно удален</response>
        /// <response code="404">Отчет не найден</response>
        /// <response code="500">Внутренняя ошибка сервера</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteReport(int id)
        {
            try
            {
                var report = await _repository.Report.GetReportByIdAsync(id, trackChanges: false);
                if (report == null)
                {
                    return NotFound($"Отчет с id: {id} не найден в базе данных.");
                }

                _repository.Report.DeleteReport(report);
                await _repository.SaveAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Обновляет отчет
        /// </summary>
        /// <param name="id">Идентификатор отчета</param>
        /// <param name="report">Обновленные данные отчета</param>
        /// <returns>Результат операции</returns>
        /// <response code="204">Отчет успешно обновлен</response>
        /// <response code="400">Некорректные данные</response>
        /// <response code="404">Отчет не найден</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateReport(int id, [FromBody] Report report)
        {
            try
            {
                if (id != report.ReportId)
                {
                    return BadRequest("ID в URL не соответствует ID в теле запроса");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var existingReport = await _repository.Report.GetReportByIdAsync(id, trackChanges: false);
                if (existingReport == null)
                {
                    return NotFound($"Отчет с id: {id} не найден в базе данных.");
                }

                // Проверка существования связанных сущностей
                var author = await _repository.Author.GetAuthorByIdAsync(report.AuthorId, trackChanges: false);
                if (author == null)
                {
                    return BadRequest($"Автор с id: {report.AuthorId} не найден в базе данных.");
                }

                var confirmed = await _repository.Confirmed.GetConfirmedByIdAsync(report.ConfirmationId, trackChanges: false);
                if (confirmed == null)
                {
                    return BadRequest($"Подтверждение с id: {report.ConfirmationId} не найдено в базе данных.");
                }

                _repository.Report.UpdateReport(report);
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