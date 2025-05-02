using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using server.Models;

namespace server.Repository.Configuration
{
    public class OrganizerConfiguration : IEntityTypeConfiguration<Organizer>
    {
        public void Configure(EntityTypeBuilder<Organizer> builder)
        {
            builder.HasData
            (
                new Organizer
                {
                    OrganizerId = 1,
                    Name = "Александр",
                    Surname = "Иванов"
                },
                new Organizer
                {
                    OrganizerId = 2,
                    Name = "Елена",
                    Surname = "Петрова"
                },
                new Organizer
                {
                    OrganizerId = 3,
                    Name = "Михаил",
                    Surname = "Сидоров"
                },
                new Organizer
                {
                    OrganizerId = 4,
                    Name = "Анна",
                    Surname = "Козлова"
                },
                new Organizer
                {
                    OrganizerId = 5,
                    Name = "Дмитрий",
                    Surname = "Новиков"
                }
            );
        }
    }
} 