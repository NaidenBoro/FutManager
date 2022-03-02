using FutManager.Data;
using FutManager.Models;
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
            List<Nation> nations = DataService.GetNations();
            return View(nations);
        }
    }
}
