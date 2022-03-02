using FutManager.Data;
using Microsoft.AspNetCore.Mvc;

namespace FutManager.Controllers
{
    public class PlayerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
        
        public IActionResult Players()
        {
            ViewBag.Nations = DataService.GetNations();
            ViewBag.Clubs = DataService.GetClubs();
            ViewBag.Players = DataService.GetPlayers();
            return View();
        }

    }
}
