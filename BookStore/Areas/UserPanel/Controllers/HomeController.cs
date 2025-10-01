using Microsoft.AspNetCore.Mvc;

namespace BookStore.Areas.UserPanel.Controllers
{
    [Area("UserPanel")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult EditProfile()
        {
            return View();
        }
    }
}
