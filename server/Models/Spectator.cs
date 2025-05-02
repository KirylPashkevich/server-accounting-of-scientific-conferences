using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace server.Models
{
    public class Spectator
    {
        [Key]
        public int SpectatorId { get; set; }

        [Required(ErrorMessage = "ID конференции обязателен")]
        public int ConferenceId { get; set; }

        [Required(ErrorMessage = "Количество зрителей обязательно")]
        [Range(1, int.MaxValue, ErrorMessage = "Количество зрителей должно быть больше 0")]
        public int NumberOfSpectators { get; set; }

        [ForeignKey("ConferenceId")]
        public Conference Conference { get; set; }
    }
} 