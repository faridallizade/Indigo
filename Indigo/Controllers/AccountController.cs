using Indigo.Helpers;
using Indigo.Models;
using Indigo.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Indigo.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _user;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<AppUser> user, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _user = user;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVm registerVm)
        {
            if (!ModelState.IsValid)
            {
                return View(registerVm);

            }
            AppUser appUser = new AppUser()
            {
                Name = registerVm.Name,
                Surname = registerVm.Surname,
                Email = registerVm.Email,
                UserName = registerVm.UserName,
            };
            var create = await _user.CreateAsync(appUser, registerVm.Password);
            if (!create.Succeeded)
            {
                foreach (var item in create.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                return View();
            }

            await _user.AddToRoleAsync(appUser, Roles.Member.ToString());

            return RedirectToAction("Index", "Home");
        }

    }
}
