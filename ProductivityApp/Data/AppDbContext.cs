using Microsoft.EntityFrameworkCore;
using ProductivityApp.Models;

namespace ProductivityApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<TaskItem> Tasks { get; set; }
        public DbSet<Habit> Habits { get; set; }
    }
}