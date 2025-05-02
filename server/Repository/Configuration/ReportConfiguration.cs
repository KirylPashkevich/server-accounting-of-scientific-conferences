using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using server.Models;

namespace server.Repository.Configuration
{
    public class ReportConfiguration : IEntityTypeConfiguration<Report>
    {
        public void Configure(EntityTypeBuilder<Report> builder)
        {
            builder.HasData
            (
                new Report
                {
                    ReportId = 1,
                    Description = "Будущее мессенджеров и приватности",
                    AuthorId = 1,
                    ConfirmationId = 1
                },
                new Report
                {
                    ReportId = 2,
                    Description = "Метавселенная: новая эра интернета",
                    AuthorId = 2,
                    ConfirmationId = 2
                },
                new Report
                {
                    ReportId = 3,
                    Description = "Облачные технологии в 2024",
                    AuthorId = 3,
                    ConfirmationId = 3
                },
                new Report
                {
                    ReportId = 4,
                    Description = "Искусственный интеллект в поиске",
                    AuthorId = 4,
                    ConfirmationId = 4
                },
                new Report
                {
                    ReportId = 5,
                    Description = "Экосистема Apple и приватность",
                    AuthorId = 5,
                    ConfirmationId = 5
                }
            );
        }
    }
} 