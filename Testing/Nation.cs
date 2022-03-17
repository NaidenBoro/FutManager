using FutManager.Controllers;
using FutManager.Data;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System.Linq;

namespace Testing
{
    public class Nation
    {
        [Test]
        public void DataBaseTest()
        {
            DataService.AddNation("1", "1", 1);
            DataService.AddNation("2", "2", 2);
            DataService.AddNation("3", "3", 3);

            Assert.AreEqual("3", DataService.GetNations().Last().Name);
            DataService.DeleteNation(DataService.GetNations().Last().Id);

            Assert.AreEqual("2", DataService.GetNations().Last().Confederation);
            DataService.DeleteNation(DataService.GetNations().Last().Id);

            Assert.AreEqual(1, DataService.GetNations().Last().Rating);
            DataService.DeleteNation(DataService.GetNations().Last().Id);

            DataService.AddNation("2", "2", 2);
            DataService.EditNation(DataService.GetNations().Last().Id, "3", "3", 3);
            Assert.AreEqual("3", DataService.GetNations().Last().Name);
            DataService.DeleteNation(DataService.GetNations().Last().Id);
        }

        [Test]
        public void DetailsShouldRedirectToErrorPageOnInvalidId()
        {
            NationController cntr = new NationController();
            var result = cntr.Details(-1) as RedirectToActionResult;
            Assert.AreEqual("Error", result.ControllerName);
        }

        [Test]
        public void DetailsShouldRedirectToViewOnValidId()
        {
            DataService.AddNation("2", "2", 2);
            NationController cntr = new NationController();
            var result = cntr.Details(1) as ViewResult;
            Assert.IsNotNull(result);
            DataService.DeleteNation(DataService.GetNations().Last().Id);
        }
    }
}
