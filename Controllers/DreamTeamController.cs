﻿using FutManager.Data;
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

        public IActionResult Details(int id)
        {
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
            x.RightMidfielder = players.FirstOrDefault(y => y.Id == x.RightMidfielderId);
            x.Manager = managers.FirstOrDefault(y => y.Id == x.ManagerId);

            return View(x);
        }

        public RedirectToActionResult Add(string name, string creator, int GoalkeeperId, int LeftDefenderId, int RightDefenderId, int LeftMidfielderId, int RightMidfielderId, int LeftForwardId, int RightForwardId, int ManagerId)
        {
            DataService.AddDreamTeam(name, creator, GoalkeeperId, LeftDefenderId, RightDefenderId, LeftMidfielderId, RightMidfielderId, LeftForwardId, RightForwardId, ManagerId);
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
                DataService.DeleteDreamteam(id);
            }
            return RedirectToAction(actionName: "Index");
        }
    }
}
