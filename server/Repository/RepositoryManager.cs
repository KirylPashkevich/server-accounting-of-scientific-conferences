namespace server.Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly Lazy<IConferenceRepository> _conferenceRepository;
        private readonly Lazy<ILocationRepository> _locationRepository;
        private readonly Lazy<IOrganizerRepository> _organizerRepository;
        private readonly Lazy<IReportRepository> _reportRepository;
        private readonly Lazy<IAuthorRepository> _authorRepository;
        private readonly Lazy<IConfirmedRepository> _confirmedRepository;
        private readonly Lazy<IChatMessageRepository> _chatMessageRepository;
        private readonly Lazy<ISpectatorRepository> _spectatorRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _conferenceRepository = new Lazy<IConferenceRepository>(() => new ConferenceRepository(repositoryContext));
            _locationRepository = new Lazy<ILocationRepository>(() => new LocationRepository(repositoryContext));
            _organizerRepository = new Lazy<IOrganizerRepository>(() => new OrganizerRepository(repositoryContext));
            _reportRepository = new Lazy<IReportRepository>(() => new ReportRepository(repositoryContext));
            _authorRepository = new Lazy<IAuthorRepository>(() => new AuthorRepository(repositoryContext));
            _confirmedRepository = new Lazy<IConfirmedRepository>(() => new ConfirmedRepository(repositoryContext));
            _chatMessageRepository = new Lazy<IChatMessageRepository>(() => new ChatMessageRepository(repositoryContext));
            _spectatorRepository = new Lazy<ISpectatorRepository>(() => new SpectatorRepository(repositoryContext));
        }

        public IConferenceRepository Conference => _conferenceRepository.Value;
        public ILocationRepository Location => _locationRepository.Value;
        public IOrganizerRepository Organizer => _organizerRepository.Value;
        public IReportRepository Report => _reportRepository.Value;
        public IAuthorRepository Author => _authorRepository.Value;
        public IConfirmedRepository Confirmed => _confirmedRepository.Value;
        public IChatMessageRepository ChatMessage => _chatMessageRepository.Value;
        public ISpectatorRepository Spectator => _spectatorRepository.Value;

        public async Task SaveAsync() => await _repositoryContext.SaveChangesAsync();
    }
} 