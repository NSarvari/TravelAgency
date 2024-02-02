using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelAgency.Data;
using TravelAgency.Models;

namespace TravelAgency.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomerController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var customers = _context.Customers.ToList();
            return View(customers);
        }

        public IActionResult Details(int id)
        {
            var customer = _context.Customers
                .Include(c=>c.Bookings)
                .ThenInclude(c=>c.Destination)
                .FirstOrDefault(c=>c.Id == id);

            return View(customer);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var customer = _context.Customers.Find(id);
            return View(customer);
        }

        [HttpPost]
        public IActionResult Edit(Customer customer)
        {
            _context.Customers.Update(customer);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var customer = _context.Customers.Find(id);
            if (customer == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(customer);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
