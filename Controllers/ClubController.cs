using FutManager.Data;
using FutManager.Models;
using Microsoft.AspNetCore.Mvc;

namespace FutManager.Controllers
{
    public class ClubController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Clubs()
        {
            List<Club> clubs = DataService.GetClubs();

            return View(clubs);
        }
    }
}
