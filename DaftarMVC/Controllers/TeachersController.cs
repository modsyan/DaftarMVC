using DaftarMVC.Data;
using DaftarMVC.Migrations;
using DaftarMVC.Models;

namespace DaftarMVC.Controllers;

using Microsoft.AspNetCore.Mvc;

public class TeachersController : Controller
{
    private ApplicationDbContext _applicationDbContext;

    public TeachersController(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }
    [HttpGet]
    public IActionResult Index()
    {
        var teachers = _applicationDbContext.Teacher.ToList();
        return View(teachers);
    }
    
    [HttpPost]
    public IActionResult Index(Teacher teacher)
    {
        return RedirectToAction("AddTeacher","Cart", teacher);
    }
}