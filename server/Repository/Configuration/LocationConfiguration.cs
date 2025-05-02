using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using server.Models;

namespace server.Repository.Configuration
{
    public class LocationConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.HasData
            (
                new Location
                {
                    LocationId = 1,
                    Name = "Конференц-зал 'Минск'",
                    Address = "ул. Ленина, 1, Минск"
                },
                new Location
                {
                    LocationId = 2,
                    Name = "Бизнес-центр 'Виктория'",
                    Address = "пр. Победителей, 7, Минск"
                },
                new Location
                {
                    LocationId = 3,
                    Name = "IT HUB 'Горизонт'",
                    Address = "ул. Притыцкого, 156, Минск"
                },
                new Location
                {
                    LocationId = 4,
                    Name = "Отель 'Беларусь'",
                    Address = "ул. Сторожевская, 15, Минск"
                },
                new Location
                {
                    LocationId = 5,
                    Name = "Технопарк",
                    Address = "пр. Независимости, 65, Минск"
                }
            );
        }
    }
} 