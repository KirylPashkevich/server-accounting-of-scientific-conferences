using Microsoft.AspNetCore.Mvc;
using server.Models;
using server.Models.DTOs;
using server.Repository;

namespace server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChatMessageController : ControllerBase
    {
        private readonly IRepositoryManager _repository;

        public ChatMessageController(IRepositoryManager repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetMessages()
        {
            try
            {
                var messages = await _repository.ChatMessage.GetAllMessagesAsync(trackChanges: false);
                return Ok(messages);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMessage(int id)
        {
            try
            {
                var message = await _repository.ChatMessage.GetMessageByIdAsync(id, trackChanges: false);
                if (message == null)
                {
                    return NotFound($"Message with ID {id} not found");
                }
                return Ok(message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateMessage([FromBody] ChatMessageCreateDto messageDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var message = new ChatMessage
                {
                    Message = messageDto.Message,
                    UserId = messageDto.UserId,
                    ConferenceId = messageDto.ConferenceId,
                    Time = DateTime.UtcNow
                };

                _repository.ChatMessage.CreateMessage(message);
                await _repository.SaveAsync();

                return CreatedAtAction(nameof(GetMessages), new { id = message.MessageId }, message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMessage(int id)
        {
            try
            {
                var message = await _repository.ChatMessage.GetMessageByIdAsync(id, trackChanges: true);
                if (message == null)
                {
                    return NotFound($"Message with ID {id} not found");
                }

                _repository.ChatMessage.DeleteMessage(message);
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