using System.ComponentModel.DataAnnotations;

namespace server.Models
{
    public class Location
    {
        [Key]
        public int LocationId { get; set; }

        [Required(ErrorMessage = "Название локации обязательно")]
        [StringLength(100, ErrorMessage = "Название не может быть длиннее 100 символов")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Адрес обязателен")]
        [StringLength(200, ErrorMessage = "Адрес не может быть длиннее 200 символов")]
        public string Address { get; set; }

        public ICollection<Conference> Conferences { get; set; }
    }
} 