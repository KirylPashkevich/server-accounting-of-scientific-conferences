using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using server.Models;

namespace server.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
                new User
                {
                    Id = 1,
                    FirstName = "Администратор",
                    LastName = "Системы",
                    MiddleName = "Администраторович",
                    Position = "Администратор",
                    Organization = "Система",
                    Address = "Адрес администратора",
                    PhoneNumber = "+375291234567",
                    Email = "admin@example.com",
                    PasswordHash = "AQAAAAEAACcQAAAAELbGq7cGxQZQZQZQZQZQZQZQZQZQZQZQZQZQZQZQZQZQZQZQZQZQZQZQZQZQ==", // Хеш для пароля "Admin123!"
                    Role = "Admin", // Роль администратора
                    CreatedAt = DateTime.UtcNow
                },
                new User
                {
                    Id = 2,
                    FirstName = "Тестовый",
                    LastName = "Пользователь",
                    MiddleName = "Тестович",
                    Position = "Тестировщик",
                    Organization = "Тестовая организация",
                    Address = "Тестовый адрес",
                    PhoneNumber = "+375297654321",
                    Email = "test@example.com",
                    PasswordHash = "AQAAAAEAACcQAAAAELbGq7cGxQZQZQZQZQZQZQZQZQZQZQZQZQZQZQZQZQZQZQZQZQZQZQZQZQZQ==", // Хеш для пароля "Test123!"
                    Role = "User", // Роль обычного пользователя
                    CreatedAt = DateTime.UtcNow
                }
            );
        }
    }
} 