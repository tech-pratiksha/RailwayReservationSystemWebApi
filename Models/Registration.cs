using System.ComponentModel.DataAnnotations;

namespace Railway_Reservationsystem_WebAPI.Models
{
    public class Registration
    {
        [Key]
        public int PassengerId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? EmailId { get; set; }
        public string? Password { get; set; }
        public string? Gender { get; set; }
        public int Age { get; set; }
        public string? MobileNumber { get; set; }


    }
}
