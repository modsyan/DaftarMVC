using DaftarMVC.Data;
using Microsoft.AspNetCore.Mvc;

namespace DaftarMVC.Controllers;

public class ChatController : Controller
{
    private ApplicationDbContext _applicationDbContext;

    public ChatController(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    // GET
    public IActionResult Index()
    {
        return View("Chat");
    }
    
    // [HttpPost]
    // public ActionResult Chat()
    // {
    //     var cookie = Request.Cookies["Email"];
    //     if (cookie != null)
    //     {
    //         string Email = cookie.Value.Split('=')[1];
    //         var account = dbCont.Accounts.Where(a => a.Email.Equals(Email)).FirstOrDefault();
    //         return View(account);
    //     }
    //     else
    //     {
    //         return RedirectToAction("Login");
    //     }
    // }
    
}