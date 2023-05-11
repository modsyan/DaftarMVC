using Microsoft.AspNetCore.Mvc;

namespace DaftarMVC.Controllers;

public class UserController : Controller
{
    // private readonly IHttpContextAccessor _httpContextAccessor;
    // public UserController(IHttpContextAccessor httpContextAccessor)
    // {
        // _httpContextAccessor = httpContextAccessor;
        
    // }

    public UserController()
    {
    }

    // GET
    public IActionResult Index()
    {
        // var FullName = HttpContext.Session.GetString("Full Name");
        // _httpContextAccessor.HttpContext.Session.SetString("Full Name", FullName);
        return View("User");
    }
}