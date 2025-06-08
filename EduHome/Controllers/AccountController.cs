using EduHome.Helpers;
using EduHome.Models;
using EduHome.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Resources;

namespace EduHome.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<AppUser> userManager,
                                 RoleManager<IdentityRole> roleManager,
                                 SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            AppUser appUser = await _userManager.FindByNameAsync(loginVM.Username);
            if (appUser == null)
            {
                appUser = await _userManager.FindByEmailAsync(loginVM.Username);
                if (appUser == null)
                {
                    ModelState.AddModelError("Username", "This accound was not found!");
                    return View();
                }

            }
            if (appUser.IsDeactive)
            {
                ModelState.AddModelError("", "Your account is deactivated");
                return View();
            }
            Microsoft.AspNetCore.Identity.SignInResult signInResult = await _signInManager.PasswordSignInAsync(appUser, loginVM.Password, loginVM.IsRemember, true);
            if (signInResult.IsLockedOut)
            {
                ModelState.AddModelError("", "You tried more than 5 times with wrong password!");
                return View();
            }
            if (!signInResult.Succeeded)
            {
                ModelState.AddModelError("Password", "Password is wrong");
                return View();
            }
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]

        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            AppUser appUser = new AppUser
            {
                Name = registerVM.Name,
                Surname = registerVM.Surname,
                Email = registerVM.Email,
                UserName = registerVM.Username,
            };
            IdentityResult identityResult = await _userManager.CreateAsync(appUser, registerVM.Password);
            if (!identityResult.Succeeded)
            {
                foreach(IdentityError error in identityResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(registerVM);
            }
            await _userManager.AddToRoleAsync(appUser,Helper.Member);
            await _signInManager.SignInAsync(appUser, registerVM.IsRemember);
            return RedirectToAction("Index", "Home");
        }
        //public async Task CreateRoles()
        //{
        //    if (!await _roleManager.RoleExistsAsync(Helper.Admin))
        //    {
        //        await _roleManager.CreateAsync(new IdentityRole { Name = Helper.Admin });
        //    }
        //    if (!await _roleManager.RoleExistsAsync(Helper.Member))
        //    {
        //        await _roleManager.CreateAsync(new IdentityRole { Name = Helper.Member });
        //    }
        //}
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
