using Microsoft.AspNetCore.Mvc;

namespace TennisCoach.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
