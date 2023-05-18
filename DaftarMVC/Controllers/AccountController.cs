using System.Text;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using DaftarMVC.Data;
using DaftarMVC.Models;
using Microsoft.AspNetCore.Mvc;


namespace DaftarMVC.Controllers;

public class AccountController : Controller
{
    private ApplicationDbContext _applicationDbContext;

    public AccountController(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    [Route("/Login")]
    [HttpGet]
    public IActionResult Login()
    {
        return View("Login");
    }

    [Route("/Login")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Logout(string? email, string? password)
    {
        if (email is null || password is null) return View("Login");

        var encryptedPassword = AuthController.GetMd5(password);
        var user =
            _applicationDbContext.Users
                .Where(u => u.Email.Equals(email) && u.Password.Equals(encryptedPassword))
                .ToList().FirstOrDefault();
        if (user is null) return View("Login");

        HttpContext.Session.SetInt32("UserId", user.Id);
        
        if (user is { FirstName: not null, LastName: not null })
        {
            HttpContext.Session.SetString("FullName", user.FirstName + " " + user.LastName);
            HttpContext.Session.SetString("FirstName", user.LastName);
            HttpContext.Session.SetString("LastName", user.LastName);
        }
        
        HttpContext.Session.SetString("Email", user.Email);
        
        if (user.Avatar_link is not null)
            HttpContext.Session.SetString("UserImage", user.Avatar_link);
        if (user.PhoneNumber is not null)
            HttpContext.Session.SetString("PhoneNumber", user.PhoneNumber);

        return RedirectToAction("Index", "Home");
    }

    [Route("/Logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Index", "Home");
    }

    [Route("/Register")]
    [HttpGet]
    public IActionResult Register()
    {
        return HttpContext.Session.GetString("id") is null ? View("Register") : RedirectToAction("Index", "home");
    }

    [Route("/Register")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Register(User user, string confirmPassword)
    {
        var check = _applicationDbContext.Users.FirstOrDefault(u => u.Email.Equals(user.Email));
        if (check != null) return View("Register");

        if (user.Password != confirmPassword) return View("Register");
        user.Password = AuthController.GetMd5(user.Password);

        _applicationDbContext.Users.Add(user);
        _applicationDbContext.SaveChanges();
        return RedirectToAction("Login", "Account");
    }
}