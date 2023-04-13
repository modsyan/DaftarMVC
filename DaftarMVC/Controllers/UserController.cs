using Microsoft.AspNetCore.Mvc;

namespace DaftarMVC.Controllers;

public class UserController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}