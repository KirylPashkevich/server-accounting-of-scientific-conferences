using System.ComponentModel.DataAnnotations;

namespace server.Models.DTOs
{
    public class ChatMessageCreateDto
    {
        [Required(ErrorMessage = "Текст сообщения обязателен")]
        [StringLength(500, ErrorMessage = "Сообщение не может быть длиннее 500 символов")]
        public string Message { get; set; }

        [Required(ErrorMessage = "ID пользователя обязателен")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "ID конференции обязателен")]
        public int ConferenceId { get; set; }
    }
} 