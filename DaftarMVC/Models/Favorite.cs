using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DaftarMVC.Models;

public class Favorite
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    // [ForeignKey("User")] 
    public int UserLikesId { get; set;}
    
    // [ForeignKey("Teacher")]
    public int TeacherLikedId { get; set;}
}