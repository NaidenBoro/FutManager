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
            List<Manager> managers = new List<Manager>(DataService.GetManagers());
            drafts.ForEach(x =>
            {
                x.Goalkeeper = players.FirstOrDefault(y => y.Id == x.GoalkeeperId);
                x.LeftDefender = players.FirstOrDefault(y => y.Id == x.LeftDefenderId);
                x.LeftForward = players.FirstOrDefault(y => y.Id == x.LeftForwardId);
                x.LeftMidfielder = players.FirstOrDefault(y => y.Id == x.LeftMidfielderId);
                x.RightDefender = players.FirstOrDefault(y => y.Id == x.RightDefenderId);
                x.RightForward = players.FirstOrDefault(y => y.Id == x.RightForwardId);
                x.RightMidfielder = players.FirstOrDefault(y => y.Id == x.RightMidfielderId);
                x.Manager = managers.FirstOrDefault(y => y.Id == x.ManagerId);
            });
            return View(drafts);
        }

        public IActionResult Create()
        {
            DraftAndPlayersAndManager x = new DraftAndPlayersAndManager();
            List<Player> players = new List<Player>(DataService.GetPlayers());
            List<Manager> managers = new List<Manager>(DataService.GetManagers());

            /*if(players.Count() < 28)
            {
                return View(players);
            }*/

            Random rnd = new Random();
            //Goalkeeper
            List<Player> goalkeepers = players.Where(y => y.Position == "Goalkeeper").OrderBy(y => rnd.Next()).Take(4).ToList();
            if (goalkeepers.Count < 4)
            {
                goalkeepers.AddRange(players.Where(y => y.Position != "Goalkeeper").OrderBy(y => rnd.Next()).Take(4-goalkeepers.Count));
            }
            x.GoalKeepers = goalkeepers;
            players = players.Except(goalkeepers).ToList();

            //Defenders
            List<Player> leftDefenders = players.Where(y => y.Position == "Defender").OrderBy(y => rnd.Next()).Take(4).ToList();
            if (leftDefenders.Count < 4)
            {
                leftDefenders.AddRange(players.Where(y => y.Position != "Defender").OrderBy(y => rnd.Next()).Take(4 - leftDefenders.Count));
            }
            x.LeftDefenders = leftDefenders;
            players = players.Except(leftDefenders).ToList();


            List<Player> rightDefenders = players.Where(y => y.Position == "Defender").OrderBy(y => rnd.Next()).Take(4).ToList();
            if (rightDefenders.Count < 4)
            {
                rightDefenders.AddRange(players.Where(y => y.Position != "Defender").OrderBy(y => rnd.Next()).Take(4 - rightDefenders.Count));
            }
            x.RightDefenders = rightDefenders;
            players = players.Except(rightDefenders).ToList();

            //Midfielders
            List<Player> leftMidfielders = players.Where(y => y.Position == "Midfielder").OrderBy(y => rnd.Next()).Take(4).ToList();
            if (leftMidfielders.Count < 4)
            {
                leftMidfielders.AddRange(players.Where(y => y.Position != "Midfielder").OrderBy(y => rnd.Next()).Take(4 - leftMidfielders.Count));
            }
            x.LeftMidfielders = leftMidfielders;
            players = players.Except(leftMidfielders).ToList();


            List<Player> rightMidfielders = players.Where(y => y.Position == "Midfielder").OrderBy(y => rnd.Next()).Take(4).ToList();
            if (rightMidfielders.Count < 4)
            {
                rightMidfielders.AddRange(players.Where(y => y.Position != "Midfielder").OrderBy(y => rnd.Next()).Take(4 - rightMidfielders.Count));
            }
            x.RightMidfielders = rightMidfielders;
            players = players.Except(rightMidfielders).ToList();

            // Forwards
            List<Player> leftForwards = players.Where(y => y.Position == "Forward").OrderBy(y => rnd.Next()).Take(4).ToList();
            if (leftForwards.Count < 4)
            {
                leftForwards.AddRange(players.Where(y => y.Position != "Forward").OrderBy(y => rnd.Next()).Take(4 - leftForwards.Count));
            }
            x.LeftForwards = leftForwards;
            players = players.Except(leftForwards).ToList();


            List<Player> rightForwards = players.Where(y => y.Position == "Forward").OrderBy(y => rnd.Next()).Take(4).ToList();
            if (rightForwards.Count < 4)
            {
                rightForwards.AddRange(players.Where(y => y.Position != "Forward").OrderBy(y => rnd.Next()).Take(4 - rightForwards.Count));
            }
            x.RightForwards = rightForwards;
            players = players.Except(rightForwards).ToList();

            //Manager
            List<Manager> coaches = managers.OrderBy(y => rnd.Next()).Take(4).ToList();
            x.Managers = coaches;
            managers = managers.Except(coaches).ToList();

            return View(x);
        }

        public IActionResult Details(int id) {
            if(!DataService.GetDrafts().Any(x=>x.Id == id))
            {
                return RedirectToAction(actionName: "Index", controllerName: "Error");
            }
            List<Draft> drafts = new List<Draft>(DataService.GetDrafts());
            Draft x = drafts.FirstOrDefault(y => id == y.Id);
            List<Player> players = new List<Player>(DataService.GetPlayers());
            List<Manager> managers = new List<Manager>(DataService.GetManagers());
            x.Goalkeeper = players.FirstOrDefault(y =>y.Id == x.GoalkeeperId);
            x.LeftDefender = players.FirstOrDefault(y => y.Id == x.LeftDefenderId);
            x.RightDefender = players.FirstOrDefault(y =>y.Id == x.RightDefenderId);
            x.LeftMidfielder = players.FirstOrDefault(y =>y.Id == x.LeftMidfielderId);
            x.RightMidfielder = players.FirstOrDefault(y =>y.Id == x.RightMidfielderId);
            x.LeftForward = players.FirstOrDefault(y =>y.Id == x.LeftForwardId);
            x.RightForward = players.FirstOrDefault(y =>y.Id == x.RightForwardId);
            x.Manager = managers.FirstOrDefault(y =>y.Id == x.ManagerId);
            
            return View(x);
        }

        public RedirectToActionResult Add(string name, string creator, int GoalkeeperId, int LeftDefenderId, int RightDefenderId, int LeftMidfielderId, int RightMidfielderId,int LeftForwardId, int RightForwardId, int ManagerId)
        {
            if (name==null||creator==null||!DataService.GetPlayers().Any(x=>x.Id==GoalkeeperId) || !DataService.GetPlayers().Any(x => x.Id == LeftDefenderId) || !DataService.GetPlayers().Any(x => x.Id == RightDefenderId) || !DataService.GetPlayers().Any(x => x.Id == LeftMidfielderId) || !DataService.GetPlayers().Any(x => x.Id == RightMidfielderId) || !DataService.GetPlayers().Any(x => x.Id == LeftForwardId) || !DataService.GetPlayers().Any(x => x.Id == RightForwardId) || !DataService.GetManagers().Any(x => x.Id == ManagerId))
            {
                return RedirectToAction(actionName: "Index", controllerName: "Error");
            }
            DataService.AddDraft(name,creator,GoalkeeperId,LeftDefenderId,RightDefenderId,LeftMidfielderId,RightMidfielderId,LeftForwardId,RightForwardId,ManagerId);
            return RedirectToAction(actionName: "Index");
        }

        public IActionResult Delete(int id)
        {
            if (!DataService.GetDrafts().Any(x => x.Id == id))
            {
                return RedirectToAction(actionName: "Index", controllerName: "Error");
            }
            return View(id);
        }
        public RedirectToActionResult Remove(int id, string password)
        {
            if (!DataService.GetDrafts().Any(x => x.Id == id))
            {
                return RedirectToAction(actionName: "Index", controllerName: "Error");
            }
            if (password == "password")
            {
                DataService.DeleteDraft(id);
            }
            return RedirectToAction(actionName: "Index");
        }
    }
}
