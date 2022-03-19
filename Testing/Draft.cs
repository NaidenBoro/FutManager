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
    public class Draft
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
                DataService.AddPlayer("a","b","Forward",i+2,i+2,nat,c,i+2,true);
            }
            for (int i = 0; i < 4; i++)
            {
                DataService.AddManager("a", "b", i + 2, nat, c, i + 2, true);
            }
        }
        [OneTimeTearDown]
        public static void Teardown()
        {
            DataService.DeleteNation(DataService.GetNations().Last().Id);
            DataService.DeleteClub(DataService.GetClubs().Last().Id);
            for (int i = 0; i < 28; i++)
            {
                DataService.DeletePlayer(DataService.GetPlayers().Last().Id);
            }
            for (int i = 0; i < 4; i++)
            {
                DataService.DeleteManager(DataService.GetManagers().Last().Id);
            }
        }

        [Test]
        public void DataBaseTest()
        {
            int id = DataService.GetPlayers().Last().Id;
            int manager = DataService.GetManagers().Last().Id;
            DataService.AddDraft("a", "b", id, id - 1, id - 2, id - 3, id - 4, id - 5, id - 6, manager);
            DataService.AddDraft("x", "b", id, id - 1, id - 2, id - 3, id - 4, id - 5, id - 6, manager);

            Assert.AreEqual("x", DataService.GetDrafts().Last().Name);
            Assert.AreEqual("b", DataService.GetDrafts().Last().Creator);
            Assert.AreEqual(id+1-1, DataService.GetDrafts().Last().GoalkeeperId);
            Assert.AreEqual(id+1-2, DataService.GetDrafts().Last().LeftDefenderId);
            Assert.AreEqual(id+1-3, DataService.GetDrafts().Last().RightDefenderId);
            Assert.AreEqual(id+1-4, DataService.GetDrafts().Last().LeftMidfielderId);
            Assert.AreEqual(id+1-5, DataService.GetDrafts().Last().RightMidfielderId);
            Assert.AreEqual(id+1-6, DataService.GetDrafts().Last().LeftForwardId);
            Assert.AreEqual(id+1-7, DataService.GetDrafts().Last().RightForwardId);
            Assert.AreEqual(manager, DataService.GetDrafts().Last().ManagerId);

            

            DataService.DeleteDraft(DataService.GetDrafts().Last().Id);
            Assert.AreEqual("a", DataService.GetDrafts().Last().Name);
            DataService.DeleteDraft(DataService.GetDrafts().Last().Id);
        }
        [Test]
        public void DetailsShouldRedirectToErrorPageOnInvalidId()
        {
            DraftController cntr = new DraftController();
            var result = cntr.Details(-1) as RedirectToActionResult;
            Assert.AreEqual("Error", result.ControllerName);
        }

        [Test]
        public void DetailsShouldRedirectToViewOnValidId()
        {
            int id = DataService.GetPlayers().Last().Id;
            int manager = DataService.GetManagers().Last().Id;
            DataService.AddDraft("x", "b", id, id - 1, id - 2, id - 3, id - 4, id - 5, id - 6, manager);
            DraftController cntr = new DraftController();
            var result = cntr.Details(DataService.GetDrafts().Last().Id) as ViewResult;
            Assert.IsNotNull(result);
            DataService.DeleteDraft(DataService.GetDrafts().Last().Id);
        }

        [Test]
        public void AddShouldRedirectToErrorPageOnInvalidId()
        {
            int id = DataService.GetPlayers().Last().Id;
            int manager = DataService.GetManagers().Last().Id;
            DataService.AddDraft("x", "b", id, id-1, id-2, id-3, id-4, id-5, id-6, manager);
            DraftController cntr = new DraftController();
            cntr.Add("a", creator: null, 1, 2, 3, 4, 5, 6, 7, 1);
            Assert.AreEqual("x", DataService.GetDrafts().Last().Name);

            var result = cntr.Add("a", "b", -1, 2, 3, 4, 5, 6, 7, 1) as RedirectToActionResult;
            Assert.AreEqual("Error", result.ControllerName);

            result = cntr.Add("a", "b", 1, 2, 3, 4, 5, 6, 7, -1) as RedirectToActionResult;
            Assert.AreEqual("Error", result.ControllerName);

            result = cntr.Add(name: null, "b", 1, 2, 3, 4, 5, 6, 7, 1) as RedirectToActionResult;
            Assert.AreEqual("Error", result.ControllerName);

            result = cntr.Add("a", "b", 1, 2, 2, 2, 5, 2, 7, 1) as RedirectToActionResult;
            Assert.AreEqual("Error", result.ControllerName);
            DataService.DeleteDraft(DataService.GetDrafts().Last().Id);


        }

        [Test]
        public void AddShouldCreateItem()
        {
            DraftController cntr = new DraftController();
            int id = DataService.GetPlayers().Last().Id;
            int manager = DataService.GetManagers().Last().Id;
            cntr.Add("x", "b", id, id - 1, id - 2, id - 3, id - 4, id - 5, id - 6, manager);
            Assert.AreEqual("x", DataService.GetDrafts().Last().Name);
            DataService.DeleteDraft(DataService.GetDrafts().Last().Id);
        }

        [Test]
        public void RemoveWrongPasswordShouldNotChangeItem()
        {
            DraftController cntr = new DraftController();
            int id = DataService.GetPlayers().Last().Id;
            int manager = DataService.GetManagers().Last().Id;
            cntr.Add("x", "b", id, id - 1, id - 2, id - 3, id - 4, id - 5, id - 6, manager);
            cntr.Add("a", "b", id, id - 1, id - 2, id - 3, id - 4, id - 5, id - 6, manager);
            cntr.Remove(DataService.GetDrafts().Last().Id,"passord");
            Assert.AreEqual("a", DataService.GetDrafts().Last().Name);
            DataService.DeleteDraft(DataService.GetDrafts().Last().Id);
            DataService.DeleteDraft(DataService.GetDrafts().Last().Id);
        }

        [Test]
        public void ValidRemoveShouldDeleteItem()
        {
            DraftController cntr = new DraftController();

            int id = DataService.GetPlayers().Last().Id;
            int manager = DataService.GetManagers().Last().Id;
            cntr.Add("x", "b", id, id - 1, id - 2, id - 3, id - 4, id - 5, id - 6, manager);
            cntr.Add("a", "b", id, id - 1, id - 2, id - 3, id - 4, id - 5, id - 6, manager);
            int dreamteam = DataService.GetDrafts().Last().Id;
            cntr.Remove(id: dreamteam, password: "password");
            Assert.AreEqual("x", DataService.GetDrafts().Last().Name);
            DataService.DeleteDraft(dreamteam - 1);
        }
        [Test]
        public void DeleteWithInvalidIdShouldRedirectToError()
        {
            DraftController cntr = new DraftController();
            var result = cntr.Remove(id: -1, password: "password") as RedirectToActionResult;
            Assert.AreEqual("Error", result.ControllerName);
        }
    }
}
