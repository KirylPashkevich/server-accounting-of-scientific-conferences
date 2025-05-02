using Microsoft.EntityFrameworkCore;
using server.Models;

namespace server.Repository
{
    public class OrganizerRepository : RepositoryBase<Organizer>, IOrganizerRepository
    {
        public OrganizerRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<Organizer>> GetAllOrganizersAsync(bool trackChanges) =>
            await FindAll(trackChanges)
                .OrderBy(o => o.Surname)
                .ToListAsync();

        public async Task<Organizer> GetOrganizerByIdAsync(int id, bool trackChanges) =>
            await FindByCondition(o => o.OrganizerId.Equals(id), trackChanges)
                .SingleOrDefaultAsync();

        public void CreateOrganizer(Organizer organizer) => Create(organizer);

        public void UpdateOrganizer(Organizer organizer) => Update(organizer);

        public void DeleteOrganizer(Organizer organizer) => Delete(organizer);

        public async Task SaveAsync() => await RepositoryContext.SaveChangesAsync();
    }
} 