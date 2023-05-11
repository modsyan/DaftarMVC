using Microsoft.AspNetCore.Mvc;

namespace DaftarMVC.Controllers;

public class HomeMoController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Contact()
    {
        return View("Contact");
    }

    public IActionResult AboutUs()
    {
        return View("About");
    }
}