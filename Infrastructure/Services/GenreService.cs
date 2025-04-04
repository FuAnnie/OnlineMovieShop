using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using ApplicationCore.Repositories;

namespace Infrastructure.Services;

public class GenreService: IGenreService
{
    private readonly IGenreRepository genreRepository;

    public GenreService(IGenreRepository genreRepository)
    {
        this.genreRepository = genreRepository;
    }
    
    public async Task<IEnumerable<Genre>> GetAllGenresAsync()
    {
        return await genreRepository.GetAllAsync();
    }
}