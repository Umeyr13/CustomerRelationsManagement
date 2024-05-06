using Microsoft.AspNetCore.Identity;
using CustomerRelationsManagement.Models;
using Microsoft.AspNetCore.Mvc;
using CustomerRelationsManagementDomain.Entities;

namespace CustomerRelationsManagement.Controllers
{
    public class LoginController : Controller
    {
		private readonly SignInManager<AppUser> _signInManager;
		private readonly UserManager<AppUser> _userManager;

		public LoginController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
		{
			_signInManager = signInManager;
			_userManager = userManager;
		}

		[HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel loginViewModel)
        {
            var result = await _signInManager.PasswordSignInAsync(loginViewModel.Username,loginViewModel.Password,false,false);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Customer");
            }
            return View();
        }
    }
}
