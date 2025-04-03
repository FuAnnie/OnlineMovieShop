using ApplicationCore.Entities;

namespace ApplicationCore.Repositories;

public interface IMovieRepository: IRepository<Movie>
{
    public Task<IEnumerable<Movie>> GetHighestGrossingMoviesAsync();
    public Task<Movie> GetMovieByIdAsync(int id);
    public Task<decimal> GetAverageRatingByIdAsync(int id);
}