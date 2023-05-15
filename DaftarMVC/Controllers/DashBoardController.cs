using DaftarMVC.Data;
using DaftarMVC.Models;
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

    
    // Teacher Handlers
    public IActionResult Teacher()
    {
        var allTeacher = _applicationDbContext.Teacher.ToList();
        return allTeacher == null ? View("Error") : View("Teacher", allTeacher);
    }

    [HttpGet]
    public IActionResult CreateTeacher()
    {
        return View("CreateTeacher");
    }
    [HttpPost]
    public IActionResult CreateTeacher(Teacher teacher)
    {
        _applicationDbContext.Teacher.Add(teacher);
        _applicationDbContext.SaveChanges();
        return RedirectToAction("Teacher", "DashBoard");
    }
    [HttpGet]
    public IActionResult UpdateTeacher(int id)
    {
        var teacher = _applicationDbContext.Teacher.FirstOrDefault(t => t.Teacher_Id.Equals(id));
        return View("UpdateTeacher", teacher);
    }
    
    [HttpPost]
    public IActionResult UpdateTeacher(Teacher teacher)
    {
        if (!ModelState.IsValid) return RedirectToRoute($"/DashBoard/UpdateTeacher/{teacher.Teacher_Id}");
        _applicationDbContext.Teacher.Update(teacher);
        _applicationDbContext.SaveChanges();
        return RedirectToAction("Teacher", "DashBoard");
    }
    

    public IActionResult RemoveTeacher(int id)
    {
        var teacherToRemove = _applicationDbContext.Teacher.FirstOrDefault(m => m.Teacher_Id.Equals(id));
        if (teacherToRemove is null) return RedirectToAction("Teacher", "DashBoard");
        _applicationDbContext.Teacher.Remove(teacherToRemove);
        _applicationDbContext.SaveChanges();
        return RedirectToAction("Teacher", "DashBoard");
    }

    
    //Users
    [HttpGet]
    public IActionResult Users()
    {
        var users = _applicationDbContext.Users.ToList();
        return View("Users", users);
    }
    
    [HttpGet]
    public IActionResult CreateUser()
    {
        return View("CreateUser");
    }
    [HttpPost]
    public IActionResult CreateUser(User user)
    {
        const string defaultPassword = "root";
        user.Password = AuthController.GetMD5(defaultPassword);
        _applicationDbContext.Users.Add(user);
        _applicationDbContext.SaveChanges();
        return RedirectToAction("Users", "DashBoard");
    }
    
    [HttpGet]
    public IActionResult UpdateUser(int id)
    {
        var user = _applicationDbContext.Users.FirstOrDefault(u => u.Id.Equals(id));
        return View("UpdateUser", user);
    }
    
    [HttpPost]
    public IActionResult UpdateUser(User user)
    {
        if (!ModelState.IsValid) return RedirectToRoute($"/DashBoard/UpdateUser/{user.Id}");
        _applicationDbContext.Users.Update(user);
        _applicationDbContext.SaveChanges();
        return RedirectToAction("Users", "DashBoard");
    }
    
    public IActionResult RemoveUser(int id)
    {
        var userToRemove = _applicationDbContext.Users.FirstOrDefault(m => m.Id.Equals(id));
        if (userToRemove is null) return RedirectToAction("Teacher", "DashBoard");
        _applicationDbContext.Users.Remove(userToRemove);
        _applicationDbContext.SaveChanges();
        return RedirectToAction("Users", "DashBoard");
    }
    
    public IActionResult Statistics()
    {
        return View("Statistics");
    }
    
    public IActionResult Chat()
    {
        return View("Chats");
    }
    
}