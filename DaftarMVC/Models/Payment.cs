using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DaftarMVC.Models;

public class Payment
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [ForeignKey(name: "UserId")]
    public int user_id { get; set; }
    public string CardHolderName { get; set; }
    public string CardNumber { get; set; }
    public string ExpiredMonth { get; set; }
    public string ExpiredYear { get; set; }
    public string CVV { get; set; }
}