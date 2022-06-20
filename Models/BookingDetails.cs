using System.ComponentModel.DataAnnotations;

namespace Railway_Reservationsystem_WebAPI.Models
{
    public class BookingDetails
    {
        [Key]
        public int TrainId { get; set; }
        public string? TravellingFrom { get; set; }
        public string? TravellingTo { get; set; }
        public string? DepartureDate { get; set; }
        public string? ReturningDate { get; set; }
        public int Adults { get; set; }
        public int Children { get; set; }
    }
}
