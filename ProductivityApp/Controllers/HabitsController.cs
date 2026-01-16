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

    public async Task<IActionResult> Complete(int id, string returnUrl = null)
    {
        var habit = await _context.Habits.FindAsync(id);
        if (habit == null)
            return NotFound();

        var today = DateTime.Today;

        // Ako je već označena danas – ne radi ništa
        if (habit.LastCompletedDate == today)
        {
            return !string.IsNullOrEmpty(returnUrl)
                ? Redirect(returnUrl)
                : RedirectToAction(nameof(Index));
        }

        // Streak logika
        if (habit.LastCompletedDate == today.AddDays(-1))
            habit.Streak++;
        else
            habit.Streak = 1;

        habit.LastCompletedDate = today;

        await _context.SaveChangesAsync();

        return !string.IsNullOrEmpty(returnUrl)
            ? Redirect(returnUrl)
            : RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int id)
    {
        var habit = await _context.Habits.FindAsync(id);
        if (habit == null)
            return NotFound();

        return View(habit);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Habit habit)
    {
        if (id != habit.Id)
            return BadRequest();

        if (!ModelState.IsValid)
            return View(habit);

        _context.Update(habit);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }
}