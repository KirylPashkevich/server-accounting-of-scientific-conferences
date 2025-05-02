using System.ComponentModel.DataAnnotations;

namespace server.Models
{
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }

        [Required(ErrorMessage = "Имя автора обязательно")]
        [StringLength(50, ErrorMessage = "Имя не может быть длиннее 50 символов")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Фамилия автора обязательна")]
        [StringLength(50, ErrorMessage = "Фамилия не может быть длиннее 50 символов")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Название организации обязательно")]
        [StringLength(100, ErrorMessage = "Название организации не может быть длиннее 100 символов")]
        public string Organization { get; set; }

        public ICollection<Report> Reports { get; set; }
    }
} 