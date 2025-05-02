using Microsoft.EntityFrameworkCore;
using server.Models;
using server.Repository.Configuration;

namespace server.Repository
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Location> Locations { get; set; }
        public DbSet<Conference> Conferences { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Spectator> Spectators { get; set; }
        public DbSet<Sponsor> Sponsors { get; set; }
        public DbSet<ChatMessage> ChatMessages { get; set; }
        public DbSet<Organizer> Organizers { get; set; }
        public DbSet<Confirmed> Confirmeds { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Apply configurations
            modelBuilder.ApplyConfiguration(new LocationConfiguration());
            modelBuilder.ApplyConfiguration(new ConferenceConfiguration());
            modelBuilder.ApplyConfiguration(new AuthorConfiguration());
            modelBuilder.ApplyConfiguration(new ReportConfiguration());
            modelBuilder.ApplyConfiguration(new SpectatorConfiguration());
            modelBuilder.ApplyConfiguration(new SponsorConfiguration());
            modelBuilder.ApplyConfiguration(new ChatMessageConfiguration());
            modelBuilder.ApplyConfiguration(new OrganizerConfiguration());
            modelBuilder.ApplyConfiguration(new ConfirmedConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());

            // Foreign key constraints
            modelBuilder.Entity<Conference>()
                .HasOne(c => c.Location)
                .WithMany(l => l.Conferences)
                .HasForeignKey(c => c.LocationId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Conference>()
                .HasOne(c => c.Organizer)
                .WithMany(o => o.Conferences)
                .HasForeignKey(c => c.OrganizerId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Conference>()
                .HasOne(c => c.Report)
                .WithMany(r => r.Conferences)
                .HasForeignKey(c => c.ReportId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Conference>()
                .HasOne(c => c.Sponsor)
                .WithMany(s => s.Conferences)
                .HasForeignKey(c => c.SponsorId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Report>()
                .HasOne(r => r.Author)
                .WithMany(a => a.Reports)
                .HasForeignKey(r => r.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Report>()
                .HasOne(r => r.Confirmed)
                .WithMany(c => c.Reports)
                .HasForeignKey(r => r.ConfirmationId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Spectator>()
                .HasOne(s => s.Conference)
                .WithMany(c => c.Spectators)
                .HasForeignKey(s => s.ConferenceId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ChatMessage>()
                .HasOne(cm => cm.Conference)
                .WithMany(c => c.ChatMessages)
                .HasForeignKey(cm => cm.ConferenceId)
                .OnDelete(DeleteBehavior.Cascade);

            // Создаем уникальный индекс для email пользователей
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();
        }
    }
} 