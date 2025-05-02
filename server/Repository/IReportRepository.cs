using server.Models;

namespace server.Repository
{
    public interface IReportRepository : IRepositoryBase<Report>
    {
        Task<IEnumerable<Report>> GetAllReportsAsync(bool trackChanges);
        Task<Report> GetReportByIdAsync(int id, bool trackChanges);
        void CreateReport(Report report);
        void UpdateReport(Report report);
        void DeleteReport(Report report);
    }
} 