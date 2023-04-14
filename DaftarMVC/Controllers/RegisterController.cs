using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using Azure.Identity;
using DaftarMVC.Data;
using DaftarMVC.Models.User;
using Microsoft.AspNetCore.Mvc;
using DaftarMVC.Controllers;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DaftarMVC.Controllers;

public class RegisterController : Controller
{
    private ApplicationDbContext _applicationDbContext;

    public RegisterController(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    // [HttpPost]
    // public IActionResult Index(string username, string email, string password, string confirmPassword, string firstName,
    //     string lastName, string avatarLink, DateTime birthDate, string phoneNumber)
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Index(User _user, string confirmPassword)
    {
        // if (!ModelState.IsValid) return View();
        
        var check = _applicationDbContext.Users.FirstOrDefault(u => u.Email.Equals(_user.Email));
        if (check != null) return View(); 
        
        if (_user.Password != confirmPassword) return View();
        _user.Password = AuthController.GetMD5(_user.Password);
        
        _applicationDbContext.Users.Add(_user);
        _applicationDbContext.SaveChanges();
        return RedirectToAction("Index", "User");
    }
}