using System.ComponentModel.DataAnnotations;

namespace server.Models.DTOs
{
    public class UserLoginDto
    {
        [Required(ErrorMessage = "Email обязателен для заполнения")]
        [EmailAddress(ErrorMessage = "Некорректный формат email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Пароль обязателен для заполнения")]
        public string Password { get; set; }
    }
} 