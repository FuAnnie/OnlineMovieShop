using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace ApplicationCore.Repositories;

public interface IMovieRepository: IRepository<Movie>
{
    public Task<IEnumerable<Movie>> GetHighestGrossingMoviesAsync();
    public Task<Movie?> GetMovieByIdAsync(int id);
    public Task<decimal> GetAverageRatingByIdAsync(int id);

    public Task<PaginatedResultSet<Movie>> GetMoviesByGenreAsync(int genreId, int pageSize, int pageNumber);
}