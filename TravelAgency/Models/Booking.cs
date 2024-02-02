using System.ComponentModel.DataAnnotations;

namespace TravelAgency.Models
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }

        public int DestinationId { get; set; }
        public Destination Destination { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
