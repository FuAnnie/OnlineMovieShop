using ApplicationCore.Entities;

namespace ApplicationCore.Contracts.Services;

public interface IMovieService
{
    IEnumerable<Movie> GetAllMovies();
}