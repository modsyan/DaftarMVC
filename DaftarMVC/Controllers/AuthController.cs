using System.Security.Cryptography;
using System.Text;

namespace DaftarMVC.Controllers;

public class AuthController
{
    public static string GetMD5(string? str)
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
}
//TODO
// Auths Entire Application
// DashBoard ADD REMOVE UPDATE TEACHERS AND USERS
// COOKIES HANDLING
// Handling DATABASES WITH TIME STAMPS
// FAVORITE TEACHER BUTTON
// Live chat from Wezzah
// Intro From Wezzah