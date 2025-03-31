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
    
    public IEnumerable<Movie> GetAllMovies()
    {
        return movieRepository.GetAll();
    }
}