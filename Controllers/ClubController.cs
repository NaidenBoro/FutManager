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
            if(name == null || league == null || rating<1)
            {
                return RedirectToAction(actionName: "Index", controllerName:"Error");
            }
            DataService.AddClub(name, league, rating);
            return RedirectToAction(actionName: "Index");
        }
        public IActionResult Delete(int id)
        {
            if (!DataService.GetClubs().Any(c => c.Id == id) || id == 0)
            {
                return RedirectToAction(actionName: "Index", controllerName: "Error");
            }
            return View(id);
        }
        public RedirectToActionResult Remove(int id,string password)
        {
            if(!DataService.GetClubs().Any(c => c.Id == id) || id==0)
            {
                return RedirectToAction(actionName: "Index", controllerName: "Error");
            }
            if(password == "password")
            {
                DataService.DeleteClub(id);
            }
            return RedirectToAction(actionName: "Index");
        }
        public IActionResult Edit(int id)
        {
            if(!DataService.GetClubs().Any(y => y.Id == id) || id==0)
            {
                return RedirectToAction(actionName: "Index", controllerName: "Error");
            }
            return View(DataService.GetClubs().FirstOrDefault(x => x.Id == id));
        }
        public RedirectToActionResult EditConfirmed(string name, string league, int rating, string password,int id)
        {
            if(name==null|| league==null|| rating < 1|| !DataService.GetClubs().Any(y => y.Id == id) || id == 0)
            {
                return RedirectToAction(actionName: "Index", controllerName: "Error");
            }
            if (password == "password")
            {
                DataService.EditClub(id, name, league, rating);
            }
            return RedirectToAction(actionName: "Index");
        }
        public IActionResult Details(int id)
        {
            if (!DataService.GetClubs().Any(y => y.Id == id))
            {
                return RedirectToAction(actionName: "Index", controllerName: "Error");
            }
            return View(DataService.GetClubs().FirstOrDefault(x => x.Id == id));
        }
    }
}
