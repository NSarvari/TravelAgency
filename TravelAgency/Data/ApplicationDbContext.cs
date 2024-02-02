using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TravelAgency.Models;

namespace TravelAgency.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Destination> Destinations { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Booking> Bookings { get; set; }
    }
}
