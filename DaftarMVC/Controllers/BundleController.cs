using DaftarMVC.Data;
using Microsoft.AspNetCore.Mvc;

namespace DaftarMVC.Controllers;

public class BundleController : Controller
{
    
    private ApplicationDbContext _applicationDbContext;

    public BundleController(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    // GET
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
    
    
    // [HttpPost]
    // public ActionResult Bundels() {
        // var cookie = Request.Cookies["Email"];
        // if (cookie != null)
        // {
        //     string Email = cookie.Value.Split('=')[1];
        //     var account = dbCont.Accounts.Where(a => a.Email.Equals(Email)).FirstOrDefault();
        //     return View(account);
        // }
        // else
        // {
        //     return RedirectToAction("Index", "Login");
        // }
    // }
    
}