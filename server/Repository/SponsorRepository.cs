using Microsoft.EntityFrameworkCore;
using server.Models;

namespace server.Repository
{
    public class SponsorRepository : ISponsorRepository
    {
        private readonly RepositoryContext _context;

        public SponsorRepository(RepositoryContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Sponsor>> GetAllSponsorsAsync(bool trackChanges) =>
            await _context.Sponsors
                .OrderBy(s => s.Organization)
                .ToListAsync();

        public async Task<Sponsor> GetSponsorByIdAsync(int id, bool trackChanges) =>
            await _context.Sponsors
                .FirstOrDefaultAsync(s => s.SponsorId == id);

        public void CreateSponsor(Sponsor sponsor) => _context.Sponsors.Add(sponsor);

        public void UpdateSponsor(Sponsor sponsor) => _context.Sponsors.Update(sponsor);

        public void DeleteSponsor(Sponsor sponsor) => _context.Sponsors.Remove(sponsor);
    }
} 