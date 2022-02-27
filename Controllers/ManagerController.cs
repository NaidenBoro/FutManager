using Microsoft.AspNetCore.Mvc;

namespace FutManager.Controllers
{
    public class ManagerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
