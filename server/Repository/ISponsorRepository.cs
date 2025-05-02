using server.Models;

namespace server.Repository
{
    public interface ISponsorRepository
    {
        Task<IEnumerable<Sponsor>> GetAllSponsorsAsync(bool trackChanges);
        Task<Sponsor> GetSponsorByIdAsync(int id, bool trackChanges);
        void CreateSponsor(Sponsor sponsor);
        void UpdateSponsor(Sponsor sponsor);
        void DeleteSponsor(Sponsor sponsor);
    }
} 