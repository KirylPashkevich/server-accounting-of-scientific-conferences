namespace server.Repository
{
    public interface IRepositoryManager
    {
        IConferenceRepository Conference { get; }
        ILocationRepository Location { get; }
        IOrganizerRepository Organizer { get; }
        IReportRepository Report { get; }
        IAuthorRepository Author { get; }
        IConfirmedRepository Confirmed { get; }
        IChatMessageRepository ChatMessage { get; }
        ISpectatorRepository Spectator { get; }
        Task SaveAsync();
    }
} 