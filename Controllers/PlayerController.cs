using Microsoft.AspNetCore.Mvc;

namespace FutManager.Controllers
{
    public class PlayerController : Controller
    {
        public string Index()
        {
            return "Not created";
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
