using FutManager.Data;
using FutManager.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace FutManager.Controllers
{
    public class DreamTeamController : Controller
    {
        public IActionResult Index()
        {
            List<DreamTeam> dreamTeams = DataService.GetDreamTeams();
            List<Player> players = new List<Player>(DataService.GetPlayers());
            List<Manager> managers = new List<Manager>(DataService.GetManagers());
            dreamTeams.ForEach(x =>
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
            return View(dreamTeams);
        }

        public IActionResult Create()
        {
            DreamTeamAndPlayersAndManager x = new DreamTeamAndPlayersAndManager();
            List<Player> players = new List<Player>(DataService.GetPlayers());
            List<Manager> managers = new List<Manager>(DataService.GetManagers());

            /*if(players.Count() < 28)
            {
                return View(players);
            }*/

            //Goalkeeper
            List<Player> goalkeepers = players.Where(y => y.Position == "Goalkeeper").ToList();
            if (goalkeepers.Count < 1)
            {
                goalkeepers.AddRange(players.Where(y => y.Position != "Goalkeeper"));
            }
            x.GoalKeepers = goalkeepers;
            //players = players.Except(goalkeepers).ToList();

            //Defenders
            List<Player> leftDefenders = players.Where(y => y.Position == "Defender").ToList();
            if (leftDefenders.Count < 1)
            {
                leftDefenders.AddRange(players.Where(y => y.Position != "Defender"));
            }
            x.LeftDefenders = leftDefenders;
            //players = players.Except(leftDefenders).ToList();


            List<Player> rightDefenders = players.Where(y => y.Position == "Defender").ToList();
            if (rightDefenders.Count < 1)
            {
                rightDefenders.AddRange(players.Where(y => y.Position != "Defender"));
            }
            x.RightDefenders = rightDefenders;
            //players = players.Except(rightDefenders).ToList();

            //Midfielders
            List<Player> leftMidfielders = players.Where(y => y.Position == "Midfielder").ToList();
            if (leftMidfielders.Count < 1)
            {
                leftMidfielders.AddRange(players.Where(y => y.Position != "Midfielder"));
            }
            x.LeftMidfielders = leftMidfielders;
            //players = players.Except(leftMidfielders).ToList();


            List<Player> rightMidfielders = players.Where(y => y.Position == "Midfielder").ToList();
            if (rightMidfielders.Count < 1)
            {
                rightMidfielders.AddRange(players.Where(y => y.Position != "Midfielder"));
            }
            x.RightMidfielders = rightMidfielders;
            //players = players.Except(rightMidfielders).ToList();

            // Forwards
            List<Player> leftForwards = players.Where(y => y.Position == "Forward").ToList();
            if (leftForwards.Count < 1)
            {
                leftForwards.AddRange(players.Where(y => y.Position != "Forward"));
            }
            x.LeftForwards = leftForwards;
            //players = players.Except(leftForwards).ToList();


            List<Player> rightForwards = players.Where(y => y.Position == "Forward").ToList();
            if (rightForwards.Count < 1)
            {
                rightForwards.AddRange(players.Where(y => y.Position != "Forward"));
            }
            x.RightForwards = rightForwards;
            //players = players.Except(rightForwards).ToList();

            //Manager
            List<Manager> coaches = managers.ToList();
            x.Managers = coaches;
            //managers = managers.Except(coaches).ToList();

            return View(x);
        }

        public IActionResult Details(int id)
        {
            if (!DataService.GetDreamTeams().Any(x => x.Id == id))
            {
                return RedirectToAction(actionName: "Index", controllerName: "Error");
            }
            List<DreamTeam> dreamTeams = new List<DreamTeam>(DataService.GetDreamTeams());
            DreamTeam x = dreamTeams.FirstOrDefault(y => id == y.Id);
            List<Player> players = new List<Player>(DataService.GetPlayers());
            List<Manager> managers = new List<Manager>(DataService.GetManagers());
            x.Goalkeeper = players.FirstOrDefault(y => y.Id == x.GoalkeeperId);
            x.LeftDefender = players.FirstOrDefault(y => y.Id == x.LeftDefenderId);
            x.RightDefender = players.FirstOrDefault(y => y.Id == x.RightDefenderId);
            x.LeftMidfielder = players.FirstOrDefault(y => y.Id == x.LeftMidfielderId);
            x.RightMidfielder = players.FirstOrDefault(y => y.Id == x.RightMidfielderId);
            x.LeftForward = players.FirstOrDefault(y => y.Id == x.LeftForwardId);
            x.RightForward = players.FirstOrDefault(y => y.Id == x.RightForwardId);
            x.Manager = managers.FirstOrDefault(y => y.Id == x.ManagerId);

            return View(x);
        }

        public RedirectToActionResult Add(string name, string creator, int GoalkeeperId, int LeftDefenderId, int RightDefenderId, int LeftMidfielderId, int RightMidfielderId, int LeftForwardId, int RightForwardId, int ManagerId)
        {
            if (name == null || creator == null || !DataService.GetPlayers().Any(x => x.Id == GoalkeeperId) || !DataService.GetPlayers().Any(x => x.Id == LeftDefenderId) || !DataService.GetPlayers().Any(x => x.Id == RightDefenderId) || !DataService.GetPlayers().Any(x => x.Id == LeftMidfielderId) || !DataService.GetPlayers().Any(x => x.Id == RightMidfielderId) || !DataService.GetPlayers().Any(x => x.Id == LeftForwardId) || !DataService.GetPlayers().Any(x => x.Id == RightForwardId) || !DataService.GetManagers().Any(x => x.Id == ManagerId))
            {
                return RedirectToAction(actionName: "Index", controllerName: "Error");
            }
            List<int> ids = new List<int>();
            ids.Add(GoalkeeperId);
            ids.Add(LeftDefenderId);
            ids.Add(RightDefenderId);
            ids.Add(LeftMidfielderId);
            ids.Add(RightMidfielderId);
            ids.Add(LeftForwardId);
            ids.Add(RightForwardId);
            if (ids.Count != ids.Distinct().ToList().Count)
            {
                return RedirectToAction(actionName: "Index", controllerName: "Error");
            }

            DataService.AddDreamTeam(name, creator, GoalkeeperId, LeftDefenderId, RightDefenderId, LeftMidfielderId, RightMidfielderId, LeftForwardId, RightForwardId, ManagerId);
            return RedirectToAction(actionName: "Index");
        }

        public IActionResult Delete(int id)
        {
            if (!DataService.GetDreamTeams().Any(x => x.Id == id))
            {
                return RedirectToAction(actionName: "Index", controllerName: "Error");
            }
            return View(id);
        }
        public RedirectToActionResult Remove(int id, string password)
        {
            if (!DataService.GetDreamTeams().Any(x => x.Id == id))
            {
                return RedirectToAction(actionName: "Index", controllerName: "Error");
            }
            if (password == "password")
            {
                DataService.DeleteDreamTeam(id);
            }
            return RedirectToAction(actionName: "Index");
        }

        public IActionResult Edit(int id)
        {
            if (!DataService.GetDreamTeams().Any(x => x.Id == id))
            {
                return RedirectToAction(actionName: "Index", controllerName: "Error");
            }

            DreamTeamAndPlayersAndManager x = new DreamTeamAndPlayersAndManager();
            List<Player> players = new List<Player>(DataService.GetPlayers());
            List<Manager> managers = new List<Manager>(DataService.GetManagers());

            DreamTeam y = DataService.GetDreamTeams().FirstOrDefault(y => y.Id == id);
            x.Id = y.Id;
            x.Name = y.Name;
            x.Creator = y.Creator;
            x.GoalkeeperId = y.GoalkeeperId;
            x.LeftDefenderId = y.LeftDefenderId;
            x.RightDefenderId = y.RightDefenderId;
            x.LeftMidfielderId = y.LeftMidfielderId;
            x.RightMidfielderId = y.RightMidfielderId;
            x.LeftForwardId = y.LeftForwardId;
            x.RightForwardId = y.RightForwardId;
            x.ManagerId = y.ManagerId;

            Random rnd = new Random();
            //Goalkeeper
            List<Player> goalkeepers = players.Where(y => y.Position == "Goalkeeper").OrderBy(y => rnd.Next()).ToList();
            if (goalkeepers.Count < 1)
            {
                goalkeepers.AddRange(players.Where(y => y.Position != "Goalkeeper").OrderBy(y => rnd.Next()));
            }
            x.GoalKeepers = goalkeepers;
            //players = players.Except(goalkeepers).ToList();

            //Defenders
            List<Player> leftDefenders = players.Where(y => y.Position == "Defender").OrderBy(y => rnd.Next()).ToList();
            if (leftDefenders.Count < 1)
            {
                leftDefenders.AddRange(players.Where(y => y.Position != "Defender").OrderBy(y => rnd.Next()));
            }
            x.LeftDefenders = leftDefenders;
            //players = players.Except(leftDefenders).ToList();


            List<Player> rightDefenders = players.Where(y => y.Position == "Defender").OrderBy(y => rnd.Next()).ToList();
            if (rightDefenders.Count < 1)
            {
                rightDefenders.AddRange(players.Where(y => y.Position != "Defender").OrderBy(y => rnd.Next()));
            }
            x.RightDefenders = rightDefenders;
            //players = players.Except(rightDefenders).ToList();

            //Midfielders
            List<Player> leftMidfielders = players.Where(y => y.Position == "Midfielder").OrderBy(y => rnd.Next()).ToList();
            if (leftMidfielders.Count < 1)
            {
                leftMidfielders.AddRange(players.Where(y => y.Position != "Midfielder").OrderBy(y => rnd.Next()));
            }
            x.LeftMidfielders = leftMidfielders;
            //players = players.Except(leftMidfielders).ToList();


            List<Player> rightMidfielders = players.Where(y => y.Position == "Midfielder").OrderBy(y => rnd.Next()).ToList();
            if (rightMidfielders.Count < 1)
            {
                rightMidfielders.AddRange(players.Where(y => y.Position != "Midfielder").OrderBy(y => rnd.Next()));
            }
            x.RightMidfielders = rightMidfielders;
            //players = players.Except(rightMidfielders).ToList();

            // Forwards
            List<Player> leftForwards = players.Where(y => y.Position == "Forward").OrderBy(y => rnd.Next()).ToList();
            if (leftForwards.Count < 1)
            {
                leftForwards.AddRange(players.Where(y => y.Position != "Forward").OrderBy(y => rnd.Next()));
            }
            x.LeftForwards = leftForwards;
            //players = players.Except(leftForwards).ToList();


            List<Player> rightForwards = players.Where(y => y.Position == "Forward").OrderBy(y => rnd.Next()).ToList();
            if (rightForwards.Count < 1)
            {
                rightForwards.AddRange(players.Where(y => y.Position != "Forward").OrderBy(y => rnd.Next()));
            }
            x.RightForwards = rightForwards;
            //players = players.Except(rightForwards).ToList();

            //Manager
            List<Manager> coaches = managers.OrderBy(y => rnd.Next()).ToList();
            x.Managers = coaches;
            //managers = managers.Except(coaches).ToList();

            

            return View(x);
        }
        public RedirectToActionResult EditConfirm(int id,string name, string creator, int GoalkeeperId, int LeftDefenderId, int RightDefenderId, int LeftMidfielderId, int RightMidfielderId, int LeftForwardId, int RightForwardId, int ManagerId)
        {
            if (name == null || creator == null || !DataService.GetPlayers().Any(x => x.Id == GoalkeeperId) || !DataService.GetPlayers().Any(x => x.Id == LeftDefenderId) || !DataService.GetPlayers().Any(x => x.Id == RightDefenderId) || !DataService.GetPlayers().Any(x => x.Id == LeftMidfielderId) || !DataService.GetPlayers().Any(x => x.Id == RightMidfielderId) || !DataService.GetPlayers().Any(x => x.Id == LeftForwardId) || !DataService.GetPlayers().Any(x => x.Id == RightForwardId) || !DataService.GetManagers().Any(x => x.Id == ManagerId))
            {
                return RedirectToAction(actionName: "Index", controllerName: "Error");
            }
            List<int> ids = new List<int>();
            ids.Add(GoalkeeperId);
            ids.Add(LeftDefenderId);
            ids.Add(RightDefenderId);
            ids.Add(LeftMidfielderId);
            ids.Add(RightMidfielderId);
            ids.Add(LeftForwardId);
            ids.Add(RightForwardId);
            if (ids.Count != ids.Distinct().ToList().Count)
            {
                return RedirectToAction(actionName: "Index", controllerName: "Error");
            }

            DataService.EditDreamTeam(id,name, creator, GoalkeeperId, LeftDefenderId, RightDefenderId, LeftMidfielderId, RightMidfielderId, LeftForwardId, RightForwardId, ManagerId);
            return RedirectToAction(actionName: "Index");
        }
    }
}
