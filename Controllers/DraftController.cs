using FutManager.Models;
using Microsoft.AspNetCore.Mvc;

namespace FutManager.Controllers
{
    public class DraftController : Controller
    {
        public IActionResult Index()
        {
            List <Draft> list = new List<Draft>();
            return View(list);
        }
    }
}
