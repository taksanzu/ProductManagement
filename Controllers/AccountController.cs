using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.Models.ViewModels;

namespace ProductManagement.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Copy data from RegisterViewModel to IdentityUser
                var user = new IdentityUser
                {
                    UserName = model.Email,
                    Email = model.Email
                };
                // thêm user vào bảng AspNetUserRoles
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded) //nếu đăng ký thành công, chuyển đến trang chủ
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("List", "Shopping");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(model);
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user != null)
            {
                var passwordCheck = await _userManager.CheckPasswordAsync(user, model.Password);
                if (passwordCheck)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("List", "Shopping");
                    }
                }
                TempData["Error"] = "Wrong credentials. Please, try again!";
                return View(model);
            }

            TempData["Error"] = "Wrong credentials. Please, try again!";
            return View(model);
        }
        public async Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("List", "Shopping");
        }
    }
}
