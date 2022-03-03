using FutManager.Data;
using FutManager.Models;
using Microsoft.AspNetCore.Mvc;

namespace FutManager.Controllers
{
    public class ClubController : Controller
    {
        public IActionResult Index()
        {
            List<Club> clubs = DataService.GetClubs();

            return View(clubs);
        }

        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Add(int id,string name,string league,int rating)
        {
            Club club = new Club(id, name, league, rating);
            DataService.AddClub(club);
            return View("Index");
        }

    }
}
