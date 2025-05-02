using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using server.Models;

namespace server.Repository.Configuration
{
    public class ConferenceConfiguration : IEntityTypeConfiguration<Conference>
    {
        public void Configure(EntityTypeBuilder<Conference> builder)
        {
            builder.HasData
            (
                new Conference
                {
                    ConferenceId = 1,
                    Name = "Telegram Conference 2024",
                    LocationId = 1,
                    OrganizerId = 1,
                    ReportId = 1,
                    SponsorId = 1
                },
                new Conference
                {
                    ConferenceId = 2,
                    Name = "Meta Connect Belarus",
                    LocationId = 2,
                    OrganizerId = 2,
                    ReportId = 2,
                    SponsorId = 2
                },
                new Conference
                {
                    ConferenceId = 3,
                    Name = "Microsoft Tech Summit",
                    LocationId = 3,
                    OrganizerId = 3,
                    ReportId = 3,
                    SponsorId = 3
                },
                new Conference
                {
                    ConferenceId = 4,
                    Name = "Google Cloud Next",
                    LocationId = 4,
                    OrganizerId = 4,
                    ReportId = 4,
                    SponsorId = 4
                },
                new Conference
                {
                    ConferenceId = 5,
                    Name = "Apple Developer Day",
                    LocationId = 5,
                    OrganizerId = 5,
                    ReportId = 5,
                    SponsorId = 5
                }
            );
        }
    }
} 