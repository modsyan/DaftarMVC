using Microsoft.AspNetCore.Mvc;

namespace DaftarMVC.Controllers;

public class DashBoardController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Users()
    {
        return View("Users");
    }
    
    public IActionResult Teachers()
    {
        return View("Teachers");
    }
    
    public IActionResult Statistics()
    {
        return View("Statistics");
    }
    
    public IActionResult Chats()
    {
        return View("Chats");
    }
    
}