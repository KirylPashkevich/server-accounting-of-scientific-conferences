using System.ComponentModel.DataAnnotations;

namespace server.Models
{
    public class Organizer
    {
        [Key]
        public int OrganizerId { get; set; }

        [Required(ErrorMessage = "Имя организатора обязательно")]
        [StringLength(50, ErrorMessage = "Имя не может быть длиннее 50 символов")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Фамилия организатора обязательна")]
        [StringLength(50, ErrorMessage = "Фамилия не может быть длиннее 50 символов")]
        public string Surname { get; set; }

        public ICollection<Conference> Conferences { get; set; }
    }
} 