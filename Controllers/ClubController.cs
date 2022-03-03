using FutManager.Data;
using FutManager.Models;
using Microsoft.AspNetCore.Mvc;

namespace FutManager.Controllers
{
    public class ClubController : Controller
    {
        public IActionResult Index()
        {
            List<Club> clubs = DataService.GetClubs();

            return View(clubs);
        }

        public IActionResult Create()
        {
            return View();
        }
        public RedirectToActionResult Add(string name,string league,int rating)
        {
            DataService.AddClub(name, league, rating);
            return RedirectToAction(actionName: "Index");
        }
        public IActionResult Delete(int id)
        {
            return View(id);
        }
        public RedirectToActionResult Remove(int id,string password)
        {
            if(password == "password")
            {
                DataService.DeleteClub(id);
            }
            return RedirectToAction(actionName: "Index");
        }
        public IActionResult Edit(int id)
        {
            return View(DataService.GetClubs().FirstOrDefault(x => x.Id == id));
        }
        public RedirectToActionResult EditConfirmed(string name, string league, int rating, string password,int id)
        {
            if (password == "password")
            {
                DataService.EditClub(id, name, league, rating);
            }
            return RedirectToAction(actionName: "Index");
        }

    }
}
