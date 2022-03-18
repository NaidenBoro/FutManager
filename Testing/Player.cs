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
            // to do
            DataService.DeleteNation(DataService.GetPlayers().Last().Id);
            DataService.DeleteClub(club_id);
            DataService.DeleteNation(nat_id);

            //...
        }
    }
}
