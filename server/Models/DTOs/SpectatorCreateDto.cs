using System.ComponentModel.DataAnnotations;

namespace server.Models.DTOs
{
    public class SpectatorCreateDto
    {
        [Required(ErrorMessage = "ID конференции обязателен")]
        public int ConferenceId { get; set; }

        [Required(ErrorMessage = "Количество зрителей обязательно")]
        [Range(1, int.MaxValue, ErrorMessage = "Количество зрителей должно быть больше 0")]
        public int NumberOfSpectators { get; set; }
    }
} 