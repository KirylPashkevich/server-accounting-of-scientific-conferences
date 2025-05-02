using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace server.Models
{
    public class Report
    {
        [Key]
        public int ReportId { get; set; }

        [Required(ErrorMessage = "Описание доклада обязательно")]
        [StringLength(1000, ErrorMessage = "Описание не может быть длиннее 1000 символов")]
        public string Description { get; set; }

        [Required(ErrorMessage = "ID автора обязателен")]
        public int AuthorId { get; set; }

        [Required(ErrorMessage = "ID подтверждения обязателен")]
        public int ConfirmationId { get; set; }

        [ForeignKey("AuthorId")]
        public Author Author { get; set; }

        [ForeignKey("ConfirmationId")]
        public Confirmed Confirmed { get; set; }

        public ICollection<Conference> Conferences { get; set; }
    }
} 