using DaftarMVC.Data;
using Microsoft.AspNetCore.Mvc;

namespace DaftarMVC.Controllers;

public class DashBoardController : Controller
{
    
    private ApplicationDbContext _applicationDbContext;

    public DashBoardController(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }
    
    // GET
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Users()
    {
        return View("Users");
    }
    
    public IActionResult Teacher()
    {
        var allTeacher = _applicationDbContext.Teacher.ToList();
        return allTeacher == null ? View("Error") : View("Teacher", allTeacher);
    }

    public IActionResult EditTeacher(int id)
    {
        var teacher = _applicationDbContext.Teacher.FirstOrDefault(t => t.Teacher_Id.Equals(id));
        return View("EditTeacher", teacher);
    }
    
    // public IActionResult RemoveTeacher()
    // {
    //     
    // }


    public IActionResult Statistics()
    {
        return View("Statistics");
    }
    
    public IActionResult Chat()
    {
        return View("Chats");
    }
    
}