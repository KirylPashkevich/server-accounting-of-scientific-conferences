using server.Models;

namespace server.Repository
{
    public interface ILocationRepository : IRepositoryBase<Location>
    {
        Task<IEnumerable<Location>> GetAllLocationsAsync(bool trackChanges);
        Task<Location> GetLocationByIdAsync(int id, bool trackChanges);
        void CreateLocation(Location location);
        void UpdateLocation(Location location);
        void DeleteLocation(Location location);
    }
} 