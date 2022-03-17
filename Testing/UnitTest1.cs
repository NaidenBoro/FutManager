using FutManager.Controllers;
using FutManager.Data;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System.Linq;

namespace Testing
{
    public class Tests
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
    }
}