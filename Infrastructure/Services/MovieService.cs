using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using ApplicationCore.Repositories;

namespace Infrastructure.Services;

public class MovieService: IMovieService
{
    private readonly IMovieRepository movieRepository;

    public MovieService(IMovieRepository movieRepository)
    {
        this.movieRepository = movieRepository;
    }
    
    public async Task<IEnumerable<Movie>> GetAllMoviesAsync()
    {
        return await movieRepository.GetAllAsync();
    }

    public async Task<IEnumerable<Movie>> GetHighestGrossingMoviesAsync()
    {
        return await movieRepository.GetHighestGrossingMoviesAsync();
    }

    public async Task<Movie> GetMovieDetailsAsync(int id)
    {
        return await movieRepository.GetMovieByIdAsync(id);
    }

    public async Task<decimal> GetMovieRatingAsync(int id)
    {
        return await movieRepository.GetAverageRatingByIdAsync(id);
    }
}