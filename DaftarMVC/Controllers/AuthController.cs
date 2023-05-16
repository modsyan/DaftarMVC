using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace DaftarMVC.Controllers;

public class AuthController : Controller
{
    public static string GetMd5(string? str)
    {
        MD5 md5 = new MD5CryptoServiceProvider();
        byte[] fromData = Encoding.UTF8.GetBytes(str);
        byte[] targetData = md5.ComputeHash(fromData);
        string byte2String = null;

        for (int i = 0; i < targetData.Length; i++)
        {
            byte2String += targetData[i].ToString("x2");

        }
        return byte2String;
    }

    // public void IsAuth()
    // {
    //     var user= HttpContext.Session.GetInt32("UserId");
    //     if (user is null) RedirectToAction ("Logout", "Account");
    // }

    // public void IsAuthintecated() 
    // {
    //     var user= HttpContext.Session.GetInt32("UserId");
    //     if (user is null) RedirectToAction ("Logout", "Account");
    // }
    //
    // public AuthController(Action action) : base(action)
    // {
    //     var user= HttpContext.Session.GetInt32("UserId");
    //     if (user is null) RedirectToAction ("Logout", "Account");
    // }
    //
    // public AuthController(Action action, CancellationToken cancellationToken) : base(action, cancellationToken)
    // {
    // }
    //
    // public AuthController(Action action, CancellationToken cancellationToken, TaskCreationOptions creationOptions) : base(action, cancellationToken, creationOptions)
    // {
    // }
    //
    // public AuthController(Action action, TaskCreationOptions creationOptions) : base(action, creationOptions)
    // {
    // }
    //
    // public AuthController(Action<object?> action, object? state) : base(action, state)
    // {
    // }
    //
    // public AuthController(Action<object?> action, object? state, CancellationToken cancellationToken) : base(action, state, cancellationToken)
    // {
    // }
    //
    // public AuthController(Action<object?> action, object? state, CancellationToken cancellationToken, TaskCreationOptions creationOptions) : base(action, state, cancellationToken, creationOptions)
    // {
    // }
    //
    // public AuthController(Action<object?> action, object? state, TaskCreationOptions creationOptions) : base(action, state, creationOptions)
    // {
    // }
}
//TODO
// Auths Entire Application
// DashBoard ADD REMOVE UPDATE TEACHERS AND USERS
// COOKIES HANDLING
// Handling DATABASES WITH TIME STAMPS
// FAVORITE TEACHER BUTTON
// Live chat from Wezzah
// Intro From Wezzah