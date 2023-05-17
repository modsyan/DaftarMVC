using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DaftarMVC.Models;

namespace DaftarMVC.Controllers;


using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View("Home");
    }




    public IActionResult Contact()
    {
        return View("Contact");
    }

    public IActionResult AboutUs()
    {
        return View("About");
    }

    public IActionResult Privacy()
    {
        return View("Privacy");
    }

    public IActionResult OldMid()
    {
        return View("OldMid");
    }

    public IActionResult Old()
    {
        return View("Old");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
