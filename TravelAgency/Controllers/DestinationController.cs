using Microsoft.AspNetCore.Mvc;
using TravelAgency.Data;
using TravelAgency.Models;

namespace TravelAgency.Controllers
{
    public class DestinationController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DestinationController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var destinations = _context.Destinations.ToList();
            return View(destinations);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Destination destination)
        {
            _context.Destinations.Add(destination);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            var destination = _context.Destinations.FirstOrDefault(d => d.Id == id);
            return View(destination);
        }

        [HttpPost]
        public IActionResult Update(Destination destination)
        {
            _context.Update(destination);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var destination = _context.Destinations.Find(id);
            if (destination == null)
            {
                return NotFound();
            }

            _context.Destinations.Remove(destination);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
