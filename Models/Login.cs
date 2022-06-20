using System.ComponentModel.DataAnnotations;

namespace Railway_Reservationsystem_WebAPI.Models
{
    public class Login
    {
        [Key]
       // public int Id { get; set; }
        public string? EmailId { get; set; } 
        public string? Password { get; set; }
    }
}
