using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using server.Models;

namespace server.Repository.Configuration
{
    public class ConfirmedConfiguration : IEntityTypeConfiguration<Confirmed>
    {
        public void Configure(EntityTypeBuilder<Confirmed> builder)
        {
            builder.HasData
            (
                new Confirmed
                {
                    ConfirmationId = 1,
                    Date = new DateTime(2024, 3, 1),
                    OrganizerId = 1
                },
                new Confirmed
                {
                    ConfirmationId = 2,
                    Date = new DateTime(2024, 3, 2),
                    OrganizerId = 2
                },
                new Confirmed
                {
                    ConfirmationId = 3,
                    Date = new DateTime(2024, 3, 3),
                    OrganizerId = 3
                },
                new Confirmed
                {
                    ConfirmationId = 4,
                    Date = new DateTime(2024, 3, 4),
                    OrganizerId = 4
                },
                new Confirmed
                {
                    ConfirmationId = 5,
                    Date = new DateTime(2024, 3, 5),
                    OrganizerId = 5
                }
            );
        }
    }
} 