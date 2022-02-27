using Microsoft.AspNetCore.Mvc;

namespace FutManager.Controllers
{
    public class NationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
