using Microsoft.AspNetCore.Mvc;

namespace DaftarMVC.Controllers;

public class IntroController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}