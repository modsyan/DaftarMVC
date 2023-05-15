using DaftarMVC.Data;
using DaftarMVC.Migrations;
using DaftarMVC.Models;
using Microsoft.AspNetCore.Mvc;


namespace DaftarMVC.Controllers;

public class TodoController : Controller
{
    private ApplicationDbContext _applicationDbContext;

    public TodoController(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    // GET
    [HttpGet]
    public IActionResult Index()
    {
        var userId = HttpContext.Session.GetInt32("UserId");
        if (userId is null) return RedirectToAction("Login", "Account");
        var todos = _applicationDbContext.Todo.Where(e=> e.UserId.Equals(userId)).ToList();
        System.Console.WriteLine(todos);

        return View("index", todos);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View("CreateTodo");
    }
    [HttpPost]
    public IActionResult Create(Todo todo)
    {
        var userId = HttpContext.Session.GetInt32("UserId");
        var user = _applicationDbContext.Users.FirstOrDefault(e => e.Id.Equals((userId)));
        if (user is null)
            return RedirectToAction("logout", "Account");
        
        todo.UserId = user.Id;
        _applicationDbContext.Todo.Add(todo);
        _applicationDbContext.SaveChanges();
        return RedirectToAction("Index", "Todo");
    }


    public IActionResult Remove(int id)
    {
        var todo = _applicationDbContext.Todo.FirstOrDefault(e => e.Id.Equals(id));
        if (todo == null) return RedirectToAction("Index", "Todo");
        _applicationDbContext.Todo.Remove(todo);
        _applicationDbContext.SaveChanges();
        return RedirectToAction("index", "Todo");
    }

    public IActionResult ToggleDone(int id)
    {
        var todo = _applicationDbContext.Todo.FirstOrDefault(e => e.Id.Equals(id));
        if (todo == null) return RedirectToAction("Index", "Todo");
        todo.Status = !todo.Status;
        _applicationDbContext.Todo.Update(todo);
        _applicationDbContext.SaveChanges();
        return RedirectToAction("Index", "Todo");
    }
}