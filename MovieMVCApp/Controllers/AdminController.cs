using Microsoft.AspNetCore.Mvc;
using MovieMVCApp.Filters;

namespace MovieMVCApp.Controllers;

public class AdminController: Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }

    [ServiceFilter<LogRequestFilter>]
    public IActionResult CreateMovie()
    {
        return View();
    }
}