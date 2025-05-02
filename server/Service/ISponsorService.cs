using server.Models;
using server.Models.DTOs;

namespace server.Service
{
    public interface ISponsorService
    {
        Task<IEnumerable<Sponsor>> GetAllSponsorsAsync();
        Task<Sponsor> GetSponsorByIdAsync(int id);
        Task<Sponsor> CreateSponsorAsync(SponsorCreateDto sponsorDto);
        Task<Sponsor> UpdateSponsorAsync(int id, SponsorUpdateDto sponsorDto);
        Task DeleteSponsorAsync(int id);
    }
} 