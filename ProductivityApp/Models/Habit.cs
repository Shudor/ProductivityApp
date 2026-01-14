using System;
using System.ComponentModel.DataAnnotations;

namespace ProductivityApp.Models
{
    public enum HabitFrequency
    {
        Daily,
        Weekly
    }

    public class Habit
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public HabitFrequency Frequency { get; set; }

        public DateTime? LastCompletedDate { get; set; }

        public int Streak { get; set; }
    }
}