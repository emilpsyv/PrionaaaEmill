using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using ProniaEmil.DataAccesLayer;
using ProniaEmil.Enums;
using ProniaEmil.Models;
using ProniaEmil.ViewModels.Account;

namespace ProniaEmil.Controllers
{

    public class AccountController(UserManager<AppUser> _userManager, SignInManager<AppUser> _signInManager,RoleManager<IdentityRole> _roleManager, ProniaEContext _context) : Controller
    {
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM vm)
        {

            if (!ModelState.IsValid) return View(vm);
            AppUser user = new AppUser
            {
                Email = vm.Email,
                Name = vm.Name,
                Surname = vm.Surname,
                UserName = vm.Username

            };

            IdentityResult result = await _userManager.CreateAsync(user, vm.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(vm);
            }
            await _userManager.AddToRoleAsync(user, UserRole.Member.ToString());

            return RedirectToAction(nameof(Index), "Home");
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM vm)
        {
            if (!ModelState.IsValid) return View(vm);
            AppUser? user = await _userManager.FindByNameAsync(vm.UsernameOrEmail);
            if (user == null)
            {
                user = await _userManager.FindByEmailAsync(vm.UsernameOrEmail);
                if (user == null)
                {
                    ModelState.AddModelError("", "İstifadəçi adı və ya şifrəsi yalnışdır");
                    return View(vm);
                }
            }
      

            var result = await _signInManager.PasswordSignInAsync(user, vm.Password, vm.RememberMe, true);
            if (result.IsLockedOut)
            {
                ModelState.AddModelError("", "Cox sayda ugursuz cehd. Zəhmət olmasa gözləyin - " + user.LockoutEnd.Value.ToString("HH:mm:ss"));
                return View(vm);
            }
            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }

        public async Task<IActionResult> CreateRoles()
        {
            foreach (UserRole role in Enum.GetValues(typeof(UserRole)))
            {
                if (!await _roleManager.RoleExistsAsync(role.ToString()))
                {
                    await _roleManager.CreateAsync(new IdentityRole
                    {
                        Name = role.ToString(),
                    });
                }
            }
           return Content("Ok");
        }

        
    }

}
