using DaftarMVC.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DaftarMVC.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext()
    {
    }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    
    public DbSet<User> Users { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Favorite> Favorites { get; set; }
    public DbSet<Teacher> Teacher { get; set; }
    public DbSet<Cart> Cart { get; set; }

}