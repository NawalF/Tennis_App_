using System.ComponentModel.DataAnnotations;

namespace TennisCoach.Models
{
    public class AdminLoginViewModel
    {

        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string PasswordHash { get; set; }

    }
}
