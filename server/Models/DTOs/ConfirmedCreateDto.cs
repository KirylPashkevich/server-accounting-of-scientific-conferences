using System.ComponentModel.DataAnnotations;

namespace server.Models.DTOs
{
    public class ConfirmedCreateDto
    {
        [Required(ErrorMessage = "ID организатора обязателен")]
        public int OrganizerId { get; set; }
    }
} 