using Microsoft.AspNetCore.Mvc;

namespace DaftarMVC.Controllers;

public class StudentController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View("Student");
    }
}