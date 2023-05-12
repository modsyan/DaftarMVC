using DaftarMVC.Data;
using DaftarMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace DaftarMVC.Controllers;

public class CartController : Controller
{
    
    private ApplicationDbContext _applicationDbContext;

    public CartController(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }
    
    // GET
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult AddTeacher(Teacher teacher)
    {
        Cart order = new Cart()
        {
            imgae = teacher.AvatarLink,
            price = teacher.MonthlyPrice,
            name = string.Concat(teacher.FirstName + " " + teacher.LastName)
        };
        _applicationDbContext.Cart.Add(order);
        _applicationDbContext.SaveChanges();
        return RedirectToAction("Index", "Teachers");
    }
    
    [HttpPost]
    public IActionResult RemoveTeacher(Cart order)
    {
        var src_order = _applicationDbContext.Cart.Find(order);
        if(src_order != null)
        _applicationDbContext.Cart.Remove(order);
        _applicationDbContext.SaveChanges();
        return View("index");
    }
}