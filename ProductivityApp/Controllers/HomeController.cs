using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProductivityApp.Models;
using ProductivityApp.Data;
using ProductivityApp.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace ProductivityApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> Today()
        {
            var today = DateTime.Today;
            var tomorrow = today.AddDays(1);

            var vm = new DashboardViewModel
            {
                TodayTasks = await _context.Tasks
                    .Where(t =>
                        !t.IsCompleted &&
                        (
                            t.DueDate == null ||
                            (t.DueDate >= today && t.DueDate < tomorrow)
                        )
                    )
                    .OrderBy(t => t.DueDate)
                    .ToListAsync(),

                Habits = await _context.Habits.ToListAsync()
            };

            return View(vm);
        }
    }
}
