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

        ViewBag.Tablero = Juego.tablero;
        ViewBag.palabra = Juego.palabra;
        ViewBag.letrasAdivinadas = Juego.letrasAdivinadas;
        ViewBag.letrasUsadas = Juego.letrasUsadas;
        ViewBag.cantLetras = Juego.cantLetras;

        return View();
    }

    public IActionResult Ganaste()
    {
        return View("Ganaste");
    }

    public IActionResult JugarLetra(char letra)
    {
        Juego.Letra(letra);

        if (Juego.verificarPalabra())
        {
            return RedirectToAction("Ganaste");
        }

        return RedirectToAction("VolverAJugar");
    }

    public IActionResult VolverAJugar()
    {
        ViewBag.palabra = Juego.palabra;
        ViewBag.letrasUsadas = Juego.letrasUsadas;
        ViewBag.letrasAdivinadas = Juego.letrasAdivinadas;
        ViewBag.cantIntentos = Juego.cantIntentos;
        ViewBag.cantLetras = Juego.cantLetras;
        ViewBag.Tablero = Juego.tablero;

        return View("Index");
    }
    [HttpPost]
    public IActionResult arriesgoPalabra(string palabra)
    {
        Juego.cantIntentos++;
        bool acerto = palabra.ToLower() == Juego.palabra;
        if (acerto)
        {
            return RedirectToAction("Ganaste");
        }
        else
        {
            return RedirectToAction("VolverAJugar");
        }
    }

}
