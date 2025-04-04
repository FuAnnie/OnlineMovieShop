using ApplicationCore.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace MovieMVCApp.ViewComponents;

public class GenresViewComponent: ViewComponent
{
    private readonly IGenreService genreService;

    public GenresViewComponent(IGenreService genreService)
    {
        this.genreService = genreService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var genres = await genreService.GetAllGenresAsync();
        return View(genres);
    }
}