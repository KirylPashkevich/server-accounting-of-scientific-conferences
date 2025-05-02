using server.Models;

namespace server.Repository
{
    public interface ISpectatorRepository : IRepositoryBase<Spectator>
    {
        Task<IEnumerable<Spectator>> GetAllSpectatorsAsync(bool trackChanges);
        Task<Spectator> GetSpectatorByIdAsync(int id, bool trackChanges);
        void CreateSpectator(Spectator spectator);
        void UpdateSpectator(Spectator spectator);
        void DeleteSpectator(Spectator spectator);
    }
} 