using Microsoft.AspNetCore.Mvc;

namespace DaftarMVC.Controllers;

public class StudentController : Controller
{
    // GET
    [Route("/news")]
    public IActionResult Index()
    {
        return View("Student");
    }
}