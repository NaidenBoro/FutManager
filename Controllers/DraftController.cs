using FutManager.Data;
using FutManager.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace FutManager.Controllers
{
    public class DraftController : Controller
    {
        public IActionResult Index()
        {
            List<Draft> drafts = DataService.GetDrafts();
            List<Player> players = new List<Player>(DataService.GetPlayers());
            drafts.ForEach(x =>
            {
                x.Goalkeeper = players.FirstOrDefault(y => y.Id == x.GoalkeeperId);
                x.LeftDefender = players.FirstOrDefault(y => y.Id == x.LeftDefenderId);
                x.LeftForward = players.FirstOrDefault(y => y.Id == x.LeftForwardId);
                x.LeftMidfielder = players.FirstOrDefault(y => y.Id == x.LeftMidfielderId);
                x.RightDefender = players.FirstOrDefault(y => y.Id == x.RightDefenderId);
                x.RightForward = players.FirstOrDefault(y => y.Id == x.RightForwardId);
                x.RightMidfielder = players.FirstOrDefault(y => y.Id == x.RightMidfielderId);
            });
            return View(drafts);
        }

        public IActionResult Create()
        {
            DraftAndPlayersAndManager x = new DraftAndPlayersAndManager();
            List<Player> players = new List<Player>(DataService.GetPlayers());
            Random rnd = new Random();
            List<Player> goalkeepers = players.Where(y => y.Position == "Goalkeeper").OrderBy(y => rnd.Next()).Take(4).ToList();
            if (goalkeepers.Count < 4)
            {
                goalkeepers.AddRange(players.Where(y => y.Position != "Goalkeeper").OrderBy(y => rnd.Next()).Take(4-goalkeepers.Count));
            }
            Console.WriteLine(goalkeepers.Last().Id);
            x.GoalKeeper = goalkeepers;



            
            return View(x);
        }
    }
}
