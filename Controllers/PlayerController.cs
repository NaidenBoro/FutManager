using Microsoft.AspNetCore.Mvc;

namespace FutManager.Controllers
{
    public class PlayerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
        
        public string Players()
        {
            return "Not created";
        }

    }
}
