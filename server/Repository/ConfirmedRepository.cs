using Microsoft.EntityFrameworkCore;
using server.Models;

namespace server.Repository
{
    public class ConfirmedRepository : RepositoryBase<Confirmed>, IConfirmedRepository
    {
        public ConfirmedRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<Confirmed>> GetAllConfirmedAsync(bool trackChanges) =>
            await FindAll(trackChanges)
                .Include(c => c.Organizer)
                .OrderBy(c => c.Date)
                .ToListAsync();

        public async Task<Confirmed> GetConfirmedByIdAsync(int id, bool trackChanges) =>
            await FindByCondition(c => c.ConfirmationId.Equals(id), trackChanges)
                .Include(c => c.Organizer)
                .SingleOrDefaultAsync();

        public void CreateConfirmed(Confirmed confirmed) => Create(confirmed);

        public void UpdateConfirmed(Confirmed confirmed) => Update(confirmed);

        public void DeleteConfirmed(Confirmed confirmed) => Delete(confirmed);
    }
} 