using FutManager.Data;
using FutManager.Models;
using Microsoft.AspNetCore.Mvc;

namespace FutManager.Controllers
{
    public class NationController : Controller
    {
        public IActionResult Index()        
        {
            List<Nation> nations = DataService.GetNations();
            return View(nations);
        }

        public IActionResult Create()
        {
            return View();
        }
        public RedirectToActionResult Add(string name, string confederation, int rating)
        {
            if (name == null || confederation == null || rating < 1)
            {
                return RedirectToAction(actionName: "Index", controllerName: "Error");
            }
            DataService.AddNation(name, confederation, rating);
            return RedirectToAction(actionName: "Index");
        }
        public IActionResult Delete(int id)
        {

            if (!DataService.GetNations().Any(y => y.Id == id))
            {
                return RedirectToAction(actionName: "Index", controllerName: "Error");
            }
            return View(id);
        }
        public RedirectToActionResult Remove(int id, string password)
        {
            if (!DataService.GetNations().Any(c => c.Id == id))
            {
                return RedirectToAction(actionName: "Index", controllerName: "Error");
            }
            if (password == "password")
            {
                
                DataService.DeleteNation(id);
            }
            return RedirectToAction(actionName: "Index");
        }
        public IActionResult Edit(int id)
        {
            if (!DataService.GetNations().Any(c => c.Id == id))
            {
                return RedirectToAction(actionName: "Index", controllerName: "Error");
            }
            return View(DataService.GetNations().FirstOrDefault(x => x.Id == id));
        }
        public RedirectToActionResult EditConfirmed(string name, string confederation, int rating, string password, int id)
        {
            if (!DataService.GetNations().Any(c => c.Id == id) || name == null || confederation == null || rating < 1)
            {
                return RedirectToAction(actionName: "Index", controllerName: "Error");
            }
            if (password == "password")
            {
                
                DataService.EditNation(id, name, confederation, rating);
            }
            return RedirectToAction(actionName: "Index");
        }
        public IActionResult Details(int id)
        {
            if (!DataService.GetNations().Any(c => c.Id == id) )
            {
                return RedirectToAction(actionName: "Index", controllerName: "Error");
            }
            return View(DataService.GetNations().FirstOrDefault(x => x.Id == id));
        }
    }
}
