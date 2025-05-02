using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace server.Models
{
    public class Confirmed
    {
        [Key]
        public int ConfirmationId { get; set; }

        [Required(ErrorMessage = "Дата подтверждения обязательна")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "ID организатора обязателен")]
        public int OrganizerId { get; set; }

        [ForeignKey("OrganizerId")]
        public Organizer Organizer { get; set; }

        public ICollection<Report> Reports { get; set; }
    }
} 