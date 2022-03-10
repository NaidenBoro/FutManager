﻿using FutManager.Data;
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
            List<Player> leftForwards = players.Where(y => y.Position == "Forwards").OrderBy(y => rnd.Next()).Take(4).ToList();
            if (leftForwards.Count < 4)
            {
                leftForwards.AddRange(players.Where(y => y.Position != "Forwards").OrderBy(y => rnd.Next()).Take(4 - leftForwards.Count));
            }
            x.LeftForwards = leftForwards;
            players = players.Except(leftForwards).ToList();


            List<Player> rightForwards = players.Where(y => y.Position == "Forwards").OrderBy(y => rnd.Next()).Take(4).ToList();
            if (rightForwards.Count < 4)
            {
                rightForwards.AddRange(players.Where(y => y.Position != "Forwards").OrderBy(y => rnd.Next()).Take(4 - rightForwards.Count));
            }
            x.RightForwards = rightForwards;
            players = players.Except(rightForwards).ToList();


            return View(x);
        }
    }
}
