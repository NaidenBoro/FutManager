using FutManager.Data;
using FutManager.Models;
using Microsoft.AspNetCore.Mvc;

namespace FutManager.Controllers
{
    public class PlayerController : Controller
    {
        public IActionResult Create()
        {
            PlayerAndClubsAndNations x = new PlayerAndClubsAndNations();
            x.Clubs = DataService.GetClubs();
            x.Nations = DataService.GetNations();
            
            return View(x);
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

        public IActionResult Edit(int id)
        {
            PlayerAndClubsAndNations x = new PlayerAndClubsAndNations();

            x.player = DataService.GetPlayers().FirstOrDefault(y => y.Id == id);
            x.Clubs = DataService.GetClubs();
            x.Nations = DataService.GetNations();

            return View(x);
        }

        public RedirectToActionResult ConfirmEdit(int id, string first_name, string last_name, string position, int nationalityId, int clubId, int age, int shirtnumber, int overall, bool isReal)
        {
            DataService.EditPlayer(id,first_name,last_name,position, nationalityId, clubId, age, shirtnumber, overall, isReal);
            return RedirectToAction(actionName: "Index");
        }
        public IActionResult Delete(int id)
        {
            return View(id);
        }

        public RedirectToActionResult Remove(int id, string password)
        {
            if (password == "password")
            {
                DataService.DeletePlayer(id);
            }
            return RedirectToAction(actionName: "Index");
        }
    }
}
