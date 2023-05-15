using DaftarMVC.Data;
using DaftarMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace DaftarMVC.Controllers;

public class FavoriteController : Controller
{
    
    private ApplicationDbContext _applicationDbContext;

    public FavoriteController(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }
    
    public IActionResult Index()
    {
        var userId = HttpContext.Session.GetInt32("UserId");
        var user = _applicationDbContext.Users.FirstOrDefault(e => e.Id.Equals((userId)));
        if (user is null)
            return RedirectToAction("logout", "Account");
        var favorites = _applicationDbContext.Favorites.Where(e => e.UserId.Equals(user.Id)).ToList();
        var teachers= new List<Teacher>();
        foreach (var teacher in favorites.Select(item => _applicationDbContext.Teacher.FirstOrDefault(e=> e.Teacher_Id.Equals(item.TeacherId))))
        {
            teachers?.Append(teacher);
        }
        return View("Index", teachers);
    }

    public IActionResult AddTeacher(int teacherId)
    {
        if (teacherId == null) return RedirectToAction("Index", "Teachers");
        var userId = HttpContext.Session.GetInt32("UserId");
        var user = _applicationDbContext.Users.FirstOrDefault(e => e.Id.Equals((userId)));
        if (user is null)
            return RedirectToAction("logout", "Account");

        var newFavorite = new Favorite()
        {
            UserId = user.Id,
            TeacherId = teacherId,
        };
        _applicationDbContext.Favorites.Add(newFavorite);
        _applicationDbContext.SaveChanges();
        return RedirectToAction("Index", "Favorite");
    }
    public IActionResult RemoveTeacher(int teacherId)
    {
        return View("Index");
    }
}