using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SaracliKend.Application.Models.Auth;
using SaracliKend.Domain.Entities;
using SaracliKendApi.Areas.AdminPanel.Models;

namespace SaracliKendApi.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (!ModelState.IsValid)
                return View();

            var user = await _userManager.FindByNameAsync(loginVM.Username);
            if (user == null)
            {
                ModelState.AddModelError("", "Incorrect Credentials!");
                return View();
            }

            var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, true);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Incorrect Credentials!");
                return View();
            }

            return RedirectToAction("Index", "Dashboard", new { area = "AdminPanel" });
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }

        public async Task<IActionResult> ChangePassword(string username)
        {
            if (username == null)
                return NotFound();
            var user = await _userManager.FindByNameAsync(username);
            if (user == null)
                return NotFound();
            return View(new ChangePasswordVM
            {
                Username = user.UserName
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordVM model)
        {
            if (!ModelState.IsValid)
                return View();
            var user = await _userManager.FindByNameAsync(model.Username);
            if (user == null)
                return NotFound();

            var checkCurrentPassword = await _userManager.CheckPasswordAsync(user, model.CurrentPassword);
            if (checkCurrentPassword == false)
            {
                ModelState.AddModelError("CurrentPassword", "Please enter the current password correctly");
                return View();
            }

            var checkPasswordsIsSame = _userManager.PasswordHasher.VerifyHashedPassword(user, user.PasswordHash, model.NewPassword);
            if (checkPasswordsIsSame == PasswordVerificationResult.Success)
            {
                ModelState.AddModelError("NewPassword", "Your new and old password cannot be the same");
                return View();
            }

            var result = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                return View();
            }

            await _userManager.UpdateSecurityStampAsync(user);
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}
