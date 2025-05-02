using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using server.Models;

namespace server.Repository.Configuration
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasData
            (
                new Author
                {
                    AuthorId = 1,
                    Name = "Павел",
                    Surname = "Дуров",
                    Organization = "Telegram"
                },
                new Author
                {
                    AuthorId = 2,
                    Name = "Марк",
                    Surname = "Цукерберг",
                    Organization = "Meta"
                },
                new Author
                {
                    AuthorId = 3,
                    Name = "Сатья",
                    Surname = "Наделла",
                    Organization = "Microsoft"
                },
                new Author
                {
                    AuthorId = 4,
                    Name = "Сундар",
                    Surname = "Пичаи",
                    Organization = "Google"
                },
                new Author
                {
                    AuthorId = 5,
                    Name = "Тим",
                    Surname = "Кук",
                    Organization = "Apple"
                }
            );
        }
    }
} 