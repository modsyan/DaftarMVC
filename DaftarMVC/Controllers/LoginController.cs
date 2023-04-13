using DaftarMVC.Data;
using DaftarMVC.Models.User;
using Microsoft.AspNetCore.Mvc;

namespace DaftarMVC.Controllers;

public class LoginController : Controller
{
    // GET
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult Index(string email, string password)
    {
        var isAuth = false;
        ApplicationDbContext db = new ApplicationDbContext();
        User user = new User
        {
            Email = email,
            Password = password,
        };
       
        // CHECK USER ------------------------->
        
        
        // CHECK USER <-------------------------
        if (!isAuth)
        {
            return View();
        }
        else
        {
            return RedirectToAction("Index");
        }
        
    }
}