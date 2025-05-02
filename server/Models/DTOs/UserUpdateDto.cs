using System.ComponentModel.DataAnnotations;

namespace server.Models.DTOs
{
    public class UserUpdateDto
    {
        [Required(ErrorMessage = "Имя обязательно для заполнения")]
        [StringLength(50, ErrorMessage = "Имя не должно превышать 50 символов")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Фамилия обязательна для заполнения")]
        [StringLength(50, ErrorMessage = "Фамилия не должна превышать 50 символов")]
        public string LastName { get; set; }

        [StringLength(50, ErrorMessage = "Отчество не должно превышать 50 символов")]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Должность обязательна для заполнения")]
        [StringLength(100, ErrorMessage = "Должность не должна превышать 100 символов")]
        public string Position { get; set; }

        [Required(ErrorMessage = "Организация обязательна для заполнения")]
        [StringLength(200, ErrorMessage = "Название организации не должно превышать 200 символов")]
        public string Organization { get; set; }

        [Required(ErrorMessage = "Адрес обязателен для заполнения")]
        [StringLength(200, ErrorMessage = "Адрес не должен превышать 200 символов")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Номер телефона обязателен для заполнения")]
        [Phone(ErrorMessage = "Некорректный формат номера телефона")]
        [StringLength(20, ErrorMessage = "Номер телефона не должен превышать 20 символов")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email обязателен для заполнения")]
        [EmailAddress(ErrorMessage = "Некорректный формат email")]
        [StringLength(100, ErrorMessage = "Email не должен превышать 100 символов")]
        public string Email { get; set; }

        [StringLength(100, MinimumLength = 6, ErrorMessage = "Пароль должен содержать от 6 до 100 символов")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Роль обязательна для заполнения")]
        [StringLength(20, ErrorMessage = "Роль не должна превышать 20 символов")]
        public string Role { get; set; }
    }
} 