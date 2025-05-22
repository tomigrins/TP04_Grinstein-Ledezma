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
        
        Juego ahorcado = new Juego();
        ahorcado.inicializarJuego();

        ViewBag.Tablero = ahorcado.tablero;
        ViewBag.palabra = ahorcado.palabra;
        ViewBag.letrasAdivinadas = ahorcado.letrasAdivinadas;
        ViewBag.letrasUsadas = ahorcado.letrasUsadas;
        ViewBag.cantLetras = ahorcado.cantLetras;

        HttpContext.Session.SetString("ahorcado", Objeto.ObjectToString(ahorcado));

        return View();
    }
    
    public IActionResult Ganaste()
    {
        return View("Ganaste");
    }

    public IActionResult JugarLetra(char letra)
    {
        Juego ahorcado = Objeto.StringToObject<Juego>(HttpContext.Session.GetString("ahorcado"));
        
        ahorcado.Letra(letra);

        if (ahorcado.verificarPalabra())
        {
            return RedirectToAction("Ganaste");
        }

        return RedirectToAction("VolverAJugar");
    }

    public IActionResult VolverAJugar()
    {
        Juego ahorcado = Objeto.StringToObject<Juego>(HttpContext.Session.GetString("ahorcado"));

        ViewBag.palabra = ahorcado.palabra;
        ViewBag.letrasUsadas = ahorcado.letrasUsadas;
        ViewBag.letrasAdivinadas = ahorcado.letrasAdivinadas;
        ViewBag.cantIntentos = ahorcado.cantIntentos;
        ViewBag.cantLetras = ahorcado.cantLetras;
        ViewBag.Tablero = ahorcado.tablero;

        return View("Index");
    }
    [HttpPost]
    public IActionResult arriesgoPalabra(string palabra)
    {
        Juego ahorcado = Objeto.StringToObject<Juego>(HttpContext.Session.GetString("ahorcado"));
        ahorcado.cantIntentos++;
        bool acerto = palabra.ToLower() == ahorcado.palabra;
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
