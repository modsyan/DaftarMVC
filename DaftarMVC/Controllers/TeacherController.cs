using Microsoft.AspNetCore.Mvc;

namespace DaftarMVC.Controllers;

public class TeacherController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View("Teacher");
    }
}