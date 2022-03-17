using FutManager.Controllers;
using FutManager.Data;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System.Linq;

namespace Testing
{
    public class Clubs
    {
        [Test]
        public void DataBaseTest()
        {
            DataService.AddClub("1", "1", 1);
            DataService.AddClub("2", "2", 2);
            DataService.AddClub("3", "3", 3);

            Assert.AreEqual("3", DataService.GetClubs().Last().Name);
            DataService.DeleteClub(DataService.GetClubs().Last().Id);

            Assert.AreEqual("2", DataService.GetClubs().Last().League);
            DataService.DeleteClub(DataService.GetClubs().Last().Id);

            Assert.AreEqual(1, DataService.GetClubs().Last().Rating);
            DataService.DeleteClub(DataService.GetClubs().Last().Id);

            DataService.AddClub("2", "2", 2);
            DataService.EditClub(DataService.GetClubs().Last().Id, "3", "3", 3);
            Assert.AreEqual("3", DataService.GetClubs().Last().Name);
            DataService.DeleteClub(DataService.GetClubs().Last().Id);
        }

        [Test]
        public void DetailsShouldRedirectToErrorPageOnInvalidId()
        {
            ClubController cntr = new ClubController();
            var result = cntr.Details(-1) as RedirectToActionResult;
            Assert.AreEqual("Error", result.ControllerName);
        }

        [Test]
        public void DetailsShouldRedirectToViewOnValidId()
        {
            DataService.AddClub("2", "2", 2);
            ClubController cntr = new ClubController();
            var result = cntr.Details(1) as ViewResult;
            Assert.IsNotNull(result);
            DataService.DeleteClub(DataService.GetClubs().Last().Id);
        }

        [Test]
        public void AddShouldRedirectToErrorPageOnInvalidId()
        {
            ClubController cntr = new ClubController();
            var result = cntr.Add(name: null, league: "1", rating: 1) as RedirectToActionResult;
            Assert.AreEqual("Error", result.ControllerName);

            result = cntr.Add(name: "1", league: null, rating: 1) as RedirectToActionResult;
            Assert.AreEqual("Error", result.ControllerName);

            result = cntr.Add("1", "1", -1) as RedirectToActionResult;
            Assert.AreEqual("Error", result.ControllerName);
        }

        [Test]
        public void AddShouldRedirectToViewOnValidId()
        {
            ClubController cntr = new ClubController();
            var result = cntr.Add("1", "1", 1) as RedirectToActionResult;
            Assert.AreEqual("1", DataService.GetClubs().Last().Name);
            DataService.DeleteClub(DataService.GetClubs().Last().Id);
        }

        [Test]
        public void EditConfirmedShouldRedirectToErrorPageOnInvalidId()
        {
            DataService.AddClub("2", "2", 2);
            int id = DataService.GetClubs().Last().Id;
            ClubController cntr = new ClubController();
            var result = cntr.EditConfirmed(id: id,name: null, league: "1",password:"password", rating: 1) as RedirectToActionResult;
            Assert.AreEqual("Error", result.ControllerName);

            result = cntr.EditConfirmed(id: id, name: "1", league: null, password: "password", rating: 1) as RedirectToActionResult;
            Assert.AreEqual("Error", result.ControllerName);

            result = cntr.EditConfirmed(id: id, name: "1", league: "1", password: "password", rating: -1) as RedirectToActionResult;
            Assert.AreEqual("Error", result.ControllerName);

            DataService.DeleteClub(DataService.GetClubs().Last().Id);
        }

        [Test]
        public void EditShouldRedirectToViewOnValidId()
        {
            DataService.AddClub("2", "2", 2);
            ClubController cntr = new ClubController();
            int id = DataService.GetClubs().Last().Id;
            var result = cntr.EditConfirmed(id: id, name: "1", league: "1", password: "password", rating: 1) as RedirectToActionResult;
            Assert.AreEqual("1", DataService.GetClubs().Last().Name);
            DataService.DeleteClub(id);
        }

        [Test]
        public void EditWrongPasswordShouldNotChangeItem()
        {
            DataService.AddClub("2", "2", 2);
            ClubController cntr = new ClubController();
            int id = DataService.GetClubs().Last().Id;
            var result = cntr.EditConfirmed(id: id, name: "1", league: "1", password: "passord", rating: 1) as RedirectToActionResult;
            Assert.AreEqual("2", DataService.GetClubs().Last().Name);
            DataService.DeleteClub(id);
        }

        [Test]
        public void RemoveWrongPasswordShouldNotChangeItem()
        {
            DataService.AddClub("2", "2", 2);
            DataService.AddClub("1", "1", 1);
            ClubController cntr = new ClubController();
            int id = DataService.GetClubs().Last().Id;
            cntr.Remove(id: id,password: "passord");
            Assert.AreEqual("1", DataService.GetClubs().Last().Name);
            DataService.DeleteClub(id);
            DataService.DeleteClub(id-1);
        }

        [Test]
        public void ValidRemoveShouldDeleteItem()
        {
            DataService.AddClub("2", "2", 2);
            DataService.AddClub("1", "1", 1);
            ClubController cntr = new ClubController();
            int id = DataService.GetClubs().Last().Id;
            cntr.Remove(id: id, password: "password");
            Assert.AreEqual("2", DataService.GetClubs().Last().Name);
            DataService.DeleteClub(id - 1);
        }
        [Test]
        public void DeleteWithInvalidIdShouldRedirectToError()
        {
            DataService.AddClub("2", "2", 2);
            int id = DataService.GetClubs().Last().Id;
            ClubController cntr = new ClubController();
            var result = cntr.Remove(id: -1, password: "password") as RedirectToActionResult;
            Assert.AreEqual("Error", result.ControllerName);
            DataService.DeleteClub(id);
        }
    }
}