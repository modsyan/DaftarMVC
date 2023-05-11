using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DaftarMVC.Controllers;

public class CookiesController : Controller
{
    // GET
    public void CreateCookie(string key, string value)
    {
        var cookieOptions = new CookieOptions
        {
            Expires = DateTime.Now.AddMinutes(2)
        };
        
        Response.Cookies.Append(key, value, cookieOptions);
    }
    
    public void ReadCookie(string key)
    {
        var cookieValue = Request.Cookies[key];
    }
    
    public void DeleteCookie(string key)
    {
        var cookieOptions = new CookieOptions
        {
            Expires = DateTime.Now.AddMinutes(-1)
        };
        Response.Cookies.Append(key, string.Empty, cookieOptions);
        
    }
    
}