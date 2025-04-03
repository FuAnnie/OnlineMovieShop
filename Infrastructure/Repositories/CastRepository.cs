using ApplicationCore.Entities;
using ApplicationCore.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class CastRepository: BaseRepository<Cast>, ICastRepository
{
    public CastRepository(MovieDbContext movieDbContext) : base(movieDbContext)
    {
    }

    public override async Task<Cast?> GetByIdAsync(int id)
    {
        return await movieDbContext.Casts
            .Include(c => c.MovieCasts)
            .ThenInclude(mc => mc.Movie)
            .FirstOrDefaultAsync(c => c.Id == id);
    }
}