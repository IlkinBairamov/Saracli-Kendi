using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SaracliKend.Domain.Entities;

namespace SaracliKendApi.Areas.AdminPanel.Controllers
{
    public class DashboardController : BaseController
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public DashboardController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
