using ApplicationCore.Entities;
using ApplicationCore.Repositories;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class PurchaseRepository: BaseRepository<Purchase>, IPurchaseRepository
{
    public PurchaseRepository(MovieDbContext movieDbContext) : base(movieDbContext)
    {
    }
}