using System.Runtime.CompilerServices;
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

    [HttpPost]
    public IActionResult Index(string username, string email, string password, string confirmPassword, string firstName, string lastName, string avatarLink, DateTime birthDate, string phoneNumber)
    {
        // Faild Login ( Return to the same Page )
        if (password != confirmPassword) return View();

        User user = new User
        {
            Username = username,
            Password = password,
            Email = email,
            FirstName = firstName,
            LastName = lastName,
            Avatar_link = avatarLink,
            BirthDate = birthDate,
            PhoneNumber = phoneNumber,
            
        };

        var freshUser= _applicationDbContext.Users.Add(user);
        if (freshUser == null) return View();
        _applicationDbContext.SaveChanges();
        return RedirectToAction("Index", "User");
        
        // if (db.Users.Find(email) != null && db.Users.Find(username) != null)
        // {
        //     return View();
        // }
    }

}