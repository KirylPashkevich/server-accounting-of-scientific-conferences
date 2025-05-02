using server.Models;

namespace server.Repository
{
    public interface IOrganizerRepository : IRepositoryBase<Organizer>
    {
        Task<IEnumerable<Organizer>> GetAllOrganizersAsync(bool trackChanges);
        Task<Organizer> GetOrganizerByIdAsync(int id, bool trackChanges);
        void CreateOrganizer(Organizer organizer);
        void UpdateOrganizer(Organizer organizer);
        void DeleteOrganizer(Organizer organizer);
        Task SaveAsync();
    }
} 