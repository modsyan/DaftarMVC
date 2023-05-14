using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DaftarMVC.Models;

public class Teacher
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Teacher_Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string? AvatarLink { get; set; }
    public string Major { get; set; }
    
    [DefaultValue("true")]
    public bool IsActive { get; set;}
    public double MonthlyPrice { get; set; }
}