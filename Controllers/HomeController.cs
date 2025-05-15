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
    if (Juego.palabra == null)
    {
        Juego.inicializarJuego(); // Asegurate de tener un método así en tu clase Juego.cs
    }

    ViewBag.palabra = Juego.palabra;
    ViewBag.letrasAdivinadas = Juego.letrasAdivinadas;
    ViewBag.letrasUsadas = Juego.letrasUsadas;

    return View();
}

public IActionResult Ganaste()
{
    return View("Ganaste");
}
public IActionResult JugarLetra(char letra)
{
    Juego.Letra(letra);

   ViewBag.palabra = Juego.palabra;
ViewBag.letrasUsadas = Juego.letrasUsadas;
ViewBag.letrasAdivinadas = Juego.letrasAdivinadas;
ViewBag.cantIntentos = Juego.cantIntentos;
ViewBag.cantLetras = Juego.cantLetras;

    if (Juego.letrasAdivinadas.Count == Juego.cantLetras)
    {
        return RedirectToAction("Ganaste");
    }

    return View("Index");
}


}
