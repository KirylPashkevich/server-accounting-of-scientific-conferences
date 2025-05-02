using Microsoft.EntityFrameworkCore;
using server.Models;

namespace server.Repository
{
    public class ReportRepository : RepositoryBase<Report>, IReportRepository
    {
        public ReportRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<Report>> GetAllReportsAsync(bool trackChanges) =>
            await FindAll(trackChanges)
                .Include(r => r.Author)
                .Include(r => r.Confirmed)
                .OrderBy(r => r.Description)
                .ToListAsync();

        public async Task<Report> GetReportByIdAsync(int id, bool trackChanges) =>
            await FindByCondition(r => r.ReportId.Equals(id), trackChanges)
                .Include(r => r.Author)
                .Include(r => r.Confirmed)
                .SingleOrDefaultAsync();

        public void CreateReport(Report report) => Create(report);

        public void UpdateReport(Report report) => Update(report);

        public void DeleteReport(Report report) => Delete(report);
    }
} 