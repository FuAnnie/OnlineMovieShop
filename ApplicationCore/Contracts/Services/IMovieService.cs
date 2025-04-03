using ApplicationCore.Entities;

namespace ApplicationCore.Contracts.Services;

public interface IMovieService
{
    Task<IEnumerable<Movie>> GetAllMoviesAsync();
    Task<IEnumerable<Movie>> GetHighestGrossingMoviesAsync();
    Task<Movie> GetMovieDetailsAsync(int id);
    Task<decimal> GetMovieRatingAsync(int id);
}