using FutManager.Data;
using FutManager.Models;
using Microsoft.AspNetCore.Mvc;

namespace FutManager.Controllers
{
    public class PlayerController : Controller
    {
        public IActionResult Create()
        {
            ViewBag.Nationions = DataService.GetNations();
            ViewBag.Clubs = DataService.GetClubs();
            return View();
        }
        public RedirectToActionResult Add(string first_name,string last_name,string position,int nationalityId,int clubId,int age,int shirtnumber,int overall,bool isReal)
        {
            DataService.AddPlayer(first_name,last_name,position,age,shirtnumber,nationalityId,clubId,overall,isReal);
            return RedirectToAction(actionName: "Index");
        }

        public IActionResult Index()
        {
            List<Club> clubs = DataService.GetClubs();
            List<Nation> nations = DataService.GetNations();
            List<Player> players = new List<Player>(DataService.GetPlayers());
            players.ForEach(x =>
            {
                x.Club = clubs.FirstOrDefault(y => y.Id == x.ClubId);
                x.Nation = nations.FirstOrDefault(y => y.Id == x.NationalityId);
            });

            return View(players);
        }

        public IActionResult Details(int id)
        {
            List<Club> clubs = DataService.GetClubs();
            List<Nation> nations = DataService.GetNations();
            Player player = DataService.GetPlayers().FirstOrDefault(x => x.Id == id);
            player.Club = clubs.FirstOrDefault(y => y.Id == player.ClubId);
            player.Nation = nations.FirstOrDefault(y => y.Id == player.NationalityId);

            return View(player);
        }

    }
}
