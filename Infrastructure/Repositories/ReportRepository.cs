using ApplicationCore.Entities;
using ApplicationCore.Repositories;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class ReportRepository: BaseRepository<Review>, IReportRepository
{
    public ReportRepository(MovieDbContext movieDbContext) : base(movieDbContext)
    {
    }
}