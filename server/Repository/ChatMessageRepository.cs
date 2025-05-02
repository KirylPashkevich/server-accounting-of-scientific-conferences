using Microsoft.EntityFrameworkCore;
using server.Models;

namespace server.Repository
{
    public class ChatMessageRepository : RepositoryBase<ChatMessage>, IChatMessageRepository
    {
        public ChatMessageRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<ChatMessage>> GetAllMessagesAsync(bool trackChanges) =>
            await FindAll(trackChanges)
                .OrderBy(m => m.Time)
                .ToListAsync();

        public async Task<ChatMessage> GetMessageByIdAsync(int messageId, bool trackChanges) =>
            await FindByCondition(m => m.MessageId.Equals(messageId), trackChanges)
                .SingleOrDefaultAsync();

        public void CreateMessage(ChatMessage message) => Create(message);

        public void DeleteMessage(ChatMessage message) => Delete(message);
    }
} 