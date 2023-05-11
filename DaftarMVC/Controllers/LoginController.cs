using DaftarMVC.Data;
using DaftarMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace DaftarMVC.Controllers;

public class LoginController : Controller
{
    private ApplicationDbContext _applicationDbContext;

    public LoginController(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    // GET
    [HttpGet]
    public IActionResult Index()
    {
        return View("Login");
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Index(string? email, string? password)
    {
        if (email == null || password == null) return View("Login");
        var encryptedPassword = AuthController.GetMD5(password);
        var data = 
            _applicationDbContext.Users
            .Where(u => u.Email.Equals(email) && u.Password.Equals(encryptedPassword))
            .ToList();
        if (!data.Any()) return View("Login");
        
        HttpContext.Session.SetString("Full Name",
            data.FirstOrDefault().FirstName + " " + data.FirstOrDefault().LastName);
        HttpContext.Session.SetString("Email", data.FirstOrDefault().Email);
        HttpContext.Session.SetInt32("idUser", data.FirstOrDefault().Id);
        
        return RedirectToAction("Index", "User");
    }
}