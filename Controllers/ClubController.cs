using FutManager.Data;
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
            ViewBag.Clubs = DataService.GetClubs();
            return View();
        }
    }
}
