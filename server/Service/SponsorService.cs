using Microsoft.EntityFrameworkCore;
using server.Models;
using server.Models.DTOs;
using server.Repository;

namespace server.Service
{
    public class SponsorService : ISponsorService
    {
        private readonly RepositoryContext _context;

        public SponsorService(RepositoryContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Sponsor>> GetAllSponsorsAsync()
        {
            return await _context.Sponsors.ToListAsync();
        }

        public async Task<Sponsor> GetSponsorByIdAsync(int id)
        {
            var sponsor = await _context.Sponsors.FindAsync(id);
            if (sponsor == null)
            {
                throw new KeyNotFoundException($"Sponsor with ID {id} not found.");
            }
            return sponsor;
        }

        public async Task<Sponsor> CreateSponsorAsync(SponsorCreateDto sponsorDto)
        {
            var sponsor = new Sponsor
            {
                Organization = sponsorDto.Organization,
                ContactPerson = sponsorDto.ContactPerson,
                Email = sponsorDto.Email,
                Phone = sponsorDto.Phone,
                Amount = sponsorDto.Amount
            };

            _context.Sponsors.Add(sponsor);
            await _context.SaveChangesAsync();
            return sponsor;
        }

        public async Task<Sponsor> UpdateSponsorAsync(int id, SponsorUpdateDto sponsorDto)
        {
            var sponsor = await _context.Sponsors.FindAsync(id);
            if (sponsor == null)
            {
                throw new KeyNotFoundException($"Sponsor with ID {id} not found.");
            }

            sponsor.Organization = sponsorDto.Organization;
            sponsor.ContactPerson = sponsorDto.ContactPerson;
            sponsor.Email = sponsorDto.Email;
            sponsor.Phone = sponsorDto.Phone;
            sponsor.Amount = sponsorDto.Amount;

            await _context.SaveChangesAsync();
            return sponsor;
        }

        public async Task DeleteSponsorAsync(int id)
        {
            var sponsor = await _context.Sponsors.FindAsync(id);
            if (sponsor == null)
            {
                throw new KeyNotFoundException($"Sponsor with ID {id} not found.");
            }

            _context.Sponsors.Remove(sponsor);
            await _context.SaveChangesAsync();
        }
    }
} 