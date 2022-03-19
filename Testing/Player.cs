using FutManager.Controllers;
using FutManager.Data;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System.Linq;


namespace Testing
{
    internal class Player
    {
        [Test]
        public void DataBaseTest()
        {
            DataService.AddClub("2", "2", 2);
            DataService.AddNation("2", "2", 2);
            int club_id = DataService.GetClubs().Last().Id;
            int nat_id = DataService.GetNations().Last().Id;
            DataService.AddPlayer("1","2","Forward",1,2,nat_id,club_id,1,true);

            Assert.AreEqual("Forward", DataService.GetPlayers().Last().Position);
            Assert.AreEqual("1", DataService.GetPlayers().Last().FirstName);
            Assert.AreEqual("2", DataService.GetPlayers().Last().LastName);
            Assert.AreEqual(1, DataService.GetPlayers().Last().Age);
            Assert.AreEqual(2, DataService.GetPlayers().Last().ShirtNumber);
            Assert.AreEqual(nat_id, DataService.GetPlayers().Last().NationalityId);
            Assert.AreEqual(club_id, DataService.GetPlayers().Last().ClubId);
            Assert.AreEqual(1, DataService.GetPlayers().Last().Overall);
            Assert.AreEqual(true, DataService.GetPlayers().Last().isReal);
            
            DataService.DeletePlayer(DataService.GetPlayers().Last().Id);
            DataService.DeleteClub(club_id);
            DataService.DeleteNation(nat_id);
        }

        [Test]
        public void DetailsShouldRedirectToErrorPageOnInvalidId()
        {
            PlayerController controller = new PlayerController();
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
            DataService.AddPlayer("1", "2", "Forward", 1, 2, nat_id, club_id, 1, true);
           
            int id = DataService.GetPlayers().Last().Id;
            PlayerController controller = new PlayerController();
            var result = controller.Details(id) as ViewResult;
            Assert.IsNotNull(result);

            DataService.DeletePlayer(id);
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
            DataService.AddPlayer("1", "2", "Forward", 1, 2, nat_id, club_id, 1, true);

            PlayerController controller = new PlayerController();

            var result = controller.Add(null, "2", "Forward", nat_id, club_id, 1, 2, 1, true);
            Assert.AreEqual("Error", result.ControllerName);

            result = controller.Add("1", null, "Forward", nat_id, club_id, 1, 2, 1, true);
            Assert.AreEqual ("Error", result.ControllerName);

            result = controller.Add("1", "2", null, nat_id, club_id, 1, 2, 1, true);
            Assert.AreEqual("Error", result.ControllerName);

            result = controller.Add("1", "2", "Forward", -1, club_id, 1, 2, 1, true);
            Assert.AreEqual("Error", result.ControllerName);

            result = controller.Add("1", "2", "Forward", nat_id, -1, 1, 2, 1, true);
            Assert.AreEqual("Error", result.ControllerName);

            result = controller.Add("1", "2", "Forward", nat_id, club_id, -1, 2, 1, true);
            Assert.AreEqual("Error", result.ControllerName);

            result = controller.Add("1", "2", "Forward", nat_id, club_id, 1, -1, 1, true);
            Assert.AreEqual("Error", result.ControllerName);

            result = controller.Add("1", "2", "Forward", nat_id, club_id, 1, 2, -1, true);
            Assert.AreEqual("Error", result.ControllerName);

            DataService.DeletePlayer(DataService.GetPlayers().Last().Id);
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
            DataService.AddPlayer("1", "2", "Forward", 1, 2, nat_id, club_id, 1, true);

            PlayerController controller = new PlayerController();
            controller.Add("1", "2", "Forward", nat_id, club_id, 1, 2, 1, true);
            Assert.AreEqual("1", DataService.GetPlayers().Last().FirstName);

            DataService.DeletePlayer(DataService.GetPlayers().Last().Id);
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
            DataService.AddPlayer("1", "2", "Forward", 1, 2, nat_id, club_id, 1, true);

            int id = DataService.GetPlayers().Last().Id;
            PlayerController controller = new PlayerController();

            var result = controller.ConfirmEdit(id, null, "2", "Forward", nat_id, club_id, 1, 2, 1, true, "password");
            Assert.AreEqual("Error", result.ControllerName);

            result = controller.ConfirmEdit(id, "1", null, "Forward", nat_id, club_id, 1, 2, 1, true, "password");
            Assert.AreEqual("Error", result.ControllerName);

            result = controller.ConfirmEdit(id, "1", "2", null, nat_id, club_id, 1, 2, 1, true, "password");
            Assert.AreEqual("Error", result.ControllerName);

            result = controller.ConfirmEdit(id, "1", "2", "Forward", -1, club_id, 1, 2, 1, true, "password");
            Assert.AreEqual("Error", result.ControllerName);

            result = controller.ConfirmEdit(id, "1", "2", "Forward", nat_id, -1, 1, 2, 1, true, "password");
            Assert.AreEqual("Error", result.ControllerName);

            result = controller.ConfirmEdit(id, "1", "2", "Forward", nat_id, club_id, -1, 2, 1, true, "password");
            Assert.AreEqual("Error", result.ControllerName);

            result = controller.ConfirmEdit(id, "1", "2", "Forward", nat_id, club_id, 1, -1, 1, true, "password");
            Assert.AreEqual("Error", result.ControllerName);

            result = controller.ConfirmEdit(id, "1", "2", "Forward", nat_id, club_id, 1, 2, -1, true, "password");
            Assert.AreEqual("Error", result.ControllerName);

            DataService.DeletePlayer(DataService.GetPlayers().Last().Id);
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
            DataService.AddPlayer("0", "1", "Defender", 1, 2, nat_id, club_id, 1, true);
               
            PlayerController controller = new PlayerController();
            int id = DataService.GetPlayers().Last().Id;
            controller.ConfirmEdit(id, "1", "2", "Forward", nat_id, club_id, 1, 2, 1, true, "password");
            Assert.AreEqual("1", DataService.GetPlayers().Last().FirstName);

            DataService.DeletePlayer(DataService.GetPlayers().Last().Id);
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
            DataService.AddPlayer("0", "1", "Defender", 1, 2, nat_id, club_id, 1, true);

            PlayerController controller = new PlayerController();
            int id = DataService.GetPlayers().Last().Id;
            controller.ConfirmEdit(id, "1", "2", "Forward", nat_id, club_id, 1, 2, 1, true, "notpassword");
            Assert.AreEqual("0", DataService.GetPlayers().Last().FirstName);

            DataService.DeletePlayer(DataService.GetPlayers().Last().Id);
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
            DataService.AddPlayer("0", "1", "Defender", 1, 2, nat_id, club_id, 1, true);
            DataService.AddPlayer("1", "2", "Midfielder", 1, 2, nat_id, club_id, 1, true);

            PlayerController controller = new PlayerController();
            int id = DataService.GetPlayers().Last().Id;
            controller.Remove(id, "notpassword");
            Assert.AreEqual("1", DataService.GetPlayers().Last().FirstName);

            DataService.DeletePlayer(id);
            DataService.DeletePlayer(id - 1);
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
            DataService.AddPlayer("0", "1", "Defender", 1, 2, nat_id, club_id, 1, true);
            DataService.AddPlayer("1", "2", "Midfielder", 1, 2, nat_id, club_id, 1, true);

            PlayerController controller = new PlayerController();
            int id = DataService.GetPlayers().Last().Id;
            controller.Remove(id, "password");
            Assert.AreEqual("0", DataService.GetPlayers().Last().FirstName);

            DataService.DeletePlayer(id - 1);
            DataService.DeleteClub(club_id);
            DataService.DeleteNation(nat_id);
        }

        [Test]
        public void RemoveWithInvalidIdShouldRedirectToError()
        {
            DataService.AddClub("2", "2", 2);
            DataService.AddNation("2", "2", 2);
            int club_id = DataService.GetClubs().Last().Id;
            int nat_id = DataService.GetNations().Last().Id;
            DataService.AddPlayer("0", "1", "Defender", 1, 2, nat_id, club_id, 1, true);

            PlayerController controller = new PlayerController();

            var result = controller.Remove(-1, "password");
            Assert.AreEqual("Error", result.ControllerName);

            DataService.DeletePlayer(DataService.GetPlayers().Last().Id);
            DataService.DeleteClub(club_id);
            DataService.DeleteNation(nat_id);

        }
        [Test]
        public void DeleteWithInvalidIdShouldRedirectToError()
        {

            PlayerController controller = new PlayerController();
            var result = controller.Delete(-1) as RedirectToActionResult;
            Assert.AreEqual("Error", result.ControllerName);

        }
    }
}
