using TravelAgency.Models;

namespace TravelAgency.Data.ViewModel
{
    public class BookingViewModel
    {
        public int BookingId { get; set; }
        public List<Booking> Bookings { get; set; }
        public int DestinationId { get; set; }
        public List<Destination> Destinations { get; set; }
        public int CustomerId { get; set; }
        public List<Customer> Customers { get; set; }
    }
}