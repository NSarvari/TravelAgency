using System.ComponentModel.DataAnnotations;

namespace TravelAgency.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int PhoneNumber { get; set; }

        public ICollection<Booking> Bookings { get; set; }
    }
}
