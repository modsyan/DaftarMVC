using Microsoft.AspNetCore.Mvc;

namespace DaftarMVC.Controllers;

public class LoginController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}