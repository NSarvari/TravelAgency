using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelAgency.Data;
using TravelAgency.Data.ViewModel;
using TravelAgency.Models;

namespace TravelAgency.Controllers
{
    public class BookingController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BookingController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var booking = _context.Bookings
                .Include(b => b.Destination)
                .Include(b => b.Customer).ToList();

            return View(booking);
        }

        public IActionResult Create()
        {
            var bookingViewModel = new BookingViewModel
            {
                Destinations = _context.Destinations.ToList(),
                Customers = _context.Customers.ToList()
            };

            return View(bookingViewModel);
        }

        [HttpPost]
        public IActionResult Create(BookingViewModel bookingViewModel)
        {
            var booking = new Booking
            {
                DestinationId = bookingViewModel.DestinationId,
                CustomerId = bookingViewModel.CustomerId,
            };

            _context.Bookings.Add(booking);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            var booking = _context.Bookings.Find(id);

            var viewModel = new BookingViewModel
            {
                BookingId = booking.Id,
                CustomerId = booking.CustomerId,
                DestinationId = booking.DestinationId,
                Destinations = _context.Destinations.ToList(),
                Customers = _context.Customers.ToList()
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Update(BookingViewModel bookingViewModel)
        {
            var booking = new Booking
            {
                Id = bookingViewModel.BookingId,
                CustomerId = bookingViewModel.CustomerId,
                DestinationId = bookingViewModel.DestinationId
            };
            _context.Entry(booking).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var booking = _context.Bookings.Find(id);
            if (booking == null)
            {
                return NotFound();
            }

            _context.Bookings.Remove(booking);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}