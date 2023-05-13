using DaftarMVC.Data;
using Microsoft.AspNetCore.Mvc;

namespace DaftarMVC.Controllers;

public class Todo : Controller
{
    
    private ApplicationDbContext _applicationDbContext;

    public Todo(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }
    // GET
        public ActionResult Index()
        {
            var userId = Request.Cookies["UserId"]?.Split('=')[1];
            if(userId is null) return RedirectToAction("Index", "Login");
            
            var user = _applicationDbContext.Users.FirstOrDefault(a => a.Id.Equals(userId));
            return View(user);
        }

}