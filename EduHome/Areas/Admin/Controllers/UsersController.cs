using EduHome.Helpers;
using EduHome.Models;
using EduHome.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;

namespace EduHome.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        public UsersController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            List<AppUser> users = await _userManager.Users.ToListAsync();
            List<UserVM> userVMs = new List<UserVM>();
            foreach (AppUser user in users)
            {
                UserVM userVM = new UserVM
                {
                    Id = user.Id,
                    Name = user.Name,
                    Surname = user.Surname,
                    Email = user.Email,
                    Username = user.UserName,
                    IsDeactive = user.IsDeactive,
                    Role = (await _userManager.GetRolesAsync(user))[0],

                };
                userVMs.Add(userVM);
            }

            return View(userVMs);
        }

        #region Create
        public IActionResult Create()
        {
            ViewBag.Roles = new List<string>
            {
                Helper.Admin,
                Helper.Member
            };

            return View();
        }
        #endregion

        #region CreatePost
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(RegisterVM registerVM, string role)
        {
            ViewBag.Roles = new List<string>
            {
                Helper.Admin,
                Helper.Member
            };
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
                foreach (IdentityError error in identityResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(registerVM);
            }

            await _userManager.AddToRoleAsync(appUser, role);

            return RedirectToAction("Index");
        }
        #endregion

        #region Update
        public async Task<IActionResult> Update(string id)
        {

            if (id == null)
            {
                return NotFound();
            }
            AppUser user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return BadRequest();
            }

            UpdateVM? dbUpdateVM = new UpdateVM
            {
                Name = user.Name,
                Surname = user.UserName,
                Email = user.Email,
                Username = user.UserName,
                Role = (await _userManager.GetRolesAsync(user))[0],
            };
            ViewBag.Roles = new List<string>
            {
                Helper.Admin,
                Helper.Member
            };


            return View(dbUpdateVM);
        }
        #endregion

        #region UpdatePost
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(string id, UpdateVM updateVM, string? role)
        {

            if (id == null)
            {
                return NotFound();
            }
            AppUser user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return BadRequest();
            }

            UpdateVM dbUpdateVM = new UpdateVM
            {
                Name = user.Name,
                Surname = user.UserName,
                Email = user.Email,
                Username = user.UserName,
                Role = (await _userManager.GetRolesAsync(user))[0],
            };
            ViewBag.Roles = new List<string>
            {
                Helper.Admin,
                Helper.Member
            };
            user.Name = updateVM.Name;
            user.Surname = updateVM.Surname;
            user.UserName = updateVM.Username;
            user.Email = updateVM.Email;

            if (!string.IsNullOrEmpty(role))
            {
                IdentityResult removeIdentityResult = await _userManager.RemoveFromRoleAsync(user, dbUpdateVM.Role);
                if (!removeIdentityResult.Succeeded)
                {
                    foreach (IdentityError error in removeIdentityResult.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    return View(dbUpdateVM);
                }

                IdentityResult addIdentityResult = await _userManager.AddToRoleAsync(user, role);
                if (!addIdentityResult.Succeeded)
                {
                    foreach (IdentityError error in addIdentityResult.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    return View(dbUpdateVM);
                }
                dbUpdateVM.Role = role;
            }
            await _userManager.UpdateAsync(user);
            return RedirectToAction("Index");
        }
        #endregion

        #region Activity

        public async Task<IActionResult> Activity(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            AppUser user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return BadRequest();
            }
            if (user.IsDeactive)
            {
                user.IsDeactive = false;
            }
            else
            {
                user.IsDeactive = true;
            }
            await _userManager.UpdateAsync(user);
            return RedirectToAction("Index");
        }

        #endregion

        #region ResetPassword

        public async Task<IActionResult> ResetPassword(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            AppUser user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return BadRequest();
            }
            return View();
        }

        #endregion

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetPasswordVM resetPasswordVM,string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            AppUser user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return BadRequest();
            }
            string token = await _userManager.GeneratePasswordResetTokenAsync(user);
            IdentityResult identityResult = await _userManager.ResetPasswordAsync(user, token, resetPasswordVM.Password);
            if (!identityResult.Succeeded)
            {
                foreach(IdentityError error in identityResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View();
            }
            if (resetPasswordVM.Password != resetPasswordVM.RepeatPassword)
            {
                ModelState.AddModelError("RepeatPassword", "this line must be as same as password!");
                return View();
            }
            return Redirect("/Account/Logout");
        }
    }
}
