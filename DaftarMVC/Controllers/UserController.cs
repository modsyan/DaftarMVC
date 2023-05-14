using Microsoft.AspNetCore.Mvc;

namespace DaftarMVC.Controllers;

public class UserController : Controller
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    public UserController(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
        
    }

    // GET
    public IActionResult Index()
    {
        // var fullName = HttpContext.Session.GetString("Full Name");
        // _httpContextAccessor.HttpContext?.Session.SetString("Full Name", FullName);
        var cookieValue = _httpContextAccessor.HttpContext?.Request.Cookies["FullName"];
        if (cookieValue is null) return RedirectToAction("Index", "Login");
        return View("User");
    }
}