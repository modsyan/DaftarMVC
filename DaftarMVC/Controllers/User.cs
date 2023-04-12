using Microsoft.AspNetCore.Mvc;

namespace DaftarMVC.Controllers;

public class User : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}