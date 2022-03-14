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
        public RedirectToActionResult Add(string First_name,string Last_name,string Position,int NationalityId,int ClubId,int Age,int ShirtNumber,int Overall,bool isReal)
        {
            List<string> positions = new List<string>();
            positions.Add("Goalkeeper");
           
            positions.Add("Defender");
           
            positions.Add("Midfielder");
           
            positions.Add("Forward");
            if ( !positions.Contains(Position))
            {
                return RedirectToAction(actionName: "Index", controllerName: "Error");
            }
             else if (First_name == null || Last_name == null || Overall < 1 || ShirtNumber<1 || Age<1 || !DataService.GetClubs().Any(y => y.Id == ClubId) || !DataService.GetNations().Any(y=>y.Id == NationalityId))
            {
                return RedirectToAction(actionName: "Index", controllerName: "Error");
            }
            DataService.AddPlayer(First_name,Last_name,Position,Age,ShirtNumber,NationalityId,ClubId,Overall,isReal);
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
            if (!DataService.GetPlayers().Any(y => y.Id == id))
            {
                return RedirectToAction(actionName: "Index", controllerName: "Error");
            }
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
            if (!DataService.GetPlayers().Any(y => y.Id==id))
            {
                return RedirectToAction(actionName: "Index", controllerName: "Error");
            }
            x.player = DataService.GetPlayers().FirstOrDefault(y => y.Id == id);
            x.Clubs = DataService.GetClubs();
            x.Nations = DataService.GetNations();

            return View(x);
        }

        public RedirectToActionResult ConfirmEdit(int id, string FirstName, string LastName, string Position, int NationalityId, int ClubId, int Age, int Shirtnumber, int Overall, bool isReal,string password)
        {
            List<string> positions = new List<string>();
            positions.Add("Goalkeeper");

            positions.Add("Defender");

            positions.Add("Midfielder");

            positions.Add("Forward");
            if (password == "password")
            { 
                if (FirstName == null || LastName == null || Overall < 1 || Shirtnumber < 1 || Age < 1 || !DataService.GetClubs().Any(y => y.Id == ClubId) || !DataService.GetNations().Any(y => y.Id == NationalityId))
                {
                    return RedirectToAction(actionName: "Index", controllerName: "Error");
                }
                 else if (!positions.Contains(Position))
                {
                    return RedirectToAction(actionName: "Index", controllerName: "Error");
                }

                DataService.EditPlayer(id, FirstName, LastName, Position, NationalityId, ClubId, Age, Shirtnumber, Overall, isReal);
            }
            return RedirectToAction(actionName: "Index");
        }
        public IActionResult Delete(int id)
        {

            if (!DataService.GetPlayers().Any(y => y.Id == id))
            {
                return RedirectToAction(actionName: "Index", controllerName: "Error");
            }
            Player player = DataService.GetPlayers().FirstOrDefault(x => x.Id == id);
            return View(player);
        }

        public RedirectToActionResult Remove(int id, string password)
        {
            if (password == "password")
            {
                if (!DataService.GetPlayers().Any(y => y.Id == id))
                {
                    return RedirectToAction(actionName: "Index", controllerName: "Error");
                }
                DataService.DeletePlayer(id);
            }
            return RedirectToAction(actionName: "Index");
        }
    }
}
