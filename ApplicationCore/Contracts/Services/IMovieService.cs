using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Services;

public interface IMovieService
{
    Task<IEnumerable<Movie>> GetAllMoviesAsync();
    Task<IEnumerable<Movie>> GetHighestGrossingMoviesAsync();
    Task<Movie?> GetMovieDetailsAsync(int id);
    Task<decimal> GetMovieRatingAsync(int id);
    Task<PaginatedResultSet<Movie>> GetMoviesByGenreAsync(int genreId, int pageSize, int pageNumber);
}