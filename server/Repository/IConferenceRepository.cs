using server.Models;

namespace server.Repository
{
    public interface IConferenceRepository : IRepositoryBase<Conference>
    {
        Task<IEnumerable<Conference>> GetAllConferencesAsync(bool trackChanges);
        Task<Conference> GetConferenceByIdAsync(int id, bool trackChanges);
        Task<IEnumerable<Conference>> GetConferencesByLocationAsync(int locationId, bool trackChanges);
        Task<IEnumerable<Conference>> GetConferencesByOrganizerAsync(int organizerId, bool trackChanges);
        void CreateConference(Conference conference);
        void UpdateConference(Conference conference);
        void DeleteConference(Conference conference);
    }
} 