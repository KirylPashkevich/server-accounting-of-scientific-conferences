using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using server.Models;

namespace server.Repository.Configuration
{
    public class SponsorConfiguration : IEntityTypeConfiguration<Sponsor>
    {
        public void Configure(EntityTypeBuilder<Sponsor> builder)
        {
            builder.HasData
            (
                new Sponsor
                {
                    SponsorId = 1,
                    Organization = "Microsoft Belarus",
                    ContactPerson = "Иван Иванов",
                    Email = "microsoft.by@microsoft.com",
                    Phone = "+375291234567",
                    Amount = 10000
                },
                new Sponsor
                {
                    SponsorId = 2,
                    Organization = "EPAM Systems",
                    ContactPerson = "Петр Петров",
                    Email = "epam.by@epam.com",
                    Phone = "+375292345678",
                    Amount = 15000
                },
                new Sponsor
                {
                    SponsorId = 3,
                    Organization = "IBA Group",
                    ContactPerson = "Алексей Алексеев",
                    Email = "iba.by@iba.com",
                    Phone = "+375293456789",
                    Amount = 12000
                },
                new Sponsor
                {
                    SponsorId = 4,
                    Organization = "Wargaming",
                    ContactPerson = "Сергей Сергеев",
                    Email = "wargaming.by@wargaming.com",
                    Phone = "+375294567890",
                    Amount = 20000
                },
                new Sponsor
                {
                    SponsorId = 5,
                    Organization = "iTechArt Group",
                    ContactPerson = "Дмитрий Дмитриев",
                    Email = "itechart.by@itechart.com",
                    Phone = "+375295678901",
                    Amount = 18000
                }
            );
        }
    }
} 