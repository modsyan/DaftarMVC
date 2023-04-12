using Microsoft.AspNetCore.Mvc;

namespace DaftarMVC.Controllers;

public class RegisterController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}