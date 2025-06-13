using System.Diagnostics;
using Activity_2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Activity_2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;       

        private readonly EntriesDbContext _context;
        public HomeController(ILogger<HomeController> logger, EntriesDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Library()
        {
            var entries = _context.Entries.ToList();
            return View(entries);
        }

        public IActionResult Write()
        {
            return View();
        }

        public IActionResult WriteForm(Library entry)
        {
            
            if (ModelState.IsValid)
    {               
                _context.Entries.Add(entry);
                _context.SaveChanges();               
              
                return RedirectToAction("Library");
            }
            return View("Write", entry);
        }

        public IActionResult Details(int id)
        {
            var entry = _context.Entries.FirstOrDefault(e => e.Id == id);
            if (entry == null) return NotFound();
            return View(entry);
        }


        public IActionResult About()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
