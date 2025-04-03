using ApplicationCore.Contracts.Services;
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
}