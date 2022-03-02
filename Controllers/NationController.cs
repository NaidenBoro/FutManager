using FutManager.Data;
using Microsoft.AspNetCore.Mvc;

namespace FutManager.Controllers
{
    public class NationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Nations()
        {
            ViewBag.Nations = DataService.GetNations();
            return View();
        }
    }
}
