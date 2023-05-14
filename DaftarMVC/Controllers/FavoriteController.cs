using DaftarMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace DaftarMVC.Controllers;

public class FavoriteController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult AddTeacher()
    {
        return View("Index");
    }
    public IActionResult RemoveTeacher()
    {
        return View("Index");
    }
}