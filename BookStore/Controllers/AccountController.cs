using BookStore.Core.DTOs.Account;
using BookStore.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class AccountController : Controller
    {
        private IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("Login")]
        public IActionResult Login(string? returnUrl = null)
        {
            if (_userService.IsUserSignIn(User))
                return RedirectToAction("Index", "Home");

            ViewData["returnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginViewModel model, string? returnUrl = null)
        {
            if (_userService.IsUserSignIn(User))
                return RedirectToAction("Index", "Home");

            if (!ModelState.IsValid)
                return View(model);

            ViewData["returnUrl"] = returnUrl;

            var result = await _userService.SignInAsync(model);
            if (result.Succeeded)
            {
                if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                    return Redirect(returnUrl);

                return RedirectToAction("Index", "Home");
            }
            if (result.IsLockedOut)
            {
                ViewData["ErrorMessage"] = "اکانت شما به دلیل پنج بار ورود ناموفق به مدت پنج دقیق قفل شده است";
                return View(model);
            }

            ModelState.AddModelError("", "رمزعبور یا نام کاربری اشتباه است");

            return View(model);
        }

        [HttpGet]
        [Route("Register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var result = await _userService.RegisterAsync(model);

            if (result.Succeeded)
                return RedirectToAction("Index", "Home");

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("LogOut")]
        public async Task<IActionResult> LogOut()
        {
            await _userService.LogOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> IsEmailInUse(string email)
        {
            var user = await _userService.IsExistEmailAsync(email);
            if (user is false)
                return Json(true);

            return Json("ایمیل تکراری است.");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> IsUserNameInUse(string userName)
        {
            var user = await _userService.IsExistUserNameAsync(userName);
            if (user is false)
                return Json(true);

            return Json("نام کاربری تکراری است.");
        }
    }
}
