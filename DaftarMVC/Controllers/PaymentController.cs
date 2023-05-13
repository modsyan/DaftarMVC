using DaftarMVC.Data;
using DaftarMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace DaftarMVC.Controllers;

public class PaymentController : Controller
{
    private ApplicationDbContext _applicationDbContext;

    public PaymentController(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    // GET
    [HttpGet]
    public IActionResult Index()
    {
        return View("Payment");
    }

    [HttpPost]
    public IActionResult Index(Payment payment)
    {
        var curUserId = Request.Cookies["UserId"]?.Split('=')[1];
        if (curUserId is null)
        {
            return RedirectToAction("Index", "Login");
        }

        var isValidCard = payment.CardNumber == null || payment.CardHolderName == null || payment.CardNumber == null ||
                          payment.ExpiredMonth == null || payment.CVV == null;
        
        if (!isValidCard)
        {
            return View("FaildTransaction");
        }

        payment.user_id = int.Parse(curUserId);

        _applicationDbContext.Payments.Add(payment);
        _applicationDbContext.SaveChanges();
        return View("SuccessTransaction");
    }
}