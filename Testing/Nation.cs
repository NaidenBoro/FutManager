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
            int id =  DataService.GetNations().Last().Id;
            var result = cntr.Details(id) as ViewResult;
            Assert.IsNotNull(result);
            DataService.DeleteNation(DataService.GetNations().Last().Id);

            
        }
        [Test]
        public void AddShouldRedirectToErrorPageOnInvalidId()
        {
            DataService.AddNation("3", "3", 3);
            NationController cntr = new NationController();
            cntr.Add(name: null, confederation: "1", rating: 1);
            Assert.AreEqual("3", DataService.GetNations().Last().Confederation);

            var result = cntr.Add(name: "1", confederation: null, rating: 1) as RedirectToActionResult;
            Assert.AreEqual("Error", result.ControllerName);

            result = cntr.Add("1", "1", -1) as RedirectToActionResult;
            Assert.AreEqual("Error", result.ControllerName);
            DataService.DeleteNation(DataService.GetNations().Last().Id);

        }

        [Test]
        public void AddShouldCreateItem()
        {
            NationController cntr = new NationController();
            cntr.Add("1", "1", 1);
            Assert.AreEqual("1", DataService.GetNations().Last().Name);
            DataService.DeleteNation(DataService.GetNations().Last().Id);
        }

        [Test]
        public void EditConfirmedShouldRedirectToErrorPageOnInvalidInput()
        {
            DataService.AddNation("2", "2", 2);
            int id = DataService.GetNations().Last().Id;
            NationController cntr = new NationController();
            var result = cntr.EditConfirmed(id: id, name: null, confederation: "1", password: "password", rating: 1) as RedirectToActionResult;
            Assert.AreEqual("Error", result.ControllerName);

            result = cntr.EditConfirmed(id: id, name: "1", confederation: null, password: "password", rating: 1) as RedirectToActionResult;
            Assert.AreEqual("Error", result.ControllerName);

            result = cntr.EditConfirmed(id: id, name: "1", confederation: "1", password: "password", rating: -1) as RedirectToActionResult;
            Assert.AreEqual("Error", result.ControllerName);

            DataService.DeleteNation(DataService.GetNations().Last().Id);
        }

        [Test]
        public void EditShouldRedirectToViewOnValidId()
        {
            DataService.AddNation("2", "2", 2);
            NationController cntr = new NationController();
            int id = DataService.GetNations().Last().Id;
            cntr.EditConfirmed(id: id, name: "1", confederation: "1", password: "password", rating: 1);
            Assert.AreEqual("1", DataService.GetNations().Last().Name);
            DataService.DeleteNation(id);
        }

        [Test]
        public void EditWrongPasswordShouldNotChangeItem()
        {
            DataService.AddNation("2", "2", 2);
            NationController cntr = new NationController();
            int id = DataService.GetNations().Last().Id;
            cntr.EditConfirmed(id: id, name: "1", confederation: "1", password: "passord", rating: 1);
            Assert.AreEqual("2", DataService.GetNations().Last().Name);
            DataService.DeleteNation(id);
        }

        [Test]
        public void RemoveWrongPasswordShouldNotChangeItem()
        {
            DataService.AddNation("2", "2", 2);
            DataService.AddNation("1", "1", 1);
            NationController cntr = new NationController();
            int id = DataService.GetNations().Last().Id;
            cntr.Remove(id: id, password: "passord");
            Assert.AreEqual("1", DataService.GetNations().Last().Name);
            DataService.DeleteNation(id);
            DataService.DeleteNation(id - 1);
        }

        [Test]
        public void ValidRemoveShouldDeleteItem()
        {
            DataService.AddNation("2", "2", 2);
            DataService.AddNation("1", "1", 1);
            NationController cntr = new NationController();
            int id = DataService.GetNations().Last().Id;
            cntr.Remove(id: id, password: "password");
            Assert.AreEqual("2", DataService.GetNations().Last().Name);
            DataService.DeleteNation(id - 1);
        }
        [Test]
        public void RemoveWithInvalidIdShouldRedirectToError()
        {
            DataService.AddNation("2", "2", 2);
            int id = DataService.GetNations().Last().Id;
            NationController cntr = new NationController();
            var result = cntr.Remove(id: -1, password: "password") as RedirectToActionResult;
            Assert.AreEqual("Error", result.ControllerName);
            DataService.DeleteNation(id);
        }
        [Test]
        public void DeleteWithInvalidIdShouldRedirectToError()
        {

            NationController controller = new NationController();
            var result = controller.Delete(-1) as RedirectToActionResult;
            Assert.AreEqual("Error", result.ControllerName);

        }
    }
}
