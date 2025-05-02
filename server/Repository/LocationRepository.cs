using Microsoft.EntityFrameworkCore;
using server.Models;

namespace server.Repository
{
    public class LocationRepository : RepositoryBase<Location>, ILocationRepository
    {
        public LocationRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<Location>> GetAllLocationsAsync(bool trackChanges) =>
            await FindAll(trackChanges)
                .OrderBy(l => l.Name)
                .ToListAsync();

        public async Task<Location> GetLocationByIdAsync(int id, bool trackChanges) =>
            await FindByCondition(l => l.LocationId.Equals(id), trackChanges)
                .SingleOrDefaultAsync();

        public void CreateLocation(Location location) => Create(location);

        public void UpdateLocation(Location location) => Update(location);

        public void DeleteLocation(Location location) => Delete(location);
    }
} 