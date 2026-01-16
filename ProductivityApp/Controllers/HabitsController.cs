using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductivityApp.Data;
using ProductivityApp.Models;

public class HabitsController : Controller
{
    private readonly AppDbContext _context;

    public HabitsController(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _context.Habits.ToListAsync());
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Habit habit)
    {
        if (!ModelState.IsValid)
            return View(habit);

        habit.Streak = 0;
        habit.LastCompletedDate = null;

        _context.Habits.Add(habit);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        var habit = await _context.Habits.FindAsync(id);
        if (habit == null)
            return NotFound();

        _context.Habits.Remove(habit);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }
}