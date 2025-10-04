using BookStore.Core.DTOs.UserPanel;
using BookStore.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookStore.Areas.UserPanel.Controllers
{
    [Area("UserPanel")]
    public class HomeController : Controller
    {
        private IUserService _userService;

        public HomeController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult EditProfile()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            model.UserName = User.Identity.Name;

            if (!ModelState.IsValid)
                return View(model);

            var result = await _userService.ChangePasswordAsync(model);
            if (result.Succeeded)
                ViewData["isChanged"] = true;
            else
                ModelState.AddModelError("", "رمزعبور فعلی اشتباه است");

            return View(model);
        }
    }
}
