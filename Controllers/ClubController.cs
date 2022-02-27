using Microsoft.AspNetCore.Mvc;

namespace FutManager.Controllers
{
    public class ClubController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
