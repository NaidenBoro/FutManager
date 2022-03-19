using FutManager.Controllers;
using FutManager.Data;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System.Linq;


namespace Testing
{
    internal class Manager
    {
        [Test]
        public void DataBaseTest()
        {
            DataService.AddClub("2", "2", 2);
            DataService.AddNation("2", "2", 2);
            int club_id = DataService.GetClubs().Last().Id;
            int nat_id = DataService.GetNations().Last().Id;
            DataService.AddManager("1", "2", 1, nat_id, club_id, 1, true);

            Assert.AreEqual("1", DataService.GetManagers().Last().FirstName);
            Assert.AreEqual("2", DataService.GetManagers().Last().LastName);
            Assert.AreEqual(1, DataService.GetManagers().Last().Age);
            Assert.AreEqual(nat_id, DataService.GetManagers().Last().NationalityId);
            Assert.AreEqual(club_id, DataService.GetManagers().Last().ClubId);
            Assert.AreEqual(1, DataService.GetManagers().Last().Rating);
            Assert.AreEqual(true, DataService.GetManagers().Last().isReal);
            
            DataService.DeleteManager(DataService.GetManagers().Last().Id);
            DataService.DeleteClub(club_id);
            DataService.DeleteNation(nat_id);
        }

        [Test]
        public void DetailsShouldRedirectToErrorPageOnInvalidId()
        {
            ManagerController controller = new ManagerController();
            var result = controller.Details(-1) as RedirectToActionResult;
            Assert.AreEqual("Error", result.ControllerName);
        }

        [Test]
        public void DetailsShouldRedirectToViewOnValidId()
        {
            DataService.AddClub("2", "2", 2);
            DataService.AddNation("2", "2", 2);
            int club_id = DataService.GetClubs().Last().Id;
            int nat_id = DataService.GetNations().Last().Id;
            DataService.AddManager("1", "2", 1, nat_id, club_id, 1, true);

            int id = DataService.GetManagers().Last().Id ;
            ManagerController controller = new ManagerController();
            var result = controller.Details(id) as ViewResult;
            Assert.IsNotNull(result);

            DataService.DeleteManager(DataService.GetManagers().Last().Id);
            DataService.DeleteClub(club_id);
            DataService.DeleteNation(nat_id);
        }

        [Test]
        public void AddShouldRedirectToErrorPageOnInvalidId()
        {

            DataService.AddClub("2", "2", 2);
            DataService.AddNation("2", "2", 2);
            int club_id = DataService.GetClubs().Last().Id;
            int nat_id = DataService.GetNations().Last().Id;
            DataService.AddManager("1", "2", 1, nat_id, club_id, 1, true);

            ManagerController controller = new ManagerController();

            var result = controller.Add(null, "2", nat_id, club_id, 1, 2, true);
            Assert.AreEqual("Error", result.ControllerName);

            result = controller.Add("1", null, nat_id, club_id, 1, 2, true);
            Assert.AreEqual("Error", result.ControllerName);

            result = controller.Add("1", "2", -1, club_id, 1, 2, true);
            Assert.AreEqual("Error", result.ControllerName);

            result = controller.Add("1", "2", nat_id, -1, 1, 2, true);
            Assert.AreEqual("Error", result.ControllerName);

            result = controller.Add("1", "2", nat_id, club_id, -1, 2, true);
            Assert.AreEqual("Error", result.ControllerName);

            result = controller.Add("1", "2", nat_id, club_id, 1, -1, true);
            Assert.AreEqual("Error", result.ControllerName);

            DataService.DeleteManager(DataService.GetManagers().Last().Id);
            DataService.DeleteClub(club_id);
            DataService.DeleteNation(nat_id);

        }

        [Test]
        public void AddShouldCreateItem()
        {

            DataService.AddClub("2", "2", 2);
            DataService.AddNation("2", "2", 2);
            int club_id = DataService.GetClubs().Last().Id;
            int nat_id = DataService.GetNations().Last().Id;
            DataService.AddManager("1", "2", 1, nat_id, club_id, 1, true);

            ManagerController controller = new ManagerController();
            controller.Add("1", "2", nat_id, club_id, 1, 2, true);
            Assert.AreEqual("1", DataService.GetManagers().Last().FirstName);

            DataService.DeleteManager(DataService.GetManagers().Last().Id);
            DataService.DeleteClub(club_id);
            DataService.DeleteNation(nat_id);
        }

        [Test]
        public void EditConfirmedShouldRedirectToErrorPageOnInvalidInput()
        {
            DataService.AddClub("2", "2", 2);
            DataService.AddNation("2", "2", 2);
            int club_id = DataService.GetClubs().Last().Id;
            int nat_id = DataService.GetNations().Last().Id;
            DataService.AddManager("1", "2", 1, nat_id, club_id, 1, true);

            int id = DataService.GetManagers().Last().Id;
            ManagerController controller = new ManagerController();

            var result = controller.ConfirmEdit(id, null, "2", nat_id, club_id, 1, 2, true, "password");
            Assert.AreEqual("Error", result.ControllerName);

            result = controller.ConfirmEdit(id, "1", null, nat_id, club_id, 1, 2, true, "password");
            Assert.AreEqual("Error", result.ControllerName);

            result = controller.ConfirmEdit(id, "1", "2", -1, club_id, 1, 2, true, "password");
            Assert.AreEqual("Error", result.ControllerName);

            result = controller.ConfirmEdit(id, "1", "2", nat_id, -1, 1, 2, true, "password");
            Assert.AreEqual("Error", result.ControllerName);

            result = controller.ConfirmEdit(id, "1", "2", nat_id, club_id, -1, 2, true, "password");
            Assert.AreEqual("Error", result.ControllerName);

            result = controller.ConfirmEdit(id, "1", "2", nat_id, club_id, 1, -1, true, "password");
            Assert.AreEqual("Error", result.ControllerName);

            DataService.DeleteManager(DataService.GetManagers().Last().Id);
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
            DataService.AddManager("0", "1", 1, nat_id, club_id, 1, true);

            ManagerController controller = new ManagerController();
            int id = DataService.GetManagers().Last().Id;
            controller.ConfirmEdit(id, "1", "2", nat_id, club_id, 1, 2, true, "password");
            Assert.AreEqual("1", DataService.GetManagers().Last().FirstName);

            DataService.DeleteManager(DataService.GetManagers().Last().Id);
            DataService.DeleteClub(club_id);
            DataService.DeleteNation(nat_id);
        }

        [Test]
        public void EditWrongPasswordShouldNotChangeItem()
        {

            DataService.AddClub("2", "2", 2);
            DataService.AddNation("2", "2", 2);
            int club_id = DataService.GetClubs().Last().Id;
            int nat_id = DataService.GetNations().Last().Id;
            DataService.AddManager("0", "1", 1, nat_id, club_id, 1, true);

            ManagerController controller = new ManagerController();
            int id = DataService.GetManagers().Last().Id;
            controller.ConfirmEdit(id, "1", "2", nat_id, club_id, 1, 2, true, "notpassword");
            Assert.AreEqual("0", DataService.GetManagers().Last().FirstName);

            DataService.DeleteManager(DataService.GetManagers().Last().Id);
            DataService.DeleteClub(club_id);
            DataService.DeleteNation(nat_id);
        }

        [Test]
        public void RemoveWrongPasswordShouldNotChangeItem()
        {
            DataService.AddClub("2", "2", 2);
            DataService.AddNation("2", "2", 2);
            int club_id = DataService.GetClubs().Last().Id;
            int nat_id = DataService.GetNations().Last().Id;
            DataService.AddManager("0", "1", 1, nat_id, club_id, 1, true);
            DataService.AddManager("1", "2", 1, nat_id, club_id, 1, true);

            ManagerController controller = new ManagerController();
            int id = DataService.GetManagers().Last().Id;
            controller.Remove(id, "notpassword");
            Assert.AreEqual("1", DataService.GetManagers().Last().FirstName);

            DataService.DeleteManager(id);
            DataService.DeleteManager(id - 1);
            DataService.DeleteClub(club_id);
            DataService.DeleteNation(nat_id);
        }

        [Test]
        public void ValidRemoveShouldDeleteItem()
        {

            DataService.AddClub("2", "2", 2);
            DataService.AddNation("2", "2", 2);
            int club_id = DataService.GetClubs().Last().Id;
            int nat_id = DataService.GetNations().Last().Id;
            DataService.AddManager("0", "1", 1, nat_id, club_id, 1, true);
            DataService.AddManager("1", "2", 1, nat_id, club_id, 1, true);

            ManagerController controller = new ManagerController();
            int id = DataService.GetManagers().Last().Id;
            controller.Remove(id, "password");
            Assert.AreEqual("0", DataService.GetManagers().Last().FirstName);

            DataService.DeleteManager(id - 1);
            DataService.DeleteClub(club_id);
            DataService.DeleteNation(nat_id);
        }

        [Test]
        public void DeleteWithInvalidIdShouldRedirectToError()
        {
            DataService.AddClub("2", "2", 2);
            DataService.AddNation("2", "2", 2);
            int club_id = DataService.GetClubs().Last().Id;
            int nat_id = DataService.GetNations().Last().Id;
            DataService.AddManager("0", "1", 1, nat_id, club_id, 1, true);

            ManagerController controller = new ManagerController();

            var result = controller.Remove(-1, "password");
            Assert.AreEqual("Error", result.ControllerName);

            DataService.DeleteManager(DataService.GetManagers().Last().Id);
            DataService.DeleteClub(club_id);
            DataService.DeleteNation(nat_id);

        }

    }
}
