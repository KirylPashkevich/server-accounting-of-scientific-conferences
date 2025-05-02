namespace server.Models.DTOs
{
    public class SponsorCreateDto
    {
        public string Organization { get; set; }
        public string ContactPerson { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public decimal Amount { get; set; }
    }

    public class SponsorUpdateDto
    {
        public string Organization { get; set; }
        public string ContactPerson { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public decimal Amount { get; set; }
    }
} 