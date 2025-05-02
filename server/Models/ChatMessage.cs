using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace server.Models
{
    public class ChatMessage
    {
        [Key]
        public int MessageId { get; set; }

        [Required(ErrorMessage = "Текст сообщения обязателен")]
        [StringLength(500, ErrorMessage = "Сообщение не может быть длиннее 500 символов")]
        public string Message { get; set; }

        [Required(ErrorMessage = "Время сообщения обязательно")]
        public DateTime Time { get; set; }

        [Required(ErrorMessage = "ID пользователя обязателен")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "ID конференции обязателен")]
        public int ConferenceId { get; set; }

        [ForeignKey("ConferenceId")]
        public Conference Conference { get; set; }
    }
} 