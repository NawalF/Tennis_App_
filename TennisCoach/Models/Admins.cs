using System.ComponentModel.DataAnnotations;

namespace TennisCoach.Models
{
    public class Admins

    {
        [Key]
        public int AdminId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash  { get; set; }
    }
}
