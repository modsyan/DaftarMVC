using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DaftarMVC.Models.User
{
    public class User
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string Password { get; set; }
        public string? Avatar_link { get; set; }
        public int? TicketsBilled { get; set;  }
        [DisplayName("BirthDate")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{dd/mm/yyyy}", ApplyFormatInEditMode = true)] 
        public DateTime? BirthDate { get; set; }

    }
}