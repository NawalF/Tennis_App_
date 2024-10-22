using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TennisCoach.Data;
using TennisCoach.Models; // Add this line to include your Member model
 // Add this for your view model
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace TennisCoach.Controllers
{
    public class MemberController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MemberController(ApplicationDbContext context)
        {
            _context = context;
        }

        private int GetMemberId()
        {
            // Assuming you have a way to get the member ID
            var userEmail = User.Identity.Name; // Get the logged-in user's email
            var member = _context.Members.FirstOrDefault(m => m.Email == userEmail); // Adjust based on your logic
            return member?.MemberId ?? 0; // Return MemberId or 0 if not found
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Enrollments()
        {
            var memberId = GetMemberId(); // Retrieve the current member's ID

            var enrollments = _context.Enrollments
                                       .Include(e => e.Schedule) // Include schedule information
                                       .ThenInclude(s => s.Coach) // Include coach information if needed
                                       .Where(e => e.MemberId == memberId)
                                       .ToList();

            return View(enrollments); 
        }
        public IActionResult EnrolledCoaches()
        {
            var memberId = GetMemberId(); // Retrieve the current member's ID

            // Get the list of coaches for the current member based on their enrollments
            var enrolledCoaches = _context.Enrollments
                                          .Include(e => e.Schedule)
                                          .ThenInclude(s => s.Coach) // Ensure coach details are included
                                          .Where(e => e.MemberId == memberId)
                                          .Select(e => e.Schedule.Coach) // Get the coaches from the schedules
                                          .Distinct() // In case of duplicate coach entries
                                          .ToList();

            return View(enrolledCoaches); 
        }
        public IActionResult Coach()
        {
            return View();
        }
        public IActionResult Schedule()
        {
            return View();
        }
        public async Task<IActionResult> Schedules()
        {
            // Retrieve the list of schedules, including the coach information
            var schedules = await _context.Schedules
                                          .Include(s => s.Coach) // Include the related Coach entity
                                          .ToListAsync();

            // Pass the list of schedules to the view
            return View(schedules);
        }

       
        public async Task<IActionResult> Enroll()
        {
            // Retrieve the list of schedules, including the coach information
            var schedules = await _context.Schedules
                                          .Include(s => s.Coach) // Include the related Coach entity
                                          .ToListAsync();

            // Pass the list of schedules to the view
            return View(schedules);
        }


        public async Task<IActionResult> Coaches()
        {
            // Retrieve the list of coaches
            var coaches = await _context.Coaches.ToListAsync();
            // Log the count of retrieved coaches for debugging
            Console.WriteLine($"Coaches retrieved: {coaches.Count}");
            // Pass the list of coaches to the view
            return View(coaches);
        }
      


    }
}

        
  
