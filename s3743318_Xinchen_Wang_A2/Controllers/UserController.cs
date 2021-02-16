using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebBankingApp.Models;
using Microsoft.AspNetCore.Identity;
using WebBankingApp.ViewModel;

namespace WebBankingApp.Controllers
{

    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public IActionResult CreateRole() => View();

        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel createRoleViewModel)
        {
            if(ModelState.IsValid)
            {
                IdentityRole identityRole = new IdentityRole
                {
                    Name = createRoleViewModel.RoleName
                };

                var result = await _roleManager.CreateAsync(identityRole);

                // check if successful
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

                // check error if occured and pass into modelstate
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(createRoleViewModel);
        }

        public IActionResult Register() => View();

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = registerViewModel.LoginID,
                    CustomerID = 0000
                };

                // wait usermanager to create new user
                var result = await _userManager.CreateAsync(user, registerViewModel.Password);

                IdentityRole identityRole = new IdentityRole
                {
                    Name = "User"
                };

                var createRoleResult = await _roleManager.CreateAsync(identityRole);


                // check if successful
                if (result.Succeeded && createRoleResult.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Customer");
                }

                // check error if occured and pass into modelstate
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                // check error if occured and pass into modelstate
                foreach (var error in createRoleResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(registerViewModel);
        }
    }
}
