using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using server.Models;

namespace server.Repository.Configuration
{
    public class ChatMessageConfiguration : IEntityTypeConfiguration<ChatMessage>
    {
        public void Configure(EntityTypeBuilder<ChatMessage> builder)
        {
            builder.HasData
            (
                new ChatMessage
                {
                    MessageId = 1,
                    Message = "Когда начнется регистрация?",
                    Time = new DateTime(2024, 3, 1, 10, 0, 0),
                    UserId = 1,
                    ConferenceId = 1
                },
                new ChatMessage
                {
                    MessageId = 2,
                    Message = "Будет ли онлайн трансляция?",
                    Time = new DateTime(2024, 3, 2, 11, 0, 0),
                    UserId = 2,
                    ConferenceId = 2
                },
                new ChatMessage
                {
                    MessageId = 3,
                    Message = "Где можно получить материалы конференции?",
                    Time = new DateTime(2024, 3, 3, 12, 0, 0),
                    UserId = 3,
                    ConferenceId = 3
                },
                new ChatMessage
                {
                    MessageId = 4,
                    Message = "Какие темы будут обсуждаться?",
                    Time = new DateTime(2024, 3, 4, 13, 0, 0),
                    UserId = 4,
                    ConferenceId = 4
                },
                new ChatMessage
                {
                    MessageId = 5,
                    Message = "Нужна ли предварительная регистрация?",
                    Time = new DateTime(2024, 3, 5, 14, 0, 0),
                    UserId = 5,
                    ConferenceId = 5
                }
            );
        }
    }
} 