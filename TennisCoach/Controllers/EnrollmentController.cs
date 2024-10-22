using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using TennisCoach.Models;
using TennisCoach.Data;
using Microsoft.AspNetCore.Authorization;

public class EnrollmentController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<IdentityUser> _userManager;

    public EnrollmentController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    [HttpPost]
    [HttpPost]
    [Authorize]
    public IActionResult Enroll(int scheduleId)
    {
        var memberId = GetMemberId(); // Retrieve the member's ID

        if (memberId <= 0)
        {
            // Handle the case where the member ID is not found
            return RedirectToAction("Index", "Home");
        }

        // Create a new enrollment
        var enrollment = new Enrollments
        {
            ScheduleId = scheduleId,
            MemberId = memberId,
            EnrollmentDate = DateTime.Now // Track enrollment time
        };

        // Add enrollment to the database
        _context.Enrollments.Add(enrollment);
        _context.SaveChanges(); // Save changes to the database

        // Redirect to the Enrollments view or back to the schedule view
        return RedirectToAction("Index", "Schedules"); // Adjust this as needed
    }


    private int GetMemberId()
    {
        // Implement this method based on your user authentication system
        // For example, retrieving the member ID from claims or session
        return 1; // Placeholder for the actual implementation
    }
}
