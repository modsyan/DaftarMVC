using DaftarMVC.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(
    option =>
        option.UseSqlServer(builder.Configuration.GetConnectionString("DBConnectionString"))
);

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(option =>
{
    option.IdleTimeout = TimeSpan.FromMinutes(10);
    option.Cookie.Name = ".UserAuth.Session";
    option.Cookie.HttpOnly = true;
    option.Cookie.IsEssential = true;
});


builder.Services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


// builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(option =>
// {
//     option.ExpireTimeSpan = TimeSpan.FromMinutes(20);
//     option.SlidingExpiration = true;
//     // option.AccessDeniedPath = "/DashBoard/";
// });
// app.UseAuthentication();
// app.UseAuthorization();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthorization();

app.UseSession();

// Application Routes

app.UseRouting();


app.MapControllerRoute(
    name: "Home",
    pattern: "Home",
    defaults: new {controller = "Home", action = "Index"}
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.MapControllerRoute(
    name: "logout",
    pattern: "logout",
    defaults: new { controller = "Account", action = "Logout" }
);

app.MapControllerRoute(
    name: "login",
    pattern: "login",
    defaults: new { controller = "Account", action = "login" }
);

app.MapControllerRoute(
    name: "Register",
    pattern: "Register",
    defaults: new { controller = "Account", action = "Register" }
);

app.Run();