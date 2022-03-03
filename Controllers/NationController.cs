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
    }
}
