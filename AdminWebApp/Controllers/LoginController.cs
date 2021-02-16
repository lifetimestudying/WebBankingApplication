using Microsoft.AspNetCore.Mvc;
using AdminWebApp.Models;
using Microsoft.AspNetCore.Http;

namespace WebBankingApp.Controllers
{
    [Route("/Mcba/SecureLogin")]
    public class LoginController : Controller
    {

        public IActionResult Login() => View();

        [HttpPost]
        public IActionResult Login(string loginID, string password)
        {

            if (loginID == null || !password.Equals("admin"))
            {
                ModelState.AddModelError("LoginFailed", "Login failed, please try again.");
                return View(new Login { LoginID = loginID });
            }

            HttpContext.Session.SetInt32("admin", 001);
            HttpContext.Session.SetString("admin", loginID);

            return RedirectToAction("Index", "Admin");
        }

        [Route("LogoutNow")]
        public IActionResult Logout()
        {
            // Logout customer.
            HttpContext.Session.Clear();

            return RedirectToAction("Index", "Home");
        }
    }
}
