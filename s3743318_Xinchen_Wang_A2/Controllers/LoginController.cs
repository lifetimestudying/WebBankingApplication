using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebBankingApp.Data;
using WebBankingApp.Models;
using WebBankingApp.ViewModel;
using System.Threading.Tasks;

namespace WebBankingApp.Controllers
{
    [Route("/MCBA/SecureLogin")]
    public class LoginController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;

        public LoginController(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public IActionResult Login() => View();

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {

            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(loginViewModel.LoginID,
                    loginViewModel.Password, false, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Customer");
                }

                // check error if occured
                if (result.IsLockedOut)
                {
                    ModelState.AddModelError("", "Your Account is been locked.    " +
                        "Dont't panic, it will auto unlock after 1 minute.");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Login Failed.");
                }

            }

            return View(loginViewModel);

        }

        [Route("LogedOut")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
