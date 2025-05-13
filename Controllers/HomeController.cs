using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP04_Grinstein_Ledezma.Models;

namespace TP04_Grinstein_Ledezma.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        Juego.inicializarJuego();
        ViewBag.letrasUsadas = Juego.letrasUsadas;
        ViewBag.cantIntentos = Juego.cantIntentos;
        return View();
    }
}
