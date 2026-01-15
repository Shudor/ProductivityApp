using ProductivityApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProductivityApp.ViewModels
{
    public class DashboardViewModel
    {
        public List<TaskItem> TodayTasks { get; set; } = new();
        public List<Habit> Habits { get; set; } = new();

        public int TotalTasks => TodayTasks.Count;
        public int CompletedTasks => TodayTasks.Count(t => t.IsCompleted);
    }
}