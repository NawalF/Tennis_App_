using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using TennisCoach.Models;
using TennisCoach.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

public class SchedulesController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<IdentityUser> _userManager;

    public SchedulesController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    public IActionResult Index()
    {
        // Get the logged-in user's member ID (assume it's stored in the user's claim or profile)
        var memberId = GetMemberId(); // This method would retrieve the actual member ID

        // Filter schedules based on the logged-in member and include coach information
        var schedules = _context.Schedules
                                .Include(s => s.Coach) // Include coach information first
                                .Where(s => s.MemberId == memberId && s.Date >= DateTime.Now) // Then filter by member ID and date
                                .ToList();

        return View(schedules);
    }

    // Method to get the logged-in member's ID (you need to implement this based on your logic)
    private int GetMemberId()
    {
        // Logic to retrieve member ID for the logged-in user
        
        return 1; 
    }


}

