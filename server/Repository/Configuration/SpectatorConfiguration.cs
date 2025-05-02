using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using server.Models;

namespace server.Repository.Configuration
{
    public class SpectatorConfiguration : IEntityTypeConfiguration<Spectator>
    {
        public void Configure(EntityTypeBuilder<Spectator> builder)
        {
            builder.HasData
            (
                new Spectator
                {
                    SpectatorId = 1,
                    ConferenceId = 1,
                    NumberOfSpectators = 100
                },
                new Spectator
                {
                    SpectatorId = 2,
                    ConferenceId = 2,
                    NumberOfSpectators = 150
                },
                new Spectator
                {
                    SpectatorId = 3,
                    ConferenceId = 3,
                    NumberOfSpectators = 200
                },
                new Spectator
                {
                    SpectatorId = 4,
                    ConferenceId = 4,
                    NumberOfSpectators = 175
                },
                new Spectator
                {
                    SpectatorId = 5,
                    ConferenceId = 5,
                    NumberOfSpectators = 125
                }
            );
        }
    }
} 