using server.Models;

namespace server.Repository
{
    public interface IConfirmedRepository : IRepositoryBase<Confirmed>
    {
        Task<IEnumerable<Confirmed>> GetAllConfirmedAsync(bool trackChanges);
        Task<Confirmed> GetConfirmedByIdAsync(int id, bool trackChanges);
        void CreateConfirmed(Confirmed confirmed);
        void UpdateConfirmed(Confirmed confirmed);
        void DeleteConfirmed(Confirmed confirmed);
    }
} 