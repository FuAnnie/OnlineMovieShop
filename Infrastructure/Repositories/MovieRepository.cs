using ApplicationCore.Entities;
using ApplicationCore.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Infrastructure.Repositories;

public class MovieRepository: BaseRepository<Movie>, IMovieRepository
{
    public MovieRepository(MovieDbContext movieDbContext) : base(movieDbContext)
    {
    }

    public async Task<IEnumerable<Movie>> GetHighestGrossingMoviesAsync()
    {
        return await movieDbContext.Movies
            .OrderBy(m => m.Revenue)
            .ToListAsync();
    }

    public async Task<Movie> GetMovieByIdAsync(int id)
    {
        return await movieDbContext.Movies
            .Include(m => m.MovieGenres)
            .Include(m => m.MovieCasts)
            .ThenInclude(mc => mc.Cast)
            .Include(m => m.Trailers)
            .Include(m => m.Favorites)
            .Include(m => m.Reviews)
            .Include(m => m.Purchases)
            .FirstOrDefaultAsync(m => m.Id == id);
    }

    public async Task<decimal> GetAverageRatingByIdAsync(int id)
    {
        var ratings = await movieDbContext.Reviews
            .Where(r => r.MovieId == id)
            .Select(r => r.Rating)
            .ToListAsync();
        
        return ratings.Any() ? ratings.Average() : 0;
    }
}