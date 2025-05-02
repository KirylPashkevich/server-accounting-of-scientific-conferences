using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace server.Models
{
    public class Conference
    {
        [Key]
        public int ConferenceId { get; set; }

        [Required(ErrorMessage = "Название конференции обязательно")]
        [StringLength(100, ErrorMessage = "Название не может быть длиннее 100 символов")]
        public string Name { get; set; }

        [Required(ErrorMessage = "ID локации обязателен")]
        public int LocationId { get; set; }

        [Required(ErrorMessage = "ID организатора обязателен")]
        public int OrganizerId { get; set; }

        [Required(ErrorMessage = "ID доклада обязателен")]
        public int ReportId { get; set; }

        [Required(ErrorMessage = "ID спонсора обязателен")]
        public int SponsorId { get; set; }

        public ICollection<Spectator> Spectators { get; set; }
        public ICollection<ChatMessage> ChatMessages { get; set; }

        [ForeignKey("LocationId")]
        public Location Location { get; set; }

        [ForeignKey("OrganizerId")]
        public Organizer Organizer { get; set; }

        [ForeignKey("ReportId")]
        public Report Report { get; set; }

        [ForeignKey("SponsorId")]
        public Sponsor Sponsor { get; set; }
    }
} 