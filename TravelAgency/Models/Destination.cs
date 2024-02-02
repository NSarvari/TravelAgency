using System.ComponentModel.DataAnnotations;

namespace TravelAgency.Models
{
    public class Destination
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Booking> Bookings { get; set; }
    }
}
