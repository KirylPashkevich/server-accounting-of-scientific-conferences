using Microsoft.EntityFrameworkCore;
using server.Models;

namespace server.Repository
{
    public class SpectatorRepository : RepositoryBase<Spectator>, ISpectatorRepository
    {
        public SpectatorRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<Spectator>> GetAllSpectatorsAsync(bool trackChanges) =>
            await FindAll(trackChanges)
                .Include(s => s.Conference)
                .ToListAsync();

        public async Task<Spectator> GetSpectatorByIdAsync(int id, bool trackChanges) =>
            await FindByCondition(s => s.SpectatorId.Equals(id), trackChanges)
                .Include(s => s.Conference)
                .SingleOrDefaultAsync();

        public void CreateSpectator(Spectator spectator) => Create(spectator);

        public void UpdateSpectator(Spectator spectator) => Update(spectator);

        public void DeleteSpectator(Spectator spectator) => Delete(spectator);
    }
} 