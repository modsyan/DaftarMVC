using System.Text;
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
        if (email is null || password is null) return View("Login");
        var encryptedPassword = AuthController.GetMD5(password);
        var user =
            _applicationDbContext.Users
                .Where(u => u.Email.Equals(email) && u.Password.Equals(encryptedPassword))
                .ToList().FirstOrDefault();
        if (user is null) return View("Login");

        // using Cookies
        // Response.Cookies.Append("FirstName", data.FirstName);
        // Response.Cookies.Append("LasName", data.LastName);
        // Response.Cookies.Append("FullName", string.Concat(data.FirstName, " ", data.LastName));
        // Response.Cookies.Append("Email", data.Email);
        // Response.Cookies.Append("Id", new StringBuilder().Append(data.Id).ToString());
        // Response.Cookies.Append("UserImage", data.Avatar_link);
        // Response.Cookies.Append("PhoneNumber", data.PhoneNumber);

        // using Sessions
        
        HttpContext.Session.SetInt32("UserId", user.Id);
        HttpContext.Session.SetString("FullName", user.FirstName + " " + user.LastName);
        HttpContext.Session.SetString("Email", user.Email);
        if (user.Avatar_link is not null)
            HttpContext.Session.SetString("UserImage", user.Avatar_link);
        if (user.PhoneNumber is not null)
            HttpContext.Session.SetString("PhoneNumber", user.PhoneNumber);

        return RedirectToAction("Index", "User");
    }
}