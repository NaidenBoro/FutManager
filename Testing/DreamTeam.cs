using FutManager.Controllers;
using FutManager.Data;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    public class DreamTeam
    {
        [OneTimeSetUp]
        public static void Setup()
        {
            DataService.AddNation("1", "1", 1);
            int nat = DataService.GetNations().Last().Id;
            DataService.AddClub("1", "1", 1);
            int c = DataService.GetClubs().Last().Id;
            for (int i = 0; i < 28; i++)
            {
                DataService.AddPlayer("a", "b", "Forward", i + 2, i + 2, nat, c, i + 2, true);
            }
            for (int i = 0; i < 4; i++)
            {
                DataService.AddManager("a", "b", i + 2, nat, c, i + 2, true);
            }
        }
        [OneTimeTearDown]
        public static void Teardown()
        {


            for (int i = 0; i < 28; i++)
            {
                DataService.DeletePlayer(DataService.GetPlayers().Last().Id);
            }
            for (int i = 0; i < 4; i++)
            {
                DataService.DeleteManager(DataService.GetManagers().Last().Id);

            }
            DataService.DeleteClub(DataService.GetClubs().Last().Id);
            DataService.DeleteNation(DataService.GetNations().Last().Id);
        }

        [Test]
        public void DataBaseTest()
        {
            int id = DataService.GetPlayers().Last().Id;
            int manager = DataService.GetManagers().Last().Id;
            DataService.AddDreamTeam("a", "b", id, id - 1, id - 2, id - 3, id - 4, id - 5, id - 6, manager);
            DataService.AddDreamTeam("x", "b", id, id - 1, id - 2, id - 3, id - 4, id - 5, id - 6, manager);

            Assert.AreEqual("x", DataService.GetDreamTeams().Last().Name);
            Assert.AreEqual("b", DataService.GetDreamTeams().Last().Creator);
            Assert.AreEqual(id + 1 - 1, DataService.GetDreamTeams().Last().GoalkeeperId);
            Assert.AreEqual(id + 1 - 2, DataService.GetDreamTeams().Last().LeftDefenderId);
            Assert.AreEqual(id + 1 - 3, DataService.GetDreamTeams().Last().RightDefenderId);
            Assert.AreEqual(id + 1 - 4, DataService.GetDreamTeams().Last().LeftMidfielderId);
            Assert.AreEqual(id + 1 - 5, DataService.GetDreamTeams().Last().RightMidfielderId);
            Assert.AreEqual(id + 1 - 6, DataService.GetDreamTeams().Last().LeftForwardId);
            Assert.AreEqual(id + 1 - 7, DataService.GetDreamTeams().Last().RightForwardId);
            Assert.AreEqual(manager, DataService.GetDreamTeams().Last().ManagerId);



            DataService.DeleteDreamTeam(DataService.GetDreamTeams().Last().Id);
            Assert.AreEqual("a", DataService.GetDreamTeams().Last().Name);
            DataService.DeleteDreamTeam(DataService.GetDreamTeams().Last().Id);
        }
        [Test]
        public void DetailsShouldRedirectToErrorPageOnInvalidId()
        {
            DreamTeamController cntr = new DreamTeamController();
            var result = cntr.Details(-1) as RedirectToActionResult;
            Assert.AreEqual("Error", result.ControllerName);
        }

        [Test]
        public void DetailsShouldRedirectToViewOnValidId()
        {
            int id = DataService.GetPlayers().Last().Id;
            int manager = DataService.GetManagers().Last().Id;
            DataService.AddDreamTeam("x", "b", id, id - 1, id - 2, id - 3, id - 4, id - 5, id - 6, manager);
            DreamTeamController cntr = new DreamTeamController();
            var result = cntr.Details(DataService.GetDreamTeams().Last().Id) as ViewResult;
            Assert.IsNotNull(result);
            DataService.DeleteDreamTeam(DataService.GetDreamTeams().Last().Id);
        }

        [Test]
        public void AddShouldRedirectToErrorPageOnInvalidId()
        {
            int id = DataService.GetPlayers().Last().Id;
            int manager = DataService.GetManagers().Last().Id;
            DataService.AddDreamTeam("x", "b", id, id - 1, id - 2, id - 3, id - 4, id - 5, id - 6, manager);
            DreamTeamController cntr = new DreamTeamController();
            cntr.Add("a", creator: null, 1, 2, 3, 4, 5, 6, 7, 1);
            Assert.AreEqual("x", DataService.GetDreamTeams().Last().Name);

            var result = cntr.Add("a", "b", -1, 2, 3, 4, 5, 6, 7, 1) as RedirectToActionResult;
            Assert.AreEqual("Error", result.ControllerName);

            result = cntr.Add("a", "b", 1, 2, 3, 4, 5, 6, 7, -1) as RedirectToActionResult;
            Assert.AreEqual("Error", result.ControllerName);

            result = cntr.Add(name: null, "b", 1, 2, 3, 4, 5, 6, 7, 1) as RedirectToActionResult;
            Assert.AreEqual("Error", result.ControllerName);

            result = cntr.Add("a", "b", 1, 2, 2, 2, 5, 2, 7, 1) as RedirectToActionResult;
            Assert.AreEqual("Error", result.ControllerName);
            DataService.DeleteDreamTeam(DataService.GetDreamTeams().Last().Id);


        }

        [Test]
        public void AddShouldCreateItem()
        {
            DreamTeamController cntr = new DreamTeamController();
            int id = DataService.GetPlayers().Last().Id;
            int manager = DataService.GetManagers().Last().Id;
            cntr.Add("x", "b", id, id - 1, id - 2, id - 3, id - 4, id - 5, id - 6, manager);
            Assert.AreEqual("x", DataService.GetDreamTeams().Last().Name);
            DataService.DeleteDreamTeam(DataService.GetDreamTeams().Last().Id);
        }

        [Test]
        public void EditConfirmedShouldRedirectToErrorPageOnInvalidInput()
        {
            DataService.AddClub("2", "2", 2);
            DataService.AddNation("2", "2", 2);
            int club_id = DataService.GetClubs().Last().Id;
            int nat_id = DataService.GetNations().Last().Id;
            DataService.AddPlayer("1", "2", "Goalkeeper", 1, 2, nat_id, club_id, 1, true);
            DataService.AddPlayer("1", "2", "Defefender", 1, 2, nat_id, club_id, 1, true);
            DataService.AddPlayer("1", "2", "Defender", 1, 2, nat_id, club_id, 1, true);
            DataService.AddPlayer("1", "2", "Midfielder", 1, 2, nat_id, club_id, 1, true);
            DataService.AddPlayer("1", "2", "Midfielder", 1, 2, nat_id, club_id, 1, true);
            DataService.AddPlayer("1", "2", "Forward", 1, 2, nat_id, club_id, 1, true);
            DataService.AddPlayer("1", "2", "Forward", 1, 2, nat_id, club_id, 1, true);
            DataService.AddManager("1", "2", 1, nat_id, club_id, 1, true);
            int player_id = DataService.GetPlayers().Last().Id;
            int manager_id = DataService.GetManagers().Last().Id;
            DataService.AddDreamTeam("x", "b", player_id, player_id - 1, player_id - 2, player_id - 3, player_id - 4, player_id - 5, player_id - 6, manager_id);

            int id = DataService.GetDreamTeams().Last().Id;
            int player = DataService.GetDreamTeams().Last().Id;
            int manager = DataService.GetDreamTeams().Last().Id;

            DreamTeamController controller = new DreamTeamController();

            var result = controller.EditConfirm(id, "x", "b", player, player - 1, player - 2, player - 3, player - 4, player - 5, player - 6, manager);
            Assert.AreEqual("Error", result.ControllerName);

            result = controller.EditConfirm(id, "x", "b", player, player - 1, player - 2, player - 3, player - 4, player - 5, player - 6, manager);
            Assert.AreEqual("Error", result.ControllerName);

            result = controller.EditConfirm(id, "x", "b", player, player - 1, player - 2, player - 3, player - 4, player - 5, player - 6, manager);
            Assert.AreEqual("Error", result.ControllerName);

            result = controller.EditConfirm(id, "x", "b", player, player - 1, player - 2, player - 3, player - 4, player - 5, player - 6, manager);
            Assert.AreEqual("Error", result.ControllerName);

            result = controller.EditConfirm(id, "x", "b", player, player - 1, player - 2, player - 3, player - 4, player - 5, player - 6, manager);
            Assert.AreEqual("Error", result.ControllerName);

            result = controller.EditConfirm(id, "x", "b", player, player - 1, player - 2, player - 3, player - 4, player - 5, player - 6, manager);
            Assert.AreEqual("Error", result.ControllerName);

            DataService.DeleteDreamTeam(DataService.GetDreamTeams().Last().Id);
            DataService.DeleteClub(club_id);
            DataService.DeleteNation(nat_id);
        }

        [Test]
        public void EditShouldRedirectToViewOnValidId()
        {

            DataService.AddClub("2", "2", 2);
            DataService.AddNation("2", "2", 2);
            int club_id = DataService.GetClubs().Last().Id;
            int nat_id = DataService.GetNations().Last().Id;
            DataService.AddPlayer("1", "2", "Goalkeeper", 1, 2, nat_id, club_id, 1, true);
            DataService.AddPlayer("1", "2", "Defefender", 1, 2, nat_id, club_id, 1, true);
            DataService.AddPlayer("1", "2", "Defender", 1, 2, nat_id, club_id, 1, true);
            DataService.AddPlayer("1", "2", "Midfielder", 1, 2, nat_id, club_id, 1, true);
            DataService.AddPlayer("1", "2", "Midfielder", 1, 2, nat_id, club_id, 1, true);
            DataService.AddPlayer("1", "2", "Forward", 1, 2, nat_id, club_id, 1, true);
            DataService.AddPlayer("1", "2", "Forward", 1, 2, nat_id, club_id, 1, true);
            DataService.AddManager("1", "2", 1, nat_id, club_id, 1, true);
            int player_id = DataService.GetPlayers().Last().Id;
            int manager_id = DataService.GetManagers().Last().Id;
            DataService.AddDreamTeam("x", "b", player_id, player_id - 1, player_id - 2, player_id - 3, player_id - 4, player_id - 5, player_id - 6, manager_id);

            DreamTeamController controller = new DreamTeamController();
            int id = DataService.GetPlayers().Last().Id;
            int manager = DataService.GetManagers().Last().Id;
            controller.EditConfirm(1, "x", "b", id, id - 1, id - 2, id - 3, id - 4, id - 5, id - 6, manager);
            Assert.AreEqual("1", DataService.GetManagers().Last().FirstName);

            DataService.DeleteDreamTeam(DataService.GetDreamTeams().Last().Id);
            DataService.DeleteClub(club_id);
            DataService.DeleteNation(nat_id);
        }

        

        [Test]
        public void RemoveWrongPasswordShouldNotChangeItem()
        {
            DreamTeamController cntr = new DreamTeamController();
            int id = DataService.GetPlayers().Last().Id;
            int manager = DataService.GetManagers().Last().Id;
            cntr.Add("x", "b", id, id - 1, id - 2, id - 3, id - 4, id - 5, id - 6, manager);
            cntr.Add("a", "b", id, id - 1, id - 2, id - 3, id - 4, id - 5, id - 6, manager);
            cntr.Remove(DataService.GetDreamTeams().Last().Id, "passord");
            Assert.AreEqual("a", DataService.GetDreamTeams().Last().Name);
            DataService.DeleteDreamTeam(DataService.GetDreamTeams().Last().Id);
            DataService.DeleteDreamTeam(DataService.GetDreamTeams().Last().Id);
        }

        [Test]
        public void ValidRemoveShouldDeleteItem()
        {
            DreamTeamController cntr = new DreamTeamController();

            int id = DataService.GetPlayers().Last().Id;
            int manager = DataService.GetManagers().Last().Id;
            cntr.Add("x", "b", id, id - 1, id - 2, id - 3, id - 4, id - 5, id - 6, manager);
            cntr.Add("a", "b", id, id - 1, id - 2, id - 3, id - 4, id - 5, id - 6, manager);
            int dreamteam = DataService.GetDreamTeams().Last().Id;
            cntr.Remove(id: dreamteam, password: "password");
            Assert.AreEqual("x", DataService.GetDreamTeams().Last().Name);
            DataService.DeleteDreamTeam(dreamteam - 1);
        }
        [Test]
        public void RemoveWithInvalidIdShouldRedirectToError()
        {
            DreamTeamController cntr = new DreamTeamController();
            var result = cntr.Remove(id: -1, password: "password") as RedirectToActionResult;
            Assert.AreEqual("Error", result.ControllerName);
        }
        [Test]
        public void DeleteWithInvalidIdShouldRedirectToError()
        {

            DreamTeamController controller = new DreamTeamController();
            var result = controller.Delete(-1) as RedirectToActionResult;
            Assert.AreEqual("Error", result.ControllerName);

        }
    }
}

