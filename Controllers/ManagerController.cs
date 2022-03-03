using FutManager.Data;
using FutManager.Models;
using Microsoft.AspNetCore.Mvc;

namespace FutManager.Controllers
{
    public class ManagerController : Controller
    {
        public IActionResult Create()
        {
            ViewBag.Nationions = DataService.GetNations();
            ViewBag.Clubs = DataService.GetClubs();
            return View();
        }
        public RedirectToActionResult Add(string first_name, string last_name,  int nationalityId, int clubId, int age, int rating, bool isReal)
        {
            DataService.AddManager(first_name, last_name, age , nationalityId, clubId, rating, isReal);
            return RedirectToAction(actionName: "Index");
        }
        public IActionResult Index()
        {
            List<Club> clubs = DataService.GetClubs();
            List<Nation> nations = DataService.GetNations();
            List<Manager> managers = new List<Manager>(DataService.GetManagers());
            managers.ForEach(x =>
            {
                x.Club = clubs.FirstOrDefault(y => y.Id == x.ClubId);
                x.Nation = nations.FirstOrDefault(y => y.Id == x.NationalityId);
            });

            return View(managers);
        }
        public IActionResult Details(int id)
        {
            List<Club> clubs = DataService.GetClubs();
            List<Nation> nations = DataService.GetNations();
            Manager manager = DataService.GetManagers().FirstOrDefault(x => x.Id == id);
            manager.Club = clubs.FirstOrDefault(y => y.Id == manager.ClubId);
            manager.Nation = nations.FirstOrDefault(y => y.Id == manager.NationalityId);

            return View(manager);
        }
    }
}
