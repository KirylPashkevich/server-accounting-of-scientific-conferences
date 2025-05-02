using System.ComponentModel.DataAnnotations;

namespace server.Models
{
    public class Sponsor
    {
        [Key]
        public int SponsorId { get; set; }

        [Required(ErrorMessage = "Название организации обязательно")]
        [StringLength(100, ErrorMessage = "Название организации не может быть длиннее 100 символов")]
        public string Organization { get; set; }

        [Required(ErrorMessage = "Контактное лицо обязательно")]
        [StringLength(100, ErrorMessage = "Имя контактного лица не может быть длиннее 100 символов")]
        public string ContactPerson { get; set; }

        [Required(ErrorMessage = "Email обязателен")]
        [EmailAddress(ErrorMessage = "Некорректный формат email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Телефон обязателен")]
        [Phone(ErrorMessage = "Некорректный формат телефона")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Сумма спонсорства обязательна")]
        [Range(0, double.MaxValue, ErrorMessage = "Сумма спонсорства должна быть положительной")]
        public decimal Amount { get; set; }

        public ICollection<Conference> Conferences { get; set; }
    }
} 