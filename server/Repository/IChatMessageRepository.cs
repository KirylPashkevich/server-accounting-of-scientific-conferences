using server.Models;

namespace server.Repository
{
    public interface IChatMessageRepository : IRepositoryBase<ChatMessage>
    {
        Task<IEnumerable<ChatMessage>> GetAllMessagesAsync(bool trackChanges);
        Task<ChatMessage> GetMessageByIdAsync(int messageId, bool trackChanges);
        void CreateMessage(ChatMessage message);
        void DeleteMessage(ChatMessage message);
    }
} 