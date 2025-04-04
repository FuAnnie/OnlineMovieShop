using ApplicationCore.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace MovieMVCApp.Controllers;

public class CastController : Controller
{
    private readonly ICastService castService;

    public CastController(ICastService castService)
    {
        this.castService = castService;
    }
    
    // GET
    public IActionResult Index()
    {
        return View();
    }

    public async Task<IActionResult> Details(int id)
    {
        var data = await castService.GetCastDetailsAsync(id);
        
        return View(data);
    }
}