using Microsoft.EntityFrameworkCore;
using server.Models;

namespace server.Repository
{
    public class ConferenceRepository : RepositoryBase<Conference>, IConferenceRepository
    {
        public ConferenceRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<Conference>> GetAllConferencesAsync(bool trackChanges) =>
            await FindAll(trackChanges)
                .Include(c => c.Location)
                .Include(c => c.Organizer)
                .Include(c => c.Report)
                .Include(c => c.Sponsor)
                .OrderBy(c => c.Name)
                .ToListAsync();

        public async Task<Conference> GetConferenceByIdAsync(int id, bool trackChanges) =>
            await FindByCondition(c => c.ConferenceId.Equals(id), trackChanges)
                .Include(c => c.Location)
                .Include(c => c.Organizer)
                .Include(c => c.Report)
                .Include(c => c.Sponsor)
                .SingleOrDefaultAsync();

        public async Task<IEnumerable<Conference>> GetConferencesByLocationAsync(int locationId, bool trackChanges) =>
            await FindByCondition(c => c.LocationId.Equals(locationId), trackChanges)
                .Include(c => c.Location)
                .Include(c => c.Organizer)
                .Include(c => c.Report)
                .Include(c => c.Sponsor)
                .OrderBy(c => c.Name)
                .ToListAsync();

        public async Task<IEnumerable<Conference>> GetConferencesByOrganizerAsync(int organizerId, bool trackChanges) =>
            await FindByCondition(c => c.OrganizerId.Equals(organizerId), trackChanges)
                .Include(c => c.Location)
                .Include(c => c.Organizer)
                .Include(c => c.Report)
                .Include(c => c.Sponsor)
                .OrderBy(c => c.Name)
                .ToListAsync();

        public void CreateConference(Conference conference) => Create(conference);

        public void UpdateConference(Conference conference) => Update(conference);

        public void DeleteConference(Conference conference) => Delete(conference);
    }
} 