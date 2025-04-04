using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MovieMVCApp.Controllers;

public class MovieController : Controller
{
    private readonly IMovieService movieService;

    public MovieController(IMovieService movieService)
    {
        this.movieService = movieService;
    }
    
    // GET
    public async Task<IActionResult> Index()
    {
        var data = await movieService.GetAllMoviesAsync();
        
        return View(data);
    }

    public async Task<IActionResult> Details(int id)
    {
        var data = await movieService.GetMovieDetailsAsync(id);
        ViewData["Rating"] = await movieService.GetMovieRatingAsync(id);
        
        return View(data);
    }

    public async Task<IActionResult> MoviesByGenre(int genreId, int pageSize = 30, int pageNumber = 1)
    {
        var data = await movieService.GetMoviesByGenreAsync(genreId, pageSize, pageNumber);
        ViewBag.GenreId = genreId;
        
        return View(data);
    }
}