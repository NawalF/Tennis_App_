using System.ComponentModel.DataAnnotations;

namespace TennisCoach.Models
{
    public class Enrollments
    {
        [Key]
        public int EnrollId { get; set; }
        public int ScheduleId { get; set; }
        public int MemberId { get; set; }
        public DateTime EnrollmentDate { get; set; } = DateTime.Now; // Default to now
        public string Status { get; set; } = "Active"; // Default status
        public string Comments { get; set; } // Optional comments

        // Navigation properties
        public virtual Schedules Schedule { get; set; }
        public virtual Members Member { get; set; }
    }




}
